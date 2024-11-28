using DevExpress.XtraBars.Docking2010;
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
    [ToolboxItem(true)]
    public class MySimpleButton: SimpleButton,IStatusBarAciklama
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;
            AppearanceHovered.ForeColor = Color.LightCyan;
        }

        public string StatusBarAciklama { get; set ; }
    }
}
