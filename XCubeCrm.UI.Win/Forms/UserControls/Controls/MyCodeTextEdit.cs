using System.ComponentModel;
using System.Drawing;
 

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyKodTextEdit:MyTextEdit
    {
        [ToolboxItem(true)]
        public MyKodTextEdit()
        {
            Properties.Appearance.BackColor = Color.PaleGoldenrod;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.MaxLength = 20;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}
