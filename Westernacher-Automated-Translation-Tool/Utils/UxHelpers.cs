using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Utils
{
    public class UxHelpers
    {
        public static Boolean checkBothLanguagesAreSelected(Boolean showWarningIfNot = true)
        {
            if (!String.IsNullOrEmpty(GlobalVariables.globalSourceLanguage) && !String.IsNullOrEmpty(GlobalVariables.globalDestinationLanguage))
            {
                return true;
            }
            else
            {
                if (showWarningIfNot)
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Please select the Source and Destination languages first", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
        }

        public static Boolean areItemsPendingToTranslate1()
        {
            List<Figure> items = globalFiguresList
             .Where(x => x.pendingToTranslate)
             .ToList();

            Console.WriteLine("Are there items pending to replace at all? : " + items.Any());
            return (items.Any());
        }

        public static Boolean areItemsPendingToTranslateBeforeCurrent()
        {
            List<Figure> items = globalFiguresList
       .Where(x => x.listIndex >= 0
                   && x.listIndex < figureUnderTranslation.listIndex
                   && x.pendingToTranslate)
       .ToList();

            Console.WriteLine("Are there items pending to replace before this one? : " + items.Any());
            return (items.Any());
        }

        public static Boolean areItemsPendingToTranslateAfterCurrent()
        {
            List<Figure> items = globalFiguresList
        .Where(x => x.listIndex >= figureUnderTranslation.listIndex
                    && x.pendingToTranslate)
        .ToList();

            Console.WriteLine("Are there items pending to replace after this one? : " + items.Any());
            return (items.Any());
        }

        public static void warnThereArentItemsPendingToTranslate()
        {
            if (!GlobalVariables.globalFiguresList.Select(x => x.pendingToTranslate).Any())
            {
                MessageBox.Show(new Form() { TopMost = true }, "Since the option to ignore non selected items is checked, please activate the 'Send for translation' checkbox next to the items you want to translate", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static async void flashLabel(Control control)
        {
            PropertyInfo textProperty = control.GetType().GetProperty("Text");
            PropertyInfo foreColorProperty = control.GetType().GetProperty("ForeColor");

            if (textProperty != null && foreColorProperty != null)
            {
                // Save the original ForeColor
                Color originalColor = control.ForeColor;
                Color originalBackColor = control.BackColor;

                for (int i = 0; i < 5; i++)
                {
                    control.ForeColor = Color.White;
                    control.BackColor = Color.LightSkyBlue;
                    await Task.Delay(200);
                    control.ForeColor = originalColor;
                    control.BackColor = originalBackColor;
                    await Task.Delay(200);
                }

                control.ForeColor = originalColor;
                control.BackColor = originalBackColor;
            }
        }

        public static async void showTemporaryText(Control control, String tempText)
        {
            try
            {
                // Check if the control has the Text and ForeColor properties
                PropertyInfo textProperty = control.GetType().GetProperty("Text");

                if (textProperty != null)
                {
                    // Save the original Text
                    String originalText = control.Text;

                    control.Text = tempText;
                    await Task.Delay(1000); // Wait for 500 milliseconds

                    control.Text = originalText;
                }
            }
            catch (Exception ex)
            {
                //This is a aesthetical process, if it fails is not critical
            }
        }

        public static Boolean checkIfThereAreItemsPendingToReplace(Boolean showWarningIfNot = true)
        {
            if (GlobalVariables.globalFiguresList.Select(x => x.pendingToReplace).Any())
            {
                return true;
            }
            else
            {
                if (showWarningIfNot)
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Please activate the 'Pending to Replace' checkbox next to the items you want to replace in the document", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
        }

        internal static void warnAllReplacementsDone()
        {
            MessageBox.Show(new Form() { TopMost = true }, "All applicable items on this presentation have been replaced with their locally stored translations", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void warnUnableToLaunchFirefox()
        {
            MessageBox.Show(new Form() { TopMost = true }, "Unable to launch Firefox. Make sure it's installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        internal static void warnUnableToSetTransLang()
        {
            MessageBox.Show(new Form() { TopMost = true }, "Unable to set up source and destination languages", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        internal static void warnUnableRetrieveTextFromThirdParty(String retrieveResult)
        {
            MessageBox.Show(new Form() { TopMost = true }, $"Unable to retrieve translated text from third party service. {retrieveResult}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}