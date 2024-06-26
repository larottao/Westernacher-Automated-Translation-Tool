using LaRottaO.CSharp.WinFormsCrossThreads;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalConstants;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class DataGridViewBind
    {
        public void bindDataGridView(MainForm mainForm, List<Figure> figuresList, DOCUMENT_TYPE documentType)
        {
            mainForm.dataGridView.Columns.Clear();

            mainForm.dataGridView.DataSource = figuresList;

            if (documentType.Equals(DOCUMENT_TYPE.PPT))
            {
                mainForm.dataGridView.Columns["slide"].HeaderText = HEADER_SLIDE_NUMBER;
                mainForm.dataGridView.Columns["id"].HeaderText = HEADER_ID;
                mainForm.dataGridView.Columns["previousText"].HeaderText = HEADER_PREV_TEXT;
                mainForm.dataGridView.Columns["newText"].HeaderText = HEADER_NEW_TEXT;
                mainForm.dataGridView.Columns["pendingToTranslate"].HeaderText = HEADER_PENDING_TO_TRANSLATE;
                mainForm.dataGridView.Columns["pendingToReplace"].HeaderText = HEADER_PENDING_TO_REPLACE;
            }

            if (documentType.Equals(DOCUMENT_TYPE.EXCEL))
            {
                mainForm.dataGridView.Columns["sheet"].HeaderText = HEADER_SHEET_NAME;
                mainForm.dataGridView.Columns["row"].HeaderText = HEADER_ROW;
                mainForm.dataGridView.Columns["column"].HeaderText = HEADER_COLUMN;
                mainForm.dataGridView.Columns["previousText"].HeaderText = HEADER_PREV_TEXT;
                mainForm.dataGridView.Columns["newText"].HeaderText = HEADER_NEW_TEXT;
                mainForm.dataGridView.Columns["pendingToTranslate"].HeaderText = HEADER_PENDING_TO_TRANSLATE;
                mainForm.dataGridView.Columns["pendingToReplace"].HeaderText = HEADER_PENDING_TO_REPLACE;
            }

            foreach (DataGridViewColumn column in mainForm.dataGridView.Columns)
            {
                if (documentType.Equals(DOCUMENT_TYPE.PPT) && RELEVANT_COLUMNS_FOR_PPTX.Contains(column.HeaderText))
                {
                    continue;
                }

                if (documentType.Equals(DOCUMENT_TYPE.EXCEL) && RELEVANT_COLUMNS_FOR_EXCEL.Contains(column.HeaderText))
                {
                    continue;
                }

                column.Visible = false;
            }

            mainForm.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            mainForm.dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            mainForm.dataGridView.MultiSelect = false;
        }
    }
}