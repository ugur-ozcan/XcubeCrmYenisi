using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTCKimlikNoTextEdit : MyTextEdit
    {
        public MyTCKimlikNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d? \d?\d? \d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Tc Kimlik no giriniz.";
        }
    }
}