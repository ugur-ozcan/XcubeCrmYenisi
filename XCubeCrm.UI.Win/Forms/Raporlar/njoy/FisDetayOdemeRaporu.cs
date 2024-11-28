using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.GenelForms;

namespace XCubeCrm.UI.Win.Forms.Raporlar.NJOY
{
    public partial class FisDetayOdemeRaporu : BaseReportListForm
    {
        private readonly sqlBaglanti bgl = new sqlBaglanti();

        public FisDetayOdemeRaporu()
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

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.FisDetayOdemeRaporu;
        }

        protected override void Listele()
        {
            // Lokasyon kontrolü
            string lokasyonKontrol = AnaForm.secilenLokasyon.Any()
                ? $"AND F.LOKASYON IN ({string.Join(",", AnaForm.secilenLokasyon)})"
                : "AND F.LOKASYON IN (SELECT ID FROM LOKASYON WHERE AKTIF=1)";

            string sorgu = @"
DECLARE @HasPOSColumns BIT
DECLARE @HasCariColumns BIT
DECLARE @DynamicPivotColumns NVARCHAR(MAX) = ''
DECLARE @DynamicPivotCariColumns NVARCHAR(MAX) = ''
DECLARE @DynamicQuery NVARCHAR(MAX)
DECLARE @PivotSection NVARCHAR(MAX) = ''

-- POS sütunları için kontrol
IF EXISTS (SELECT 1 FROM BANKA_POS)
BEGIN
    SELECT @DynamicPivotColumns = STRING_AGG(QUOTENAME(AD), ',')
    FROM BANKA_POS
    SET @HasPOSColumns = 1
END
ELSE
BEGIN
    SET @HasPOSColumns = 0
    SET @DynamicPivotColumns = '''DummyPOS'''
END

-- Cari sütunları için kontrol
IF EXISTS (
    SELECT 1 
    FROM FINANS_DETAY D 
    JOIN CARI C ON C.ID = D.KART_BORCLU
    WHERE D.FINANS_ISLEM_TURU = 68
)
BEGIN
    SELECT @DynamicPivotCariColumns = STRING_AGG(QUOTENAME(AD), ',')
    FROM (
        SELECT DISTINCT C.AD 
        FROM FINANS_DETAY D 
        JOIN CARI C ON C.ID = D.KART_BORCLU
        WHERE D.FINANS_ISLEM_TURU = 68
    ) AS CariList
    SET @HasCariColumns = 1
END
ELSE
BEGIN
    SET @HasCariColumns = 0
    SET @DynamicPivotCariColumns = '''DummyCari'''
END

SET @DynamicQuery = N'
WITH Fisler As (
    SELECT F.* ,T.IADE,T.AD AS FIS_TURU_AD
    FROM FIS F
    INNER JOIN FIS_TURU T ON T.ID=F.FIS_TURU
    WHERE F.ID>0 
    AND F.FIS_TARIHI BETWEEN @BaslangicTarihi AND @BitisTarihi
    ' + @LokasyonKontrol + '
    AND (F.FIS_TURU IN (11,12,35,36))   		
), 
PosOdemeler AS (
    SELECT 
        D.FIS,
        BP.AD AS BANKA_POS_ADI,
        ABS(D.TUTAR*IIF(D.FINANS_ISLEM_TURU=55,-1,1)) AS TUTAR
    FROM FINANS_DETAY D
    JOIN BANKA_POS BP ON BP.ID = D.KART_BORCLU
    WHERE D.FINANS_ISLEM_TURU IN (15,55) 
    AND D.KART_ALACAKLI > 0
),
CariOdemeler AS (
    SELECT 
        D.FIS,
        C.AD AS CARI_ADI,
        ABS(D.TUTAR) AS TUTAR
    FROM FINANS_DETAY D
    JOIN CARI C ON C.ID = D.KART_BORCLU
    WHERE D.FINANS_ISLEM_TURU = 68
),' +
CASE 
    WHEN @HasPOSColumns = 1 THEN '
PosPivot AS (
    SELECT *
    FROM PosOdemeler
    PIVOT (
        SUM(TUTAR)
        FOR BANKA_POS_ADI IN (' + @DynamicPivotColumns + ')
    ) AS PVT
),'
    ELSE '
PosPivot AS (
    SELECT 
        f.ID as FIS,
        NULL as ' + @DynamicPivotColumns + '
    FROM Fisler f
),'
END +
CASE 
    WHEN @HasCariColumns = 1 THEN '
CariPivot AS (
    SELECT *
    FROM CariOdemeler
    PIVOT (
        SUM(TUTAR)
        FOR CARI_ADI IN (' + @DynamicPivotCariColumns + ')
    ) AS PVT
),'
    ELSE '
CariPivot AS (
    SELECT 
        f.ID as FIS,
        NULL as ' + @DynamicPivotCariColumns + '
    FROM Fisler f
),'
END + '
Tahsilat As (
    SELECT 
        T.FIS,
        T.GENELTOPLAM,
        T.GENELTOPLAM*IIF(T.IADE=1,-1,1) TUTAR,
        SUM(T.NAKIT)*IIF(T.IADE=1,-1,1) NAKIT,
        ABS(SUM(T.KREDIKARTI))*IIF(T.IADE=1,-1,1) KREDI_KARTI,
        ABS(SUM(T.CARI_TAHSILAT))*IIF(T.IADE=1,-1,1) CARI_TAHSILAT,
        ABS(SUM(T.PUAN))*IIF(T.IADE=1,-1,1) PUAN,
        ABS(SUM(T.KUPON))*IIF(T.IADE=1,-1,1) KUPON,
        ABS(SUM(T.NAKIT+T.KREDIKARTI+T.CARI_TAHSILAT+T.PUAN+T.KUPON))*IIF(T.IADE=1,-1,1) TAHSILAT
    FROM (
        SELECT 
            D.FIS,
            F.GENELTOPLAM,
            F.IADE,
            CASE WHEN D.FINANS_ISLEM_TURU IN (1,2) THEN D.TUTAR*IIF(D.FINANS_ISLEM_TURU=2,-1,1) ELSE 0 END NAKIT,
            CASE WHEN D.FINANS_ISLEM_TURU IN (15,55) AND D.KART_ALACAKLI>0 THEN D.TUTAR*IIF(D.FINANS_ISLEM_TURU=55,-1,1) ELSE 0 END KREDIKARTI,
            CASE WHEN D.FINANS_ISLEM_TURU IN (68) THEN D.TUTAR ELSE 0 END CARI_TAHSILAT,
            CASE WHEN D.FINANS_ISLEM_TURU IN (79) THEN D.TUTAR ELSE 0 END PUAN,
            CASE WHEN D.FINANS_ISLEM_TURU IN (119) THEN D.TUTAR ELSE 0 END KUPON
        FROM FINANS_DETAY D
        JOIN FINANS_ISLEM_TURU T ON T.ID=D.FINANS_ISLEM_TURU
        JOIN Fisler F ON F.ID=D.FIS
        WHERE D.FINANS_ISLEM_TURU NOT IN (53,54,100,104)
    ) AS T
    GROUP BY T.FIS,T.GENELTOPLAM,T.IADE
)
SELECT 
    L.FIS,
    L.FIS_TURU,
    L.BELGENO,
    L.FIS_TARIHI,
    L.LOKASYON,
    L.MIKTAR_FIS,
    L.FIYAT,
    L.AD,
    L.DAHIL_FIYAT,
    L.TUTAR,
    L.DAHIL_TUTAR,
    L.SATIR_YUVARLAMA,
    L.NET_KDV_DAHIL_TUTAR AS SATIR___DAHIL_TUTAR___NET,
    L.TOPLAM_KDV,
    CASE WHEN L.SIRA=1 THEN IIF(L.IADE=1,-1,1)*L.FIS_ISKONTO_TOPLAM ELSE 0 END FIS_ISKONTO_TOPLAM,
    CASE WHEN L.SIRA=1 THEN L.GENELTOPLAM ELSE 0 END GENELTOPLAM,
    CASE WHEN L.SIRA=1 THEN IIF(L.IADE=1,-1,1)*L.FIS_KDV_TOPLAM ELSE 0 END FIS_KDV_TOPLAM,
    L.SIRA,
    T.NAKIT,
    T.KREDI_KARTI,
    T.CARI_TAHSILAT AS TAHSILAT_CARISI,
    T.PUAN,
    T.KUPON,
    T.TAHSILAT,
    CASE WHEN L.SIRA=1 THEN COALESCE(L.GENELTOPLAM,0)-COALESCE(T.TAHSILAT,0) ELSE 0 END VERESIYE,
    P.*,
    C.*
FROM (
    SELECT 
        D.FIS,
        F.FIS_TURU_AD AS FIS_TURU,
        F.BELGENO,
        F.FIS_TARIHI,
        L.AD LOKASYON,
        D.MIKTAR_FIS,
        D.FIYAT,
        S.AD,
        D.DAHIL_FIYAT,
        D.TUTAR,
        D.DAHIL_TUTAR,
        ((F.YUVARLAMA*DBO.BOL(SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)) OVER (PARTITION BY D.FIS),
          SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)*((100+D.KDV_TOPTAN)/100)) OVER (PARTITION BY D.FIS))))*
         DBO.BOL((D.TUTAR*((100-D.ISKONTO_HESAP)/100)), 
         SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)) OVER (PARTITION BY D.FIS)) SATIR_YUVARLAMA,
        ((D.TUTAR*((100-D.ISKONTO_HESAP)/100))-
         (((F.YUVARLAMA*DBO.BOL(SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)) OVER (PARTITION BY D.FIS),
           SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)*((100+D.KDV_TOPTAN)/100)) OVER (PARTITION BY D.FIS))))*
          DBO.BOL((D.TUTAR*((100-D.ISKONTO_HESAP)/100)), 
          SUM(D.TUTAR*((100-D.ISKONTO_HESAP)/100)) OVER (PARTITION BY D.FIS))))*
         ((D.KDV_TOPTAN+100)/100)*IIF(F.IADE=1,-1,1) NET_KDV_DAHIL_TUTAR,
        F.FIS_ISKONTO_TOPLAM,
        D.TOPLAM_KDV,
        (IIF(F.IADE=1,-1,1)*F.GENELTOPLAM) AS GENELTOPLAM,
        F.KDV_TOPLAM FIS_KDV_TOPLAM,
        F.IADE,
        ROW_NUMBER() OVER (PARTITION BY D.FIS ORDER BY D.ID) SIRA
    FROM FIS_DETAY D
    INNER JOIN Fisler F ON F.ID=D.FIS
    LEFT JOIN CARI C ON C.ID=F.CARI
    LEFT JOIN LOKASYON L ON L.ID=D.LOKASYON
    LEFT JOIN STOK S ON S.ID=D.STOK
) AS L
LEFT JOIN Tahsilat T ON T.FIS=L.FIS AND L.SIRA=1
LEFT JOIN PosPivot P ON P.FIS = L.FIS
LEFT JOIN CariPivot C ON C.FIS = L.FIS'

EXEC sp_executesql @DynamicQuery, 
    N'@BaslangicTarihi DATETIME, @BitisTarihi DATETIME, @LokasyonKontrol NVARCHAR(MAX)', 
    @BaslangicTarihi = @BaslangicTarihi, 
    @BitisTarihi = @BitisTarihi,
    @LokasyonKontrol = @LokasyonKontrol";

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(bgl.baglantiNJOY().ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.Add("@BaslangicTarihi", SqlDbType.DateTime).Value = DateTime.Parse(AnaForm.baslangicTarihi);
                    cmd.Parameters.Add("@BitisTarihi", SqlDbType.DateTime).Value = DateTime.Parse(AnaForm.bitisTarihi);
                    cmd.Parameters.Add("@LokasyonKontrol", SqlDbType.NVarChar).Value = lokasyonKontrol;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                grid.DataSource = dt;

                // DevExpress Grid için decimal format ayarları
                GridView gridView = grid.MainView as GridView;
                if (gridView != null)
                {
                    string[] decimalColumns = new[] {
            "FIYAT", "DAHIL_FIYAT", "TUTAR", "DAHIL_TUTAR",
            "SATIR_YUVARLAMA", "SATIR___DAHIL_TUTAR___NET"
        };

                    foreach (string columnName in decimalColumns)
                    {
                        GridColumn column = gridView.Columns[columnName];
                        if (column != null)
                        {
                            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            column.DisplayFormat.FormatString = "N3"; // 3 decimal places
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor yüklenirken hata oluştu:\n{ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}