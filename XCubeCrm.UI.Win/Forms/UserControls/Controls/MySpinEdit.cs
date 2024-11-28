using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.Utils;
using System.ComponentModel;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MySpinEdit: SpinEdit,IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MySpinEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "d";
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get  ; set  ; }
    }
}
