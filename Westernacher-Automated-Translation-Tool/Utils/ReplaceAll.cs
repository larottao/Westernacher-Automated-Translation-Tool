using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Utils
{
    public static class ReplaceAll
    {
        private static String lastReplaced = "";

        public static void replace(String previousText, String newText, DataGridView dataGridView)

        {
            //This is a temporary solution to debounce the clicking action, causing multiple replaces of the same word

            if (!lastReplaced.Equals(newText))
            {
                lastReplaced = newText;
             

                List<Figure> pendingToReplace = globalFiguresList.Where(x => x.previousText.Equals(previousText)).ToList();

                if (!pendingToReplace.Any())
                {
                    return;
                }

                /*
                DialogResult result = MessageBox.Show($"Do you want to replace all ocurrences of '{previousText}' with '{newText}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                */

                foreach (var figure in pendingToReplace)
                {
                    figure.newText = newText;
                    figure.pendingToTranslate = false;
                    figure.pendingToReplace = true;
                }

                dataGridView.Refresh();

                new SaveOnDisk().savefiguresListToJson(GlobalVariables.globalFiguresList, GlobalVariables.currentOfficeDocPath + ".json");

              
            }
        }
    }
}