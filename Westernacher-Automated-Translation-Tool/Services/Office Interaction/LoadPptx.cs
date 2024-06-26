using Automated_Office_Translation_Tool.Forms;
using System;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class LoadPptx
    {
        public void load(MainForm mainForm)
        {
            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            Tuple<Boolean, String> openPowerpointInstanceResult = _iPowerPointInteraction.launchPowerpoint();

            loadingScreen.Close();

            if (!openPowerpointInstanceResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, openPowerpointInstanceResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            Tuple<Boolean, String> openPowerpointFileResult = _iPowerPointInteraction.openPowerpointFile(currentOfficeDocPath);

            loadingScreen.Close();

            if (!openPowerpointFileResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, openPowerpointFileResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            new LoadNewOrExistingProject().load(mainForm);
        }
    }
}