using DevExpress.XtraEditors;
using System;
using System.Linq;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;
using XCubeCrm.UI.Win.Functions;
using static Telerik.WinControls.NativeMethods;



namespace XCubeCrm.UI.Win.Forms.FirmaForms
{
    public partial class FirmaEditForm : BaseEditForm
    {
        public FirmaEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new FirmaBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Firma;
            EventsLoad();

        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Firma() : ((FirmaBll)Bll).Single(FilterFunctions.Filtre<Firma>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((FirmaBll)Bll).YeniKodVer();
            txtFirmaAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Firma)OldEntity;

            txtKod.Text = entity.Kod;
            txtFirmaAdi.Text = entity.FirmaAdi;
            txtVergiNo.Text = entity.VergiNo;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            myPictureEdit1.EditValue = entity.ResimData;
         }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Firma
            {
                Id = Id,
                Kod = txtKod.Text,
                FirmaAdi = txtFirmaAdi.Text,
                VergiNo = txtVergiNo.Text,
                Aciklama = txtAciklama.Text,
                ResimData = (byte[])myPictureEdit1.EditValue,     //ÖNEMLİ
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {

            if (!(sender is ButtonEdit)) return;

            
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
          }

        private void myPictureEdit1_DoubleClick(object sender, EventArgs e)
        {

        }

        protected override void Control_Enter(object sender, EventArgs e)
        {
            if (!(sender is MyPictureEdit resim)) return;
            resim.Sec(popupMenuResim);
        }
    }
}