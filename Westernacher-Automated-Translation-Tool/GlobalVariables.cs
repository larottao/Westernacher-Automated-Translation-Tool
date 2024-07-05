using Automated_Office_Translation_Tool.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Automated_Office_Translation_Tool
{
    public static class GlobalVariables
    {
        public static OnDiskDictionary onDiskDictionary { get; set; } = new OnDiskDictionary();

        public static readonly IPowerPointInteraction _iPowerPointInteraction = new PowerPointInteractionService();

        public static readonly IExcelInteraction _iExcelInteraction = new ExcelInteractionService();
        public static ContextMenuStrip contextMenuStrip { get; set; } = new ContextMenuStrip();
        public static String currentOfficeDocPath { get; set; }
        public static int dataGridViewSelectedRow { get; set; } = -1;
        public static List<Figure> globalFiguresList { get; set; } = new List<Figure>();
        public static Figure figureUnderTranslation { get; set; } = new Figure();
        public static String globalSourceLanguage { get; set; }
        public static String globalDestinationLanguage { get; set; }

        public static string googleTranslateURL { get; set; } = "https://translate.google.com/?sl=SOURCELANG&tl=DESTINATIONLANG&op=translate";
        public static String googleTranslateInputCssSelector { get; set; } = "[aria-label='Source text']";
        public static String googleTranslateCopyButtonCssSelector { get; set; } = "[aria-label='Copy translation']";
        public static string googleTranslateSeleniumProfileName { get; set; } = "Automatizacion";

        public static String deepLUrl { get; set; } = "https://api-free.deepl.com/v2/translate";
        public static String deepLAuthKey { get; set; } = "";
        public static float minimumSizeTextWillBeShrinked { get; internal set; } = 12;
    }
}