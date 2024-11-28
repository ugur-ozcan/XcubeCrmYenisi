using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;
using DevExpress.XtraBars;
using XCubeCrm.UI.Win.Forms.ParametrelerForms;


namespace XCubeCrm.UI.Win.Forms.TestForms
{
    public partial class TestListForm : BaseListForm
    {
        public TestListForm()
        {
            InitializeComponent();
            Bll = new NumaralamaKontrolBll();
            btnBagliKartlar.Caption = "Test Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.NumaralamaKontrol;
            FormShow = new ShowEditForms<TestEditForm>();
            Navigator = longNavigator1.Navigator;
            if (IsMdiChild)
            {
                ShowItems = new BarItem[] { btnBagliKartlar };
            }

        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((NumaralamaKontrolBll)Bll).List(FilterFunctions.Filtre<NumaralamaKontrol>(AktifKartlariGoster));
        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<NumaralamaKontrol>();
            if (entity == null) return;

            ShowListForms<ParametrelerListForm>.ShowListForm(KartTuru.Parametreler, entity.Id, entity.Numara);
        }
    }
}
