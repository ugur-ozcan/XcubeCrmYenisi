using DevExpress.XtraDiagram.Base;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.OkulForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;
using XCubeCrm.UI.Win.GenelForms;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class CariBakiyeler : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
         public CariBakiyeler( )
        {
     
            InitializeComponent();
        }

        protected override void Listele()
        {
            
            araSorgu = "";
            if (AnaForm.aktifKayilar != "")
            {
                araSorgu += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";
            }
            if (AnaForm.cariLogicalref!="")
            {
                araSorgu += "AND CLC.LOGICALREF IN (" + AnaForm.cariLogicalref + ")";
            }
            if(AnaForm.ozelKod!="")
            {
                araSorgu += "AND CLC.SPECODE IN (" + AnaForm.ozelKod + ")";
            }
            if (AnaForm.ozelKod2 != "")
            {
                araSorgu += "AND CLC.SPECODE2 IN (" + AnaForm.ozelKod2 + ")";
            }
            if (AnaForm.ozelKod3 != "")
            {
                araSorgu += "AND CLC.SPECODE3 IN (" + AnaForm.ozelKod3 + ")";
            }
            if (AnaForm.ozelKod4 != "")
            {
                araSorgu += "AND CLC.SPECODE4 IN (" + AnaForm.ozelKod4 + ")";
            }
            if (AnaForm.ozelKod5 != "")
            {
                araSorgu += "AND CLC.SPECODE5 IN (" + AnaForm.ozelKod5 + ")";
            }
            if (AnaForm.yetkiKodu != "")
            {
                araSorgu += "AND CLC.CYPHCODE IN (" + AnaForm.yetkiKodu + ")";
            }
            if (AnaForm.dovizTuru!="")
            {
                araSorgu += "AND CLFL.TRCURR IN (" + AnaForm.dovizTuru + ")";
            }
            if (AnaForm.satisElemani!="")
            {
                araSorgu+=" and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( "+
" SELECT LOGICALREF,   " + 
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_SLSCLREL SL  " + 
" JOIN " + AnaForm.db +  ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma +  " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " + 
" FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_CLCARD CL " + 
" ) AS AAA WHERE AAA.SALESMANREF IN ( "+ AnaForm.satisElemani + "))";
            }
            araSorgu += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";
            string sorgu = " SELECT " +
        " Id, " +
        " Kod,  " +
        " Unvan,  " +
        " Borc - Alacak as Bakiye,  " +
        " Borc,  " +
        " Alacak,  " +
        " [TlBorc] - [TlAlacak] AS TlBakiye,  " +
        " [TlBorc],  " +
        " [TlAlacak],  " +
        " [UsdBorc] - [UsdAlacak] AS UsdBakiye,  " +
        " [UsdBorc],  " +
        " [UsdAlacak],  " +
        " [EuroBorc] - [EuroAlacak] AS EuroBakiye,  " +
        " [EuroBorc],  " +
        " [EuroAlacak],  " +
        " [UsdYerelBorc] - [UsdYerelAlacak] AS UsdYerelBakiye,  " +
        " [UsdYerelBorc],  " +
        " [UsdYerelAlacak],  " +
        " [EuroYerelBorc] - [EuroYerelAlacak] AS EuroYerelBakiye,  " +
        " [EuroYerelBorc],  " +
        " [EuroYerelAlacak] " +
        " FROM(  " +
        " SELECT " +
        " Id, " +
        " Kod,  " +
        " Unvan,  " +
        " COALESCE(SUM(BORÇ), 0)Borc,  " +
        " COALESCE(SUM(Alacak), 0)Alacak,  " +
        " COALESCE(SUM([TlBorc]), 0)[TlBorc],  " +
        " COALESCE(SUM([TlAlacak]), 0)[TlAlacak],  " +
        " COALESCE(SUM([UsdBorc]), 0)[UsdBorc],  " +
        " COALESCE(SUM([UsdAlacak]), 0)[UsdAlacak],  " +
        " COALESCE(SUM([EuroBorc]), 0)[EuroBorc],  " +
        " COALESCE(SUM([EuroAlacak]), 0)[EuroAlacak],  " +
        " COALESCE(SUM([UsdYerelBorc]), 0)[UsdYerelBorc],  " +
        " COALESCE(SUM([UsdYerelAlacak]), 0)[UsdYerelAlacak],  " +
        " COALESCE(SUM([EuroYerelBorc]), 0)[EuroYerelBorc],  " +
        " COALESCE(SUM([EuroYerelAlacak]), 0)[EuroYerelAlacak],  " +
        " COALESCE(SUM([GBPYerelBorc]), 0)[GBPYerelBorc],  " +
        " COALESCE(SUM([GBPYerelAlacak]), 0)[GBPYerelAlacak],  " +
        " COALESCE(SUM([CHFYerelBorc]), 0)[CHFYerelBORÇ],  " +
        " COALESCE(SUM([CHFYerelAlacak]), 0)[CHFYerelAlacak] " +
" FROM(  " +
    " SELECT " +
        " CLFL.DATE_ TARIH,  " +
        " CASE(CASE WHEN CLFL.MONTH_ IS NULL THEN MONTH(CLFL.DATE_) ELSE CLFL.MONTH_ END) " +
        " WHEN 1 THEN 'Ocak' " +
        " WHEN 2 THEN 'Şubat' " +
        " WHEN 3 THEN 'Mart' " +
        " WHEN 4 THEN 'Nisan' " +
        " WHEN 5 THEN 'Mayıs' " +
        " WHEN 6 THEN 'Haziran' " +
        " WHEN 7 THEN 'Temmuz' " +
        " WHEN 8 THEN 'Ağustos' " +
        " WHEN 9 THEN 'Eylül' " +
        " WHEN 10 THEN 'Ekim' " +
        " WHEN 11 THEN 'Kasım' " +
        " WHEN 12 THEN 'Aralık' " +
        " ELSE 'Diğer' END AS AYADI,  " +
        " CASE CLFL.TRCODE WHEN 1 THEN 'Nakit Tahsilat' " +
        " WHEN 2 THEN 'Nakit Ödeme' " +
        " WHEN 3 THEN 'Borç Dekontu' " +
        " WHEN 4 THEN 'Alacak Dekontu' " +
        " WHEN 5 THEN 'Virman Fişi' " +
        " WHEN 6 THEN 'Kur Farkı Fişi' " +
        " WHEN 12 THEN 'Özel Fiş' " +
        " WHEN 14 THEN 'Açılış Fişi' " +
        " WHEN 20 THEN 'Gelen Havale' " +
        " WHEN 21 THEN 'Gönderilen Havale' " +
        " WHEN 24 THEN 'Döviz Alış Belgesi' " +
        " WHEN 25 THEN 'Döviz Satış belgesi' " +
        " WHEN 28 THEN 'Alınan Hizmet Faturası' " +
        " WHEN 29 THEN 'Verilen Hizmet Faturası' " +
        " WHEN 31 THEN 'Satın Alma Faturası' " +
        " WHEN 32 THEN 'Perakende Satış İade Faturası' " +
        " WHEN 33 THEN 'Toptan Satış İade Faturası' " +
        " WHEN 34 THEN 'Alınan Hizmet Faturası' " +
        " WHEN 35 THEN 'Alınan Proforma Fatura' " +
        " WHEN 36 THEN 'Satın Alma İade Faturası' " +
        " WHEN 37 THEN 'Perakende Satış Faturası' " +
        " WHEN 38 THEN 'Toptan Satış Faturası' " +
        " WHEN 39 THEN 'Verilen Hizmet Faturası' " +
        " WHEN 40 THEN 'Verilen proforma fatura' " +
        " WHEN 41 THEN 'Verilen Vade Farkı Faturası' " +
        " WHEN 42 THEN 'Alınan Vade Farkı Faturası' " +
        " WHEN 43 THEN 'Satın Alma Fiyat Farkı Faturası' " +
        " WHEN 44 THEN 'Satış Fiyat Farkı Faturası' " +
        " WHEN 45 THEN 'Verilen Serbest Meslek Makbuzu' " +
        " WHEN 46 THEN 'Alınan Serbest Meslek Makbuzu' " +
        " WHEN 56 THEN 'Müstahsil Makbuzu' " +
        " WHEN 61 THEN 'Çek Girişi' " +
        " WHEN 62 THEN 'Senet Girişi' " +
        " WHEN 63 THEN 'Çek Çıkışı (Cari Hesaba)' " +
        " WHEN 64 THEN 'Senet Çıkışı (Cari Hesaba)' " +
        " WHEN 70 THEN 'Kredi CLCı Fişi' " +
        " WHEN 71 THEN 'Kredi CLCı İade Fişi' " +
        " WHEN 72 THEN 'Firma Kredi CLCı Fişi' " +
        " WHEN 73 THEN 'Firma Kredi CLCı İade Fişi' " +
        " WHEN 81 THEN 'Satınalma Siparişi' " +
        " WHEN 82 THEN 'Satış Siparişi' END AS TÜR,  " +
        " CLC.LOGICALREF Id, " +
        " CLC.CODE AS Kod,  " +
        " CLC.DEFINITION_ AS Unvan,  " +
        " CASE WHEN CLFL.MONTH_ IS NULL THEN MONTH(CLFL.DATE_) ELSE CLFL.MONTH_ END AY,  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 THEN CLFL.AMOUNT END, 0) AS[BORÇ],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 THEN CLFL.AMOUNT END, 0) AS[Alacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 THEN CLFL.AMOUNT END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 THEN CLFL.AMOUNT END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) AS[TlBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) AS[TlAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Tl Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) AS[UsdBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) AS[UsdAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Usd Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) AS[EuroBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) AS[EuroAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Euro Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) AS[UsdYerelBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) AS[UsdYerelAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[UsdYerel Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) AS[EuroYerelBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) AS[EuroYerelAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[EuroYerel Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) AS[GBPYerelBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) AS[GBPYerelAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[GBPYerel Bakiye],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0) AS[CHFYerelBorc],  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0) AS[CHFYerelAlacak],  " +
        " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) -  " +
        " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0)) " +
        " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[CHFYerel Bakiye] " +
    " FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_CLFLINE AS CLFL LEFT OUTER JOIN " +
    " " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_CLCARD AS CLC ON CLFL.CLIENTREF = CLC.LOGICALREF " +
    " WHERE(CLFL.CANCELLED = 0) AND(CLC.ACTIVE = 0) AND(CLFL.PAIDINCASH = 0) " +
    " and CLFL.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' " +
     araSorgu + 
    "            ) AS TMP " +
    " GROUP BY " +
    " ID, " +
    " Kod,  " +
    " Unvan " +
"  ) AS Bakiye " ;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.baglanti());

            grid.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariBakiyeler;
            RaporMu = true;
            //FormShow = new ShowEditForms<CariBakiyeler>();


        }
 

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            //ShowReportListForms<CariBakiyeler>.ShowReportDialogListForm();
            int idsi = (int)(tablo.GetFocusedRowCellValue("Id"));
            if (tablo.FocusedRowHandle < 1) return;


            ShowReportListForms<CariHareketler>.ShowDialogListForm(KartTuru.CariHareketler,idsi);


        }
    }
}