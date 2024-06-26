using System;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Utils
{
    public class ChangeTextWithRightClick
    {
        public void changeInDocument(Boolean useNewText, Boolean usePrevText, DataGridView dataGridView, Boolean resizeTextSizeIfNecessary)

        {
            Tuple<Boolean, String, Figure> getFigureResult = getFigureFromDataGridView(dataGridView);

            Tuple<Boolean, String> replaceTextResult = null;

            if (!getFigureResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, getFigureResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Figure figureToChange = getFigureResult.Item3;

            ;

            if (_iPowerPointInteraction.isPowerpointFileOpen())
            {
                replaceTextResult =
                _iPowerPointInteraction.replaceFigureText(figureToChange, usePrevText, useNewText, resizeTextSizeIfNecessary);
            }
            else if (_iExcelInteraction.isExcelWorkbookOpen())
            {
                replaceTextResult =
            _iExcelInteraction.replaceFigureText(figureToChange, usePrevText, useNewText);
            }

            if (replaceTextResult.Item1)
            {
                figureToChange.pendingToReplace = false;
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, replaceTextResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private Tuple<Boolean, String, Figure> getFigureFromDataGridView(DataGridView dataGridView)
        {
            int selectedRow = dataGridView.SelectedRows[0].Index;

            if (selectedRow != -1)
            {
                Figure figureToChange = GlobalVariables.globalFiguresList[selectedRow];

                return new Tuple<Boolean, String, Figure>(true, "", figureToChange);
            }
            else
            {
                return new Tuple<Boolean, String, Figure>(false, "Select a row first", new Figure());
            }
        }
    }
}