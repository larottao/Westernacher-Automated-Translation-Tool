using Automated_Office_Translation_Tool.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalConstants;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class LoadNewOrExistingProject
    {
        public void load(MainForm mainForm)
        {
            if (File.Exists(currentOfficeDocPath + ".json"))
            {
                //This feature resulted to be dangerous, because a distracted user can click 'No' and destroy all the work by accident
                //DialogResult result = MessageBox.Show(new Form() { TopMost = true }, "Do you want to keep working on the existing project? Yes to kep working, No to delete it and start from scratch", "Existing project found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if (result == DialogResult.Yes)
                //{
                loadFiguresFromDisk();
                //}
                //else
                //{
                //    extractFiguresFromFile();
                //    saveFiguresToDisk();
                //}
            }
            else
            {
                extractFiguresFromFile();
                saveFiguresToDisk();
            }

            mainForm.Text = GlobalConstants.APP_NAME + " " + currentOfficeDocPath;

            bindFiguresListToDgv(mainForm);
        }

        private void loadFiguresFromDisk()
        {
            Tuple<Boolean, String, List<Figure>> figureLoadResult = new LoadFromDisk().loadfiguresListFromJson(currentOfficeDocPath + ".json");

            if (figureLoadResult.Item1)
            {
                //Load from Disk Successful
                globalFiguresList = figureLoadResult.Item3;
            }
            else
            {
                //Load from Disk Failed, Overwrite and continue

                MessageBox.Show(new Form() { TopMost = true }, $"Project loading failed. {figureLoadResult.Item2} A new project will be created fom scratch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                extractFiguresFromFile();

                saveFiguresToDisk();
            }
        }

        private void saveFiguresToDisk()
        {
            new SaveOnDisk().savefiguresListToJson(globalFiguresList, currentOfficeDocPath + ".json");
        }

        private void extractFiguresFromFile()
        {
            Tuple<Boolean, String, List<Figure>> figuresListResult;

            switch (Path.GetExtension(currentOfficeDocPath))
            {
                case ".pptx":
                case ".ppt":

                    figuresListResult = _iPowerPointInteraction.extractPowerpointTextTofiguresList();

                    if (!figuresListResult.Item1)
                    {
                        MessageBox.Show(new Form() { TopMost = true }, figuresListResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    globalFiguresList = figuresListResult.Item3;

                    break;

                case ".xlsx":
                case ".xls":

                    figuresListResult = _iExcelInteraction.extractExcelTofiguresList(false);

                    if (!figuresListResult.Item1)
                    {
                        MessageBox.Show(new Form() { TopMost = true }, figuresListResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    globalFiguresList = figuresListResult.Item3;

                    break;
            }
        }

        private void bindFiguresListToDgv(MainForm mainForm)
        {
            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            //Load the file on disk on the Datagrid view
            switch (Path.GetExtension(currentOfficeDocPath))
            {
                case ".pptx":
                case ".ppt":
                    new DataGridViewBind().bindDataGridView(mainForm, globalFiguresList, DOCUMENT_TYPE.PPT);
                    break;

                case ".xlsx":
                case ".xls":
                    new DataGridViewBind().bindDataGridView(mainForm, globalFiguresList, DOCUMENT_TYPE.EXCEL);
                    break;
            }

            loadingScreen.Close();
        }
    }
}