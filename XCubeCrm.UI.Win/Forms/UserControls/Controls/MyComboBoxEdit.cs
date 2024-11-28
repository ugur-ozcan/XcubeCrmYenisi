using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using XCubeCrm.UI.Win.Interfaces;


namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyComboBoxEdit:ComboBoxEdit,IStatusBarKisayol
    {
        public MyComboBoxEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4 : ";
        public string StatusBarKisayolAciklama { get; set; }
    }
}
