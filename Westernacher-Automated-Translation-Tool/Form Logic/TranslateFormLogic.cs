using Automated_Office_Translation_Tool.Interfaces;
using Automated_Office_Translation_Tool.Services;
using Automated_Office_Translation_Tool.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaRottaO.CSharp.WinFormsCrossThreads;
using static Automated_Office_Translation_Tool.GlobalConstants;
using static Automated_Office_Translation_Tool.GlobalVariables;
using Automated_Office_Translation_Tool.Models;
using Automated_Office_Translation_Tool.Forms;
using Automated_Office_Translation_Tool.Services.Translation;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class TranslateFormLogic
    {
        private readonly ITranslation _translateWithWebSite = new TranslateWithWebsite();

        private readonly ITranslation _translateWithDeepLAPI = new TranslateWithDeepLAPI();

        private readonly MainForm _mainForm;

        private readonly TranslationToolbarForm _translationControlsForm;

        private Boolean skipNumbersAndBlanks = true;

        private Boolean saveTranslationOnLocalDictionary = true;

        private Boolean autoAdvanceToNextItem = false;

        private Boolean ignoreNotPendingToTranslate = false;

        private Boolean tryLocalDictionaryFirst = true;

        private TRANSLATION_METHOD translationMethod = TRANSLATION_METHOD.WEBSITE;

        public TranslateFormLogic(MainForm mainForm, TranslationToolbarForm translationControlsForm)
        {
            _mainForm = mainForm;
            _translationControlsForm = translationControlsForm;
        }

        public void dataGridViewIndexChanged(object sender, EventArgs e)
        {
            showSelectedFigureUnderTranslationOnScreen();
        }

        public Boolean showSelectedFigureUnderTranslationOnScreen()
        {
            try
            {
                if (GlobalVariables.dataGridViewSelectedRow == -1)
                {
                    return false;
                }

                figureUnderTranslation = GlobalVariables.globalFiguresList[GlobalVariables.dataGridViewSelectedRow];

                _translationControlsForm.textBoxPreviousText.SetTextThreadSafe(figureUnderTranslation.previousText);

                if (figureUnderTranslation.pendingToTranslate)
                {
                    _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe("");
                }
                else
                {
                    _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe(figureUnderTranslation.newText);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void setAutoAdvanceToNextItem(Boolean value)
        {
            autoAdvanceToNextItem = value;
        }

        public void setSkipNumbersAndBlanks(Boolean value)
        {
            skipNumbersAndBlanks = value;
        }

        public void setSavingOnLocalDictionary(Boolean value)
        {
            saveTranslationOnLocalDictionary = value;
        }

        public void setTryLocalDictionaryFirst(Boolean value)
        {
            tryLocalDictionaryFirst = value;
        }

        public void setsetIgnoreNotPendintToTranslate(Boolean value)
        {
            ignoreNotPendingToTranslate = value;
        }

        public async Task setupBrowser(String source, String destination)
        {
            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            await Task.Run(() =>
            {
                loadingScreen.labelRow2.SetTextThreadSafe("Opening Firefox");
                if (!_translateWithWebSite.openBrowser())
                {
                    UxHelpers.warnUnableToLaunchFirefox();
                    loadingScreen.Close();
                }

                loadingScreen.labelRow2.SetTextThreadSafe("Setting source and destination languages");

                if (!_translateWithWebSite.setTranslationLanguages(source, destination))
                {
                    UxHelpers.warnUnableToSetTransLang();
                    loadingScreen.Close();
                }
            });

            loadingScreen.Close();
        }

        public async Task setTargetLanguage(String source, String destination)
        {
            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();

            await Task.Run(() =>
            {
                _translateWithWebSite.setTranslationLanguages(source, destination);
            });

            loadingScreen.Close();
        }

        public async Task translateItemOnScreen()
        {
            if (_translationControlsForm.radioButtonTranslateWeb.Checked)
            {
                translationMethod = TRANSLATION_METHOD.WEBSITE;
            }

            if (_translationControlsForm.radioButtonTranslateAPI.Checked)
            {
                translationMethod = TRANSLATION_METHOD.API;
            }

            _translationControlsForm.textBoxPreviousText.SetTextThreadSafe("");
            _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe("");

            if (!showSelectedFigureUnderTranslationOnScreen())
            {
                return;
            }

            if (ignoreNotPendingToTranslate &&
                !figureUnderTranslation.pendingToTranslate &&
                UxHelpers.areItemsPendingToTranslateAfterCurrent())
            {
                await goToNextItem();
                return;
            }

            if (!UxHelpers.checkBothLanguagesAreSelected())
            {
                return;
            }

            if (skipNumbersAndBlanks &&
                Filters.IsBlankOrNonAlphabetic(figureUnderTranslation.previousText))
            {
                await goToNextItem();
                return;
            }

            //Reads from the local dictionary first, to see if the word or phrase already exists

            if (tryLocalDictionaryFirst)
            {
                LocalTranslationQuery localTranslationQuery =
                    new LocalTranslationQuery(
                        GlobalVariables.globalSourceLanguage,
                        GlobalVariables.globalDestinationLanguage,
                        figureUnderTranslation.previousText
                        );

                Tuple<bool, string> localDiskResult = onDiskDictionary.ReadFromDictionary(localTranslationQuery);

                if (localDiskResult.Item1)
                {
                    UxHelpers.showTemporaryText(_translationControlsForm.labelTransInfo, "From local dictionary");
                    _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe(localDiskResult.Item2);

                    if (autoAdvanceToNextItem)
                    {
                        await acceptAll();
                        return;
                    }

                    return;
                }
            }

            //Local dictionary failed, lets try website or API

            Tuple<Boolean, String> retrieveResult = new Tuple<Boolean, String>(false, String.Empty);

            if (translationMethod.Equals(TRANSLATION_METHOD.API))
            {
                _translateWithDeepLAPI.setTranslationLanguages(globalSourceLanguage, globalDestinationLanguage);
                retrieveResult = _translateWithDeepLAPI.translate(figureUnderTranslation.previousText);
            }
            else if (translationMethod.Equals(TRANSLATION_METHOD.WEBSITE))
            {
                if (!_translateWithWebSite.checkIfBrowserIsOpen())
                {
                    DialogResult result = MessageBox.Show(new Form() { TopMost = true }, "Do you want to launch the browser to start translating?", "Browser not open", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _translateWithWebSite.openBrowser();
                        _translateWithWebSite.setTranslationLanguages(globalSourceLanguage, globalDestinationLanguage);
                        await translateItemOnScreen();
                        return;
                    }
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                retrieveResult = _translateWithWebSite.translate(figureUnderTranslation.previousText);
            }

            if (retrieveResult.Item1)
            {
                _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe(retrieveResult.Item2);

                if (translationMethod.Equals(TRANSLATION_METHOD.WEBSITE))
                {
                    UxHelpers.showTemporaryText(_translationControlsForm.labelTransInfo, "From website");
                }

                if (translationMethod.Equals(TRANSLATION_METHOD.API))
                {
                    UxHelpers.showTemporaryText(_translationControlsForm.labelTransInfo, "From API");
                }

                if (autoAdvanceToNextItem)
                {
                    await acceptAll();
                }
            }
            else
            {
                _translationControlsForm.textBoxTranslatedText.SetTextThreadSafe("");
                _translationControlsForm.checkBoxAutoAdvance.SetCheckedThreadSafe(false);
                UxHelpers.warnUnableRetrieveTextFromThirdParty(retrieveResult.Item2);
            }
        }

        public async Task acceptAll()
        {
            await Task.Run(async () =>
            {
                figureUnderTranslation.newText = _translationControlsForm.textBoxTranslatedText.GetTextThreadSafe();
                ;

                foreach (var figure in globalFiguresList.Where(x => x.previousText.Equals(figureUnderTranslation.previousText)))
                {
                    figure.newText = figureUnderTranslation.newText;
                    figure.pendingToTranslate = false;
                    figure.pendingToReplace = true;
                }

                ;

                new SaveOnDisk().savefiguresListToJson(GlobalVariables.globalFiguresList, GlobalVariables.currentOfficeDocPath + ".json");

                ;

                if (saveTranslationOnLocalDictionary && figureUnderTranslation.newText != null)
                {
                    LocalTranslation newTranslation = new LocalTranslation
                    {
                        SourceLanguage = GlobalVariables.globalSourceLanguage,
                        TargetLanguage = GlobalVariables.globalDestinationLanguage,
                        OriginalText = figureUnderTranslation.previousText,
                        ChangedText = figureUnderTranslation.newText
                    };

                    ;

                    onDiskDictionary.SaveToDictionary(newTranslation);

                    _mainForm.dataGridView.refreshFromAnotherThread();
                }

                if (autoAdvanceToNextItem)
                {
                    await goToNextItem();
                }
            });
        }

        public async Task goToNextItem()
        {
            await Task.Run(async () =>
            {
                try
                {
                    //If there are no items on the list, we have nowhere to go!

                    if (_mainForm.dataGridView.getRowCountThreadSafe() == 0)
                    {
                        return;
                    }

                    //If we are already at the last item, why going forward!

                    if (GlobalVariables.dataGridViewSelectedRow == _mainForm.dataGridView.getRowCountThreadSafe() - 1)
                    {
                        _translationControlsForm.checkBoxAutoAdvance.SetCheckedThreadSafe(false);
                        return;
                    }

                    //if we only care about pending items and there are no one left ahead, why going forward

                    if (ignoreNotPendingToTranslate && !UxHelpers.areItemsPendingToTranslateAfterCurrent())
                    {
                        UxHelpers.flashLabel(_translationControlsForm.checkBoxIgnoreNotPending);
                        return;
                    }

                    //Ok, lets go forward then!

                    GlobalVariables.dataGridViewSelectedRow++;

                    _mainForm.dataGridView.setSelectedRowThreadSafes(dataGridViewSelectedRow);

                    if (!showSelectedFigureUnderTranslationOnScreen())
                    {
                        return;
                    }

                    if (autoAdvanceToNextItem)
                    {
                        await translateItemOnScreen();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    _translationControlsForm.checkBoxAutoAdvance.SetCheckedThreadSafe(false);
                }
            });
        }

        public async Task goToPrevItem()
        {
            await Task.Run(() =>
            {
                try
                {
                    //If there are no items on the list, we can't go anywhere

                    if (_mainForm.dataGridView.getRowCountThreadSafe() == 0)
                    {
                        return;
                    }

                    //If we are at the first item, why going backward

                    if (GlobalVariables.dataGridViewSelectedRow == -1)
                    {
                        _mainForm.dataGridView.setSelectedRowThreadSafes(0);

                        return;
                    }

                    //if we only care about pending items and there are no one before this one, why going back

                    if (ignoreNotPendingToTranslate && !UxHelpers.areItemsPendingToTranslateBeforeCurrent())
                    {
                        UxHelpers.flashLabel(_translationControlsForm.checkBoxIgnoreNotPending);
                        return;
                    }

                    //Lets go backwards then

                    GlobalVariables.dataGridViewSelectedRow--;

                    _mainForm.dataGridView.setSelectedRowThreadSafes(dataGridViewSelectedRow);

                    showSelectedFigureUnderTranslationOnScreen();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }
    }
}