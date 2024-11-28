using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyCheckEdit:CheckEdit,IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyCheckEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.Transparent;
        }
        public override bool EnterMoveNextControl { get ; set  ; }
        public string StatusBarAciklama { get ; set  ; }
    }
}
