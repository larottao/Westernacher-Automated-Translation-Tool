using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Automated_Office_Translation_Tool
{
    public static class GlobalConstants
    {
        internal static readonly string APP_NAME = "Westernacher Automated Translation Tool";

        public static ToolStripMenuItem locateOnPresentationMenuItem { get; set; } = new ToolStripMenuItem("Locate on Presentation");
        public static ToolStripMenuItem locateOnWorkbookMenuItem { get; set; } = new ToolStripMenuItem("Locate on Workbook");
        public static ToolStripMenuItem copyOriginalTextMenuItem { get; set; } = new ToolStripMenuItem("Copy original text");
        public static ToolStripMenuItem replaceAll { get; set; } = new ToolStripMenuItem("Replace all occurrences of the Previous Text with this New Text \n and save translation on disk for future use");
        public static ToolStripMenuItem changeInDocumentMenuItem { get; set; } = new ToolStripMenuItem("Change to translated in document");
        public static ToolStripMenuItem revertInDocumentMenuItem { get; set; } = new ToolStripMenuItem("Revert this to original in document");
        public static ToolStripMenuItem separatorMenuItem { get; set; } = new ToolStripMenuItem("-");

        public const string HEADER_SLIDE_NUMBER = "Slide Number";
        public const string HEADER_ID = "Id";

        public const string HEADER_SHEET_NAME = "Sheet Name";
        public const string HEADER_ROW = "Row";
        public const string HEADER_COLUMN = "Column";

        public const string HEADER_PREV_TEXT = "Previous Text";
        public const string HEADER_NEW_TEXT = "New Text";
        public const string HEADER_PENDING_TO_TRANSLATE = "Send for translation";
        public const string HEADER_PENDING_TO_REPLACE = "Pending to Replace";

        public static readonly ReadOnlyCollection<string> RELEVANT_COLUMNS_FOR_PPTX = new ReadOnlyCollection<string>(
            new List<string> {
            HEADER_SLIDE_NUMBER,
            HEADER_ID,
            HEADER_PREV_TEXT,
            HEADER_NEW_TEXT,
            HEADER_PENDING_TO_TRANSLATE,
            HEADER_PENDING_TO_REPLACE
            });

        public static readonly ReadOnlyCollection<string> RELEVANT_COLUMNS_FOR_EXCEL = new ReadOnlyCollection<string>(
            new List<string> {
            HEADER_SHEET_NAME,
            HEADER_ROW,
            HEADER_COLUMN,
            HEADER_PREV_TEXT,
            HEADER_NEW_TEXT,
            HEADER_PENDING_TO_TRANSLATE,
            HEADER_PENDING_TO_REPLACE
            });

        public static readonly string SAVED_TRANSLATIONS_FILE = "saved_translations.txt";

        public enum DOCUMENT_TYPE
        { PPT, EXCEL }

        public enum TRANSLATION_METHOD
        { WEBSITE, API }

        public enum SELECTED_TRANSLATION_API
        { GOOGLE_TRANSLATE, LIBRE_TRANSLATE, DEEPL, CHATGPT }

        public static Dictionary<string, string> LANGUAGE { get; } = new Dictionary<string, string>
        {
            { "Bulgarian", "bg" },
            { "Chinese Simplified", "zh-CN" },
            { "Chinese Traditional", "zh-TW" },
            { "English", "en" },
            { "Finnish", "fi" },
            { "French", "fr" },
            { "German", "de" },
            { "Hindi", "hi" },
            { "Irish", "ga" },
            { "Norwegian", "no" },
            { "Polish", "pl" },
            { "Spanish", "es" },
            { "Swedish", "sv" },
            { "Romanian", "ro" },
        };

        public const String ERROR_UNABLE_RETRIEVE_TEXT_FROM_BROWSER = "ERROR: UNABLE TO GET TRANSLATED TEXT FROM BROWSER";

        public const String ERROR_UNABLE_CLEAR_BROWSER = "ERROR: UNABLE TO CLEAR PREVIOUS TEXT ON BROWSER";
        public const String ERROR_UNABLE_SEND_TEXT_TO_BROWSER = "ERROR: UNABLE TO SEND TEXT TO BROWSER";
    }
}