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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Functions;
namespace XCubeCrm.UI.Win.Reports.FormReports
{
    public partial class BaseRapor : RibbonForm
    {
        protected ControlNavigator Navigator;
        protected  GridView Tablo;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;


        public BaseRapor()
        {
            InitializeComponent();
        }


  
        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Navigator.NavigatableControl = Tablo.GridControl;
            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        protected internal void DegiskenleriDoldur()
        {
        }
        public void EventsLoad()
        {
            //Button events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Cursor.Current = Cursors.WaitCursor;

            //if (e.Item == btnDisariAktar)
            //{
            //    var link = (BarSubItemLink)e.Item.Links[0];
            //    link.Focus();
            //    link.OpenMenu();
            //    link.Item.ItemLinks[0].Focus();
            //}
            //else if (e.Item == btnStandartExcelDosyasi)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.ExcellStandart, e.Item.Caption, Text);

            //}
            //else if (e.Item == btnExcelDosyasiFormatli)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.ExcellFormatli, e.Item.Caption, Text);
            //}
            //else if (e.Item == btnExcelDosyasiFormatsiz)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.ExcellFormatsiz, e.Item.Caption);
            //}
            //else if (e.Item == btnWordDosyasi)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.WordDosyasi, e.Item.Caption);
            //}
            //else if (e.Item == btnWordDosyasi)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.PdfDosyasi, e.Item.Caption);
            //}
            //else if (e.Item == btnTxtDosyasi)
            //{
            //    Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.TextDosyasi, e.Item.Caption);
            //}
            //else if (e.Item == btnRaporSablonlari)
            //{
            //    Listele();
            //}
            //else if (e.Item == btnYenile)
            //    RaporSablonSec();
            //else if (e.Item == btnGruplamaPaneliGenislet)
            //    Tablo.OptionsView.ShowGroupPanel = !Tablo.OptionsView.ShowGroupPanel;
            //else if (e.Item == btnTumGruplariGenislet)
            //    Tablo.ExpandAllGroups();
            //else if (e.Item == btnTumGruplariDaralt)
            //    Tablo.CollapseAllGroups();

            //else if (e.Item == btnFiltrele)
            //    FiltreSec();
            //else if (e.Item == btnKolonlar)
            //{
            //    if (Tablo.CustomizationForm == null)
            //        Tablo.ShowCustomization();
            //    else Tablo.HideCustomization();
            //}
            //else if (e.Item == btnYazdir) Yazdir();
            //else if (e.Item == btnCikis) Close();
            //else if (e.Item == btnAktifPasifKayitlar)
            //{
            //    AktifKartlariGoster = !AktifKartlariGoster;
            //    FormCaptionAyarla();
            //}

            Cursor.Current = DefaultCursor;
        }

    }
}