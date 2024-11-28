using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Bll.General;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Forms.BaseForms;

namespace XCubeCrm.UI.Win.Forms.TestForms
{
    public partial class TestEditForm : BaseEditForm
    {
        public TestEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new NumaralamaKontrolBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.NumaralamaKontrol;
            EventsLoad();

        }
        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new NumaralamaKontrol() : ((NumaralamaKontrolBll)Bll).Single(FilterFunctions.Filtre<NumaralamaKontrol>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((NumaralamaKontrolBll)Bll).YeniKodVer();
            txtNumaralamaAdi.Focus();
        }


        protected override void NesneyiKontrollereBagla()
        {
            var entity = (NumaralamaKontrol)OldEntity;
            txtKod.Text = entity.Kod;
            txtNumaralamaAdi.Text = entity.Numara;
            txtAciklama.Text = entity.FisTuru;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new NumaralamaKontrol
            {
                Id = Id,
                Kod = txtKod.Text,
                Numara = txtNumaralamaAdi.Text,
                FisTuru = txtAciklama.Text,
                Durum = tglDurum.IsOn,
            };

            ButonEnabledDurumu();
        }
    }
}