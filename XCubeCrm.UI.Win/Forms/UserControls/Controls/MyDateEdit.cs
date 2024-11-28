using DevExpress.XtraEditors;
using System;
using DevExpress.Utils;
using System.Drawing;
using XCubeCrm.UI.Win.Interfaces;
using System.ComponentModel;


namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDateEdit:DateEdit,IStatusBarKisayol
    {
        public MyDateEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaskSettings.Set("useAdvancingCaret", true);
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisayol { get; set; } = "F4 : ";
        public string StatusBarKisayolAciklama { get; set; } = "Tarih Seç";
        public string StatusBarAciklama { get; set; }
    }
}
