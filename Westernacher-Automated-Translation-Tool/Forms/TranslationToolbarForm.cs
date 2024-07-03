using Automated_Office_Translation_Tool.Utils;
using System;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalConstants;
using static Automated_Office_Translation_Tool.GlobalVariables;
using LaRottaO.CSharp.WinFormsCrossThreads;
using System.Linq;
using Automated_Office_Translation_Tool.Models;
using Automated_Office_Translation_Tool.Form_Logic;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace Automated_Office_Translation_Tool
{
    public partial class TranslationToolbarForm : Form
    {
        private readonly MainForm _mainForm;

        private TranslateFormLogic translationFormLogic;

        private Point mouseDownLocation;

        private ProgramSettings programSettings;

        private String settingsFilePath = "";

        public TranslationToolbarForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            translationFormLogic = new TranslateFormLogic(mainForm, this);
            _mainForm.dataGridView.Click += translationFormLogic.dataGridViewIndexChanged;

            // Add mouse event handlers to the form
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // When the mouse is pressed, store the position
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // When the mouse is moved, update the form position
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mouseDownLocation.X, this.Location.Y + e.Y - mouseDownLocation.Y);
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the mouse position when the mouse button is released
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = Point.Empty;
            }
        }

        private void TranslationWebSiteForm_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<String, String> lang in LANGUAGE)
            {
                comboBoxSourceLanguage.Items.Add(lang.Key);
                comboBoxDestLanguage.Items.Add(lang.Key);
            }

            this.Height = tabControlConfig.Top - 5;

            this.Left = _mainForm.Left - (this.Width / 3);
            this.Top = (_mainForm.Top + _mainForm.Height / 2) + (this.Height / 2);

            settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                var json = File.ReadAllText(settingsFilePath);
                programSettings = JsonSerializer.Deserialize<ProgramSettings>(json);
                textBoxBrowserProfileName.Text = programSettings.BrowserProfileName;
                textBoxGoogleTranslateUrl.Text = programSettings.GoogleTranslateUrl;
                textBoxInputCssSelector.Text = programSettings.TextInputCssSelector;
                textBoxCopyButtonCssSelector.Text = programSettings.CopyButtonCssSelector;
                textBoxDeepLURL.Text = programSettings.DeepLUrl;
                textBoxDeepLAuthKey.Text = programSettings.DeepLAuthKey;
            }
            else
            {
                programSettings = new ProgramSettings();
            }
        }

        private void SaveSettings()
        {
            programSettings.BrowserProfileName = textBoxBrowserProfileName.Text;
            programSettings.GoogleTranslateUrl = textBoxGoogleTranslateUrl.Text;
            programSettings.TextInputCssSelector = textBoxInputCssSelector.Text;
            programSettings.CopyButtonCssSelector = textBoxCopyButtonCssSelector.Text;
            programSettings.DeepLUrl = textBoxDeepLURL.Text;
            programSettings.DeepLAuthKey = textBoxDeepLAuthKey.Text;

            var json = JsonSerializer.Serialize(programSettings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(settingsFilePath, json);
        }

        private async void buttonNextItem_Click(object sender, EventArgs e)
        {
            await translationFormLogic.goToNextItem();
        }

        private async void buttonPrevItem_Click(object sender, EventArgs e)
        {
            await translationFormLogic.goToPrevItem();
        }

        private async void buttonTryTranslate_Click(object sender, EventArgs e)
        {
            if (_mainForm.dataGridView.getRowCountThreadSafe() == 0)
            {
                return;
            }

            if (GlobalVariables.dataGridViewSelectedRow == 0)
            {
                _mainForm.dataGridView.setSelectedRowThreadSafes(0);
            }

            if (!UxHelpers.checkBothLanguagesAreSelected())
            {
                UxHelpers.flashLabel(comboBoxSourceLanguage);
                UxHelpers.flashLabel(comboBoxDestLanguage);
                return;
            }

            if (checkBoxIgnoreNotPending.GetCheckedThreadSafe() && !UxHelpers.areItemsPendingToTranslate1())
            {
                UxHelpers.flashLabel(checkBoxIgnoreNotPending);
                UxHelpers.warnThereArentItemsPendingToTranslate();
                return;
            }
            await translationFormLogic.translateItemOnScreen();
        }

        private async void buttonReplaceAllOc_Click(object sender, EventArgs e)
        {
            if (_mainForm.dataGridView.getRowCountThreadSafe() == 0)
            {
                return;
            }

            if (!UxHelpers.checkBothLanguagesAreSelected())
            {
                UxHelpers.flashLabel(labelComboSource);
                UxHelpers.flashLabel(labelComboDest);
                return;
            }

            await translationFormLogic.acceptAll();

            await translationFormLogic.goToNextItem();
        }

        private void buttonReplaceWithLocalDic_Click(object sender, EventArgs e)
        {
            if (!UxHelpers.checkBothLanguagesAreSelected())
            {
                UxHelpers.flashLabel(comboBoxSourceLanguage);
                UxHelpers.flashLabel(comboBoxDestLanguage);
                return;
            }

            if (_mainForm.dataGridView.getRowCountThreadSafe() == 0)
            {
                return;
            }

            if (!globalFiguresList.Any())
            {
                return;
            }

            foreach (var figure in globalFiguresList)
            {
                LocalTranslationQuery lookupTranslation =
                    new LocalTranslationQuery(
                        GlobalVariables.globalSourceLanguage,
                        GlobalVariables.globalDestinationLanguage,
                        figure.previousText);

                var result = onDiskDictionary.ReadFromDictionary(lookupTranslation);

                if (result.Item1)
                {
                    figure.newText = result.Item2;
                    figure.pendingToTranslate = false;
                    figure.pendingToReplace = true;
                }
            }

            _mainForm.dataGridView.Refresh();

            new SaveOnDisk().savefiguresListToJson(GlobalVariables.globalFiguresList, GlobalVariables.currentOfficeDocPath + ".json");

            UxHelpers.warnAllReplacementsDone();
        }

        private async void buttonLaunchBrowser_Click(object sender, EventArgs e)
        {
            if (!UxHelpers.checkBothLanguagesAreSelected())
            {
                UxHelpers.flashLabel(comboBoxSourceLanguage);
                UxHelpers.flashLabel(comboBoxDestLanguage);
                return;
            }

            await translationFormLogic.setupBrowser(GlobalVariables.globalSourceLanguage, GlobalVariables.globalDestinationLanguage);
        }

        private void checkBoxAutoAdvance_CheckedChanged(object sender, EventArgs e)
        {
            buttonAcceptTranslation.Visible = !checkBoxAutoAdvance.Checked;

            translationFormLogic.setAutoAdvanceToNextItem(checkBoxAutoAdvance.GetCheckedThreadSafe());
        }

        private void checkBoxSkipNumbrsBlanks_CheckedChanged(object sender, EventArgs e)
        {
            translationFormLogic.setSkipNumbersAndBlanks(checkBoxSkipNumbrsBlanks.GetCheckedThreadSafe());
        }

        private void checkBoxSaveOnLocalDic_CheckedChanged(object sender, EventArgs e)
        {
            translationFormLogic.setSavingOnLocalDictionary(checkBoxSaveOnLocalDic.GetCheckedThreadSafe());
        }

        private void TranslationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Close();
        }

        private async void comboBoxSourceLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UxHelpers.checkBothLanguagesAreSelected(false))
            {
                await translationFormLogic.setTargetLanguage(LANGUAGE[comboBoxSourceLanguage.GetTextThreadSafe()], LANGUAGE[comboBoxDestLanguage.GetTextThreadSafe()]);
            }

            GlobalVariables.globalSourceLanguage = LANGUAGE[comboBoxSourceLanguage.GetTextThreadSafe()];
        }

        private async void comboBoxDestLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UxHelpers.checkBothLanguagesAreSelected(false))
            {
                await translationFormLogic.setTargetLanguage(LANGUAGE[comboBoxSourceLanguage.GetTextThreadSafe()], LANGUAGE[comboBoxDestLanguage.GetTextThreadSafe()]);
            }

            GlobalVariables.globalDestinationLanguage = LANGUAGE[comboBoxDestLanguage.GetTextThreadSafe()];
        }

        private void checkBoxIgnoreNotPending_CheckedChanged(object sender, EventArgs e)
        {
            translationFormLogic.setsetIgnoreNotPendintToTranslate(checkBoxIgnoreNotPending.GetCheckedThreadSafe());
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void checkBoxLocalDic_CheckedChanged(object sender, EventArgs e)
        {
            translationFormLogic.setTryLocalDictionaryFirst(checkBoxLocalDic.GetCheckedThreadSafe());
        }

        private void textBoxInputCssSelector_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.googleTranslateInputCssSelector = textBoxInputCssSelector.Text;
            SaveSettings();
        }

        private void textBoxBrowserProfileName_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.googleTranslateSeleniumProfileName = textBoxBrowserProfileName.Text;
            SaveSettings();
        }

        private void textBoxCopyButtonCssSelector_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.googleTranslateCopyButtonCssSelector = textBoxCopyButtonCssSelector.Text;
            SaveSettings();
        }

        private void buttonClearCache_Click(object sender, EventArgs e)
        {
            deleteStorageContents(GlobalVariables.googleTranslateSeleniumProfileName);
        }

        private static void deleteStorageContents(string partialProfileName)
        {
            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string firefoxProfilesPath = Path.Combine(appDataPath, "Mozilla\\Firefox\\Profiles");

                string[] matchingProfiles = Directory.GetDirectories(firefoxProfilesPath, "*" + partialProfileName + "*");

                foreach (string profile in matchingProfiles)
                {
                    string storagePath = Path.Combine(profile, "storage");

                    if (Directory.Exists(storagePath))
                    {
                        foreach (string file in Directory.GetFiles(storagePath))
                        {
                            File.Delete(file);
                        }

                        foreach (string subDirectory in Directory.GetDirectories(storagePath))
                        {
                            Directory.Delete(subDirectory, true);
                        }

                        MessageBox.Show(new Form() { TopMost = true }, $"Contents of 'storage' folder in profile '{profile}' deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"'storage' folder not found in profile '{profile}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void checkBoxShowAdvConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAdvConfig.Checked)
            {
                this.Height = tabControlConfig.Top + tabControlConfig.Height + 10;
            }
            else
            {
                this.Height = tabControlConfig.Top - 5;
            }
        }

        private void textBoxDeepLURL_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.deepLUrl = textBoxDeepLURL.Text;
            SaveSettings();
        }

        private void textBoxDeepLAuthKey_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.deepLAuthKey = textBoxDeepLAuthKey.Text;
            SaveSettings();
        }

        private void textBoxGoogleTranslateUrl_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.googleTranslateURL = textBoxGoogleTranslateUrl.Text;
            SaveSettings();
        }

        private void radioButtonTranslateWeb_CheckedChanged(object sender, EventArgs e)
        {
            buttonLaunchBrowser.Visible = radioButtonTranslateWeb.Checked;
        }

        private void radioButtonTranslateAPI_CheckedChanged(object sender, EventArgs e)
        {
            buttonLaunchBrowser.Visible = radioButtonTranslateWeb.Checked;
        }
    }
}