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

namespace XCubeCrm.UI.Win.Forms.ParametrelerForms
{
 
    public partial class ParametrelerEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _tipId;
        private readonly string _tipAdi; 
        #endregion
        public ParametrelerEditForm(params object[] prm)
        {
            InitializeComponent();
            _tipId = (long)prm[0];
            _tipAdi = (string)prm[1];
            DataLayoutControl = myDataLayoutControl;
            Bll = new ParametrelerBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Parametreler;
            EventsLoad();

        }

        public  override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Parametreler() : ((ParametrelerBll)Bll).Single(FilterFunctions.Filtre<Parametreler>(Id));
            NesneyiKontrollereBagla();
            Text = Text + $" - ( {_tipAdi} )";

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((ParametrelerBll)Bll).YeniKodVer(x => x.TipId == _tipId);
            txtParametrelerAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Parametreler)OldEntity;

            txtKod.Text = entity.Kod;
            txtParametrelerAdi.Text = entity.ParametreBaslik;
            txtParametreDegeri.Text = entity.ParametreDegeri;
            txtFirma.Text = entity.Firma;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Parametreler
            {
                Id = Id,
                Kod = txtKod.Text,
                ParametreBaslik = txtParametrelerAdi.Text,
                Firma = (txtFirma.Text),
                TipId = _tipId,
                ParametreDegeri = txtParametreDegeri.Text,
                Durum = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }
        protected override bool EntityInsert()
        {
            return ((ParametrelerBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.TipId == _tipId);
        }
        protected override bool EntityUpdate()
        {
            return ((ParametrelerBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.TipId == _tipId);
        }
    }
}