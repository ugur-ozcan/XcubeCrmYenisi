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
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;

namespace XCubeCrm.UI.Win.Forms.IlceForms
{

    public partial class IlceEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _ilId;
        private readonly string _ilAdi;
        #endregion
        public IlceEditForm(params object[] prm)
        {
            InitializeComponent();
            _ilId = (long)prm[0];
            _ilAdi = (string)prm[1];
            DataLayoutControl = myDataLayoutControl;
            Bll = new IlceBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Ilce;
            EventsLoad();

        }

        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Ilce() : ((IlceBll)Bll).Single(FilterFunctions.Filtre<Ilce>(Id));
            NesneyiKontrollereBagla();
            Text = Text + $" - ( {_ilAdi} )";

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IlceBll)Bll).YeniKodVer(x => x.IlId == _ilId);
            txtIlceAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Ilce)OldEntity;

            txtKod.Text = entity.Kod;
            txtIlceAdi.Text = entity.IlceAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Ilce
            {
                Id = Id,
                Kod = txtKod.Text,
                IlceAdi = txtIlceAdi.Text,
                IlId = _ilId,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((IlceBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.IlId == _ilId);
        }
        protected override bool EntityUpdate()
        {
            return ((IlceBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.IlId == _ilId);
        }
    }
}