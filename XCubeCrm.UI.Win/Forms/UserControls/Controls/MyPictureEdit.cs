using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using XCubeCrm.UI.Win.Interfaces;
using System.ComponentModel;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyPictureEdit: PictureEdit,IStatusBarKisayol
    {
        [ToolboxItem(true)]
        public MyPictureEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.Appearance.ForeColor = Color.Maroon;
            Properties.NullText = "Resim seçilmedi.";
            Properties.SizeMode = PictureSizeMode.Stretch;
            Properties.ShowMenu = false;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4: ";
        public string StatusBarKisayolAciklama { get; set; }
    }
}
