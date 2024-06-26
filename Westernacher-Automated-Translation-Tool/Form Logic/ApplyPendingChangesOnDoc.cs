using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Automated_Office_Translation_Tool.GlobalVariables;

namespace Automated_Office_Translation_Tool.Services
{
    public class ApplyPendingChangesOnDoc
    {
        public Tuple<Boolean, String> apply()
        {
            if (!globalFiguresList.Where(x => x.pendingToReplace).Any())
            {
                return new Tuple<Boolean, String>(false, "There are no figures marked as pending to be replaced in the document.");
            }

            foreach (Figure figure in globalFiguresList)
            {
                try
                {
                    if (!figure.pendingToReplace)
                    {
                        continue;
                    }

                    Tuple<Boolean, String> replaceTextResult = null;

                    string extension = Path.GetExtension(currentOfficeDocPath);

                    switch (extension.ToLower())
                    {
                        case ".pptx":
                        case ".ppt":
                            replaceTextResult =
                      _iPowerPointInteraction.replaceFigureText(figure, false, true, true);
                            break;

                        case ".xlsx":
                        case ".xls":
                            replaceTextResult =
                      _iExcelInteraction.replaceFigureText(figure, false, true);
                            break;
                    }

                    if (replaceTextResult.Item1)
                    {
                        figure.pendingToReplace = false;
                    }
                    else
                    {
                        return new Tuple<Boolean, String>(false, replaceTextResult.Item2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(new Form() { TopMost = true }, "Unable to replace item in document: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            return new Tuple<Boolean, String>(true, "");
        }
    }
}