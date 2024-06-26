using Automated_Office_Translation_Tool.Forms;
using System;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class LoadExcel
    {
        public void load(MainForm mainForm)
        {

            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            Tuple<Boolean, String> openExcelnstanceResult = _iExcelInteraction.launchExcel();

            loadingScreen.Close();

            if (!openExcelnstanceResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, openExcelnstanceResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            Tuple<Boolean, String> openExcelFileResult = _iExcelInteraction.openExcelWorkbook(currentOfficeDocPath);

            loadingScreen.Close();

            if (!openExcelFileResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, openExcelFileResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Tuple<Boolean, String> activateSheetResult = _iExcelInteraction.activateSheetByIndex(1);

            if (!activateSheetResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, openExcelFileResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            new LoadNewOrExistingProject().load(mainForm);
        }
    }
}