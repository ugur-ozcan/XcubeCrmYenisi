using DevExpress.Utils;
using DevExpress.XtraExport.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyEmailTextEdit:MyTextEdit
    {
        [ToolboxItem(true)]
        public MyEmailTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));

            Properties.MaskSettings.Set("mask", "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+");

            StatusBarAciklama = "Mail Adresini Giriniz.";
        }
    }
}


