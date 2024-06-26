using Automated_Office_Translation_Tool.Interfaces;
using LaRottaO.CSharp.WinFormsCrossThreads;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalConstants;
using static Automated_Office_Translation_Tool.GlobalVariables;
using Keys = OpenQA.Selenium.Keys;

namespace Automated_Office_Translation_Tool.Services
{
    internal class TranslateWithWebsite : ITranslation
    {
        private IWebDriver driver;

        public bool openBrowser()
        {
            try
            {
                Debug.WriteLine("Opening web browser...");

                FirefoxProfile profile = new FirefoxProfileManager().GetProfile(GlobalVariables.googleTranslateSeleniumProfileName);

                FirefoxOptions options = new FirefoxOptions();

                options.Profile = profile;

                driver = new FirefoxDriver(options);

                Debug.WriteLine("Opening web browser OK");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());
                return false;
            }
        }

        public bool checkIfBrowserIsOpen()
        {
            return driver != null;
        }

        public bool goToProviderSite()
        {
            try
            {
                driver.Navigate().GoToUrl(GlobalVariables.googleTranslateURL);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());
                return false;
            }
        }

        public Tuple<Boolean, String> translate(string originalText)
        {
            IWebElement googleTranslateInputBox;
            IWebElement googleTranslateCopyTextButton;

            WebDriverWait wait1Second = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToInt32(1)));

            try
            {
                ClipboardOps.ClearClipboardFromAnotherThread();

                googleTranslateInputBox =
                    wait1Second.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                        By.CssSelector(googleTranslateInputCssSelector)));

                googleTranslateInputBox.Clear();

                Actions actions = new Actions(driver);

                googleTranslateInputBox.Click();

                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();
                Thread.Sleep(200);
                actions.SendKeys(Keys.Delete).Build().Perform();

                Thread.Sleep(500);

                actions.SendKeys("a").Build().Perform();
                Thread.Sleep(200);
                actions.SendKeys(Keys.Backspace).Build().Perform();

                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Tuple<Boolean, String>(false, ERROR_UNABLE_CLEAR_BROWSER);
            }

            Thread.Sleep(500);

            try
            {
                googleTranslateInputBox.SendKeys(originalText);

                //Enough fot 500 words
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());

                return new Tuple<Boolean, String>(false, ERROR_UNABLE_SEND_TEXT_TO_BROWSER);
            }

            try
            {
                Debug.WriteLine("Retrieving translated text...");

                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                Debug.WriteLine($"Awaiting for element with aria-label 'Copy translation'...");
                googleTranslateCopyTextButton = wait1Second.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(googleTranslateCopyButtonCssSelector)));

                if (googleTranslateCopyTextButton == null)
                {
                    Debug.WriteLine($"Element with aria-label 'Copy translation' not found!");
                    return new Tuple<Boolean, String>(false, ERROR_UNABLE_RETRIEVE_TEXT_FROM_BROWSER);
                }

                Debug.WriteLine($"Clearing clipboard...");

                ClipboardOps.ClearClipboardFromAnotherThread();

                Debug.WriteLine($"Clicking element with aria-label 'Copy translation'...");

                googleTranslateCopyTextButton.Click();

                // Wait for 1 second after clicking for better stability

                Thread.Sleep(1000);

                return new Tuple<Boolean, String>(true, ClipboardOps.GetClipboardTextThreadSafe());
            }
            catch (WebDriverTimeoutException)
            {
                Debug.WriteLine($"Element with aria-label 'Copy translation' not found within the timeout period!");
                return new Tuple<Boolean, String>(false, ERROR_UNABLE_RETRIEVE_TEXT_FROM_BROWSER);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());
                return new Tuple<Boolean, String>(false, ERROR_UNABLE_RETRIEVE_TEXT_FROM_BROWSER);
            }
        }

        public bool closeBrowser()
        {
            try
            {
                if (driver != null)
                {
                    driver.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());
                return false;
            }
        }

        public bool setTranslationLanguages(string sourceLang, string destLang)
        {
            if (!checkIfBrowserIsOpen())
            {
                return false;
            }

            try
            {
                driver.Navigate().GoToUrl(GlobalVariables.googleTranslateURL.Replace("SOURCELANG", sourceLang).Replace("DESTINATIONLANG", destLang));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form() { TopMost = true }, ex.ToString());
                return false;
            }
        }
    }
}