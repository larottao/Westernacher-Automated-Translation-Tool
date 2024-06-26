namespace Automated_Office_Translation_Tool.Forms
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.labelRow1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelRow2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRow1
            // 
            this.labelRow1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRow1.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelRow1.Location = new System.Drawing.Point(78, 11);
            this.labelRow1.Name = "labelRow1";
            this.labelRow1.Size = new System.Drawing.Size(312, 22);
            this.labelRow1.TabIndex = 71;
            this.labelRow1.Text = "Please wait";
            this.labelRow1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelRow2
            // 
            this.labelRow2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.labelRow2.Location = new System.Drawing.Point(78, 33);
            this.labelRow2.Name = "labelRow2";
            this.labelRow2.Size = new System.Drawing.Size(312, 28);
            this.labelRow2.TabIndex = 72;
            this.labelRow2.Text = "Loading document";
            this.labelRow2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 73);
            this.ControlBox = false;
            this.Controls.Add(this.labelRow2);
            this.Controls.Add(this.labelRow1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelRow1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label labelRow2;
    }
}