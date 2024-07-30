using Automated_Office_Translation_Tool.Form_Logic;
using Automated_Office_Translation_Tool.Services;
using Automated_Office_Translation_Tool.Utils;
using LaRottaO.CSharp.WinFormsCrossThreads;
using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool
{
    public partial class MainForm : Form
    {
        private TranslationToolbarForm translationForm;

        public MainForm()
        {
            InitializeComponent();

            KeyPreview = true;
        }

        private void buttonLoadOfficeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Supported Office Files|*.ppt;*.pptx;*.xls;*.xlsx",
                Title = "Select a Powerpoint or Excel file to translate"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (GlobalVariables.currentOfficeDocPath != null)
                {
                    DialogResult saveBeforeClosingElection = offerToSaveDocumentBeforeExiting();

                    if (saveBeforeClosingElection == DialogResult.Cancel)
                    {
                        return;
                    }

                    Boolean saveBeforeClosing = false;

                    if (saveBeforeClosingElection == DialogResult.Yes)
                    {
                        saveBeforeClosing = true;
                    }

                    closeCurrentlyOpenedFiles(saveBeforeClosing);
                }

                string extension = Path.GetExtension(openFileDialog.FileName);

                switch (extension.ToLower())
                {
                    case ".pptx":
                    case ".ppt":
                        currentOfficeDocPath = openFileDialog.FileName;
                        new LoadPptx().load(this);
                        break;

                    case ".xlsx":
                    case ".xls":
                        currentOfficeDocPath = openFileDialog.FileName;
                        new LoadExcel().load(this);
                        break;

                    default:
                        MessageBox.Show(new Form() { TopMost = true }, "Unsupported file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                }
            }
        }

        private void buttonInjectNewValues_Click(object sender, EventArgs e)
        {
            if (currentOfficeDocPath == null)
            {
                UxHelpers.flashLabel(buttonLoadOfficeFile);
                return;
            }

            if (!UxHelpers.checkIfThereAreItemsPendingToReplace())
            {
                return;
            }

            Tuple<Boolean, String> changesResult = new ApplyPendingChangesOnDoc().apply();

            dataGridView.Refresh();

            if (!changesResult.Item1)
            {
                MessageBox.Show(new Form() { TopMost = true }, changesResult.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            MessageBox.Show(new Form() { TopMost = true }, "Process Complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult saveBeforeClosingElection = offerToSaveDocumentBeforeExiting();

            if (saveBeforeClosingElection == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            Boolean saveBeforeClosing = false;

            if (saveBeforeClosingElection == DialogResult.Yes)
            {
                saveBeforeClosing = true;
            }

            closeCurrentlyOpenedFiles(saveBeforeClosing);
            closeCurrentOfficeInstance();
        }

        private DialogResult offerToSaveDocumentBeforeExiting()
        {
            if (GlobalVariables.currentOfficeDocPath == null)
            {
                return DialogResult.No;
            }

            return MessageBox.Show(new Form() { TopMost = true }, "Do you want to save the changes made on the office document?", "Before exiting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void closeCurrentlyOpenedFiles(Boolean saveBeforeClosing)
        {
            if (_iPowerPointInteraction.isPowerpointFileOpen())
            {
                _iPowerPointInteraction.closePowerpointFile(saveBeforeClosing);
            }

            if (_iExcelInteraction.isExcelWorkbookOpen())
            {
                _iExcelInteraction.closeExcelFile(saveBeforeClosing);
            }
        }

        private void closeCurrentOfficeInstance()
        {
            if (_iPowerPointInteraction.isPowerpointFileOpen())
            {
                _iPowerPointInteraction.closePowerpoint();
            }

            if (_iExcelInteraction.isExcelWorkbookOpen())
            {
                _iExcelInteraction.closeExcel();
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                new ChangeTextWithRightClick().changeInDocument(true, false, dataGridView, true);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = GlobalConstants.APP_NAME;

            translationForm = new TranslationToolbarForm(this);
            translationForm.Show();

            translationForm.Activate();

            UxHelpers.flashLabel(buttonLoadOfficeFile);
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void buttonShowToolbar_Click(object sender, EventArgs e)
        {
            translationForm.Show();
            translationForm.Activate();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalVariables.dataGridViewSelectedRow = e.RowIndex;
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            GlobalVariables.dataGridViewSelectedRow = e.RowIndex;
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GlobalVariables.dataGridViewSelectedRow = e.RowIndex;

                new DataGridViewRightClick(this).rightClick();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            new DataGridViewChangeValue().changeValue(sender, e);
        }

        private void buttonMarkPendingToReplace_Click(object sender, EventArgs e)
        {
            foreach (Figure figure in globalFiguresList)
            {
                figure.pendingToReplace = !String.IsNullOrEmpty(figure.newText);
            }

            dataGridView.Refresh();
        }

        private void buttonSetProofing_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_iPowerPointInteraction.setProofingLanguage(Microsoft.Office.Core.MsoLanguageID.msoLanguageIDMexicanSpanish).Item2);
        }
    }
}