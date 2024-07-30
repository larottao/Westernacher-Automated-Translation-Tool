using Microsoft.Office.Core;
using System;
using System.Collections.Generic;

namespace Automated_Office_Translation_Tool
{
    public interface IPowerPointInteraction
    {
        Tuple<Boolean, String> launchFileSelectionDialog();

        Tuple<Boolean, String> launchPowerpoint();

        Tuple<Boolean, String> openPowerpointFile(String filePath);

        Boolean isPowerpointFileOpen();

        Tuple<bool, string> setProofingLanguage(MsoLanguageID msoLanguageID);

        Tuple<bool, string> tryToSelectSlideAndFigure(int slideNumber, int id);

        Tuple<Boolean, String, List<Figure>> extractPowerpointTextTofiguresList();

        Tuple<Boolean, String> replaceFigureText(Figure figure, Boolean usePreviousText, Boolean useNewText, Boolean shrinkTextIfNecessary);

        Tuple<Boolean, String> closePowerpointFile(Boolean saveBeforeClosing);

        Tuple<Boolean, String> closePowerpoint();
    }
}