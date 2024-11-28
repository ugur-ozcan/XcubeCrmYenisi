using DevExpress.XtraEditors;

using DevExpress.XtraBars;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Common.Functions;
using XCubeCrm.Model.Entities.Base.Interfaces;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.Model.Entities;
using System;


namespace XCubeCrm.UI.Win.GenelForms
{
    public partial class TabloDokumParametreleri : BaseEditForm
    {
        #region Variables
        private DokumSekli _dokumSekli;
        readonly private string _raporBaslik;
        #endregion

        public TabloDokumParametreleri(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl2;
           
            HideItems = new BarItem[] { btnYeni, btnKaydet, btnGeriAl, btnSil };
            ShowItems = new BarItem[] { btnYazdir, btnBaskiOnizleme };
            EventsLoad();

            _raporBaslik = prm[0].ToString();
        }



        public  override void Yukle()
        {
            txtRaporBasligi.Text = _raporBaslik;
            cmbBaslikEkle.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            cmbRaporuKagidaSigdir.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<RaporuKagidaSigdirmaTuru>());
            cmbYazdirmaYonu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<YazdirmaYonu>());
            cmbYatayCizgileriGoster.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            cmbDikeyCizgileriGoster.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            cmbSutunBasliklariniGoster.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<EvetHayir>());
            cmbYaziciAdi.Properties.Items.AddRange(GeneralFunctions.YazicilariListele());

            cmbBaslikEkle.SelectedItem = EvetHayir.Evet.ToName();
            cmbRaporuKagidaSigdir.SelectedItem = RaporuKagidaSigdirmaTuru.YaziBoyutunuKuculterekSigdir.ToName();
            cmbYazdirmaYonu.SelectedItem = YazdirmaYonu.Otomatik.ToName();
            cmbYatayCizgileriGoster.SelectedItem = EvetHayir.Evet.ToName();
            cmbDikeyCizgileriGoster.SelectedItem = EvetHayir.Evet.ToName();
            cmbSutunBasliklariniGoster.SelectedItem = EvetHayir.Evet.ToName();
            cmbYaziciAdi.EditValue = GeneralFunctions.DefaultYazici();
        }

        protected internal override IBaseEntity ReturnEntity()
        {
            var entity = new DokumParametreleri
            {
                RaporBaslik = txtRaporBasligi.Text,
                BaslikEkle = cmbBaslikEkle.Text.GetEnum<EvetHayir>(),
                RaporuKagidaSigdir = cmbRaporuKagidaSigdir.Text.GetEnum<RaporuKagidaSigdirmaTuru>(),
                YazdirmaYonu = cmbYazdirmaYonu.Text.GetEnum<YazdirmaYonu>(),
                YatayCizgileriGoster = cmbYatayCizgileriGoster.Text.GetEnum<EvetHayir>(),
                DikeyCizgileriGoster = cmbDikeyCizgileriGoster.Text.GetEnum<EvetHayir>(),
                SutunBasliklariniGoster = cmbSutunBasliklariniGoster.Text.GetEnum<EvetHayir>(),
                YaziciAdi = cmbYaziciAdi.Text,
                KopyaSayisi = (int)spnKopyaSayisi.Value,
                DokumSekli = _dokumSekli
            };
            return entity;
        }

        protected override void Yazdir()
        {
            _dokumSekli = DokumSekli.TabloYazdir;
            Close();
        }

        protected override void BaskiOnizleme()
        {
            _dokumSekli = DokumSekli.TabloBaskiOnizleme;
            Close();
        }

        protected override void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender != cmbBaslikEkle) return;
            txtRaporBasligi.Enabled = cmbBaslikEkle.Text.GetEnum<EvetHayir>() == EvetHayir.Evet;
        }
    }
}