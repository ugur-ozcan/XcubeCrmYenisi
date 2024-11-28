using System.ComponentModel;
using DevExpress.Utils;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyTelefonNoTextEdit : MyTextEdit
    {
        [ToolboxItem(true)]
        public MyTelefonNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegularMaskManager));
            
            Properties.MaskSettings.Set("mask", "(\\d?\\d?\\d?) \\d\\d\\d-\\d\\d-\\d\\d");

            StatusBarAciklama = "Telefon Numarası Giriniz.";
        }
        public override bool EnterMoveNextControl { get; set; } = true;
    }
}
