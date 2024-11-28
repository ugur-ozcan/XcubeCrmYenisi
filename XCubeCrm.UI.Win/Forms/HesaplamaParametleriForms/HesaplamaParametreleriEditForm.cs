using DevExpress.XtraEditors;
using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Functions;
using static Telerik.WinControls.NativeMethods;



namespace XCubeCrm.UI.Win.Forms.HesaplamaParametreleriForms
{
    public partial class HesaplamaParametreleriEditForm : BaseEditForm
    {
        public HesaplamaParametreleriEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new HesaplamaParametreleriBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.HesaplamaParametreleri;
            EventsLoad();

        }

        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new HesaplamaParametreleri() : ((HesaplamaParametreleriBll)Bll).Single(FilterFunctions.Filtre<HesaplamaParametreleri>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((HesaplamaParametreleriBll)Bll).YeniKodVer();
            txtParametreAd.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (HesaplamaParametreleri)OldEntity;

            txtKod.Text = entity.Kod;
            txtParametreAd.Text = entity.ParametreAdi;
            txtParametreDeger.Text = entity.ParametreDegeri;
            txtAciklama.Text = entity.ParametreAciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new HesaplamaParametreleri
            {
                Id = Id,
                Kod = txtKod.Text,
                ParametreAdi = txtParametreAd.Text,
                ParametreDegeri = txtParametreDeger.Text,
                ParametreAciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
  
    }
}