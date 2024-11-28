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

namespace XCubeCrm.UI.Win.Forms.TipForms
{
    public partial class TipEditForm : BaseEditForm
    {
        public TipEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new TipBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Tip;
            EventsLoad();

        }
        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Tip() : ((TipBll)Bll).Single(FilterFunctions.Filtre<Tip>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((TipBll)Bll).YeniKodVer();
            txtTipAdi.Focus();
        }


        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Tip)OldEntity;
            txtKod.Text = entity.Kod;
            txtTipAdi.Text = entity.TipAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Tip
            {
                Id = Id,
                Kod = txtKod.Text,
                TipAdi = txtTipAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
            };

            ButonEnabledDurumu();
        }
    }
}