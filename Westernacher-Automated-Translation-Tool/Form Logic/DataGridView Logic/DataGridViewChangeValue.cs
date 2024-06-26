using System.Windows.Forms;

namespace Automated_Office_Translation_Tool.Form_Logic
{
    public class DataGridViewChangeValue
    {
        public void changeValue(object sender, DataGridViewCellEventArgs e)
        {
            new SaveOnDisk().savefiguresListToJson(GlobalVariables.globalFiguresList, GlobalVariables.currentOfficeDocPath + ".json");
        }
    }
}