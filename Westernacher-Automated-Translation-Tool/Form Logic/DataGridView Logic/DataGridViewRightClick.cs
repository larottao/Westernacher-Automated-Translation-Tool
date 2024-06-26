using Automated_Office_Translation_Tool.Models;
using Automated_Office_Translation_Tool.Utils;
using LaRottaO.CSharp.WinFormsCrossThreads;
using System;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalConstants;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class DataGridViewRightClick
    {
        private readonly MainForm _mainForm;

        public DataGridViewRightClick(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        private void syncronizeDataGridViewSelRowWithSelectedCell()
        {
            if (GlobalVariables.dataGridViewSelectedRow > 0)
            {
                _mainForm.dataGridView.clearSelectionThreadSafe();
                _mainForm.dataGridView.setSelectedRowThreadSafes(GlobalVariables.dataGridViewSelectedRow);
            }
        }

        public void rightClick()
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            Console.WriteLine("Selected Row: " + GlobalVariables.dataGridViewSelectedRow);

            contextMenuStrip = new ContextMenuStrip();

            separatorMenuItem.Click += Separator_Click;

            if (_iPowerPointInteraction.isPowerpointFileOpen())
            {
                locateOnPresentationMenuItem.Click += LocateOnPresentationMenuItem_Click;

                contextMenuStrip.Items.Add(locateOnPresentationMenuItem);
            }

            if (_iExcelInteraction.isExcelWorkbookOpen())
            {
                locateOnWorkbookMenuItem.Click += LocateOnWorkbookMenuItem_Click;

                contextMenuStrip.Items.Add(locateOnWorkbookMenuItem);
            }

            contextMenuStrip.Items.Add(separatorMenuItem);

            copyOriginalTextMenuItem.Click += CopyOriginalTextMenuItem_Click;
            contextMenuStrip.Items.Add(copyOriginalTextMenuItem);

            contextMenuStrip.Items.Add(separatorMenuItem);

            changeInDocumentMenuItem.Click += changeInDocument_Click;
            contextMenuStrip.Items.Add(changeInDocumentMenuItem);

            revertInDocumentMenuItem.Click += revertInDocument_Click;
            contextMenuStrip.Items.Add(revertInDocumentMenuItem);

            contextMenuStrip.Items.Add(separatorMenuItem);

            replaceAll.Click += replaceAll_Click;
            contextMenuStrip.Items.Add(replaceAll);

            contextMenuStrip.Show(_mainForm.dataGridView, _mainForm.dataGridView.PointToClient(Cursor.Position));
        }

        private void Separator_Click(object sender, EventArgs e)
        {
            //Do Nothing
        }

        //TODO input string incorrect
        private void LocateOnPresentationMenuItem_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            int slideNumber = globalFiguresList[dataGridViewSelectedRow].slide;
            int id = globalFiguresList[dataGridViewSelectedRow].id;
            GlobalVariables._iPowerPointInteraction.tryToSelectSlideAndFigure(slideNumber, id);
        }

        private void LocateOnWorkbookMenuItem_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            String worksheet = globalFiguresList[dataGridViewSelectedRow].sheet;
            int row = globalFiguresList[dataGridViewSelectedRow].row;
            int col = globalFiguresList[dataGridViewSelectedRow].columnAsNumber;

            _iExcelInteraction.tryToSelectCell(worksheet, row, col);
        }

        private void CopyOriginalTextMenuItem_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            try
            {
                String selectedText = globalFiguresList[dataGridViewSelectedRow].previousText;
                Clipboard.SetText(selectedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, $"ERROR: Unable to copy text to clipboard. {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void changeInDocument_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            new ChangeTextWithRightClick().changeInDocument(true, false, _mainForm.dataGridView, true);
        }

        private void revertInDocument_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            new ChangeTextWithRightClick().changeInDocument(false, true, _mainForm.dataGridView, true);
        }

        private void replaceAll_Click(object sender, EventArgs e)
        {
            syncronizeDataGridViewSelRowWithSelectedCell();

            try
            {
                if (!UxHelpers.checkBothLanguagesAreSelected())
                {
                    return;
                }

                String prevText = globalFiguresList[dataGridViewSelectedRow].previousText;
                String newText = globalFiguresList[dataGridViewSelectedRow].newText;

                ReplaceAll.replace(prevText, newText, _mainForm.dataGridView);

                LocalTranslation newTranslation = new LocalTranslation
                {
                    SourceLanguage = GlobalVariables.globalSourceLanguage,
                    TargetLanguage = GlobalVariables.globalDestinationLanguage,
                    OriginalText = prevText,
                    ChangedText = newText
                };

                onDiskDictionary.SaveToDictionary(newTranslation);
                Console.WriteLine("Translation saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, $"ERROR: Unable to copy text to clipboard. {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}