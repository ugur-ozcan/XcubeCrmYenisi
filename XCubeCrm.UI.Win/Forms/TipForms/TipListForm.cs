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



namespace XCubeCrm.UI.Win.Forms.TipForms
{
    public partial class TipListForm : BaseListForm
    {
        public TipListForm()
        {
            InitializeComponent();
            Bll = new TipBll();
            btnBagliKartlar.Caption = "Parametre Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Tip;
            FormShow = new ShowEditForms<TipEditForm>();
            Navigator = longNavigator1.Navigator;
            if (IsMdiChild)
            {
                ShowItems = new BarItem[] { btnBagliKartlar };
            }

        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((TipBll)Bll).List(FilterFunctions.Filtre<Tip>(AktifKartlariGoster));
            int sayi = ((TipBll)Bll).List(FilterFunctions.Filtre<Tip>(AktifKartlariGoster)).Count();
            System.Windows.Forms.MessageBox.Show(sayi.ToString());
        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Tip>();
            if (entity == null) return;

            ShowListForms<ParametrelerListForm>.ShowListForm(KartTuru.Parametreler, entity.Id, entity.TipAdi);
        }
    }
}
