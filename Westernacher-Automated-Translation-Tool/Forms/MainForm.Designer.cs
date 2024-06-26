namespace Automated_Office_Translation_Tool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonLoadOfficeFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonShowToolbar = new System.Windows.Forms.Button();
            this.buttonInjectNewValues = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.Gray;
            this.dataGridView.Location = new System.Drawing.Point(13, 83);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1074, 545);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowEnter);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // buttonLoadOfficeFile
            // 
            this.buttonLoadOfficeFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoadOfficeFile.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonLoadOfficeFile.FlatAppearance.BorderSize = 2;
            this.buttonLoadOfficeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadOfficeFile.Location = new System.Drawing.Point(12, 22);
            this.buttonLoadOfficeFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadOfficeFile.Name = "buttonLoadOfficeFile";
            this.buttonLoadOfficeFile.Size = new System.Drawing.Size(219, 42);
            this.buttonLoadOfficeFile.TabIndex = 1;
            this.buttonLoadOfficeFile.Text = "Open Powerpoint or Excel Office File";
            this.buttonLoadOfficeFile.UseVisualStyleBackColor = true;
            this.buttonLoadOfficeFile.Click += new System.EventHandler(this.buttonLoadOfficeFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.buttonShowToolbar);
            this.groupBox1.Controls.Add(this.buttonInjectNewValues);
            this.groupBox1.Controls.Add(this.buttonLoadOfficeFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(900, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonShowToolbar
            // 
            this.buttonShowToolbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowToolbar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonShowToolbar.FlatAppearance.BorderSize = 2;
            this.buttonShowToolbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowToolbar.Location = new System.Drawing.Point(239, 22);
            this.buttonShowToolbar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowToolbar.Name = "buttonShowToolbar";
            this.buttonShowToolbar.Size = new System.Drawing.Size(219, 42);
            this.buttonShowToolbar.TabIndex = 4;
            this.buttonShowToolbar.Text = "Show Translation Toolbar";
            this.buttonShowToolbar.UseVisualStyleBackColor = true;
            this.buttonShowToolbar.Click += new System.EventHandler(this.buttonShowToolbar_Click);
            // 
            // buttonInjectNewValues
            // 
            this.buttonInjectNewValues.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInjectNewValues.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonInjectNewValues.FlatAppearance.BorderSize = 2;
            this.buttonInjectNewValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInjectNewValues.Location = new System.Drawing.Point(466, 22);
            this.buttonInjectNewValues.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInjectNewValues.Name = "buttonInjectNewValues";
            this.buttonInjectNewValues.Size = new System.Drawing.Size(219, 42);
            this.buttonInjectNewValues.TabIndex = 3;
            this.buttonInjectNewValues.Text = "Apply changes on Office File";
            this.buttonInjectNewValues.UseVisualStyleBackColor = true;
            this.buttonInjectNewValues.Click += new System.EventHandler(this.buttonInjectNewValues_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 638);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Office Translation Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoadOfficeFile;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInjectNewValues;
        private System.Windows.Forms.Button buttonShowToolbar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

