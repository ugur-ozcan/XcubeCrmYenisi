using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.Drawing;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyToggleSwitch : ToggleSwitch,IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyToggleSwitch()
        {
            Name = "tglDurum";
            Properties.OffText = "Pasif";
            Properties.OnText = "Aktif";
            Properties.AutoHeight = false;
            Properties.AutoWidth = true;
            Properties.GlyphAlignment = HorzAlignment.Far;
            Properties.Appearance.ForeColor = Color.Maroon;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; } = "Durumunu Seçiniz.";
    }
}
