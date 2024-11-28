using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using XCubeCrm.Bll.General;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System.IO;

namespace XCubeCrm.UI.Win.Forms.FiltreForms
{
    public partial class FiltreEditForm : BaseEditForm
    {
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;


        public FiltreEditForm(params object[] prm)
        {
            InitializeComponent();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnYeni, btnGeriAl };
            ShowItems = new BarItem[] { btnFarkliKaydet, btnUygula };
            DataLayoutControl = myDataLayoutControl;
            Bll = new FiltreBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Filtre;

            EventsLoad();
        }

        public  override void Yukle()
        {
            txtFiltreMetni.SourceControl = _filtreGrid;
            while (true)
            {
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                {
                    OldEntity = new Filtre();
                    Id = BaseIslemTuru.IdOlustur(OldEntity);
                    txtKod.Text = ((FiltreBll)Bll).YeniKodVer(x => x.KartTuru == _filtreKartTuru);
                }
                else
                {
                    OldEntity = ((FiltreBll)Bll).Single(FilterFunctions.Filtre<Filtre>(Id));
                    if (OldEntity == null)
                    {
                        BaseIslemTuru = IslemTuru.EntityInsert;
                        continue;
                    }
                    NesneyiKontrollereBagla();
                }
                break;
            }
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Filtre)OldEntity;

            txtKod.Text = entity.Kod;
            txtFiltreAdi.Text = entity.FiltreAdi;
            txtFiltreMetni.FilterString = entity.FiltreMetni;
        }
        protected override void GuncelNesneOlustur()
        {
            GridView view = _filtreGrid.MainView as GridView;
            var kolonAyarlari = "";
            var kolonGizlilik = "";
            var kolonSiralama = "";

            if (view != null)
            {
                using (var ms = new MemoryStream())
                {
                    view.SaveLayoutToStream(ms);
                    kolonAyarlari = Convert.ToBase64String(ms.ToArray());
                }
                kolonGizlilik = SaveColumnVisibility(view);
                kolonSiralama = SaveColumnOrder(view);
            }

            CurrentEntity = new Filtre
            {
                Id = Id,
                Kod = txtKod.Text,
                FiltreAdi = txtFiltreAdi.Text,
                FiltreMetni = txtFiltreMetni.FilterString,
                KartTuru = _filtreKartTuru,
                KolonAyarlari = kolonAyarlari,
                KolonGizlilik = kolonGizlilik,
                KolonSiralama = kolonSiralama
            };

            ButonEnabledDurumu();
        }
        private string SaveColumnVisibility(GridView view)
        {
            var visibility = new Dictionary<string, bool>();
            foreach (GridColumn column in view.Columns)
            {
                visibility[column.FieldName] = column.Visible;
            }
            return JsonConvert.SerializeObject(visibility);
        }

        private string SaveColumnOrder(GridView view)
        {
            var order = new Dictionary<string, int>();
            foreach (GridColumn column in view.Columns)
            {
                order[column.FieldName] = column.VisibleIndex;
            }
            return JsonConvert.SerializeObject(order);
        }

        protected override bool EntityInsert()
        {
            return ((FiltreBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KartTuru == _filtreKartTuru);
        }
        protected override bool EntityUpdate()
        {
            return ((FiltreBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KartTuru == _filtreKartTuru);
        }
        protected override void FiltreUygula()
        {
            txtFiltreMetni.Select();
            txtFiltreMetni.ApplyFilter();
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnKaydet, btnFarkliKaydet, btnSil, BaseIslemTuru, OldEntity, CurrentEntity);
        }
    }
}