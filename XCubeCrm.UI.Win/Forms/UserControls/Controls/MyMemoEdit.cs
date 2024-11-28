using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using XCubeCrm.UI.Win.Interfaces;

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    public class MyMemoEdit: MemoEdit,IStatusBarAciklama
    {
        [ToolboxItem(true)]
        public MyMemoEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 700;
            Properties.WordWrap = true;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; } = "Açıklama Giriniz.";
    }
}
