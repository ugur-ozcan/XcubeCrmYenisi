using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.Interfaces;
using DevExpress.Utils;
using System.ComponentModel;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyCalcEdit :CalcEdit,IStatusBarKisayol
    {
        [ToolboxItem(true)]
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.Default;
            Properties.EditMask = "n4";
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        
        public string StatusBarAciklama { get ; set ; }
        public string StatusBarKisayol { get; set; } = "F4 : ";
        public string StatusBarKisayolAciklama { get; set; } = "Hesap Makinesi";
    }
}
