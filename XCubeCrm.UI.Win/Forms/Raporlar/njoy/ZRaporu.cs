using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;

namespace XCubeCrm.UI.Win.Forms.Raporlar.njoy
{
    public partial class ZRaporu : BaseReportListForm
    {
        private readonly sqlBaglanti bgl = new sqlBaglanti();
        private const string BaseQuery = @"
WITH TAHSILAT_TIPLERI AS (
    SELECT 'NAKİT' AS AD, 1 AS SIRA
    UNION ALL
    SELECT DISTINCT(BN.AD), 2 AS SIRA
    FROM BANKA BN 
    INNER JOIN BANKA_POS BP ON BP.BANKA = BN.ID AND BP.AKTIF = 1
    WHERE BN.AKTIF = 1
    UNION ALL
    SELECT C.AD, 3 AS SIRA
    FROM CARI C
    WHERE C.AKTIF = 1 AND C.TAHSILAT_CARISI = 1
),
FisTahsilat AS (
    SELECT 
        CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN 'NAKİT' 
            WHEN FD.FINANS_ISLEM_TURU IN (15,55) THEN COALESCE(BN.AD,'') 
            WHEN FD.FINANS_ISLEM_TURU IN (79) THEN 'PUAN'
            WHEN FD.FINANS_ISLEM_TURU IN (68) THEN TC.AD
            ELSE '' 
        END AS TAHSIL_SEKLI,
        SUM(FD.TUTAR * CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (2,3,55) THEN -1 
            WHEN FD.FINANS_ISLEM_TURU=68 AND T.IADE=1 THEN -1 
            ELSE 1 
        END) AS FIS_TAHSILAT,
        0 AS FIS_DISI_TAHSILAT
    FROM FIS_POS P 
    INNER JOIN FIS F ON F.ID=P.FIS  
    INNER JOIN FIS_TURU T ON T.ID=F.FIS_TURU
    INNER JOIN FINANS_DETAY FD ON P.FIS= FD.FIS
    INNER JOIN DOVIZ_AD DV ON FD.DOVIZ_AD = DV.ID
    LEFT JOIN BANKA_POS BP ON (BP.ID=FD.KART_BORCLU OR BP.ID=FD.KART_ALACAKLI) AND FD.FINANS_ISLEM_TURU IN (15,55)
    LEFT JOIN BANKA BN ON BN.ID=BP.BANKA
    LEFT JOIN CARI TC ON (TC.ID=FD.KART_BORCLU OR TC.ID=FD.KART_ALACAKLI) AND FD.FINANS_ISLEM_TURU=68 AND TC.TAHSILAT_CARISI=1
    WHERE FD.FINANS_ISLEM_TURU NOT IN (53,54,100,104,62,63) 
    AND F.LOKASYON IN ({0})
    AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
    GROUP BY 
        CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN 'NAKİT' 
            WHEN FD.FINANS_ISLEM_TURU IN (15,55) THEN COALESCE(BN.AD,'')  
            WHEN FD.FINANS_ISLEM_TURU IN (79) THEN 'PUAN'
            WHEN FD.FINANS_ISLEM_TURU IN (68) THEN TC.AD
            ELSE '' 
        END
),
FisDisiTahsilat AS (
    SELECT 
        CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN 'NAKİT' 
            WHEN FD.FINANS_ISLEM_TURU IN (15,55) THEN COALESCE(BN.AD,'') 
            WHEN FD.FINANS_ISLEM_TURU IN (79) THEN 'PUAN'
            WHEN FD.FINANS_ISLEM_TURU IN (68) THEN TC.AD
            ELSE '' 
        END AS TAHSIL_SEKLI,
        0 AS FIS_TAHSILAT,
        SUM(FD.TUTAR * CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (2,3,55) THEN -1 
            WHEN FD.FINANS_ISLEM_TURU=68 THEN 1 
            ELSE 1 
        END) AS FIS_DISI_TAHSILAT
    FROM FIS_POS P 
    INNER JOIN FINANS_DETAY FD ON P.FIS= FD.FIS
    INNER JOIN FINANS F ON F.ID = FD.FINANS
    INNER JOIN DOVIZ_AD DV ON FD.DOVIZ_AD = DV.ID
    LEFT JOIN BANKA_POS BP ON (BP.ID=FD.KART_BORCLU OR BP.ID=FD.KART_ALACAKLI) AND FD.FINANS_ISLEM_TURU IN (15,55)
    LEFT JOIN BANKA BN ON BN.ID=BP.BANKA
    LEFT JOIN CARI TC ON (TC.ID=FD.KART_BORCLU OR TC.ID=FD.KART_ALACAKLI) AND FD.FINANS_ISLEM_TURU=68 AND TC.TAHSILAT_CARISI=1
    WHERE FD.FINANS_ISLEM_TURU NOT IN (53,54,100,104,62,63) 
    AND F.LOKASYON IN ({0})
    AND P.KAPANIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
    AND P.POS_SIPARIS_TIPI = 4
    GROUP BY 
        CASE 
            WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN 'NAKİT' 
            WHEN FD.FINANS_ISLEM_TURU IN (15,55) THEN COALESCE(BN.AD,'')  
            WHEN FD.FINANS_ISLEM_TURU IN (79) THEN 'PUAN'
            WHEN FD.FINANS_ISLEM_TURU IN (68) THEN TC.AD
            ELSE '' 
        END
),
TumTahsilatlar AS (
    SELECT 
        t.AD as TAHSIL_SEKLI,
        t.SIRA,
        COALESCE(f.FIS_TAHSILAT, 0) as FIS_TAHSILAT,
        COALESCE(fd.FIS_DISI_TAHSILAT, 0) as FIS_DISI_TAHSILAT,
        COALESCE(f.FIS_TAHSILAT, 0) + COALESCE(fd.FIS_DISI_TAHSILAT, 0) as TOPLAM,
        0 as POS1, 0 as POS2, 0 as POS3, 0 as POS4, 0 as POS5,
        0 as POS6, 0 as POS7, 0 as POS8, 0 as POS9, 0 as POS10
    FROM TAHSILAT_TIPLERI t
    LEFT JOIN FisTahsilat f ON t.AD = f.TAHSIL_SEKLI
    LEFT JOIN FisDisiTahsilat fd ON t.AD = fd.TAHSIL_SEKLI
    
    UNION ALL
    
    SELECT 
        'AÇIK HESAP' as TAHSIL_SEKLI,
        4 as SIRA,
        SUM(IIF(T.IADE=1,-1,1)*F.GENELTOPLAM-COALESCE(TH.TAHSILAT,0)) as FIS_TAHSILAT,
        0 as FIS_DISI_TAHSILAT,
        SUM(IIF(T.IADE=1,-1,1)*F.GENELTOPLAM-COALESCE(TH.TAHSILAT,0)) as TOPLAM,
        0,0,0,0,0,0,0,0,0,0
    FROM FIS_POS P
    JOIN FIS F ON F.ID=P.FIS
    JOIN FIS_TURU T ON T.ID=F.FIS_TURU
    JOIN DOVIZ_AD DV ON DV.ID=F.DOVIZ_AD
    JOIN CARI C ON C.ID=F.CARI
    LEFT JOIN (
        SELECT 
            T.FIS,
            T.GENELTOPLAM,
            (SUM(T.NAKIT+T.KREDIKARTI+T.CARI_TAHSILAT+T.PUAN))*IIF(T.IADE=1,-1,1) TAHSILAT
        FROM (
            SELECT 
                D.FIS,
                F.GENELTOPLAM,
                FT.IADE,
                CASE WHEN D.FINANS_ISLEM_TURU IN (1,2) THEN D.TUTAR*IIF(D.FINANS_ISLEM_TURU=2,-1,1) ELSE 0 END NAKIT,
                CASE WHEN D.FINANS_ISLEM_TURU IN (15,55) AND D.KART_ALACAKLI>0 THEN D.TUTAR*IIF(D.FINANS_ISLEM_TURU=55,-1,1) ELSE 0 END KREDIKARTI,
                CASE WHEN D.FINANS_ISLEM_TURU IN (68) THEN D.TUTAR*IIF(FT.IADE=1,-1,1) ELSE 0 END CARI_TAHSILAT,
                CASE WHEN D.FINANS_ISLEM_TURU IN (79) THEN D.TUTAR ELSE 0 END PUAN
            FROM FINANS_DETAY D
            JOIN FINANS_ISLEM_TURU T ON T.ID=D.FINANS_ISLEM_TURU
            JOIN FIS F ON F.ID=D.FIS
            JOIN FIS_TURU FT ON FT.ID=F.FIS_TURU
            WHERE D.FINANS_ISLEM_TURU NOT IN (53,54,100,104)
        ) AS T
        GROUP BY T.FIS,T.GENELTOPLAM,T.IADE
    ) AS TH ON TH.FIS=P.FIS
    WHERE F.GENELTOPLAM>COALESCE(TH.TAHSILAT,0)
    GROUP BY DV.AD
)
SELECT 
    ROW_NUMBER() OVER (ORDER BY t.SIRA, t.TAHSIL_SEKLI) as ID,
    t.TAHSIL_SEKLI,
    t.FIS_TAHSILAT,
    t.FIS_DISI_TAHSILAT,
    t.TOPLAM,
    t.POS1, t.POS2, t.POS3, t.POS4, t.POS5,
    t.POS6, t.POS7, t.POS8, t.POS9, t.POS10,
    t.TOPLAM - (t.POS1 + t.POS2 + t.POS3 + t.POS4 + t.POS5 + 
                t.POS6 + t.POS7 + t.POS8 + t.POS9 + t.POS10) as FARK
FROM TumTahsilatlar t
ORDER BY t.SIRA, t.TAHSIL_SEKLI";
        public ZRaporu()
        {
            InitializeComponent();

            // Tarih kontrolü - zorunlu alan
            if (string.IsNullOrEmpty(AnaForm.baslangicTarihi) || string.IsNullOrEmpty(AnaForm.bitisTarihi))
            {
                MessageBox.Show("Lütfen tarih aralığı seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
        }



        protected override void Listele()
        {
            // Tarih kontrolü
            if (string.IsNullOrEmpty(AnaForm.baslangicTarihi) || string.IsNullOrEmpty(AnaForm.bitisTarihi))
            {
                MessageBox.Show("Lütfen tarih aralığı seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lokasyon filtresi oluştur
                string lokasyonFilter = AnaForm.secilenLokasyon.Any()
                    ? string.Join(",", AnaForm.secilenLokasyon)
                    : "(SELECT ID FROM LOKASYON WHERE AKTIF = 1)";

                // 1. Grid için Z Raporu verilerini yükle
                LoadZRaporuData(lokasyonFilter);

                // 2. Grid için diğer raporları yükle
                 LoadSecondaryReports(lokasyonFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadZRaporuData(string lokasyonFilter)
        {
            string query = string.Format(BaseQuery, lokasyonFilter);
            using (var conn = bgl.baglantiNJOY())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Parse(AnaForm.baslangicTarihi));
                cmd.Parameters.AddWithValue("@BitisTarihi", DateTime.Parse(AnaForm.bitisTarihi));
                cmd.CommandTimeout = 0;

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                grid.DataSource = dt;
                ConfigureGridView();
            }
        }

     
        private void LoadSecondaryReports(string lokasyonFilter)
        {
            using (var conn = bgl.baglantiNJOY())
            {
                conn.Open();
                var finalTable = new DataTable();

                // Kolonları oluştur
                foreach (char c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                {
                    finalTable.Columns.Add(c.ToString(), typeof(string));
                }

                try
                {
                    // 1. Paket Sayıları
                    var paketData = GetQueryData(conn, GetPaketQuery(lokasyonFilter));
                    AddReportSection(finalTable, "PAKET SAYILARI", paketData);

                    // 2. Kesilecek Faturalar
                    var faturaData = GetQueryData(conn, GetKesilecekFaturalarQuery(lokasyonFilter));
                    AddReportSection(finalTable, "KESİLECEK FATURALAR", faturaData);

                    // 3. Bugün Yapılan Tahsilatlar
                    var tahsilatData = GetQueryData(conn, GetBugunYapilanTahsilatlarQuery(lokasyonFilter));
                    AddReportSection(finalTable, "BUGÜN YAPILAN TAHSİLATLAR", tahsilatData);

                    // 4. Entegrasyon Firma Komisyonları
                    var komisyonData = GetQueryData(conn, GetEntegrasyonKomisyonlariQuery(lokasyonFilter));
                    AddReportSection(finalTable, "ENTEGRASYON FİRMA KOMİSYONLARI", komisyonData);

                    grid2.DataSource = finalTable;
                    ConfigureSecondaryGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private DataTable GetQueryData(SqlConnection conn, string query)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Parse(AnaForm.baslangicTarihi));
                cmd.Parameters.AddWithValue("@BitisTarihi", DateTime.Parse(AnaForm.bitisTarihi));
                cmd.CommandTimeout = 0;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }


        private void AddReportSection(DataTable finalTable, string title, DataTable sourceData)
        {
            // Başlık satırı
            var headerRow = finalTable.NewRow();
            headerRow["A"] = title;
            finalTable.Rows.Add(headerRow);

            // Kolon başlıkları
            if (sourceData.Columns.Count > 0)
            {
                var columnRow = finalTable.NewRow();
                for (int i = 0; i < sourceData.Columns.Count && i < 26; i++)
                {
                    columnRow[i] = sourceData.Columns[i].ColumnName;
                }
                finalTable.Rows.Add(columnRow);

                // Veri satırları
                foreach (DataRow sourceRow in sourceData.Rows)
                {
                    var dataRow = finalTable.NewRow();
                    for (int i = 0; i < sourceData.Columns.Count && i < 26; i++)
                    {
                        if (sourceRow[i] != DBNull.Value)
                        {
                            if (IsNumericType(sourceData.Columns[i].DataType))
                            {
                                dataRow[i] = Convert.ToDecimal(sourceRow[i]).ToString("N2");
                            }
                            else
                            {
                                dataRow[i] = sourceRow[i].ToString();
                            }
                        }
                        else
                        {
                            dataRow[i] = "0,00";
                        }
                    }
                    finalTable.Rows.Add(dataRow);
                }

                // Toplam satırı
                if (HasNumericColumns(sourceData))
                {
                    var totalRow = finalTable.NewRow();
                    totalRow["A"] = "TOPLAM";
                    for (int i = 1; i < sourceData.Columns.Count && i < 26; i++)
                    {
                        if (IsNumericType(sourceData.Columns[i].DataType))
                        {
                            var sum = sourceData.Compute($"SUM([{sourceData.Columns[i].ColumnName}])", "");
                            totalRow[i] = sum != DBNull.Value ? Convert.ToDecimal(sum).ToString("N2") : "0,00";
                        }
                    }
                    finalTable.Rows.Add(totalRow);
                }
            }

            // Boş ayırıcı satır
            finalTable.Rows.Add(finalTable.NewRow());
        }
        private DataTable ExecuteQuery(SqlConnection conn, string query)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Parse(AnaForm.baslangicTarihi));
                cmd.Parameters.AddWithValue("@BitisTarihi", DateTime.Parse(AnaForm.bitisTarihi));
                cmd.CommandTimeout = 0;

                var dt = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        private void AddReportToTable(DataTable mergedTable, DataTable sourceTable, string reportTitle)
        {
            // Başlık satırı ekle
            var headerRow = mergedTable.NewRow();
            headerRow["A"] = reportTitle;
            mergedTable.Rows.Add(headerRow);

            // Kolon başlıklarını ekle
            var columnRow = mergedTable.NewRow();
            for (int i = 0; i < sourceTable.Columns.Count && i < 26; i++)
            {
                columnRow[i] = sourceTable.Columns[i].ColumnName;
            }
            mergedTable.Rows.Add(columnRow);

            // Verileri ekle
            foreach (DataRow sourceRow in sourceTable.Rows)
            {
                var newRow = mergedTable.NewRow();
                for (int i = 0; i < sourceTable.Columns.Count && i < 26; i++)
                {
                    // Sayısal değerleri formatlı şekilde ekle
                    if (sourceRow[i] != DBNull.Value && IsNumericType(sourceTable.Columns[i].DataType))
                    {
                        decimal value = Convert.ToDecimal(sourceRow[i]);
                        newRow[i] = value.ToString("N2");
                    }
                    else
                    {
                        newRow[i] = sourceRow[i].ToString();
                    }
                }
                mergedTable.Rows.Add(newRow);
            }

            // Toplam satırı ekle
            if (HasNumericColumns(sourceTable))
            {
                var totalRow = mergedTable.NewRow();
                totalRow["A"] = "TOPLAM";
                for (int i = 1; i < sourceTable.Columns.Count && i < 26; i++)
                {
                    if (IsNumericType(sourceTable.Columns[i].DataType))
                    {
                        object sum = sourceTable.Compute($"SUM([{sourceTable.Columns[i].ColumnName}])", "");
                        if (sum != DBNull.Value)
                        {
                            totalRow[i] = Convert.ToDecimal(sum).ToString("N2");
                        }
                    }
                }
                mergedTable.Rows.Add(totalRow);
            }
        }

        private void AddEmptyRow(DataTable table)
        {
            table.Rows.Add(table.NewRow());
        }

        private bool HasNumericColumns(DataTable table)
        {
            return table.Columns.Cast<DataColumn>().Any(col => IsNumericType(col.DataType));
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(decimal) || type == typeof(double) ||
                   type == typeof(float) || type == typeof(int) ||
                   type == typeof(long) || type == typeof(short);
        }


        private string GetPaketQuery(string lokasyonFilter)
        {
            return $@"
    SELECT 
        TIP = CASE 
            WHEN F.ACIKLAMA LIKE '%PAKET GEL-AL%' THEN 'Bekliyor Paketimiz' 
            WHEN F.ACIKLAMA LIKE '%PAKET SERVİS%' THEN 'Dışarı Paketimiz' 
            ELSE 'Diğer' 
        END,
        SAYI = COUNT(*),
        TUTAR = SUM(F.GENELTOPLAM)
    FROM FIS F
    WHERE F.ACIKLAMA LIKE '%PAKET%' 
    AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
    AND F.LOKASYON IN ({lokasyonFilter})
    GROUP BY 
        CASE 
            WHEN F.ACIKLAMA LIKE '%PAKET GEL-AL%' THEN 'Bekliyor Paketimiz' 
            WHEN F.ACIKLAMA LIKE '%PAKET SERVİS%' THEN 'Dışarı Paketimiz' 
            ELSE 'Diğer' 
        END";
        }

        private string GetKesilecekFaturalarQuery(string lokasyonFilter)
        {
            return $@"
    SELECT 
        CARI_KOD = CR.KOD,
        CARI_AD = CR.AD,
        ACIKLAMA = F.ACIKLAMA,
        NAKIT = SUM(CASE WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN FD.TUTAR ELSE 0 END),
        [GARANTİ BANKASI A.Ş.] = SUM(CASE WHEN FD.FINANS_ISLEM_TURU IN (15,55) AND BN.AD = 'GARANTİ BANKASI A.Ş.' THEN FD.TUTAR ELSE 0 END)
    FROM FIS F
    INNER JOIN CARI CR ON CR.ID = F.CARI
    LEFT JOIN FINANS_DETAY FD ON FD.FIS = F.ID
    LEFT JOIN BANKA_POS BP ON BP.ID = FD.KART_BORCLU
    LEFT JOIN BANKA BN ON BN.ID = BP.BANKA
    WHERE F.ACIKLAMA LIKE '%FATURA KESİLECEK%'
    AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
    AND F.LOKASYON IN ({lokasyonFilter})
    GROUP BY CR.KOD, CR.AD, F.ACIKLAMA";
        }
        private string GetBugunYapilanTahsilatlarQuery(string lokasyonFilter)
        {
            return $@"
    WITH TahsilatData AS (
        SELECT 
             C.KOD,
            C.AD,
            CASE 
                WHEN FD.FINANS_ISLEM_TURU IN (1,2,3) THEN 'NAKİT'
                WHEN FD.FINANS_ISLEM_TURU IN (15,55) AND BP.ID IS NOT NULL THEN BN.AD
                WHEN FD.FINANS_ISLEM_TURU = 79 THEN 'PUAN'
                WHEN FD.FINANS_ISLEM_TURU = 68 AND TC.ID IS NOT NULL THEN TC.AD
                ELSE 'DİĞER'
            END AS ODEME_TIPI,
            ABS(FD.TUTAR * 
                CASE 
                    WHEN FD.FINANS_ISLEM_TURU IN (2,3,55) THEN -1 
                    ELSE 1 
                END) AS TUTAR
        FROM FINANS_DETAY FD
        INNER JOIN CARI C ON C.ID = FD.KART_ALACAKLI
        LEFT JOIN BANKA_POS BP ON (BP.ID = FD.KART_BORCLU OR BP.ID = FD.KART_ALACAKLI) 
            AND FD.FINANS_ISLEM_TURU IN (15,55)
        LEFT JOIN BANKA BN ON BN.ID = BP.BANKA
        LEFT JOIN CARI TC ON (TC.ID = FD.KART_BORCLU OR TC.ID = FD.KART_ALACAKLI) 
            AND TC.TAHSILAT_CARISI = 1 AND FD.FINANS_ISLEM_TURU = 68
        WHERE FD.FINANS_ISLEM_TURU NOT IN (53,54,100,104,62,63)
        AND FD.FIS IN (
            SELECT F.ID 
            FROM FIS F 
            WHERE F.LOKASYON IN ({lokasyonFilter})
            AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
        )
    ),
    OzetTahsilat AS (
        SELECT 
             KOD,
            AD,
            ODEME_TIPI,
            SUM(TUTAR) as TOPLAM_TUTAR
        FROM TahsilatData
        GROUP BY  KOD, AD, ODEME_TIPI
    )
    SELECT *
    FROM (
        SELECT 
             KOD,
            AD,
            ODEME_TIPI,
            TOPLAM_TUTAR
        FROM OzetTahsilat
    ) AS SourceTable
    PIVOT (
        SUM(TOPLAM_TUTAR)
        FOR ODEME_TIPI IN (
            [NAKİT],
            [GARANTİ BANKASI A.Ş.],
            [TÜRKİYE EKONOMİ BANKASI A.Ş.],
            [TÜRKİYE İŞ BANKASI A.Ş.],
            [VAKIFLAR BANKASI A.Ş.],
            [MULTINET],
            [SODEKSO-PLUXEE],
            [TICKET],
            [PUAN]
        )
    ) AS PivotTable
    ORDER BY KOD";
        }
        private string GetEntegrasyonKomisyonlariQuery(string lokasyonFilter)
        {
            return @"
            WITH TumSonuclar AS(
        --Önce tüm aktif carileri ve tahsilatları birleştirelim
        SELECT
            t.AD as TAHSIL_SEKLI,
            COALESCE(f.FIS_TAHSILAT, 0) as FIS_TAHSILAT,
            COALESCE(fd.FIS_DISI_TAHSILAT, 0) as FIS_DISI_TAHSILAT,
            COALESCE(f.FIS_TAHSILAT, 0) + COALESCE(fd.FIS_DISI_TAHSILAT, 0) as TOPLAM,
            t.VADE_FARKI as KOMISYON_ORANI,
            (COALESCE(f.FIS_TAHSILAT, 0) + COALESCE(fd.FIS_DISI_TAHSILAT, 0)) * t.VADE_FARKI / 100 as KOMISYON_TUTARI,
            1 as SIRALAMA
        FROM(
            SELECT C.AD, C.VADE_FARKI
            FROM CARI C
            WHERE C.AKTIF = 1
            AND C.TAHSILAT_CARISI = 1
            ) t
        LEFT JOIN(
            --Fiş tahsilatları
            SELECT TC.AD,
                SUM(FD.TUTAR * CASE WHEN T.IADE = 1 THEN - 1 ELSE 1 END) AS FIS_TAHSILAT
            FROM FINANS_DETAY FD
            JOIN FIS F ON F.ID = FD.FIS
            JOIN FIS_TURU T ON T.ID = F.FIS_TURU
            JOIN CARI TC ON TC.ID = FD.KART_BORCLU AND TC.TAHSILAT_CARISI = 1
            WHERE FD.FINANS_ISLEM_TURU = 68
            AND F.LOKASYON IN(" + lokasyonFilter + @")
            AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
            GROUP BY TC.AD
        ) f ON t.AD = f.AD
        LEFT JOIN(
            --Fiş dışı tahsilatlar
            SELECT TC.AD,
                SUM(FD.TUTAR) AS FIS_DISI_TAHSILAT
            FROM FINANS_DETAY FD
            JOIN FINANS F ON F.ID = FD.FINANS
            JOIN CARI TC ON TC.ID = FD.KART_BORCLU AND TC.TAHSILAT_CARISI = 1
            WHERE FD.FINANS_ISLEM_TURU = 68
            AND F.LOKASYON IN(" + lokasyonFilter + @")
            AND F.TARIH BETWEEN @BaslangicTarihi AND @BitisTarihi
            GROUP BY TC.AD
        ) fd ON t.AD = fd.AD
    )
            SELECT
         TAHSIL_SEKLI,
        FIS_TAHSILAT,
        FIS_DISI_TAHSILAT,
        TOPLAM,
        KOMISYON_ORANI,
        KOMISYON_TUTARI
            FROM TumSonuclar
            ORDER BY SIRALAMA, TAHSIL_SEKLI";
        }

        private void ExecuteAndAddToDataSet(SqlConnection conn, string query, string tableName, DataSet dataSet)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Parse(AnaForm.baslangicTarihi));
                cmd.Parameters.AddWithValue("@BitisTarihi", DateTime.Parse(AnaForm.bitisTarihi));
                cmd.CommandTimeout = 0;

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable(tableName);
                adapter.Fill(dt);
                dataSet.Tables.Add(dt);
            }
        }

        private DataTable MergeDataTables(DataTableCollection tables)
        {
            var mergedTable = new DataTable();

            // Alfabetik kolonları oluştur
            int maxColumns = tables.Cast<DataTable>().Max(t => t.Columns.Count);
            for (int i = 0; i < maxColumns; i++)
            {
                mergedTable.Columns.Add(((char)('A' + i)).ToString());
            }

            // Her rapor için verileri ekle
            foreach (DataTable table in tables)
            {
                // Rapor başlığı satırı
                var headerRow = mergedTable.NewRow();
                headerRow[0] = table.TableName;
                mergedTable.Rows.Add(headerRow);

                // Kolon başlıkları satırı
                var columnRow = mergedTable.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    columnRow[i] = table.Columns[i].ColumnName;
                }
                mergedTable.Rows.Add(columnRow);

                // Veri satırları
                foreach (DataRow sourceRow in table.Rows)
                {
                    var newRow = mergedTable.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        newRow[i] = sourceRow[i];
                    }
                    mergedTable.Rows.Add(newRow);
                }

                // Toplam satırı ekle (sayısal kolonlar için)
                var totalRow = mergedTable.NewRow();
                totalRow[0] = "TOPLAM";
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    if (IsNumericType(table.Columns[i].DataType))
                    {
                        totalRow[i] = table.Compute($"SUM([{table.Columns[i].ColumnName}])", "");
                    }
                }
                mergedTable.Rows.Add(totalRow);

                // Boş ayırıcı satır ekle
                mergedTable.Rows.Add(mergedTable.NewRow());
            }

            return mergedTable;
        }

        private void ConfigureSecondaryGridView()
        {
            var view = tablo2;
            if (view == null) return;

            // Temel grid ayarları
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ShowFooter = false;
            view.OptionsView.ShowColumnHeaders = true;

            // Tüm kolonlar için format ayarları
            foreach (GridColumn column in view.Columns)
            {
                // Kolon başlıkları için alfabetik etiketler (A, B, C, ...)
                column.Caption = column.FieldName;

                // Sayısal değerler için format
                if (IsNumericType(column.ColumnType))
                {
                    column.DisplayFormat.FormatType = FormatType.Numeric;
                    column.DisplayFormat.FormatString = "n2";
                }

                // Hizalama ayarları
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                column.OptionsColumn.AllowEdit = false;
            }

            // Özel satır stilleri için event
            view.RowStyle += (s, e) => {
                var gridView = s as GridView;
                var value = gridView?.GetRowCellValue(e.RowHandle, "A")?.ToString();

                if (value == null)
                {
                    // Boş ayırıcı satırlar
                    e.Appearance.BackColor = Color.White;
                }
                else if (value.Contains("RAPOR") || value == "PAKET SAYILARI" ||
                        value == "KESİLECEK FATURALAR" || value == "BUGÜN YAPILAN TAHSİLATLAR" ||
                        value == "ENTEGRASYON FİRMA KOMİSYONLARI")
                {
                    // Rapor başlıkları
                    e.Appearance.BackColor = Color.LightSteelBlue;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else if (value == "TOPLAM")
                {
                    // Toplam satırları
                    e.Appearance.BackColor = Color.LightYellow;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else if (IsHeaderRow(gridView, e.RowHandle))
                {
                    // Kolon başlık satırları
                    e.Appearance.BackColor = Color.LightGray;
                }
            };

            // Kolon genişliklerini otomatik ayarla
            view.BestFitColumns();
        }

        private bool IsHeaderRow(GridView view, int rowHandle)
        {
            var currentValue = view.GetRowCellValue(rowHandle, "A")?.ToString();
            var prevValue = rowHandle > 0 ?
                view.GetRowCellValue(rowHandle - 1, "A")?.ToString() : null;

            return !string.IsNullOrEmpty(currentValue) &&
                   (currentValue == "TIP" || currentValue == "CARI_KOD" ||
                    currentValue == "KOD" || currentValue == "TAHSIL_SEKLI") &&
                   (prevValue?.Contains("RAPOR") == true || prevValue == "PAKET SAYILARI" ||
                    prevValue == "KESİLECEK FATURALAR" || prevValue == "BUGÜN YAPILAN TAHSİLATLAR" ||
                    prevValue == "ENTEGRASYON FİRMA KOMİSYONLARI");
        }
        // Yardımcı metodlar
   
        private bool IsIntegerType(Type type)
        {
            return type == typeof(int) || type == typeof(long) ||
                   type == typeof(short) || type == typeof(byte);
        }

        private void ConfigureGridView()
        {
            var view = grid.MainView as MyGridView;
            if (view == null) return;

            // Temel kolon ayarları
            view.Columns["ID"].Visible = false;
            view.Columns["TAHSIL_SEKLI"].Caption = "Tahsilat Şekli";
            view.Columns["FIS_TAHSILAT"].Caption = "Fiş Tahsilat";
            view.Columns["FIS_DISI_TAHSILAT"].Caption = "Fiş Dışı Tahsilat";
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowFooter = true;
            view.OptionsNavigation.UseTabKey = true;
            view.OptionsNavigation.UseTabKey = true;
            view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            // Para birimi formatı için
            string[] moneyColumns = { "FIS_TAHSILAT", "FIS_DISI_TAHSILAT", "TOPLAM", "FARK" };
            foreach (string colName in moneyColumns)
            {
                if (view.Columns[colName] != null)
                {
                    view.Columns[colName].DisplayFormat.FormatType = FormatType.Numeric;
                    view.Columns[colName].DisplayFormat.FormatString = "n2";
                    view.Columns[colName].OptionsColumn.AllowEdit = false;
                    view.Columns[colName].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    view.Columns[colName].SummaryItem.DisplayFormat = "{0:n2}";

                }
            }

            // POS kolonları için ayarlar 
            for (int i = 1; i <= 10; i++)
            {
                var posCol = view.Columns[$"POS{i}"];
                if (posCol != null)
                {
                    posCol.Caption = $"POS {i}";
                    posCol.OptionsColumn.AllowEdit = true;
                    posCol.DisplayFormat.FormatType = FormatType.Numeric;
                    posCol.DisplayFormat.FormatString = "n2";
                    posCol.Width = 100;
                    posCol.AppearanceCell.BackColor = Color.LightCyan;
                    posCol.OptionsColumn.AllowFocus = true;

                    // RepositoryItemTextEdit kullanarak EditValue ayarla
                    var edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    edit.DisplayFormat.FormatType = FormatType.Numeric;
                    edit.DisplayFormat.FormatString = "n2";
                    edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    edit.Mask.EditMask = "n2";
                    posCol.ColumnEdit = edit;
                }
            }


            // TOPLAM satırı için özel format
            view.RowStyle += (s, e) =>
            {
                var gridView = s as GridView;
                if (gridView?.GetRowCellValue(e.RowHandle, "TAHSIL_SEKLI")?.ToString() == "TOPLAM")
                {
                    e.Appearance.BackColor = Color.LightYellow;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            };

            // FARK sütunu hesaplama için event
            view.CellValueChanged += (s, e) =>
            {
                if (e.Column.FieldName.StartsWith("POS"))
                {
                    var gridView = s as GridView;
                    if (gridView == null) return;

                    var rowHandle = e.RowHandle;
                    var totalValue = Convert.ToDecimal(gridView.GetRowCellValue(rowHandle, "TOPLAM"));
                    decimal posTotal = 0;

                    // POS değerlerini topla
                    for (int i = 1; i <= 10; i++)
                    {
                        var fieldName = $"POS{i}";
                        var value = gridView.GetRowCellValue(rowHandle, fieldName);
                        if (value != DBNull.Value && value != null)
                        {
                            posTotal += Convert.ToDecimal(value);
                        }
                    }

                    // FARK değerini güncelle
                    gridView.SetRowCellValue(rowHandle, "FARK", totalValue - posTotal);
                }
            };


            view.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var gridView = s as GridView;
                    if (gridView == null) return;

                    // Mevcut pozisyonu al
                    var currentRowHandle = gridView.FocusedRowHandle;
                    var currentColumn = gridView.FocusedColumn;

                    if (currentRowHandle < gridView.DataRowCount - 1)
                    {
                        // Alt satıra git
                        gridView.FocusedRowHandle = currentRowHandle + 1;
                    }
                    else
                    {
                        // Son satırdaysa, bir sonraki POS sütununa geç ve ilk satıra dön
                        var nextColumnIndex = currentColumn.VisibleIndex + 1;
                        while (nextColumnIndex < gridView.VisibleColumns.Count)
                        {
                            var nextColumn = gridView.VisibleColumns[nextColumnIndex];
                            if (nextColumn.FieldName.StartsWith("POS"))
                            {
                                gridView.FocusedColumn = nextColumn;
                                gridView.FocusedRowHandle = 0;
                                break;
                            }
                            nextColumnIndex++;
                        }
                    }

                    e.Handled = true;
                }
            };



            // Grid ayarları
            view.OptionsNavigation.UseTabKey = true;
            view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            view.OptionsView.ShowFooter = true;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.ShowAutoFilterRow = true;

            // Footer toplamları
            view.FooterPanelHeight = 35;
            foreach (GridColumn column in view.Columns)
            {
                if (column.FieldName != "TAHSIL_SEKLI" && !column.FieldName.StartsWith("POS"))
                {
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    column.SummaryItem.DisplayFormat = "{0:n2}";
                }
            }

            // POS hücrelerinde otomatik seçim için
            view.ShowingEditor += (s, e) =>
            {
                var gridView = s as GridView;
                if (gridView?.FocusedColumn?.FieldName.StartsWith("POS") == true)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (gridView.ActiveEditor != null)
                        {
                            gridView.ActiveEditor.SelectAll();
                        }
                    }));
                }
            };
        }


        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.ZRaporuAl;

            // Grid'in refresh edilmesi için event
            if (grid.MainView is MyGridView view)
            {
                view.CellValueChanged += (s, e) =>
                {
                    if (e.Column.FieldName.StartsWith("POS"))
                    {
                        view.PostEditor(); // Değişikliği kaydet
                        view.UpdateTotalSummary(); // Toplamları güncelle
                        view.RefreshData(); // Grid'i yenile
                    }
                };
            }
        }
    }
}