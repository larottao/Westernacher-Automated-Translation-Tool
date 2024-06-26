using Automated_Office_Translation_Tool.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Automated_Office_Translation_Tool
{
    internal class ExcelInteractionService : IExcelInteraction
    {
        private Application excelApp;
        private Workbook workBook;
        private Worksheet workSheet;

        public Tuple<bool, string> closeExcel()
        {
            try
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO CLOSE EXCEL. " + ex.ToString());
            }
        }

        public Tuple<bool, string> closeExcelFile(Boolean saveBeforeClosing)
        {
            try
            {
                if (saveBeforeClosing)
                {
                    workBook.Save();
                }

                workBook.Close();

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO CLOSE WORKBOOK. " + ex.ToString());
            }
        }

        public Tuple<bool, string, List<Figure>> extractExcelTofiguresList(Boolean replaceLineJumps)
        {
            int totalSheetsInWorkBook = getWorkbookTotalSheets().Item2;

            List<Figure> figuresList = new List<Figure>();

            int listIndex = 0;

            putExcelInManualMode();

            //Iterate every sheet
            //Iterate all columns of a row
            //Then proceed to the next row

            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            for (int workSheetIndex = 1; workSheetIndex < totalSheetsInWorkBook; workSheetIndex++)
            {
                workSheet = workBook.Sheets[workSheetIndex];

                int sheetTotalRows = getSheetTotalRows().Item2;

                for (int rowIndex = 1; rowIndex < sheetTotalRows; rowIndex++)
                {
                    int sheetTotalColumns = getSheetTotalColumns().Item2;

                    for (int colIndex = 1; colIndex < sheetTotalColumns; colIndex++)
                    {
                        loadingScreen.labelRow2.Text = $"Worksheet {workSheetIndex.ToString()} of {totalSheetsInWorkBook}. Row {rowIndex} of {sheetTotalRows}, Col {colIndex} of {sheetTotalColumns}";

                        Figure figure = new Figure();

                        figure.listIndex = listIndex;
                        figure.id = 0;
                        figure.sheet = workSheet.Name;
                        figure.sheetNumber = workSheetIndex;
                        figure.row = rowIndex;
                        figure.column = getColumnLetterByNumber(colIndex).Item2;
                        figure.columnAsNumber = colIndex;

                        String cellValueAsString = "";

                        dynamic cell = workSheet.Cells[rowIndex, colIndex];

                        if (cell.value != null)
                        {
                            cellValueAsString = Convert.ToString(cell.value);
                        }

                        if (replaceLineJumps)
                        {
                            cellValueAsString = cellValueAsString.Replace("\n", " ");
                            cellValueAsString = cellValueAsString.Replace("\r", " ");
                        }

                        figure.previousText = cellValueAsString;
                        //figure.newText = cellValueAsString;

                        if (!String.IsNullOrEmpty(figure.previousText))
                        {
                            figuresList.Add(figure);
                            listIndex++;
                        }
                    }
                }
            }

            putExcelInAutoMode();

            loadingScreen.Close();

            return new Tuple<bool, string, List<Figure>>(true, "", figuresList);
        }

        public Tuple<bool, string> getColumnLetterByNumber(int number)
        {
            try
            {
                const int baseValue = 'A'; // ASCII value of 'A' minus 1
                int dividend = number;
                string columnName = "";

                while (dividend > 0)
                {
                    int remainder = (dividend - 1) % 26;
                    columnName = (char)(baseValue + remainder) + columnName;
                    dividend = (dividend - 1) / 26;
                }

                return new Tuple<Boolean, String>(true, columnName);
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, string>(false, ex.ToString());
            }
        }

        public Tuple<bool, int> getColumnNumberByLetter(string letters)
        {
            try
            {
                int result = 0;
                foreach (char letter in letters.ToUpper())
                {
                    result *= 26;
                    result += (int)letter - 64;
                }

                return new Tuple<Boolean, int>(true, result);
            }
            catch
            {
                return new Tuple<Boolean, int>(false, 0);
            }
        }

        public bool isExcelWorkbookOpen()
        {
            return workBook != null;
        }

        public Tuple<bool, string> launchExcel()
        {
            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                return new Tuple<Boolean, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, string>(false, "ERROR: UNABLE TO OPEN EXCEL. " + ex.ToString());
            }
        }

        public Tuple<bool, string> launchFileSelectionDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select an Excel Book to translate"
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

        public Tuple<bool, string> openExcelWorkbook(string filePath)
        {
            try
            {
                workBook = excelApp.Workbooks.Open(filePath);

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, "ERROR: UNABLE TO OPEN WORKBOOK. " + ex.ToString());
            }
        }

        public Tuple<bool, string> activateSheetByIndex(int sheetIndex)
        {
            try
            {
                workSheet = workBook.Sheets[sheetIndex];
                workSheet.Activate();
                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public Tuple<bool, string> activateSheetByName(String sheetName)
        {
            try
            {
                workSheet = workBook.Sheets[sheetName];
                workSheet.Activate();
                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public void putExcelInAutoMode()
        {
            try
            {
                excelApp.ScreenUpdating = true;
                excelApp.Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationAutomatic;
                excelApp.EnableEvents = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void putExcelInManualMode()
        {
            try
            {
                excelApp.ScreenUpdating = false;
                excelApp.Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual;
                excelApp.EnableEvents = false;
            }
            catch (Exception ex)
            {
            }
        }

        public Tuple<bool, string> replaceFigureText(Figure figure, Boolean usePreviousText, Boolean useNewText)
        {
            try
            {
                activateSheetByIndex(figure.sheetNumber);
                dynamic cell = workSheet.Cells[figure.row, figure.column];

                if (useNewText)
                {
                    cell.Value = figure.newText;
                }

                if (usePreviousText)
                {
                    cell.Value = figure.previousText;
                }

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public Tuple<bool, string> tryToSelectCell(int sheetIndex, int row, int col)
        {
            try
            {
                Tuple<bool, string> acivationResult = activateSheetByIndex(sheetIndex);
                if (!acivationResult.Item1)
                {
                    return new Tuple<Boolean, String>(false, "UNABLE TO ACTIVATE SHEET. " + acivationResult.Item2);
                }
                dynamic cell = workSheet.Cells[row, col];
                cell.Select();
                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public Tuple<bool, string> tryToSelectCell(string sheetName, int row, int col)
        {
            try
            {
                Tuple<bool, string> acivationResult = activateSheetByName(sheetName);
                if (!acivationResult.Item1)
                {
                    return new Tuple<Boolean, String>(false, "UNABLE TO ACTIVATE SHEET. " + acivationResult.Item2);
                }

                dynamic cell = workSheet.Cells[row, col];

                cell.Select();

                return new Tuple<Boolean, String>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public Tuple<bool, int> getSheetTotalRows()
        {
            try
            {
                return new Tuple<Boolean, int>(true, workSheet.UsedRange.Rows.Count + 1);
            }
            catch
            {
                return new Tuple<Boolean, int>(false, 0);
            }
        }

        public Tuple<bool, int> getSheetTotalColumns()
        {
            try
            {
                return new Tuple<Boolean, int>(true, workSheet.UsedRange.Columns.Count + 1);
            }
            catch
            {
                return new Tuple<Boolean, int>(false, 0);
            }
        }

        public Tuple<bool, int> getWorkbookTotalSheets()
        {
            try
            {
                return new Tuple<Boolean, int>(true, workBook.Sheets.Count + 1);
            }
            catch
            {
                return new Tuple<Boolean, int>(false, 0);
            }
        }
    }
}