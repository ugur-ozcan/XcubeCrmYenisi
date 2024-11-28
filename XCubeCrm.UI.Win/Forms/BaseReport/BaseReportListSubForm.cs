using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.UI.Win.Functions;

namespace XCubeCrm.UI.Win.Forms.BaseReport
{
    public partial class BaseReportListSubForm : DevExpress.XtraEditors.XtraForm
    {
        protected internal GridView Tablo;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        private bool _formSablonKayitEdilecek;
        private bool _tabloSablonKayitEdilecek;
        protected internal long? SeciliGelecekId;
        protected internal bool MultiSelect;
        protected internal long? SeciliGidecekId;
        protected KartTuru BaseKartTuru;

        protected internal IslemTuru BaseIslemTuru;
        protected internal long Id;
        protected internal bool RefreshYapilacak;
        public BaseReportListSubForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            //Button events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //table events


            //form events

            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }
        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = MultiSelect;

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;

            //Güncellenecek
        }
        protected virtual void DegiskenleriDoldur()
        {

        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnDisariAktar)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnStandartExcelDosyasi)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm")), DosyaTuru.ExcellStandart, e.Item.Caption, Text);

            }
            else if (e.Item == btnExcelDosyasiFormatli)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.ExcellFormatli, e.Item.Caption, Text);
            }
            else if (e.Item == btnExcelDosyasiFormatsiz)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.ExcellFormatsiz, e.Item.Caption);
            }
            else if (e.Item == btnWordDosyasi)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm")), DosyaTuru.WordDosyasi, e.Item.Caption);
            }
            else if (e.Item == btnWordDosyasi)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.PdfDosyasi, e.Item.Caption);
            }
            else if (e.Item == btnTxtDosyasi)
            {
                Tablo.TabloDisariAktar(this.Text.ToString() + (Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd hh mm-")), DosyaTuru.TextDosyasi, e.Item.Caption);
            }

            else if (e.Item == btnYeni)
            {
                //yetki kontrolü
                // ShowEditForm(-1);
            }
            else if (e.Item == btnDuzelt)
            {


                //ShowEditForm(Tablo.GetRowId());
            }
            else if (e.Item == btnSil)
            {
                //yetki kontrolü
                // EntityDelete();
            }
            else if (e.Item == btnSec)
            {
                MessageBox.Show(SeciliGelecekId.ToString());
                SelectEntity();
            }
            else if (e.Item == btnYenile)
            {
                Listele();
            }
            //else if (e.Item == btnFiltrele)
            //    FiltreSec();
            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                    Tablo.ShowCustomization();
                else Tablo.HideCustomization();
            }
  
            //else if (e.Item == btnYazdir) //Yazdir();
            else if (e.Item == btnCikis) Close();
            else if (e.Item == btnAktifPasifKayitlar)
            {
                //AktifKartlariGoster = !AktifKartlariGoster;
                //FormCaptionAyarla();
            }

            Cursor.Current = DefaultCursor;
        }

        private void BaseListForm_Shown(object sender, EventArgs e)
        {
 
            Tablo.Focus();
            ButonGizleGoster();
            // SutunGizleGoster();

            if (IsMdiChild || !SeciliGelecekId.HasValue) return; //SeciliGelecekId == null) return;
            Tablo.RowFocus("Id", SeciliGelecekId);
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            SablonYukle();
        }
        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }
        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }
        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }
        private void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);

            if (_tabloSablonKayitEdilecek)
                Tablo.TabloSablonKaydet(IsMdiChild ? Name + " Tablosu" : Name + " TablosuMDI");
        }
        private void SablonYukle()
        {
            if (IsMdiChild)
                Tablo.TabloSablonYukle(Name + " Tablosu");
            else
            {
                Name.FormSablonYukle(this);
                Tablo.TabloSablonYukle(Name + " TablosuMDI");
            }
        }
        void ButonGizleGoster()
        {

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            /*            I
                          V
            foreach (BarItem item in ShowItems)
            {
                item.Visibility = BarItemVisibility.Always;
            }
            */
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);


            barInsert.Visibility = BarItemVisibility.Never;
            barDelete.Visibility = BarItemVisibility.Never;
            barDuzelt.Visibility = BarItemVisibility.Never;
            barKaydet.Visibility = BarItemVisibility.Never;
            barInsertAciklama.Visibility = BarItemVisibility.Never;
            barDeleteAciklama.Visibility = BarItemVisibility.Never;
            barDuzeltAciklama.Visibility = BarItemVisibility.Never;
            barKaydetAciklama.Visibility = BarItemVisibility.Never;
            btnDuzelt.Visibility = BarItemVisibility.Never;
            btnSil.Visibility = BarItemVisibility.Never;
            btnYeni.Visibility = BarItemVisibility.Never;
            btnKaydet.Visibility = BarItemVisibility.Never;



        }
        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = DefaultCursor;
        }
        private void SelectEntity()
        {
            if (MultiSelect)
            {
                //Güncellenecek
            }
            //  else SelectedEntity = Tablo.GetRow<BaseEntity>();
            MessageBox.Show(SeciliGelecekId.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }
        private void IslemTuruSec()
        {
            if (!IsMdiChild)
            {
                //Güncellenecek
                SelectEntity();//mdi değilse seçim yap

            }
            //else if (IsMdiChild && RaporMu ==true)
            //{
            //    MessageBox.Show("Güncelleme açılacak");
            //}
            else
            {
                btnDuzelt.PerformClick(); //mdi değilse içine giriş double click gibi çalış
            }
        }
        protected virtual void Listele()
        {
            //Tablo.GridControl.DataSource = ((OkulBll)Bll).List(FilterFunctions.Filter<Okul>(AktifKartlariGoster));
        }


    }

}