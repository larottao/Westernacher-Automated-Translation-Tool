using System;
using System.Collections.Generic;

namespace Automated_Office_Translation_Tool
{
    public interface IExcelInteraction
    {
        Tuple<Boolean, String> launchFileSelectionDialog();

        Tuple<Boolean, String> launchExcel();

        Tuple<Boolean, String> openExcelWorkbook(String filePath);

        Boolean isExcelWorkbookOpen();

        Tuple<Boolean, String> activateSheetByIndex(int sheetIndex);

        Tuple<Boolean, String> activateSheetByName(String sheetName);

        void putExcelInAutoMode();

        void putExcelInManualMode();

        Tuple<Boolean, int> getColumnNumberByLetter(String letters);

        Tuple<Boolean, String> getColumnLetterByNumber(int number);

        Tuple<Boolean, int> getWorkbookTotalSheets();

        Tuple<Boolean, int> getSheetTotalRows();

        Tuple<Boolean, int> getSheetTotalColumns();

        Tuple<bool, string> tryToSelectCell(int sheetIndex, int row, int col);

        Tuple<bool, string> tryToSelectCell(String sheetName, int row, int col);

        Tuple<Boolean, String, List<Figure>> extractExcelTofiguresList(Boolean replaceLineJumps);

        Tuple<Boolean, String> replaceFigureText(Figure figure, Boolean usePreviousText, Boolean useNewText);

        Tuple<Boolean, String> closeExcelFile(Boolean saveBeforeClosing);

        Tuple<Boolean, String> closeExcel();
    }
}