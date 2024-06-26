using System;

namespace Automated_Office_Translation_Tool
{
    public class Figure
    {
        public int listIndex { get; set; }
        public int id { get; set; }

        //Powerpoint --------------------------------
        public int slide { get; set; }

        public String sheet { get; set; }
        public int sheetNumber { get; set; }

        public Boolean belongsToATable { get; set; }
        public int parentTableId { get; set; }
        public int parentTableRow { get; set; }
        public int parentTableColumn { get; set; }

        //Excel -------------------------------------

        public int row { get; set; }
        public String column { get; set; }
        public int columnAsNumber { get; set; }

        //General -------------------------------------
        public Boolean containsText { get; set; }

        public Boolean textExtractionFailed { get; set; }
        public String textExtractionFailureReason { get; set; }
        public String previousText { get; set; }
        public Boolean PreviousTextIsBlank { get; set; }
        public Boolean prevTextContainsOnlyNumbersOrSymbols { get; set; }
        public String newText { get; set; }
        public Boolean pendingToTranslate { get; set; }
        public Boolean pendingToReplace { get; set; }
    }
}