namespace Automated_Office_Translation_Tool
{
    partial class TranslationToolbarForm
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
            this.buttonNextItem = new System.Windows.Forms.Button();
            this.buttonTryTranslate = new System.Windows.Forms.Button();
            this.buttonPrevItem = new System.Windows.Forms.Button();
            this.textBoxTranslatedText = new System.Windows.Forms.TextBox();
            this.textBoxPreviousText = new System.Windows.Forms.TextBox();
            this.checkBoxAutoAdvance = new System.Windows.Forms.CheckBox();
            this.checkBoxSkipNumbrsBlanks = new System.Windows.Forms.CheckBox();
            this.buttonAcceptTranslation = new System.Windows.Forms.Button();
            this.comboBoxDestLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxSourceLanguage = new System.Windows.Forms.ComboBox();
            this.labelComboDest = new System.Windows.Forms.Label();
            this.labelComboSource = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonTranslateWeb = new System.Windows.Forms.RadioButton();
            this.radioButtonTranslateAPI = new System.Windows.Forms.RadioButton();
            this.checkBoxIgnoreNotPending = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveOnLocalDic = new System.Windows.Forms.CheckBox();
            this.buttonLaunchBrowser = new System.Windows.Forms.Button();
            this.buttonReplaceWithLocalDic = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelTransInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLocalDic = new System.Windows.Forms.CheckBox();
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tabPageAPI = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDeepLURL = new System.Windows.Forms.TextBox();
            this.textBoxDeepLAuthKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageSelenium = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonClearCache = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGoogleTranslateUrl = new System.Windows.Forms.TextBox();
            this.textBoxBrowserProfileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInputCssSelector = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCopyButtonCssSelector = new System.Windows.Forms.TextBox();
            this.checkBoxShowAdvConfig = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControlConfig.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tabPageAPI.SuspendLayout();
            this.tabPageSelenium.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNextItem
            // 
            this.buttonNextItem.BackColor = System.Drawing.Color.White;
            this.buttonNextItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonNextItem.FlatAppearance.BorderSize = 2;
            this.buttonNextItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextItem.ForeColor = System.Drawing.Color.Black;
            this.buttonNextItem.Location = new System.Drawing.Point(629, 162);
            this.buttonNextItem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNextItem.Name = "buttonNextItem";
            this.buttonNextItem.Size = new System.Drawing.Size(100, 48);
            this.buttonNextItem.TabIndex = 49;
            this.buttonNextItem.Text = "Next item";
            this.buttonNextItem.UseVisualStyleBackColor = false;
            this.buttonNextItem.Click += new System.EventHandler(this.buttonNextItem_Click);
            // 
            // buttonTryTranslate
            // 
            this.buttonTryTranslate.BackColor = System.Drawing.Color.White;
            this.buttonTryTranslate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTryTranslate.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonTryTranslate.FlatAppearance.BorderSize = 2;
            this.buttonTryTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTryTranslate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTryTranslate.ForeColor = System.Drawing.Color.Black;
            this.buttonTryTranslate.Location = new System.Drawing.Point(303, 162);
            this.buttonTryTranslate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTryTranslate.Name = "buttonTryTranslate";
            this.buttonTryTranslate.Size = new System.Drawing.Size(156, 48);
            this.buttonTryTranslate.TabIndex = 50;
            this.buttonTryTranslate.Text = "Try to translate";
            this.buttonTryTranslate.UseVisualStyleBackColor = false;
            this.buttonTryTranslate.Click += new System.EventHandler(this.buttonTryTranslate_Click);
            // 
            // buttonPrevItem
            // 
            this.buttonPrevItem.BackColor = System.Drawing.Color.White;
            this.buttonPrevItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrevItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonPrevItem.FlatAppearance.BorderSize = 2;
            this.buttonPrevItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevItem.ForeColor = System.Drawing.Color.Black;
            this.buttonPrevItem.Location = new System.Drawing.Point(197, 162);
            this.buttonPrevItem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrevItem.Name = "buttonPrevItem";
            this.buttonPrevItem.Size = new System.Drawing.Size(101, 48);
            this.buttonPrevItem.TabIndex = 51;
            this.buttonPrevItem.Text = "Previous Item";
            this.buttonPrevItem.UseVisualStyleBackColor = false;
            this.buttonPrevItem.Click += new System.EventHandler(this.buttonPrevItem_Click);
            // 
            // textBoxTranslatedText
            // 
            this.textBoxTranslatedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTranslatedText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTranslatedText.ForeColor = System.Drawing.Color.Black;
            this.textBoxTranslatedText.Location = new System.Drawing.Point(9, 42);
            this.textBoxTranslatedText.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTranslatedText.Multiline = true;
            this.textBoxTranslatedText.Name = "textBoxTranslatedText";
            this.textBoxTranslatedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTranslatedText.Size = new System.Drawing.Size(429, 68);
            this.textBoxTranslatedText.TabIndex = 60;
            this.textBoxTranslatedText.WordWrap = false;
            // 
            // textBoxPreviousText
            // 
            this.textBoxPreviousText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPreviousText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPreviousText.ForeColor = System.Drawing.Color.Black;
            this.textBoxPreviousText.Location = new System.Drawing.Point(7, 42);
            this.textBoxPreviousText.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPreviousText.Multiline = true;
            this.textBoxPreviousText.Name = "textBoxPreviousText";
            this.textBoxPreviousText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPreviousText.Size = new System.Drawing.Size(427, 68);
            this.textBoxPreviousText.TabIndex = 61;
            this.textBoxPreviousText.WordWrap = false;
            // 
            // checkBoxAutoAdvance
            // 
            this.checkBoxAutoAdvance.AutoSize = true;
            this.checkBoxAutoAdvance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoAdvance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAutoAdvance.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAutoAdvance.Location = new System.Drawing.Point(756, 162);
            this.checkBoxAutoAdvance.Name = "checkBoxAutoAdvance";
            this.checkBoxAutoAdvance.Size = new System.Drawing.Size(156, 19);
            this.checkBoxAutoAdvance.TabIndex = 63;
            this.checkBoxAutoAdvance.Text = "Auto Accept translations";
            this.checkBoxAutoAdvance.UseVisualStyleBackColor = true;
            this.checkBoxAutoAdvance.CheckedChanged += new System.EventHandler(this.checkBoxAutoAdvance_CheckedChanged);
            // 
            // checkBoxSkipNumbrsBlanks
            // 
            this.checkBoxSkipNumbrsBlanks.AutoSize = true;
            this.checkBoxSkipNumbrsBlanks.Checked = true;
            this.checkBoxSkipNumbrsBlanks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSkipNumbrsBlanks.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSkipNumbrsBlanks.Location = new System.Drawing.Point(340, 56);
            this.checkBoxSkipNumbrsBlanks.Name = "checkBoxSkipNumbrsBlanks";
            this.checkBoxSkipNumbrsBlanks.Size = new System.Drawing.Size(167, 19);
            this.checkBoxSkipNumbrsBlanks.TabIndex = 64;
            this.checkBoxSkipNumbrsBlanks.Text = "Skip numbers and blanks";
            this.checkBoxSkipNumbrsBlanks.UseVisualStyleBackColor = true;
            this.checkBoxSkipNumbrsBlanks.CheckedChanged += new System.EventHandler(this.checkBoxSkipNumbrsBlanks_CheckedChanged);
            // 
            // buttonAcceptTranslation
            // 
            this.buttonAcceptTranslation.BackColor = System.Drawing.Color.White;
            this.buttonAcceptTranslation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcceptTranslation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonAcceptTranslation.FlatAppearance.BorderSize = 2;
            this.buttonAcceptTranslation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcceptTranslation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcceptTranslation.ForeColor = System.Drawing.Color.Black;
            this.buttonAcceptTranslation.Location = new System.Drawing.Point(465, 162);
            this.buttonAcceptTranslation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAcceptTranslation.Name = "buttonAcceptTranslation";
            this.buttonAcceptTranslation.Size = new System.Drawing.Size(156, 48);
            this.buttonAcceptTranslation.TabIndex = 65;
            this.buttonAcceptTranslation.Text = "Accept given translation and go to Next item";
            this.buttonAcceptTranslation.UseVisualStyleBackColor = false;
            this.buttonAcceptTranslation.Click += new System.EventHandler(this.buttonReplaceAllOc_Click);
            // 
            // comboBoxDestLanguage
            // 
            this.comboBoxDestLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxDestLanguage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDestLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxDestLanguage.FormattingEnabled = true;
            this.comboBoxDestLanguage.Location = new System.Drawing.Point(335, 15);
            this.comboBoxDestLanguage.Name = "comboBoxDestLanguage";
            this.comboBoxDestLanguage.Size = new System.Drawing.Size(103, 23);
            this.comboBoxDestLanguage.TabIndex = 71;
            this.comboBoxDestLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestLanguage_SelectedIndexChanged);
            // 
            // comboBoxSourceLanguage
            // 
            this.comboBoxSourceLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxSourceLanguage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSourceLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxSourceLanguage.FormattingEnabled = true;
            this.comboBoxSourceLanguage.Location = new System.Drawing.Point(331, 14);
            this.comboBoxSourceLanguage.Name = "comboBoxSourceLanguage";
            this.comboBoxSourceLanguage.Size = new System.Drawing.Size(103, 23);
            this.comboBoxSourceLanguage.TabIndex = 70;
            this.comboBoxSourceLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceLanguage_SelectedIndexChanged);
            // 
            // labelComboDest
            // 
            this.labelComboDest.AutoSize = true;
            this.labelComboDest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComboDest.ForeColor = System.Drawing.Color.Black;
            this.labelComboDest.Location = new System.Drawing.Point(200, 19);
            this.labelComboDest.Name = "labelComboDest";
            this.labelComboDest.Size = new System.Drawing.Size(129, 15);
            this.labelComboDest.TabIndex = 69;
            this.labelComboDest.Text = "Destination Language";
            this.labelComboDest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComboSource
            // 
            this.labelComboSource.AutoSize = true;
            this.labelComboSource.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComboSource.ForeColor = System.Drawing.Color.Black;
            this.labelComboSource.Location = new System.Drawing.Point(220, 18);
            this.labelComboSource.Name = "labelComboSource";
            this.labelComboSource.Size = new System.Drawing.Size(105, 15);
            this.labelComboSource.TabIndex = 68;
            this.labelComboSource.Text = "Source Language";
            this.labelComboSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "New text";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 69;
            this.label3.Text = "Previous text";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButtonTranslateWeb
            // 
            this.radioButtonTranslateWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonTranslateWeb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTranslateWeb.ForeColor = System.Drawing.Color.Black;
            this.radioButtonTranslateWeb.Location = new System.Drawing.Point(20, 63);
            this.radioButtonTranslateWeb.Name = "radioButtonTranslateWeb";
            this.radioButtonTranslateWeb.Size = new System.Drawing.Size(186, 26);
            this.radioButtonTranslateWeb.TabIndex = 71;
            this.radioButtonTranslateWeb.Text = "Use Google with Selenium";
            this.radioButtonTranslateWeb.UseVisualStyleBackColor = true;
            this.radioButtonTranslateWeb.CheckedChanged += new System.EventHandler(this.radioButtonTranslateWeb_CheckedChanged);
            // 
            // radioButtonTranslateAPI
            // 
            this.radioButtonTranslateAPI.AutoSize = true;
            this.radioButtonTranslateAPI.Checked = true;
            this.radioButtonTranslateAPI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonTranslateAPI.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTranslateAPI.ForeColor = System.Drawing.Color.Black;
            this.radioButtonTranslateAPI.Location = new System.Drawing.Point(20, 25);
            this.radioButtonTranslateAPI.Name = "radioButtonTranslateAPI";
            this.radioButtonTranslateAPI.Size = new System.Drawing.Size(68, 19);
            this.radioButtonTranslateAPI.TabIndex = 72;
            this.radioButtonTranslateAPI.TabStop = true;
            this.radioButtonTranslateAPI.Text = "Use API";
            this.radioButtonTranslateAPI.UseVisualStyleBackColor = true;
            this.radioButtonTranslateAPI.CheckedChanged += new System.EventHandler(this.radioButtonTranslateAPI_CheckedChanged);
            // 
            // checkBoxIgnoreNotPending
            // 
            this.checkBoxIgnoreNotPending.AutoSize = true;
            this.checkBoxIgnoreNotPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxIgnoreNotPending.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnoreNotPending.ForeColor = System.Drawing.Color.Black;
            this.checkBoxIgnoreNotPending.Location = new System.Drawing.Point(340, 75);
            this.checkBoxIgnoreNotPending.Name = "checkBoxIgnoreNotPending";
            this.checkBoxIgnoreNotPending.Size = new System.Drawing.Size(295, 19);
            this.checkBoxIgnoreNotPending.TabIndex = 77;
            this.checkBoxIgnoreNotPending.Text = "Ignore items not marked as \'Send for Translation\'";
            this.checkBoxIgnoreNotPending.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreNotPending.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreNotPending_CheckedChanged);
            // 
            // checkBoxSaveOnLocalDic
            // 
            this.checkBoxSaveOnLocalDic.AutoSize = true;
            this.checkBoxSaveOnLocalDic.Checked = true;
            this.checkBoxSaveOnLocalDic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveOnLocalDic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSaveOnLocalDic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSaveOnLocalDic.ForeColor = System.Drawing.Color.Black;
            this.checkBoxSaveOnLocalDic.Location = new System.Drawing.Point(340, 36);
            this.checkBoxSaveOnLocalDic.Name = "checkBoxSaveOnLocalDic";
            this.checkBoxSaveOnLocalDic.Size = new System.Drawing.Size(285, 19);
            this.checkBoxSaveOnLocalDic.TabIndex = 74;
            this.checkBoxSaveOnLocalDic.Text = "Save successful translations on local dictionary";
            this.checkBoxSaveOnLocalDic.UseVisualStyleBackColor = true;
            this.checkBoxSaveOnLocalDic.CheckedChanged += new System.EventHandler(this.checkBoxSaveOnLocalDic_CheckedChanged);
            // 
            // buttonLaunchBrowser
            // 
            this.buttonLaunchBrowser.BackColor = System.Drawing.Color.White;
            this.buttonLaunchBrowser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaunchBrowser.Location = new System.Drawing.Point(213, 64);
            this.buttonLaunchBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLaunchBrowser.Name = "buttonLaunchBrowser";
            this.buttonLaunchBrowser.Size = new System.Drawing.Size(101, 24);
            this.buttonLaunchBrowser.TabIndex = 76;
            this.buttonLaunchBrowser.Text = "Launch Firefox";
            this.buttonLaunchBrowser.UseVisualStyleBackColor = false;
            this.buttonLaunchBrowser.Visible = false;
            this.buttonLaunchBrowser.Click += new System.EventHandler(this.buttonLaunchBrowser_Click);
            // 
            // buttonReplaceWithLocalDic
            // 
            this.buttonReplaceWithLocalDic.BackColor = System.Drawing.Color.White;
            this.buttonReplaceWithLocalDic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReplaceWithLocalDic.Location = new System.Drawing.Point(767, 542);
            this.buttonReplaceWithLocalDic.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReplaceWithLocalDic.Name = "buttonReplaceWithLocalDic";
            this.buttonReplaceWithLocalDic.Size = new System.Drawing.Size(136, 24);
            this.buttonReplaceWithLocalDic.TabIndex = 75;
            this.buttonReplaceWithLocalDic.Text = "Use internal dic now";
            this.buttonReplaceWithLocalDic.UseVisualStyleBackColor = false;
            this.buttonReplaceWithLocalDic.Visible = false;
            this.buttonReplaceWithLocalDic.Click += new System.EventHandler(this.buttonReplaceWithLocalDic_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxPreviousText);
            this.groupBox2.Controls.Add(this.labelComboSource);
            this.groupBox2.Controls.Add(this.comboBoxSourceLanguage);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 123);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelTransInfo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxTranslatedText);
            this.groupBox3.Controls.Add(this.comboBoxDestLanguage);
            this.groupBox3.Controls.Add(this.labelComboDest);
            this.groupBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(465, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 123);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // labelTransInfo
            // 
            this.labelTransInfo.AutoSize = true;
            this.labelTransInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransInfo.ForeColor = System.Drawing.Color.Black;
            this.labelTransInfo.Location = new System.Drawing.Point(68, 18);
            this.labelTransInfo.Name = "labelTransInfo";
            this.labelTransInfo.Size = new System.Drawing.Size(0, 15);
            this.labelTransInfo.TabIndex = 79;
            this.labelTransInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 78;
            this.label1.Text = "Translation Toolbar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxLocalDic
            // 
            this.checkBoxLocalDic.AutoSize = true;
            this.checkBoxLocalDic.Checked = true;
            this.checkBoxLocalDic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLocalDic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxLocalDic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLocalDic.ForeColor = System.Drawing.Color.Black;
            this.checkBoxLocalDic.Location = new System.Drawing.Point(340, 16);
            this.checkBoxLocalDic.Name = "checkBoxLocalDic";
            this.checkBoxLocalDic.Size = new System.Drawing.Size(254, 19);
            this.checkBoxLocalDic.TabIndex = 78;
            this.checkBoxLocalDic.Text = "Prefer local dictionary before of API or web";
            this.checkBoxLocalDic.UseVisualStyleBackColor = true;
            this.checkBoxLocalDic.CheckedChanged += new System.EventHandler(this.checkBoxLocalDic_CheckedChanged);
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Controls.Add(this.tabPageConfig);
            this.tabControlConfig.Controls.Add(this.tabPageAPI);
            this.tabControlConfig.Controls.Add(this.tabPageSelenium);
            this.tabControlConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlConfig.Location = new System.Drawing.Point(12, 225);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(900, 136);
            this.tabControlConfig.TabIndex = 79;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.radioButtonTranslateWeb);
            this.tabPageConfig.Controls.Add(this.checkBoxLocalDic);
            this.tabPageConfig.Controls.Add(this.checkBoxIgnoreNotPending);
            this.tabPageConfig.Controls.Add(this.checkBoxSkipNumbrsBlanks);
            this.tabPageConfig.Controls.Add(this.buttonLaunchBrowser);
            this.tabPageConfig.Controls.Add(this.radioButtonTranslateAPI);
            this.tabPageConfig.Controls.Add(this.checkBoxSaveOnLocalDic);
            this.tabPageConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageConfig.Location = new System.Drawing.Point(4, 24);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(892, 108);
            this.tabPageConfig.TabIndex = 2;
            this.tabPageConfig.Text = "Translation Options";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageAPI
            // 
            this.tabPageAPI.Controls.Add(this.label8);
            this.tabPageAPI.Controls.Add(this.textBoxDeepLURL);
            this.tabPageAPI.Controls.Add(this.textBoxDeepLAuthKey);
            this.tabPageAPI.Controls.Add(this.label9);
            this.tabPageAPI.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAPI.Location = new System.Drawing.Point(4, 24);
            this.tabPageAPI.Name = "tabPageAPI";
            this.tabPageAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAPI.Size = new System.Drawing.Size(892, 108);
            this.tabPageAPI.TabIndex = 1;
            this.tabPageAPI.Text = "API Configuration";
            this.tabPageAPI.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 70;
            this.label8.Text = "DeepL URL";
            // 
            // textBoxDeepLURL
            // 
            this.textBoxDeepLURL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeepLURL.Location = new System.Drawing.Point(164, 29);
            this.textBoxDeepLURL.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDeepLURL.Name = "textBoxDeepLURL";
            this.textBoxDeepLURL.Size = new System.Drawing.Size(441, 21);
            this.textBoxDeepLURL.TabIndex = 71;
            this.textBoxDeepLURL.Text = "https://api-free.deepl.com/v2/translate";
            this.textBoxDeepLURL.TextChanged += new System.EventHandler(this.textBoxDeepLURL_TextChanged);
            // 
            // textBoxDeepLAuthKey
            // 
            this.textBoxDeepLAuthKey.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeepLAuthKey.Location = new System.Drawing.Point(164, 58);
            this.textBoxDeepLAuthKey.Name = "textBoxDeepLAuthKey";
            this.textBoxDeepLAuthKey.PasswordChar = '*';
            this.textBoxDeepLAuthKey.Size = new System.Drawing.Size(441, 21);
            this.textBoxDeepLAuthKey.TabIndex = 72;
            this.textBoxDeepLAuthKey.TextChanged += new System.EventHandler(this.textBoxDeepLAuthKey_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 73;
            this.label9.Text = "DeepL API key";
            // 
            // tabPageSelenium
            // 
            this.tabPageSelenium.Controls.Add(this.label6);
            this.tabPageSelenium.Controls.Add(this.buttonClearCache);
            this.tabPageSelenium.Controls.Add(this.label4);
            this.tabPageSelenium.Controls.Add(this.textBoxGoogleTranslateUrl);
            this.tabPageSelenium.Controls.Add(this.textBoxBrowserProfileName);
            this.tabPageSelenium.Controls.Add(this.label2);
            this.tabPageSelenium.Controls.Add(this.textBoxInputCssSelector);
            this.tabPageSelenium.Controls.Add(this.label7);
            this.tabPageSelenium.Controls.Add(this.textBoxCopyButtonCssSelector);
            this.tabPageSelenium.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSelenium.Location = new System.Drawing.Point(4, 24);
            this.tabPageSelenium.Name = "tabPageSelenium";
            this.tabPageSelenium.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelenium.Size = new System.Drawing.Size(892, 108);
            this.tabPageSelenium.TabIndex = 0;
            this.tabPageSelenium.Text = "Google Translate / Selenium Configuration";
            this.tabPageSelenium.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 71;
            this.label6.Text = "Translation website";
            // 
            // buttonClearCache
            // 
            this.buttonClearCache.BackColor = System.Drawing.Color.White;
            this.buttonClearCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearCache.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonClearCache.FlatAppearance.BorderSize = 2;
            this.buttonClearCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearCache.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearCache.Location = new System.Drawing.Point(360, 16);
            this.buttonClearCache.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearCache.Name = "buttonClearCache";
            this.buttonClearCache.Size = new System.Drawing.Size(124, 30);
            this.buttonClearCache.TabIndex = 54;
            this.buttonClearCache.Text = "Clear cache";
            this.buttonClearCache.UseVisualStyleBackColor = false;
            this.buttonClearCache.Click += new System.EventHandler(this.buttonClearCache_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "Firefox profile name";
            // 
            // textBoxGoogleTranslateUrl
            // 
            this.textBoxGoogleTranslateUrl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGoogleTranslateUrl.Location = new System.Drawing.Point(168, 71);
            this.textBoxGoogleTranslateUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGoogleTranslateUrl.Name = "textBoxGoogleTranslateUrl";
            this.textBoxGoogleTranslateUrl.Size = new System.Drawing.Size(697, 21);
            this.textBoxGoogleTranslateUrl.TabIndex = 72;
            this.textBoxGoogleTranslateUrl.Text = "https://translate.google.com/?sl=SOURCELANG&tl=DESTINATIONLANG&op=translate";
            this.textBoxGoogleTranslateUrl.TextChanged += new System.EventHandler(this.textBoxGoogleTranslateUrl_TextChanged);
            // 
            // textBoxBrowserProfileName
            // 
            this.textBoxBrowserProfileName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBrowserProfileName.Location = new System.Drawing.Point(167, 20);
            this.textBoxBrowserProfileName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBrowserProfileName.Name = "textBoxBrowserProfileName";
            this.textBoxBrowserProfileName.Size = new System.Drawing.Size(174, 21);
            this.textBoxBrowserProfileName.TabIndex = 58;
            this.textBoxBrowserProfileName.Text = "Automatizacion";
            this.textBoxBrowserProfileName.TextChanged += new System.EventHandler(this.textBoxBrowserProfileName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 15);
            this.label2.TabIndex = 70;
            this.label2.Text = "Copy button CSS Selector";
            // 
            // textBoxInputCssSelector
            // 
            this.textBoxInputCssSelector.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputCssSelector.Location = new System.Drawing.Point(691, 13);
            this.textBoxInputCssSelector.Name = "textBoxInputCssSelector";
            this.textBoxInputCssSelector.Size = new System.Drawing.Size(174, 21);
            this.textBoxInputCssSelector.TabIndex = 67;
            this.textBoxInputCssSelector.Text = "[aria-label=\'Source text\']";
            this.textBoxInputCssSelector.TextChanged += new System.EventHandler(this.textBoxInputCssSelector_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 15);
            this.label7.TabIndex = 69;
            this.label7.Text = "Text input CSS Selector";
            // 
            // textBoxCopyButtonCssSelector
            // 
            this.textBoxCopyButtonCssSelector.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCopyButtonCssSelector.Location = new System.Drawing.Point(691, 42);
            this.textBoxCopyButtonCssSelector.Name = "textBoxCopyButtonCssSelector";
            this.textBoxCopyButtonCssSelector.Size = new System.Drawing.Size(174, 21);
            this.textBoxCopyButtonCssSelector.TabIndex = 68;
            this.textBoxCopyButtonCssSelector.Text = "[aria-label=\'Copy translation\']";
            this.textBoxCopyButtonCssSelector.TextChanged += new System.EventHandler(this.textBoxCopyButtonCssSelector_TextChanged);
            // 
            // checkBoxShowAdvConfig
            // 
            this.checkBoxShowAdvConfig.AutoSize = true;
            this.checkBoxShowAdvConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowAdvConfig.Location = new System.Drawing.Point(756, 191);
            this.checkBoxShowAdvConfig.Name = "checkBoxShowAdvConfig";
            this.checkBoxShowAdvConfig.Size = new System.Drawing.Size(131, 19);
            this.checkBoxShowAdvConfig.TabIndex = 80;
            this.checkBoxShowAdvConfig.Text = "Show configuration";
            this.checkBoxShowAdvConfig.UseVisualStyleBackColor = true;
            this.checkBoxShowAdvConfig.CheckedChanged += new System.EventHandler(this.checkBoxShowAdvConfig_CheckedChanged);
            // 
            // TranslationToolbarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 368);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxShowAdvConfig);
            this.Controls.Add(this.tabControlConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPrevItem);
            this.Controls.Add(this.checkBoxAutoAdvance);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonTryTranslate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonAcceptTranslation);
            this.Controls.Add(this.buttonReplaceWithLocalDic);
            this.Controls.Add(this.buttonNextItem);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TranslationToolbarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TranslationForm_FormClosing);
            this.Load += new System.EventHandler(this.TranslationWebSiteForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControlConfig.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tabPageAPI.ResumeLayout(false);
            this.tabPageAPI.PerformLayout();
            this.tabPageSelenium.ResumeLayout(false);
            this.tabPageSelenium.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNextItem;
        private System.Windows.Forms.Button buttonTryTranslate;
        private System.Windows.Forms.Button buttonPrevItem;
        private System.Windows.Forms.CheckBox checkBoxSkipNumbrsBlanks;
        private System.Windows.Forms.Button buttonAcceptTranslation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxTranslatedText;
        public System.Windows.Forms.TextBox textBoxPreviousText;
        public System.Windows.Forms.CheckBox checkBoxAutoAdvance;
        private System.Windows.Forms.Button buttonReplaceWithLocalDic;
        private System.Windows.Forms.CheckBox checkBoxSaveOnLocalDic;
        private System.Windows.Forms.Button buttonLaunchBrowser;
        public System.Windows.Forms.RadioButton radioButtonTranslateWeb;
        public System.Windows.Forms.RadioButton radioButtonTranslateAPI;
        public System.Windows.Forms.ComboBox comboBoxDestLanguage;
        public System.Windows.Forms.ComboBox comboBoxSourceLanguage;
        public System.Windows.Forms.CheckBox checkBoxIgnoreNotPending;
        public System.Windows.Forms.Label labelComboDest;
        public System.Windows.Forms.Label labelComboSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelTransInfo;
        private System.Windows.Forms.CheckBox checkBoxLocalDic;
        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.TabPage tabPageSelenium;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonClearCache;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGoogleTranslateUrl;
        private System.Windows.Forms.TextBox textBoxBrowserProfileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInputCssSelector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCopyButtonCssSelector;
        private System.Windows.Forms.TabPage tabPageAPI;
        private System.Windows.Forms.CheckBox checkBoxShowAdvConfig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDeepLURL;
        private System.Windows.Forms.TextBox textBoxDeepLAuthKey;
        private System.Windows.Forms.Label label9;
    }
}