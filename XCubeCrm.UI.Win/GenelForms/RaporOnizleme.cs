using DevExpress.XtraPrinting;

namespace XCubeCrm.UI.Win.GenelForms
{
    public partial class RaporOnizleme : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RaporOnizleme(params object[] prm)
        {
            InitializeComponent();

            raporGosterici.PrintingSystem = (PrintingSystem) prm[0];
            Text = $"{Text} ( {prm[1].ToString()} )";
        }
    }
}