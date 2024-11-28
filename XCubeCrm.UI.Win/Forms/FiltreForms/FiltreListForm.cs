
using System;
using System.Linq;





using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Show;
 
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;

namespace XCubeCrm.UI.Win.Forms.FiltreForms
{
    public partial class FiltreListForm : BaseListForm
    {
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;
        public FiltreListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new FiltreBll();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnFiltrele, btnKolonlar, btnYazdir, btnDisariAktar, barFiltrele, barFiltreleAciklama, barKolonlar, barKolonlarAciklama, barDisariAktar, barDisariAktarAciklama, barYazdir, barYazdirAciklama };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Filtre;
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((FiltreBll)Bll).List(x => x.KartTuru == _filtreKartTuru);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<FiltreEditForm>.ShowDialogEditForm(KartTuru.Filtre, id, _filtreKartTuru, _filtreGrid);
            ShowEditFormDefault(result);
        }


    }
}