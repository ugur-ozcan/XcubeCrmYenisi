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

namespace XCubeCrm.UI.Win.Forms.IlForms
{
    public partial class IlEditForm : BaseEditForm
    {
        public IlEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new IlBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Il;
            EventsLoad();

        }
        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Il() : ((IlBll)Bll).Single(FilterFunctions.Filtre<Il>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IlBll)Bll).YeniKodVer();
            txtIlAdi.Focus();
        }


        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Il)OldEntity;
            txtKod.Text = entity.Kod;
            txtIlAdi.Text = entity.IlAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Il
            {
                Id = Id,
                Kod = txtKod.Text,
                IlAdi = txtIlAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
            };

            ButonEnabledDurumu();
        }
    }
}