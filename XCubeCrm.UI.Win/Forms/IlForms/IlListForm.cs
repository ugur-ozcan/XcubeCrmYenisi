using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;
using DevExpress.XtraBars;
using XCubeCrm.UI.Win.Forms.IlceForms;

namespace XCubeCrm.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
            Bll = new IlBll();
            btnBagliKartlar.Caption = "İlçe Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator1.Navigator;
            if (IsMdiChild)
            {
                ShowItems = new BarItem[] { btnBagliKartlar };
            }

        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((IlBll)Bll).List(FilterFunctions.Filtre<Il>(AktifKartlariGoster));
        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Il>();
            if (entity == null) return;

            ShowListForms<IlceListForm>.ShowListForm(KartTuru.Ilce, entity.Id, entity.IlAdi);
        }
    }
}
