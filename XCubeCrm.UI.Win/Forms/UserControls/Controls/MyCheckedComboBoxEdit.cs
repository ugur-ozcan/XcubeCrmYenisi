using DevExpress.XtraEditors;
 using System.ComponentModel;
using System.Drawing;
 
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyCheckedComboBoxEdit: CheckedComboBoxEdit,IStatusBarKisayol
    {
        [ToolboxItem(true)]
        public MyCheckedComboBoxEdit()
        {
      
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisayol { get; set  ; }
        public string StatusBarKisayolAciklama { get; set; } = "F4 : ";
        public string StatusBarAciklama { get; set; }
    }
}
