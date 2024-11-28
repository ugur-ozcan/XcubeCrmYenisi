using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Drawing;

using DevExpress.XtraGrid;
using System.Data;
using System.Windows.Forms;
using System;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.GenelForms;
using XCubeCrm.UI.Win;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using System.Linq;

namespace XCubeCrm.UI.Win.Forms.Raporlar.njoy
{
    public partial class ZRaporuEski : BaseReportListForm
    {
        private sqlBaglanti bgl = new sqlBaglanti();
        private DataTable mainData;
        private DataTable posData;

        public ZRaporuEski()
        {
            InitializeComponent();
            if (!TarihKontrol()) return;

            CustomizeGrid();  // Grid genel ayarları
            LoadData();       // Verileri yükle
            SetupGrid();      // Grid kolonlarını ay

        }

        private void CustomizeGrid()
        {
            // Mevcut grid ayarlarını koruyup, sadece Z Raporu için gereken değişiklikleri yap
            tablo.OptionsView.ShowGroupPanel = false;  // Gruplama panelini gizle
            tablo.OptionsMenu.EnableColumnMenu = false; // Kolon menüsünü devre dışı bırak
            tablo.OptionsView.ColumnAutoWidth = true; // Otomatik genişlik

            // Event handler'ları temizle ve yeniden ekle
            RemoveExistingEventHandlers();
            tablo.CellValueChanged += Tablo_CellValueChanged;
        }

        private void RemoveExistingEventHandlers()
        {
            // Var olan event handler'ları temizle
            var field = typeof(MyGridView).GetField("EventCellValueChanged",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValue(tablo, null);
            }
        }

        private bool TarihKontrol()
        {
            if (string.IsNullOrEmpty(AnaForm.baslangicTarihi) || string.IsNullOrEmpty(AnaForm.bitisTarihi))
            {
                MessageBox.Show("Lütfen tarih aralığı seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return false;
            }
            return true;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.ZRaporuAl;
        }

        private void LoadData()
        {
            string lokasyonKosulu = AnaForm.secilenLokasyon.Any()
                ? $"AND PG.LOKASYON IN ({string.Join(",", AnaForm.secilenLokasyon)})"
                : "AND PG.LOKASYON IN (SELECT ID FROM LOKASYON WHERE AKTIF=1)";

            string mainQuery = @"WITH TAHSILAT_TIPLERI AS (
            SELECT 'Nakit' AS AD, 1 AS GRUP_SIRA
            UNION
            SELECT BP.AD, 2 AS GRUP_SIRA
            FROM BANKA_POS BP
            JOIN BANKA B ON B.ID = BP.BANKA
            WHERE BP.AKTIF = 1 AND B.AKTIF = 1
            UNION
            SELECT C.AD, 3 AS GRUP_SIRA
            FROM CARI C 
            WHERE C.AKTIF = 1 AND C.TAHSILAT_CARISI = 1
            UNION
            SELECT 'Açık hesap', 4 AS GRUP_SIRA
        ),
        SATIS_TUTARLARI AS (
            SELECT 
                TT.AD,
                TT.GRUP_SIRA,
                COALESCE(DOVIZ_AD.AD, 'TRY') AS DOVIZ_AD,
                COALESCE(SUM(POS_TAHSILAT_W_FIS.TUTAR), 0) AS SATIS_TUTAR,
                COALESCE(SUM(POS_TAHSILAT_W_FIS.TUTAR) * COALESCE(DOVIZ_KUR_SON.SATIS, 1), 0) AS SATIS_TUTAR_TL
            FROM TAHSILAT_TIPLERI TT
            LEFT JOIN POS_TAHSILAT_W_FIS ON TT.AD = POS_TAHSILAT_W_FIS.AD
            LEFT JOIN POS_GECICI  PG ON PG.ID = POS_TAHSILAT_W_FIS.POS_GECICI 
            LEFT JOIN DOVIZ_AD ON POS_TAHSILAT_W_FIS.DOVIZ_AD = DOVIZ_AD.ID
            LEFT JOIN DOVIZ_KUR_SON_V AS DOVIZ_KUR_SON ON DOVIZ_KUR_SON.DOVIZ_AD = POS_TAHSILAT_W_FIS.DOVIZ_AD
            WHERE PG.KAPANDI = 1 " + lokasyonKosulu + @"
            AND PG.TARIH BETWEEN @BaslangicTarihi AND @BitisTarihi
            GROUP BY TT.AD, TT.GRUP_SIRA, DOVIZ_AD.AD, DOVIZ_KUR_SON.SATIS
        ),
        TAHSILAT_DETAY AS (
            SELECT 
                PG.ID AS POS_GECICI,
                FD.FINANS_ISLEM_TURU,
                CASE 
                    WHEN FD.FINANS_ISLEM_TURU = 15 THEN BP.AD
                    WHEN FD.FINANS_ISLEM_TURU = 68 THEN C.AD
                    WHEN FD.FINANS_ISLEM_TURU IN (1,2) THEN 'Nakit'
                    ELSE 'Açık hesap'
                END AS TAHSILAT_ADI,
                FD.TUTAR,
                DV.AD AS DOVIZ_ADI,
                FIT.AD AS FINANS_ISLEM_TURU_ADI,
                COALESCE(DK.SATIS, 1) AS KUR
            FROM POS_GECICI PG
            INNER JOIN FINANS_DETAY FD ON FD.FIS = PG.ID
            LEFT JOIN BANKA_POS BP ON BP.ID = FD.KART_BORCLU AND FD.FINANS_ISLEM_TURU = 15
            LEFT JOIN CARI C ON C.ID = FD.KART_BORCLU AND FD.FINANS_ISLEM_TURU = 68
            LEFT JOIN DOVIZ_AD DV ON DV.ID = FD.DOVIZ_AD
            LEFT JOIN FINANS_ISLEM_TURU FIT ON FIT.ID = FD.FINANS_ISLEM_TURU
            LEFT JOIN DOVIZ_KUR_SON_V DK ON DK.DOVIZ_AD = FD.DOVIZ_AD
            WHERE PG.KAPANDI = 1  " + lokasyonKosulu + @"
            AND PG.TARIH BETWEEN @BaslangicTarihi AND @BitisTarihi
        ),
        NORMAL_ROWS AS (
            SELECT 
                TT.AD AS TAHSILAT_ADI,
                TT.GRUP_SIRA,
                CAST(COALESCE(ST.SATIS_TUTAR_TL, 0) AS DECIMAL(18,2)) AS SATIS_TL,
                CAST(COALESCE(SUM(TD.TUTAR * TD.KUR), 0) AS DECIMAL(18,2)) AS TAHSILAT_TL
            FROM TAHSILAT_TIPLERI TT
            LEFT JOIN SATIS_TUTARLARI ST ON TT.AD = ST.AD
            LEFT JOIN TAHSILAT_DETAY TD ON TT.AD = TD.TAHSILAT_ADI
            GROUP BY 
                TT.AD,
                TT.GRUP_SIRA,
                ST.SATIS_TUTAR_TL
        )
SELECT 
    TAHSILAT_ADI,
    GRUP_SIRA, -- ORDER BY için gerekli
    CAST(SATIS_TL AS DECIMAL(18,2)) AS SATIS_TL,
    CAST(TAHSILAT_TL AS DECIMAL(18,2)) AS TAHSILAT_TL,
    CAST((SATIS_TL + TAHSILAT_TL) AS DECIMAL(18,2)) AS TOPLAM_CIRO,
    CAST(0 AS DECIMAL(18,2)) AS FARK,
    CAST(0 AS DECIMAL(18,2)) AS POS_TOPLAMLARI
FROM NORMAL_ROWS
UNION ALL
SELECT 
    'TOPLAM' AS TAHSILAT_ADI,
    999 AS GRUP_SIRA, -- En sona gelmesi için büyük değer
    SUM(SATIS_TL) AS SATIS_TL,
    SUM(TAHSILAT_TL) AS TAHSILAT_TL,
    SUM(SATIS_TL + TAHSILAT_TL) AS TOPLAM_CIRO,
    0 AS FARK,
    0 AS POS_TOPLAMLARI
FROM NORMAL_ROWS
ORDER BY 
      GRUP_SIRA  ,
    TAHSILAT_ADI";

            string posQuery = @"SELECT ID, AD, MF, AD + '-' + MF AS KOLON_ADI 
                          FROM POS_MOBIL_MF 
                          WHERE TR_LOKASYON IN (SELECT ID FROM LOKASYON WHERE AKTIF=1)";

            try
            {
                using (SqlConnection conn = bgl.baglantiNJOY())
                {
                    conn.Open();

                    // Önce POS verilerini yükle
                    using (SqlCommand cmd = new SqlCommand(posQuery, conn))
                    {
                        posData = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(posData);
                        }
                    }

                    // Ana veriyi yükle
                    using (SqlCommand cmd = new SqlCommand(mainQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Parse(AnaForm.baslangicTarihi));
                        cmd.Parameters.AddWithValue("@BitisTarihi", DateTime.Parse(AnaForm.bitisTarihi));

                        mainData = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(mainData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu:\n{ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGrid()
        {
            // Grid ayarları
            tablo.OptionsView.ShowAutoFilterRow = true;
            tablo.OptionsView.ShowFooter = true;
            tablo.OptionsView.ColumnAutoWidth = false;
            tablo.OptionsView.ShowGroupPanel = false;

            // Önce grid'i temizle
            tablo.Columns.Clear();
            zRaporuGrid.DataSource = null;

            // Ana kolonları ekle
            foreach (DataColumn col in mainData.Columns)
            {
                bool isNumeric = col.DataType == typeof(decimal) ||
                                col.DataType == typeof(double) ||
                                col.DataType == typeof(int);
                var gridCol = AddGridColumn(col.ColumnName, col.ColumnName, 100, isNumeric);
                if (col.ColumnName == "GRUP_SIRA")
                    gridCol.Visible = false;
            }

            // POS kolonlarını ekle
            foreach (DataRow row in posData.Rows)
            {
                string kolonAdi = row["KOLON_ADI"].ToString();
                if (!mainData.Columns.Contains(kolonAdi))
                {
                    // Önce DataTable'a ekle
                    mainData.Columns.Add(kolonAdi, typeof(decimal));
                    // Sonra grid kolonu ekle
                    var col = AddGridColumn(kolonAdi, kolonAdi, 120, true);
                    col.OptionsColumn.AllowEdit = true;
                    col.AppearanceCell.BackColor = Color.LightGreen;
                    col.OptionsColumn.TabStop = true;  // Tab ile gezilebilir
                    col.OptionsColumn.AllowFocus = true;  // Fokuslanabilir
                }
            }

            // Fark kolonunun formatlaması
            StyleFormatCondition farkNegatif = new StyleFormatCondition();
            farkNegatif.Column = tablo.Columns["FARK"];
            farkNegatif.Condition = FormatConditionEnum.Less;
            farkNegatif.Value1 = 0;
            farkNegatif.Appearance.BackColor = Color.Red;
            tablo.FormatConditions.Add(farkNegatif);

            // Navigasyon ayarları
            tablo.OptionsNavigation.UseTabKey = true;  // Tab ile kolonlar arası geçiş

            // Event handler'ları ekle (sadece bir kez)
            tablo.CellValueChanged += Tablo_CellValueChanged;
            tablo.KeyDown += Tablo_KeyDown;

            // En son veriyi bağla
            zRaporuGrid.DataSource = mainData;
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                // Mevcut kolon indeksini al
                int currentColumnIndex = view.FocusedColumn.VisibleIndex;
                int currentRowHandle = view.FocusedRowHandle;

                // Bir sonraki satıra geç
                int nextRowHandle = currentRowHandle + 1;
                if (nextRowHandle < view.DataRowCount)
                {
                    view.FocusedRowHandle = nextRowHandle;

                    // Aynı kolona odaklan
                    if (currentColumnIndex >= 0 && currentColumnIndex < view.VisibleColumns.Count)
                    {
                        view.FocusedColumn = view.VisibleColumns[currentColumnIndex];

                        // Eğer düzenlenebilir bir kolondaysa edit moduna al
                        if (view.FocusedColumn.OptionsColumn.AllowEdit)
                        {
                            view.ShowEditor();
                        }
                    }
                }
            }

            else if (e.KeyCode == Keys.Tab)
            {
                if (view.FocusedColumn.OptionsColumn.AllowEdit)
                {
                    e.Handled = true;

                    // Sonraki düzenlenebilir kolona geç
                    var editableColumns = view.VisibleColumns
                        .Cast<GridColumn>()
                        .Where(c => c.OptionsColumn.AllowEdit)
                        .ToList();

                    var currentIndex = editableColumns.IndexOf(view.FocusedColumn);
                    if (currentIndex >= 0 && currentIndex < editableColumns.Count - 1)
                    {
                        view.FocusedColumn = editableColumns[currentIndex + 1];
                        view.ShowEditor();
                    }
                }
            }
        }

        private void Tablo_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                var view = sender as GridView;
                if (view == null) return;

                // Eğer son kolondaysak
                if (view.FocusedColumn == view.Columns[view.Columns.Count - 1])
                {
                    // İlk POS kolonunu bul
                    var posColumns = view.Columns
                        .Cast<GridColumn>()
                        .Where(c => posData.Rows.Cast<DataRow>()
                            .Any(r => r["KOLON_ADI"].ToString() == c.FieldName))
                        .ToList();

                    if (posColumns.Any())
                    {
                        var firstPosColumn = posColumns.First();
                        // Bir sonraki satıra geç ve ilk POS kolonuna odaklan
                        BeginInvoke(new Action(() =>
                        {
                            view.Focus();
                            view.MoveNext();
                            view.FocusedColumn = firstPosColumn;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private GridColumn AddGridColumn(string fieldName, string caption, int width, bool numeric = false)
        {
            GridColumn col = new GridColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Width = width;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;

            if (numeric)
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "n2";
            }

            tablo.Columns.Add(col);
            return col;
        }

        private void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                // Eğer değişen hücre bir POS kolonuysa
                if (posData.Rows.Cast<DataRow>().Any(r => r["KOLON_ADI"].ToString() == e.Column.FieldName))
                {
                    decimal posTotal = 0;

                    // POS kolonlarının toplamını hesapla
                    foreach (DataRow posRow in posData.Rows)
                    {
                        string kolonAdi = posRow["KOLON_ADI"].ToString();
                        var value = tablo.GetRowCellValue(e.RowHandle, kolonAdi);
                        if (value != null && decimal.TryParse(value.ToString(), out decimal amount))
                        {
                            posTotal += amount;
                        }
                    }

                    // DataTable'ı güncelle
                    DataRow dataRow = ((DataRowView)tablo.GetRow(e.RowHandle)).Row;
                    dataRow[e.Column.FieldName] = e.Value;

                    // POS toplamını güncelle
                    tablo.SetRowCellValue(e.RowHandle, "POS_TOPLAMLARI", posTotal);
                    dataRow["POS_TOPLAMLARI"] = posTotal;

                    // Farkı hesapla
                    decimal toplamCiro = Convert.ToDecimal(tablo.GetRowCellValue(e.RowHandle, "TOPLAM_CIRO"));
                    decimal fark = posTotal - toplamCiro;
                    tablo.SetRowCellValue(e.RowHandle, "FARK", fark);
                    dataRow["FARK"] = fark;

                    // Grid'i yenile
                    tablo.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesaplama sırasında hata oluştu:\n{ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}