
using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraBars;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.Data;using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GridHitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest;
using DevExpress.XtraGrid.Registrator;  // Bu önemli
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
  using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.FiltreForms;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;
using XCubeCrm.UI.Win.Show.Interfaces;
using DevExpress.XtraReports.Design;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;


namespace XCubeCrm.UI.Win.Forms.BaseReport
{
    public partial class BaseReportListForm : DevExpress.XtraEditors.XtraForm
    {
        protected internal GridView Tablo;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;

        private bool _formSablonKayitEdilecek = true;
        private bool _tabloSablonKayitEdilecek = true;
        protected internal long? SeciliGelecekId;
        protected internal bool MultiSelect;
        protected internal long SeciliGidecekId;
        protected KartTuru BaseKartTuru;
        protected bool RaporMu = true;
        protected IBaseFormShow FormShow;
        protected string raporTuru = "";
        protected internal int Id;


        private long _filtreId;
        public BaseReportListForm()
        {

            InitializeComponent();
        }

        private void EventsLoad()
        {
            //Button events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;


            tabloEvents();
            //table events

            Tablo.KeyDown += Tablo_KeyDown;

            Tablo.DoubleClick += Tablo_DoubleClick;

            Tablo.KeyDown += Tablo_KeyDown;
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
            Tablo.ColumnPositionChanged += Tablo_ColumnPositionChanged;
            Tablo.EndSorting += Tablo_EndSorting;
            Tablo.FilterEditorCreated += Tablo_FilterEditorCreated;
            Tablo.ColumnFilterChanged += Tablo_ColumnFilterChanged;
            Tablo.CustomDrawFooterCell += Tablo_CustomDrawFooterCell;
            
            //form events

            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        private void tabloEvents()
        {
            Tablo.MouseUp += Tablo_MouseUp;
        }
        protected virtual void Tablo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Tablo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            if (Tablo != null)
            {
                // Grid ayarlarını sıfırla
                Tablo.ClearSorting();
                Tablo.ClearGrouping();
                Tablo.ClearColumnsFilter();

                // Temel ayarlar
                Tablo.OptionsView.ShowFooter = true;
                Tablo.OptionsView.ShowGroupPanel = true;
                Tablo.OptionsMenu.EnableColumnMenu = true;
                Tablo.OptionsMenu.EnableFooterMenu = true;
                Tablo.OptionsMenu.EnableGroupPanelMenu = true;

                // Seçim ayarları
                Tablo.OptionsSelection.MultiSelect = MultiSelect;

                // Diğer ayarlar
                Tablo.OptionsView.ColumnAutoWidth = false;
                Tablo.OptionsView.ShowAutoFilterRow = true;
            }

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;
        }
        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var info = Tablo.CalcHitInfo(e.Location);

            // Footer, GroupPanel veya kolon başlığında isek
            if (info.HitTest == GridHitTest.Footer || info.HitTest == GridHitTest.GroupPanel || info.HitTest == GridHitTest.Column)
            {
                return; // DevExpress'in kendi menüsünü kullanması için
            }

            // Sadece normal satırlarda context menu göster
            if ((info.HitTest == GridHitTest.Row && !info.InGroupRow ) || (info.HitTest ==  GridHitTest.RowCell && !info.InGroupRow) )
            {
                e.SagMenuGoster(sagMenu);
            }
        }





        private void FooterMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var summaryType = (DevExpress.Data.SummaryItemType)((DevExpress.XtraBars.BarButtonItem)e.Item).Tag;
            var column = Tablo.FocusedColumn;

            if (column != null)
            {
                // Mevcut summary'i kaldır
                var existingSummary = Tablo.Columns[column.FieldName].SummaryItem;
                if (existingSummary != null)
                    Tablo.Columns[column.FieldName].Summary.Remove(existingSummary);

                // Yeni summary ekle
                Tablo.Columns[column.FieldName].Summary.Add(summaryType);
            }
        }
        private void Tablo_EndSorting(object sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_ColumnPositionChanged(object sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_FilterEditorCreated(object sender, FilterControlEventArgs e)
        {
            e.ShowFilterEditor = false;
            ShowEditForms<FiltreEditForm>.ShowDialogEditForm(KartTuru.Filtre, _filtreId, BaseKartTuru, Tablo.GridControl);
        }
        private void Tablo_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tablo.ActiveFilterString))
                _filtreId = 0;
        }
        private void Tablo_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (!Tablo.OptionsView.ShowFooter) return;
            // if (e.Column.Summary.Count > 0)
            // e.Appearance.TextOptions.HAlignment = e.Column.ColumnEdit.Appearance.HAlignment;
        }
        protected virtual void DegiskenleriDoldur()
        {

        }

        protected virtual void GridKontrolEt()
        {
            tabloEvents();
        }
        private void FormCaptionAyarla()
        {
 
 
            Listele();
        }
        protected void ShowBaseReportDetailFormDefault(long id)
        {
            if (id <= 0) return;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }
        protected virtual void ShowBaseReportDetailForm(long id)
        {

            //// Yeni bir form oluşturuyoruz
            //BorcAlacakFaturalar childForm = new BorcAlacakFaturalar();
            //// Yeni formun ana formunu belirliyoruz
            //childForm.MdiParent = this.MdiParent;
            //// Yeni formu gösteriyoruz
            //childForm.Show();

            //ShowReportListForms<MuhasebeHesapKoduFarkliOlanlar>.ShowReportListForm2(KartTuru.MuhasebeHesapKoduFarkliOlanlar);

            //var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
            //ShowBaseReportDetailFormDefault(result);


        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridKontrolEt();
          
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
            else if (e.Item == btnEnUygunGenislik)
            {
                Tablo.OptionsView.ColumnAutoWidth = false;
                for (int i = 0; i < Tablo.Columns.Count; i++) Tablo.Columns[i].BestFit();
            }

            else if (e.Item == btnYeni)
            {
                //yetki kontrolü
                // ShowEditForm(-1);
            }
            else if (e.Item == btnDuzelt)
            {



                //ShowEditForm(Tablo.GetRowId());

                ShowBaseReportDetailForm(Tablo.GetRowId());
            }
            else if (e.Item == btnSil)
            {
                //yetki kontrolü
                // EntityDelete();
            }
            else if (e.Item == btnSec)
            {
                MessageBox.Show(SeciliGelecekId.ToString());

                SeciliGidecekId = long.Parse(Tablo.GetFocusedRowCellValue("Id").ToString());
                //SelectEntity();
                MessageBox.Show(Tablo.GetFocusedRowCellValue("Id").ToString());
                BaseReportSubFormsShow(SeciliGidecekId);
            }
            else if (e.Item == btnYenile)
            {
                Listele();
            }
            else if (e.Item == btnFiltrele)
                FiltreSec();
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
        private void FiltreSec()
        {
            var entity = (Filtre)ShowListForms<FiltreListForm>.ShowDialogListForm(KartTuru.Filtre, _filtreId, BaseKartTuru, Tablo.GridControl);
            if (entity == null) return;

            _filtreId = entity.Id;
            Tablo.ActiveFilterString = entity.FiltreMetni;

            try
            {
                // Kolon ayarlarını yükle
                if (!string.IsNullOrEmpty(entity.KolonAyarlari))
                {
                    byte[] layoutBytes = Convert.FromBase64String(entity.KolonAyarlari);
                    using (var ms = new MemoryStream(layoutBytes))
                    {
                        Tablo.RestoreLayoutFromStream(ms);
                    }
                }

                // Kolon gizlilik durumlarını yükle
                if (!string.IsNullOrEmpty(entity.KolonGizlilik))
                {
                    RestoreColumnVisibility(entity.KolonGizlilik);
                }

                // Kolon sıralamasını yükle
                if (!string.IsNullOrEmpty(entity.KolonSiralama))
                {
                    RestoreColumnOrder(entity.KolonSiralama);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapabilirsiniz
            }
        }

        private void RestoreColumnVisibility(string visibilityJson)
        {
            try
            {
                var visibility = JsonConvert.DeserializeObject<Dictionary<string, bool>>(visibilityJson);
                foreach (GridColumn column in Tablo.Columns)
                {
                    if (visibility.ContainsKey(column.FieldName))
                        column.Visible = visibility[column.FieldName];
                }
            }
            catch { }
        }

        private void RestoreColumnOrder(string orderJson)
        {
            try
            {
                var columnOrder = JsonConvert.DeserializeObject<Dictionary<string, int>>(orderJson);
                foreach (GridColumn column in Tablo.Columns)
                {
                    if (columnOrder.ContainsKey(column.FieldName))
                        column.VisibleIndex = columnOrder[column.FieldName];
                }
            }
            catch { }
        }


        protected virtual void BaseReportSubFormsShow(long id)
        {


            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
            BaseReportSubFormsShowDefault(result);


        }

        protected void BaseReportSubFormsShowDefault(long id)
        {
            if (id <= 0) return;
            Tablo.RowFocus("Id", id);

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
            btnEnUygunGenislik.Visibility = BarItemVisibility.Always;



        }
        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            //üç satırı ben yorum yaptım
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
            else if ((Tablo.GetFocusedRowCellValue("Id").ToString()) != null)
            {
                // MessageBox.Show(Tablo.GetFocusedRowCellValue("Id").ToString());

                SeciliGidecekId = long.Parse((Tablo.GetFocusedRowCellValue("Id").ToString()));
            }

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
            //else if (IsMdiChild && RaporMu == true)
            //{
            //    ShowReportListForms<CariBakiyeler>.ShowReportListForm(KartTuru.CariBakiyeler);
            //    MessageBox.Show(Tablo.GetFocusedRowCellValue("Id").ToString());
                
            //    MessageBox.Show("Güncelleme açılacak");
            //}
            else
            {
                
                //btnDuzelt.PerformClick(); //mdi değilse içine giriş double click gibi çalış
            }
        }
        protected virtual void Listele()
        {
            //Tablo.GridControl.DataSource = ((OkulBll)Bll).List(FilterFunctions.Filter<Okul>(AktifKartlariGoster));
        }
 
    
    }

}