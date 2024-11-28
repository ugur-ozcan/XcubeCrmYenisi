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
    public partial class CariHareketler : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        public string araSorgu = "";
        public CariHareketler( )
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
            if (AnaForm.cariLogicalref != "")
            {
                araSorgu += "AND CLC.LOGICALREF IN (" + AnaForm.cariLogicalref + ")";
            }
            if (AnaForm.cariLogicalref != "")
            {
                araSorgu += "AND CLC.LOGICALREF IN (" + Id + ")";
            }
            if (AnaForm.ozelKod != "")
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
            if (AnaForm.dovizTuru != "")
            {
                araSorgu += "AND CTRNS.TRCURR IN (" + AnaForm.dovizTuru + ")";
            }
            if (AnaForm.satisElemani != "")
            {
                araSorgu += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_SLSCLREL SL  " +
" JOIN " + AnaForm.db +  ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma +  " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }
            araSorgu += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";

            string sorgu = " SELECT " +
" T.LOGICALREF, T.[CARI_HESAP_KODU],T.ACIKLAMA AS CARI_UNVANI,T.TARIH,T.FIS_NO,T.FIS_TURU, ISNULL( BANKAADI,'') AS BANKA , T.SATIR_ACIKLAMASI, T.FISACIKLAMASI , T.BORC,T.ALACAK, " +
" T.ISLEM_DOVIZI, " +
" T.ISLEM_DOVIZ_TUTARI, " +
" T.[ISLEM_KURU], " +
"  OZELKOD4, " +
"  OZELKOD5,  " +
" KAYITTARIHI, " +
" DEGISTIRMETARIHI " +
" FROM ( " +
" SELECT TOP 100 PERCENT " +
" BANK.DEFINITION_ AS BANKAADI, " +
" CTRNS.LOGICALREF ASDD,  " +
" CTRNS.FTIME, " +
" CTRNS.CLIENTREF, " +
" CTRNS.LOGICALREF, " +
" CLC.SPECODE5 OZELKOD5, " +
" CLC.SPECODE4 OZELKOD4, " +
" CLC.CODE [CARI_HESAP_KODU], " +
" CLC.DEFINITION_ [ACIKLAMA], " +
" CTRNS.DATE_ TARIH, " +
" CTRNS.TRANNO [FIS_NO], " +
" CLFIC.GENEXP1 + CLFIC.GENEXP2 + CLFIC.GENEXP3 + CLFIC.GENEXP4 + CLFIC.GENEXP5 + CLFIC.GENEXP6 AS FISACIKLAMASI, " +
" CTRNS.TRCODE, " +
" CTRNS.MODULENR, " +
" CTRNS.CAPIBLOCK_CREADEDDATE AS KAYITTARIHI, " +
" CTRNS.CAPIBLOCK_MODIFIEDDATE AS DEGISTIRMETARIHI, " +
" CASE ((CTRNS.MODULENR*100)+CTRNS.TRCODE) " +
" WHEN 381 THEN 'Satış Siparişi' " +
" WHEN 382 THEN 'Satınalma Siparişi' " +
" WHEN 431 THEN 'Satın Alma Faturası' " +
" WHEN 432 THEN 'Perakende Satış İade Faturası' " +
" WHEN 433 THEN 'Toptan Satış İade Faturası' " +
" WHEN 434 THEN 'Alınan Hizmet Faturası' " +
" WHEN 435 THEN 'Alınan Proforma Faturası' " +
" WHEN 436 THEN 'Alım İade Faturası' " +
" WHEN 437 THEN 'Perakende Satış Faturası' " +
" WHEN 438 THEN 'Toptan Satış Faturası' " +
" WHEN 439 THEN 'Verilen Hizmet Faturası' " +
" WHEN 440 THEN 'Verilen Proforma Faturası' " +
" WHEN 441 THEN 'Verilen Vade Farkı Faturası' " +
" WHEN 442 THEN 'Alınan Vade Farkı Faturası' " +
" WHEN 443 THEN 'Alınan Fiyat Farkı Faturası' " +
" WHEN 444 THEN 'Verilen Fiyat Farkı Faturası' " +
" WHEN 456 THEN 'Müstahsil Makbuzu' " +
" WHEN 501 THEN 'Nakit Tahsilat' " +
" WHEN 502 THEN 'Nakit Ödeme' " +
" WHEN 503 THEN 'Borç Dekontu' " +
" WHEN 504 THEN 'Alacak Dekontu' " +
" WHEN 505 THEN 'Virman İşlemi' " +
" WHEN 506 THEN 'Kur Farkı İşlemi' " +
" WHEN 546 THEN 'Alınan Serbest Meslek Makbuzu' " +
" WHEN 512 THEN 'Özel İşlem' " +
" WHEN 514 THEN 'Açılış Fişi'  " +
" WHEN 570 THEN 'Kredi Kartı Fişi' " +
" WHEN 572 THEN 'Firma Kredi Kartı Fişi' " +
" WHEN 661 THEN 'Çek Girişi' " +
" WHEN 662  THEN 'Senet Girişi' " +
" WHEN 663 THEN 'Çek Çıkış Cari Hesaba' " +
" WHEN 664 THEN 'Senet Çıkış Cari Hesaba' " +
" WHEN 720 THEN 'Gelen Havaleler' " +
" WHEN 721 THEN 'Gönderilen Havaleler' " +
" WHEN 728 THEN 'Banka Alınan Hizmet' " +
" WHEN 729 THEN 'Banka Verilen Hizmet' " +
" WHEN 1001 THEN 'Nakit Tahsilat' " +
" WHEN 1002 THEN 'Nakit Ödeme' " +
" WHEN 6103 THEN 'Borç Dekontu (Çek)' " +
" WHEN 6104 THEN 'Alacak Dekontu (Çek)' " +
" END [FIS_TURU], " +
" CTRNS.DOCODE [BELGE_NO], " +
" CTRNS.LINEEXP [SATIR_ACIKLAMASI], " +
" CASE SIGN WHEN 0 THEN  ROUND(AMOUNT,2) ELSE 0 END BORC, " +
" CASE SIGN WHEN 1 THEN  ROUND(-1*AMOUNT,2) ELSE 0 END ALACAK, " +
" CASE SIGN WHEN 0 THEN  ROUND(AMOUNT,2) ELSE  ROUND(-1*AMOUNT,2) END TUTAR, " +
" CASE CTRNS.TRCURR WHEN 0 THEN 'TL'  WHEN 160 THEN 'TL'  WHEN 1 THEN  'USD' WHEN 17 THEN  'GBP' WHEN 20 THEN  'EUR' END [ISLEM_DOVIZI], " +
" CASE SIGN WHEN 0 THEN  ROUND(CTRNS.TRNET,2) ELSE  ROUND(-1*CTRNS.TRNET,2) END [ISLEM_DOVIZ_TUTARI], " +
" CASE CTRNS.TRCURR WHEN 0 THEN 1  ELSE CTRNS.TRRATE END [ISLEM_KURU]  " +
" FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_CLFLINE CTRNS WITH (NOLOCK) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PAYPLANS PAYPL WITH (NOLOCK) " +
"         ON (CTRNS.PAYDEFREF = PAYPL.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_CLFICHE CLFIC WITH (NOLOCK) " +
"         ON (CTRNS.SOURCEFREF = CLFIC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_INVOICE INVFC WITH (NOLOCK) " +
"         ON (CTRNS.SOURCEFREF = INVFC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_CSROLL RLFIC WITH (NOLOCK) " +
"         ON (CTRNS.SOURCEFREF = RLFIC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_EMFICHE GLFIC WITH (NOLOCK) " +
"         ON (CTRNS.ACCFICHEREF = GLFIC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CLCARD CLC WITH (NOLOCK) " +
"         ON (CTRNS.CLIENTREF = CLC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_01_ORFICHE ORFIC WITH (NOLOCK) " +
"         ON (CTRNS.SOURCEFREF = ORFIC.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PURCHOFFER POFFER WITH (NOLOCK) " +
"         ON (CTRNS.OFFERREF = POFFER.LOGICALREF) " +
"     LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_BANKACC BANK WITH (NOLOCK) " +
"         ON (BANK.LOGICALREF = CTRNS.BANKACCREF) " +
" WHERE     CTRNS.PAIDINCASH=0 AND CTRNS.CANCELLED=0   " +
//" AND (CTRNS.TRCODE IN ( 31, 32, 33, 34, 36, 37, 38, 39, 43, 44, 56, 1, 2, 3, 4, 5, 6, 12, 14, 41, 42, 45, 46, 70,71, 72, 73, 20, 21, 24, 25, 28, 29, 30, 61, 62, 63, 64, 75, 81, 82 )) " +
     araSorgu +
" ORDER BY CTRNS.CLIENTREF,CTRNS.DATE_, " +
" CASE WHEN CTRNS.TRCODE = 14 AND CTRNS.MODULENR = 5 THEN 0 ELSE 1 END, " +
" CASE WHEN CTRNS.MODULENR = 5 THEN CLFIC.TIME WHEN CTRNS.MODULENR = 4 THEN INVFC.TIME_ ELSE CTRNS.FTIME END, " +
" CLFIC.LOGICALREF " +
" ) AS T  " +
" WHERE TARIH BETWEEN '" + AnaForm.baslangicTarihi + "' and '" + AnaForm.bitisTarihi + "' " +
  
" ORDER BY  TARIH,FTIME,LOGICALREF ";

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
            BaseKartTuru = KartTuru.CariHareketler;
           // FormShow = new ShowEditForms<OkulEditForm>();


        }
    }
}