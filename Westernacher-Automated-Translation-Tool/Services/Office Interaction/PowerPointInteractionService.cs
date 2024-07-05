using Automated_Office_Translation_Tool.Forms;
using Automated_Office_Translation_Tool.Utils;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.PowerPoint.Application;

using Shape = Microsoft.Office.Interop.PowerPoint.Shape;

namespace Automated_Office_Translation_Tool
{
    internal class PowerPointInteractionService : IPowerPointInteraction
    {
        private Application pptApp;
        private Presentation pptPresentation;

        public Tuple<bool, string> launchPowerpoint()
        {
            try
            {
                pptApp = new Application();
                return new Tuple<Boolean, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, string>(false, "ERROR: UNABLE TO OPEN POWERPOINT. " + ex.ToString());
            }
        }

        public Tuple<Boolean, String> launchFileSelectionDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PowerPoint Files|*.ppt;*.pptx",
                Title = "Select a PowerPoint Presentation to translate"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return new Tuple<Boolean, String>(true, openFileDialog.FileName);
            }
            else
            {
                return new Tuple<Boolean, String>(false, "WARNING: NO FILE SELECTED.");
            }
        }

        public Tuple<Boolean, String> openPowerpointFile(String filePath)
        {
            try
            {
                pptPresentation = pptApp.Presentations.Open(filePath);
                Console.WriteLine(filePath + " loaded. Total slides on pptx: " + pptPresentation.Slides.Count);

                if (pptPresentation.Slides.Count == 0)
                {
                    return new Tuple<Boolean, String>(false, "ERROR: PRESENTATION HAS ZERO SLIDES.");
                }

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO OPEN PRESENTATION. " + ex.ToString());
            }
        }

        public Tuple<Boolean, String, List<Figure>> extractPowerpointTextTofiguresList()
        {
            try
            {
                List<Figure> figuresList = new List<Figure>();

                int listIndex = 0;

                if (pptPresentation.Slides.Count == 0)
                {
                    return new Tuple<Boolean, String, List<Figure>>(false, "ERROR: PRESENTATION DOES NOT CONTAIN ANY SLIDES", figuresList);
                }

                LoadingScreen loadingScreen = new LoadingScreen();
                loadingScreen.Show();

                foreach (Slide slide in pptPresentation.Slides)
                {
                    int totalShapeCount = slide.Shapes.Count;
                    int processedShapeConter = 1;

                    foreach (Shape shape in slide.Shapes)
                    {
                        loadingScreen.labelRow2.Text = $"Slide {slide.SlideNumber} of {pptPresentation.Slides.Count} Ungrouping Figure {processedShapeConter} of {totalShapeCount}";

                        try
                        {
                            if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
                            {
                                shape.Ungroup();
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"DEBUG: Unable to ungroup the shape with Id: {slide.SlideID} on Slide: {slide.SlideNumber}. Reason: {ex.ToString()}");
                        }
                        processedShapeConter++;
                    }

                    processedShapeConter = 1;

                    foreach (Shape shape in slide.Shapes)
                    {
                        loadingScreen.labelRow2.Text = $"Slide {slide.SlideNumber} of {pptPresentation.Slides.Count} Loading Figure {processedShapeConter} of {totalShapeCount}";

                        try
                        {
                            if (shape.HasTextFrame == MsoTriState.msoTrue)
                            {
                                if (shape.TextFrame.HasText == MsoTriState.msoTrue)
                                {
                                    var textRange = shape.TextFrame.TextRange;

                                    Figure figure = new Figure();

                                    figure.listIndex = listIndex;
                                    figure.slide = slide.SlideNumber;
                                    figure.id = shape.Id;
                                    figure.belongsToATable = false;
                                    figure.containsText = true;
                                    figure.previousText = textRange.Text.ToString();
                                    //figure.newText = textRange.Text.ToString();
                                    figure.PreviousTextIsBlank = String.IsNullOrEmpty(figure.previousText);
                                    figure.pendingToReplace = false;

                                    figure.pendingToTranslate = !Filters.IsBlankOrNonAlphabetic(textRange.Text.ToString());

                                    if (figure.containsText && !figure.PreviousTextIsBlank)
                                    {
                                        figuresList.Add(figure);
                                        listIndex++;
                                    }
                                }
                            }
                            else if (shape.HasTable == MsoTriState.msoTrue)
                            {
                                Table table = shape.Table;

                                for (int col = 1; col <= table.Columns.Count; col++)
                                {
                                    for (int row = 1; row <= table.Rows.Count; row++)
                                    {
                                        Cell cell = table.Cell(row, col);

                                        Shape cellShape = cell.Shape;

                                        if (cellShape.HasTextFrame == MsoTriState.msoTrue && cellShape.TextFrame.HasText == MsoTriState.msoTrue)
                                        {
                                            var textRange = cellShape.TextFrame.TextRange;

                                            Figure figure = new Figure();

                                            figure.listIndex = listIndex;
                                            figure.slide = slide.SlideNumber;
                                            figure.belongsToATable = true;
                                            figure.parentTableId = shape.Id;
                                            figure.parentTableColumn = col;
                                            figure.parentTableRow = row;
                                            figure.containsText = true;
                                            figure.previousText = textRange.Text.ToString();
                                            //figure.newText = textRange.Text.ToString();
                                            figure.PreviousTextIsBlank = String.IsNullOrEmpty(figure.previousText);
                                            figure.pendingToReplace = false;

                                            figure.pendingToTranslate = !Filters.IsBlankOrNonAlphabetic(textRange.Text.ToString());

                                            if (figure.containsText && !figure.PreviousTextIsBlank)
                                            {
                                                figuresList.Add(figure);
                                                listIndex++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.WriteLine($"DEBUG: Shape with Id: {slide.SlideID} on Slide: {slide.SlideNumber} is not a frame nor a Table");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"DEBUG: Unable to determine if the shape with Id: {slide.SlideID} on Slide: {slide.SlideNumber} contains text. Reason: {ex.ToString()}");
                        }

                        processedShapeConter++;
                    }
                }

                loadingScreen.Close();

                return new Tuple<Boolean, String, List<Figure>>(true, "", figuresList);
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String, List<Figure>>(false, $"ERROR: Unable to extract data from presentation. Try again. {ex.ToString()}", null);
            }
        }

        public Tuple<Boolean, String> replaceFigureText(Figure figure, Boolean usePreviousText, Boolean useNewText, Boolean shrinkTextIfNecessary)
        {
            try
            {
                pptPresentation.Slides[figure.slide].Select();

                Slide slide = pptPresentation.Slides[figure.slide];

                slide.Select();

                foreach (Shape shape in slide.Shapes)
                {
                    try
                    {
                        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
                        {
                            shape.Ungroup();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"DEBUG: Unable to ungroup the shape with Id: {slide.SlideID} on Slide: {slide.SlideNumber}. Reason: {ex.ToString()}");
                    }
                }

                if (!figure.belongsToATable)
                {
                    foreach (Shape shape in slide.Shapes)
                    {
                        if (figure.id.Equals(shape.Id))
                        {
                            shape.Select();

                            if (useNewText)
                            {
                                shape.TextFrame.TextRange.Text = figure.newText;

                                if (shrinkTextIfNecessary)
                                {
                                    try
                                    {
                                        float textWidth = shape.TextFrame.TextRange.BoundWidth;
                                        float textHeight = shape.TextFrame.TextRange.BoundHeight;

                                        float shapeWidth = shape.Width;
                                        float shapeHeight = shape.Height;

                                        if (textWidth > shapeWidth || textHeight > shapeHeight)
                                        {
                                            // Text is bigger than the shape size
                                            AdjustTextSizeToFit(shape.TextFrame, shapeWidth, shapeHeight);
                                            System.Console.WriteLine($"Text in shape '{shape.Name}' has been adjusted to fit inside the shape.");
                                        }
                                        else
                                        {
                                            System.Console.WriteLine($"Text in shape '{shape.Name}' fits inside the shape.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.ToString());
                                        Console.WriteLine("Unable to Shrink");
                                    }
                                }
                            }

                            if (usePreviousText)
                            {
                                shape.TextFrame.TextRange.Text = figure.previousText;
                            }

                            return new Tuple<Boolean, String>(true, "");
                        }
                    }
                }
                else// if (argFigure.belongsToATable)
                {
                    foreach (Shape shape in slide.Shapes)
                    {
                        if (figure.parentTableId.Equals(shape.Id))
                        {
                            shape.Select();

                            Table table = shape.Table;

                            Cell cell = table.Cell(figure.parentTableRow, figure.parentTableColumn);

                            Shape cellShape = cell.Shape;

                            if (useNewText)
                            {
                                cellShape.TextFrame.TextRange.Text = figure.newText;

                                if (shrinkTextIfNecessary)
                                {
                                    try
                                    {
                                        float textWidth = shape.TextFrame.TextRange.BoundWidth;
                                        float textHeight = shape.TextFrame.TextRange.BoundHeight;

                                        float shapeWidth = shape.Width;
                                        float shapeHeight = shape.Height;

                                        if (textWidth > shapeWidth || textHeight > shapeHeight)
                                        {
                                            // Text is bigger than the shape size
                                            AdjustTextSizeToFit(shape.TextFrame, shapeWidth, shapeHeight);
                                            System.Console.WriteLine($"Text in shape '{shape.Name}' has been adjusted to fit inside the shape.");
                                        }
                                        else
                                        {
                                            System.Console.WriteLine($"Text in shape '{shape.Name}' fits inside the shape.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.ToString());
                                        Console.WriteLine("Unable to Shrink");
                                    }
                                }
                            }
                            if (usePreviousText)
                            {
                                cellShape.TextFrame.TextRange.Text = figure.previousText;
                            }

                            break;
                        }
                    }
                }

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO SELECT SLIDE / FIGURE. " + ex.ToString());
            }
        }

        private static void AdjustTextSizeToFit(Microsoft.Office.Interop.PowerPoint.TextFrame textFrame, float maxWidth, float maxHeight)
        {
            float currentFontSize = textFrame.TextRange.Font.Size;
            float scaleFactor = 0.9f; // Adjust this value to change how much the font size is reduced

            // Reduce font size until text fits inside the shape
            while (textFrame.TextRange.BoundWidth > maxWidth || textFrame.TextRange.BoundHeight > maxHeight)
            {
                currentFontSize *= scaleFactor;
                textFrame.TextRange.Font.Size = currentFontSize;
                if (textFrame.TextRange.Font.Size <= 8)
                {
                    break;
                }
            }
        }

        public Tuple<bool, string> closePowerpointFile(Boolean saveBeforeClosing)
        {
            try
            {
                if (saveBeforeClosing)
                {
                    pptPresentation.Save();
                }

                pptPresentation.Close();

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO CLOSE PRESENTATION. " + ex.ToString());
            }
        }

        public Tuple<bool, string> closePowerpoint()
        {
            try
            {
                pptApp.Quit();
                Marshal.ReleaseComObject(pptApp);
                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO CLOSE POWERPOINT. " + ex.ToString());
            }
        }

        public Tuple<bool, string> tryToSelectSlideAndFigure(int slideNumber, int id)
        {
            try
            {
                Slide slide = pptPresentation.Slides[slideNumber];

                slide.Select();

                foreach (Shape shape in slide.Shapes)
                {
                    try
                    {
                        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
                        {
                            shape.Ungroup();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"DEBUG: Unable to ungroup the shape with Id: {slide.SlideID} on Slide: {slide.SlideNumber}. Reason: {ex.ToString()}");
                    }
                }

                foreach (Shape shape in slide.Shapes)
                {
                    if (id.Equals(shape.Id))
                    {
                        shape.Select();
                        return new Tuple<Boolean, String>(true, "");
                    }
                }

                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO FIND SLIDE / FIGURE. ");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO SELECT SLIDE / FIGURE. " + ex.ToString());
            }
        }

        public bool isPowerpointFileOpen()
        {
            return pptPresentation != null;
        }
    }
}