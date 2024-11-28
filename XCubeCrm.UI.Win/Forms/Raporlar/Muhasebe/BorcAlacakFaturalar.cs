using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils.About;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Native.Templates;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class BorcAlacakFaturalar : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorguCari = "", araSorguUrun = "", araSorguIsyeri = "", araSorguCari2 = "";
        public BorcAlacakFaturalar()
        {

            InitializeComponent();
            //Listele();
        }

        private void grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void Listele()
        {
            araSorguCari = string.Empty;
            if (AnaForm.cariLogicalref != string.Empty)
            {
                araSorguCari += "AND CLC.LOGICALREF IN (" + AnaForm.cariLogicalref + ")";
            }
            if (AnaForm.ozelKod != string.Empty)
            {
                araSorguCari += "AND CLC.SPECODE IN (" + AnaForm.ozelKod + ")";
            }
            if (AnaForm.ozelKod2 != string.Empty)
            {
                araSorguCari += "AND CLC.SPECODE2 IN (" + AnaForm.ozelKod2 + ")";
            }
            if (AnaForm.ozelKod3 != string.Empty)
            {
                araSorguCari += "AND CLC.SPECODE3 IN (" + AnaForm.ozelKod3 + ")";
            }
            if (AnaForm.ozelKod4 != string.Empty)
            {
                araSorguCari += "AND CLC.SPECODE4 IN (" + AnaForm.ozelKod4 + ")";
            }
            if (AnaForm.ozelKod5 != string.Empty)
            {
                araSorguCari += "AND CLC.SPECODE5 IN (" + AnaForm.ozelKod5 + ")";
            }
            if (AnaForm.yetkiKodu != string.Empty)
            {
                araSorguCari += "AND CLC.CYPHCODE IN (" + AnaForm.yetkiKodu + ")";
            }
            if (AnaForm.dovizTuru != string.Empty)
            {
                araSorguCari += "AND ISLEM.DOVIZTURU IN (" + AnaForm.dovizTuru + ")";
            }
            if (AnaForm.isyeri != string.Empty)
            {
                araSorguCari += "AND ISLEM.BRANCH IN (" + AnaForm.isyeri + ")";
            }
            if (AnaForm.aktifKayilar != string.Empty)
            {
                araSorguCari += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";
            }
            if (AnaForm.satisElemani != string.Empty)
            {
                araSorguCari += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_SLSCLREL SL  " +
" JOIN " + AnaForm.db + ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma + " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }

            araSorguUrun = string.Empty;
            if (AnaForm.aktifKayitlarUrun != string.Empty)
            {
                araSorguUrun += "AND ITS.ACTIVE IN (" + AnaForm.aktifKayitlarUrun + ")";
            }
            if (AnaForm.urunLogicalref != "")
            {
                araSorguUrun += "AND ITS.LOGICALREF IN (" + AnaForm.urunLogicalref + ")";
            }
            if (AnaForm.urunOzelKod != "")
            {
                araSorguUrun += "AND ITS.SPECODE IN (" + AnaForm.urunOzelKod.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod2 != "")
            {
                araSorguUrun += "AND ITS.SPECODE2 IN (" + AnaForm.urunOzelKod2.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod3 != "")
            {
                araSorguUrun += "AND ITS.SPECODE3 IN (" + AnaForm.urunOzelKod3.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod4 != "")
            {
                araSorguUrun += "AND ITS.SPECODE4 IN (" + AnaForm.urunOzelKod4.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod5 != "")
            {
                araSorguUrun += "AND ITS.SPECODE5 IN (" + AnaForm.urunOzelKod5.Replace("'", "''") + ")";
            }
            if (AnaForm.urunGrup != "")
            {
                araSorguUrun += "AND ITS.STGRPCODE IN (" + AnaForm.urunGrup.Replace("'", "''") + ")";
            }
            if (AnaForm.urunTip != "")
            {
                araSorguUrun += "AND ITS.CARDTYPE IN (" + AnaForm.urunTip + ")";
            }
            if (AnaForm.urunTip != "")
            {
                araSorguUrun += "AND PRCURR IN (" + AnaForm.dovizTuru + ")";
            }

            if (AnaForm.isyeri != "")
            {
                araSorguUrun += " AND STL.SOURCEINDEX  IN ( SELECT DISTINCT(NR) FROM " + AnaForm.db + ".DBO.L_CAPIWHOUSE WHERE FIRMNR ='" + AnaForm.firma + "' AND DIVISNR IN (   " + AnaForm.isyeri + "))";
            }
            if (AnaForm.ambar != "")
            {
                araSorguUrun += " AND STL.SOURCEINDEX  IN (" + AnaForm.ambar + ")";
            }
            if (AnaForm.dovizTuru != "")
            {
                araSorguUrun += " AND STL.PRCURR  IN (" + AnaForm.dovizTuru + ")";
            }

            araSorguCari2 = string.Empty;
            if (AnaForm.aktifKayilar != string.Empty)
            {
                araSorguUrun += "AND CLC.ACTIVE IN (" + AnaForm.aktifKayilar + ")";
            }
            if (AnaForm.cariLogicalref != string.Empty)
            {
                araSorguUrun += "AND CLC.LOGICALREF IN (" + AnaForm.cariLogicalref + ")";
            }
            if (AnaForm.ozelKod != string.Empty)
            {
                araSorguUrun += "AND CLC.SPECODE IN (" + AnaForm.ozelKod + ")";
            }
            if (AnaForm.ozelKod2 != string.Empty)
            {
                araSorguUrun += "AND CLC.SPECODE2 IN (" + AnaForm.ozelKod2 + ")";
            }
            if (AnaForm.ozelKod3 != string.Empty)
            {
                araSorguUrun += "AND CLC.SPECODE3 IN (" + AnaForm.ozelKod3 + ")";
            }
            if (AnaForm.ozelKod4 != string.Empty)
            {
                araSorguUrun += "AND CLC.SPECODE4 IN (" + AnaForm.ozelKod4 + ")";
            }
            if (AnaForm.ozelKod5 != string.Empty)
            {
                araSorguUrun += "AND CLC.SPECODE5 IN (" + AnaForm.ozelKod5 + ")";
            }
            if (AnaForm.yetkiKodu != string.Empty)
            {
                araSorguUrun += "AND CLC.CYPHCODE IN (" + AnaForm.yetkiKodu + ")";
            }

            if (AnaForm.satisElemani != string.Empty)
            {
                araSorguUrun += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_SLSCLREL SL  " +
" JOIN " + AnaForm.db + ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma + " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }

            string silmeSorgusu = " IF OBJECT_ID('tempdb.dbo.#KAPALIFATURALAR', 'U') IS NOT NULL DROP TABLE #KAPALIFATURALAR; " +
" IF OBJECT_ID('tempdb.dbo.#CLFLINETAHTAKDET1', 'U') IS NOT NULL DROP TABLE #CLFLINETAHTAKDET1; " +
" IF OBJECT_ID('tempdb.dbo.#PAYTRANSTAHTAKDET1', 'U') IS NOT NULL DROP TABLE #PAYTRANSTAHTAKDET1; " +
" IF OBJECT_ID('tempdb.dbo.#CLCARDTAHTAKDET1', 'U') IS NOT NULL DROP TABLE #CLCARDTAHTAKDET1; " +
" IF OBJECT_ID('tempdb.dbo.#INVOICE1', 'U') IS NOT NULL DROP TABLE #INVOICE1; " +
" IF OBJECT_ID('tempdb.dbo.#BNLINE1', 'U') IS NOT NULL DROP TABLE #BNLINE1; " +
" IF OBJECT_ID('tempdb.dbo.#PAYPLANS1', 'U') IS NOT NULL DROP TABLE #PAYPLANS1; " +
" IF OBJECT_ID('tempdb.dbo.#LGSLSMAN1', 'U') IS NOT NULL DROP TABLE #LGSLSMAN1; " +
" IF OBJECT_ID('tempdb.dbo.#ACIKFATURALAR', 'U') IS NOT NULL DROP TABLE #ACIKFATURALAR; " +
" IF OBJECT_ID('tempdb.dbo.#CFLRISK', 'U') IS NOT NULL DROP TABLE #CFLRISK; " +
" IF OBJECT_ID('tempdb.dbo.#CLFLINERISKDETAY', 'U') IS NOT NULL DROP TABLE #CLFLINERISKDETAY; " +
" IF OBJECT_ID('tempdb.dbo.#PTTRANSRISKDETAY', 'U') IS NOT NULL DROP TABLE #PTTRANSRISKDETAY; " +
" IF OBJECT_ID('tempdb.dbo.#CLCARDRISKDETAY', 'U') IS NOT NULL DROP TABLE #CLCARDRISKDETAY;" +
"     IF OBJECT_ID('tempdb.dbo.#FATURALISTESI', 'U') IS NOT NULL DROP TABLE #FATURALISTESI;  " +
"   	      IF OBJECT_ID('tempdb.dbo.#FATURABASLIK', 'U') IS NOT NULL DROP TABLE #FATURABASLIK;";
 

                SqlCommand komut = new SqlCommand(silmeSorgusu, bgl.baglanti());

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                string sorgu3 = string.Empty;




            #region AcikFaturalar

            sorgu3 = " SELECT CL.LOGICALREF,CL.ACTIVE,CL.DBSTOTAL1,CL.DBSTOTAL2,CL.DBSTOTAL3,CL.DBSTOTAL4,CL.DBSTOTAL5,CL.DBSTOTAL6,CL.DBSTOTAL7,CL.DBSLIMIT1,CL.DBSLIMIT2,CL.DBSLIMIT3,CL.DBSLIMIT4,CL.DBSLIMIT5,CL.DBSLIMIT6,CL.DBSLIMIT7,  " +
" CL.TELNRS1,CL.TELNRS2,CL.SPECODE,CL.SPECODE2,CL.SPECODE3,CL.SPECODE4,CL.SPECODE5,CL.TOWN,CL.CITY,CL.TRADINGGRP,CL.CODE,CL.DEFINITION_,CL.EDINO,CL.DISTRICT,CL.BANKBRANCHS7,CL.BANKACCOUNTS7 " +
" INTO #CLCARDTAHTAKDET1  " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD(NOLOCK) CL " +
"      ,(SELECT CLIENTREF FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE(NoLock) " +
" WHERE 1 = 1 " +
" GROUP BY CLIENTREF) CF " +
" WHERE 1 = 1 AND CF.CLIENTREF = CL.LOGICALREF " +
" SELECT PT.APPROVENUM,PT.DEVIRPROCDATE,PT.CANCELLED,PT.CROSSREF,PT.PROCDATE,PT.TRCODE,PT.LOGICALREF,PT.SIGN,PT.CARDREF,PT.PAID,PT.PAIDINCASH,PT.MODULENR,PT.FICHEREF,PT.DATE_,PT.BANKACCREF,PT.TOTAL,PT.TRCURR,PT.TRRATE " +
" INTO #PAYTRANSTAHTAKDET1  " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_PAYTRANS(NoLock) PT,#CLCARDTAHTAKDET1 CL  " +
" WHERE CL.LOGICALREF = PT.CARDREF " +
" SELECT CF.SALESMANREF,CF.DOCODE,CF.LINEEXP,CF.TRANNO,CF.CYPHCODE,CF.DATE_,CF.TRADINGGRP,CF.DEVIRPROCDATE, CF.LOGICALREF,CF.BRANCH,CF.TRNET,CF.SPECODE " +
"      ,CF.CLPRJREF,CF.MODULENR,CF.SIGN,CF.TRCODE,CF.CLIENTREF,CF.TRRATE,CF.CANCELLED,CF.TRCURR,CF.PAYDEFREF,CF.SOURCEFREF,CF.AMOUNT " +
" INTO #CLFLINETAHTAKDET1 FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE(NoLock) CF,#CLCARDTAHTAKDET1 CL  " +
" WHERE CL.LOGICALREF = CF.CLIENTREF " +
" SELECT INV.CYPHCODE,INV.FICHENO,INV.TRNET,INV.DATE_,INV.TRCODE,INV.GRPCODE, INV.SPECODE,INV.CLIENTREF,INV.LOGICALREF,INV.PROJECTREF INTO #INVOICE1  " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_INVOICE INV(NoLock),#CLCARDTAHTAKDET1 CL WHERE CL.LOGICALREF=INV.CLIENTREF  " +
" SELECT * INTO #LGSLSMAN1 FROM " + AnaForm.db + ".dbo.LG_SLSMAN  " +
" SELECT * INTO #PAYPLANS1 FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYPLANS PP(NoLock)  " +
" SELECT * INTO #KAPALIFATURALAR FROM (  " +
" SELECT BRANCH, KOD,UNVAN,'Kapalı İşlem' ISLEMTIPI, FATURANO,FATURATARIHI,TAHSILATTARIHI,TAHSILSEKLI,TAHSILATTUTARI TUTAR, TAHSILATTUTARIDOVIZ TUTARDOVIZ,DOVIZ,ISLEMKURU,VADE VADEGUN, VADEDENSAPMA, TOPLAMVADE, ACIKLAMA, KAPAMAISLEMI, KAPATILANFATURA, FATURAVADETARIHI, DOVIZTURU  " +
" FROM(  " +
" SELECT " +
" CL1.BRANCH, CL.CODE KOD, CL.DEFINITION_ UNVAN,   " +
" CL1.TRANNO AS FATURANO, CASE WHEN CL1.TRCODE = 14 THEN CL1.DEVIRPROCDATE ELSE B.PROCDATE END AS FATURATARIHI, C.PROCDATE AS TAHSILATTARIHI " +
"        , '1' SIRA " +
"        , CASE " +
" when C.TRCODE = 14 and C.MODULENR = 5 THEN 'Açılış Fişi' " +
" when C.TRCODE = 1 and C.MODULENR = 10 THEN 'Nakit Tahsilat' " +
" when C.TRCODE = 2 and C.MODULENR = 10 THEN 'Nakit Ödeme' " +
" when C.TRCODE = 11 and C.MODULENR = 10 THEN 'Cari Hesap Tahsilat' " +
" when C.TRCODE = 12 and C.MODULENR = 10 THEN 'Cari Hesap Ödeme' " +
" when C.TRCODE = 21 and C.MODULENR = 10 THEN 'Bankaya Yatırılan' " +
" when C.TRCODE = 12 and C.MODULENR = 10 THEN 'Bankadan Çekilen' " +
" when C.TRCODE = 31 and C.MODULENR = 10 THEN 'Satınalma Faturası' " +
" when C.TRCODE = 32 and C.MODULENR = 10 THEN 'Perakende Satış İade Faturası' " +
" when C.TRCODE = 33 and C.MODULENR = 10 THEN 'Toptan Satış İade Faturası' " +
" when C.TRCODE = 34 and C.MODULENR = 10 THEN 'Alınan Hizmet Faturası' " +
" when C.TRCODE = 35 and C.MODULENR = 10 THEN 'Satınalma İade Faturası' " +
" when C.TRCODE = 36 and C.MODULENR = 10 THEN 'Perakende Satış Faturası' " +
" when C.TRCODE = 37 and C.MODULENR = 10 THEN 'Toptan Satış Faturası' " +
" when C.TRCODE = 38 and C.MODULENR = 10 THEN 'Verilen Hizmet Faturası' " +
" when C.TRCODE = 39 and C.MODULENR = 10 THEN 'Müstahsil Makbuzu' " +
" when C.TRCODE = 41 and C.MODULENR = 10 THEN 'Muh. Tahsil' " +
" when C.TRCODE = 42 and C.MODULENR = 10 THEN 'Muh. Tediye' " +
" when C.TRCODE = 61 and C.MODULENR = 10 THEN 'Çek Tahsili' " +
" when C.TRCODE = 62 and C.MODULENR = 10 THEN 'Senet Tahsili' " +
" when C.TRCODE = 63 and C.MODULENR = 10 THEN 'Çek Ödemesi' " +
" when C.TRCODE = 64 and C.MODULENR = 10 THEN 'Senet Ödemesi' " +
" when C.TRCODE = 71 and C.MODULENR = 10 THEN 'Açılış (Borç)' " +
" when C.TRCODE = 72 and C.MODULENR = 10 THEN 'Açılış (Alacak)' " +
" when C.TRCODE = 73 and C.MODULENR = 10 THEN 'Virman (Borç)' " +
" when C.TRCODE = 74 and C.MODULENR = 10 THEN 'Virman (Alacak)' " +
" when C.TRCODE = 75 and C.MODULENR = 10 THEN 'Gider Pusulası' " +
" when C.TRCODE = 76 and C.MODULENR = 10 THEN 'Verilen Serbest Mes' " +
" when C.TRCODE = 77 and C.MODULENR = 10 THEN 'Alınan Serbest Mes' " +
" when C.TRCODE = 1 and C.MODULENR = 6 THEN 'Çek Girişi' " +
" when C.TRCODE = 2 and C.MODULENR = 6 THEN 'Senet Girişi' " +
" when C.TRCODE = 3 and C.MODULENR = 6 THEN 'Çek Çıkış Cari Hesaba' " +
" when C.TRCODE = 4 and C.MODULENR = 6 THEN 'Senet Çıkış Cari Hesaba' " +
" when C.TRCODE = 5 and C.MODULENR = 6 THEN 'Çek Çıkış Banka Tahsil' " +
" when C.TRCODE = 6 and C.MODULENR = 6 THEN 'Senet Çıkış Banka Tahsil' " +
" when C.TRCODE = 7 and C.MODULENR = 6 THEN 'Çek Çıkış Banka Teminat' " +
" when C.TRCODE = 8 and C.MODULENR = 6 THEN 'Senet Çıkış Banka Teminat' " +
" when C.TRCODE = 9 and C.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri çeki' " +
" when C.TRCODE = 10 and C.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri Senedi' " +
" when C.TRCODE = 11 and C.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Çekimiz' " +
" when C.TRCODE = 12 and C.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Senedimiz' " +
" when C.TRCODE = 13 and C.MODULENR = 6 THEN 'İşyerleri Arası İ.Bordrosu Müşteri Çeki' " +
" when C.TRCODE = 1 and C.MODULENR = 7 THEN 'Banka İşlem Fişi' " +
" when C.TRCODE = 2 and C.MODULENR = 7 THEN 'Banka Virman Fişi' " +
" when C.TRCODE = 3 and C.MODULENR = 7 THEN 'Gelen Havale / Eft' " +
" when C.TRCODE = 4 and C.MODULENR = 7 THEN 'Gönderilen Havale / Eft' " +
" when C.TRCODE = 5 and C.MODULENR = 7 THEN 'Banka Açılış Fişi' " +
" when C.TRCODE = 6 and C.MODULENR = 7 THEN 'Banka Kur Farkı Fişi' " +
" when C.TRCODE = 7 and C.MODULENR = 7 THEN 'Döviz Alış Belgesi' " +
" when C.TRCODE = 8 and C.MODULENR = 7 THEN 'Döviz Satış Belgesi' " +
" when C.TRCODE = 16 and C.MODULENR = 7 THEN 'Banka Alınan Hizmet Faturası' " +
" when C.TRCODE = 17 and C.MODULENR = 7 THEN 'Banka Verilen Hizmet Faturası' " +
" when C.TRCODE = 18 and C.MODULENR = 7 THEN 'Bankadan Çek Ödemesi' " +
" when C.TRCODE = 19 and C.MODULENR = 7 THEN 'Bankadan Senet Ödemesi' " +
" when C.TRCODE = 1 and C.MODULENR = 5 THEN 'Nakit Tahsilat' " +
" when C.TRCODE = 2 and C.MODULENR = 5 THEN 'Nakit Ödeme' " +
" when C.TRCODE = 3 and C.MODULENR = 5 THEN 'Borç Dekontu' " +
" when C.TRCODE = 4 and C.MODULENR = 5 THEN 'Alacak Dekontu' " +
" when C.TRCODE = 5 and C.MODULENR = 5 THEN 'Virman Işlemi' " +
" when C.TRCODE = 6 and C.MODULENR = 5 THEN 'Kur Farkı İşlemi' " +
" when C.TRCODE = 12 and C.MODULENR = 5 THEN 'Özel İşlem' " +
" when C.TRCODE = 20 and C.MODULENR = 5 THEN 'Gelen Havaleler' " +
" when C.TRCODE = 21 and C.MODULENR = 5 THEN 'Gönderilen Havaleler' " +
" when C.TRCODE = 31 and C.MODULENR = 5 THEN 'Mal Alım Faturası' " +
" when C.TRCODE = 32 and C.MODULENR = 5 THEN 'Perakende Satış İade Faturası' " +
" when C.TRCODE = 24 and C.MODULENR = 5 THEN 'Döviz Alış Belgesi' " +
" when C.TRCODE = 25 and C.MODULENR = 5 THEN 'Döviz Satış Belgesi' " +
" when C.TRCODE = 33 and C.MODULENR = 5 THEN 'Toptan Satış İade Faturası' " +
" when C.TRCODE = 34 and C.MODULENR = 5 THEN 'Alınan Hizmet Faturası' " +
" when C.TRCODE = 35 and C.MODULENR = 5 THEN 'Alınan Proforma Faturası' " +
" when C.TRCODE = 36 and C.MODULENR = 5 THEN 'Alım İade Faturası' " +
" when C.TRCODE = 37 and C.MODULENR = 5 THEN 'Perakende Satış Faturası' " +
" when C.TRCODE = 38 and C.MODULENR = 5 THEN 'Toptan Satış Faturası' " +
" when C.TRCODE = 39 and C.MODULENR = 5 THEN 'Verilen Hizmet Faturası' " +
" when C.TRCODE = 40 and C.MODULENR = 5 THEN 'Verilen Proforma Faturası' " +
" when C.TRCODE = 41 and C.MODULENR = 5 THEN 'Verilen Vade Farkı Faturası' " +
" when C.TRCODE = 42 and C.MODULENR = 5 THEN 'Alınan Vade Farkı Faturası' " +
" when C.TRCODE = 43 and C.MODULENR = 5 THEN 'Alınan Fiyat Farkı Faturası' " +
" when C.TRCODE = 44 and C.MODULENR = 5 THEN 'Verilen Fiyat Farkı Faturası' " +
" when C.TRCODE = 46 and C.MODULENR = 5 THEN 'Alınan Serbest Meslek Makbuzu' " +
" when C.TRCODE = 28 and C.MODULENR = 5 THEN 'Banka Alınan Hizmet Faturası' " +
" when C.TRCODE = 56 and C.MODULENR = 5 THEN 'Müsthsil Makbuzu' " +
" when C.TRCODE = 61 and C.MODULENR = 5 THEN 'Çek Girişi' " +
" when C.TRCODE = 62 and C.MODULENR = 5 THEN 'Senet Girişi' " +
" when C.TRCODE = 63 and C.MODULENR = 5 THEN 'Çek Çıkış Cari Hesaba' " +
" when C.TRCODE = 64 and C.MODULENR = 5 THEN 'Senet Çıkış Cari Hesaba' " +
" when C.TRCODE = 70 and C.MODULENR = 5 THEN 'Kredik Kartı Fişi' " +
" when C.TRCODE = 71 and C.MODULENR = 5 THEN 'Kredik Kartı İade Fişi' " +
" when C.TRCODE = 2 and C.MODULENR = 4 THEN 'Perakende Satış İade' " +
" when C.TRCODE = 3 and C.MODULENR = 4 THEN 'Toptan Satış İade' " +
" when C.TRCODE = 7 and C.MODULENR = 4 THEN 'Perakede Satış Faturası' " +
" when C.TRCODE = 8 and C.MODULENR = 4 THEN 'Toptan Satış Faturası' " +
" when C.TRCODE = 9 and C.MODULENR = 4 THEN 'Verilen Hizmet Faturası' " +
" when C.TRCODE = 10 and C.MODULENR = 4 THEN 'Verilen Proforma Faturası' " +
" when C.TRCODE = 14 and C.MODULENR = 4 THEN 'Verilen Fiyat Farkı Faturası' " +
" when C.TRCODE = 1 and C.MODULENR = 4 THEN 'Mal Alım Faturası' " +
" when C.TRCODE = 4 and C.MODULENR = 4 THEN 'Alınan Hizmet Faturası' " +
" when C.TRCODE = 5 and C.MODULENR = 4 THEN 'Alınan Proforma Faturası' " +
" when C.TRCODE = 6 and C.MODULENR = 4 THEN 'Alım İade Faturası' " +
" when C.TRCODE = 13 and C.MODULENR = 4 THEN 'Alınan Fiyat Farkı Faturası' " +
" when C.TRCODE = 41 and C.MODULENR = 4 THEN 'Verilen Vade Farkı Faturası' " +
" when C.TRCODE = 42 and C.MODULENR = 4 THEN 'Alınan Vade Farkı Faturası' " +
" when C.TRCODE = 26 and C.MODULENR = 4 THEN 'Müstahsil Makbuzu' " +
" when C.TRCODE = 1 and C.MODULENR = 3 THEN 'Ödemeli Satış Siparişi' " +
" when C.TRCODE = 2 and C.MODULENR = 3 THEN 'Ödemeli Satınalma Siparişi' " +
" when C.TRCODE = 3 and C.MODULENR = 61 THEN 'Borç Dekontu' " +
" when C.TRCODE = 4 and C.MODULENR = 61 THEN 'Alacak Dekontu' end AS TAHSILSEKLI " +
"      , SUM(C.PAID * (CASE WHEN C.TRRATE = 0 THEN 1 ELSE C.TRRATE END)) AS TAHSILATTUTARI  " +
"      ,SUM(CASE WHEN(c.TRCURR > 0) AND C.TRCURR<>160 THEN C.PAID ELSE 0 END) AS TAHSILATTUTARIDOVIZ  " +
"      ,MAX(C.TRCURR) AS DOVIZTURU  " +
"      ,CASE WHEN MAX(C.TRCURR) IN(0, 160) THEN 'TL' WHEN MAX(C.TRCURR)= 1 THEN 'USD' WHEN MAX(C.TRCURR)= 20 THEN 'EUR' ELSE 'DIG' END DOVIZ  " +
"      ,CASE WHEN MAX(C.TRCURR) NOT IN(0,160) THEN MAX(C.TRRATE)  ELSE NULL END ISLEMKURU  " +
"      ,0  AS BAREM_,  " +
" SUM(DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN " +
" (CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) " +
" ELSE B.PROCDATE END, (CLF.DATE_)), B.DATE_))  AS VADE,  " +
" CASE WHEN(CLF.SPECODE = 'Adsadsa' OR CLF.CYPHCODE = 'Asdada') THEN 0 ELSE " +
" (DATEDIFF(dd, B.PROCDATE, C.DATE_) - DATEDIFF(dd, B.PROCDATE, B.DATE_)) " +
" END AS VADEDENSAPMA,  " +
" SUM((DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN(CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) ELSE B.PROCDATE END, (CLF.DATE_)), B.DATE_) +  " +
" CASE " +
" WHEN((DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN(CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) " +
" ELSE B.PROCDATE END, (CLF.DATE_)), C.DATE_) - DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN " +
" (CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) ELSE B.PROCDATE END, (CLF.DATE_)), B.DATE_)) > 0) " +
" AND 1 = 2 " +
" THEN 0 ELSE(DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN(CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) " +
" ELSE B.PROCDATE END, (CLF.DATE_)), C.DATE_) - DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN " +
" (CASE WHEN B.DEVIRPROCDATE IS NULL THEN(CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) ELSE B.PROCDATE END, (CLF.DATE_)), B.DATE_)) END " +
"                )) AS TOPLAMVADE,  " +
" (DATEDIFF(dd, ISNULL(CASE WHEN B.MODULENR = 5 THEN(CASE WHEN B.DEVIRPROCDATE IS NULL THEN " +
" (CASE WHEN CL1.DEVIRPROCDATE IS NULL THEN CL1.DATE_ ELSE CL1.DEVIRPROCDATE END) ELSE B.DEVIRPROCDATE END) ELSE B.PROCDATE END, (CLF.DATE_)), C.PROCDATE)) AS TAHSILATHIZI  " +
"      ,0  AS ISKONTO  " +
"      ,CL1.LINEEXP AS ACIKLAMA " +
"      , CASE WHEN C.MODULENR IN(5,6) AND C.TRCODE IN(1,2,70) THEN C.DATE_ else C.PROCDATE END AS " +
" NAKITEDONUS " +
"      ,CASE when B.TRCODE = 1 and B.MODULENR = 10 THEN 'Nakit Tahsilat' " +
" when B.TRCODE = 2 and B.MODULENR = 10 THEN 'Nakit Ödeme' " +
" when B.TRCODE = 11 and B.MODULENR = 10 THEN 'Cari Hesap Tahsilat' " +
" when B.TRCODE = 12 and B.MODULENR = 10 THEN 'Cari Hesap Ödeme' " +
" when B.TRCODE = 21 and B.MODULENR = 10 THEN 'Bankaya Yatırılan' " +
" when B.TRCODE = 12 and B.MODULENR = 10 THEN 'Bankadan Çekilen' " +
" when B.TRCODE = 31 and B.MODULENR = 10 THEN 'Satınalma Faturası' " +
" when B.TRCODE = 32 and B.MODULENR = 10 THEN 'Perakende Satış İade Faturası' " +
" when B.TRCODE = 33 and B.MODULENR = 10 THEN 'Toptan Satış İade Faturası' " +
" when B.TRCODE = 34 and B.MODULENR = 10 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 35 and B.MODULENR = 10 THEN 'Satınalma İade Faturası' " +
" when B.TRCODE = 36 and B.MODULENR = 10 THEN 'Perakende Satış Faturası' " +
" when B.TRCODE = 37 and B.MODULENR = 10 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 38 and B.MODULENR = 10 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 39 and B.MODULENR = 10 THEN 'Müstahsil Makbuzu' " +
" when B.TRCODE = 41 and B.MODULENR = 10 THEN 'Muh. Tahsil' " +
" when B.TRCODE = 42 and B.MODULENR = 10 THEN 'Muh. Tediye' " +
" when B.TRCODE = 61 and B.MODULENR = 10 THEN 'Çek Tahsili' " +
" when B.TRCODE = 62 and B.MODULENR = 10 THEN 'Senet Tahsili' " +
" when B.TRCODE = 63 and B.MODULENR = 10 THEN 'Çek Ödemesi' " +
" when B.TRCODE = 64 and B.MODULENR = 10 THEN 'Senet Ödemesi' " +
" when B.TRCODE = 71 and B.MODULENR = 10 THEN 'Açılış (Borç)' " +
" when B.TRCODE = 72 and B.MODULENR = 10 THEN 'Açılış (Alacak)' " +
" when B.TRCODE = 73 and B.MODULENR = 10 THEN 'Virman (Borç)' " +
" when B.TRCODE = 74 and B.MODULENR = 10 THEN 'Virman (Alacak)' " +
" when B.TRCODE = 75 and B.MODULENR = 10 THEN 'Gider Pusulası' " +
" when B.TRCODE = 76 and B.MODULENR = 10 THEN 'Verilen Serbest Mes' " +
" when B.TRCODE = 77 and B.MODULENR = 10 THEN 'Alınan Serbest Mes' " +
" when B.TRCODE = 1 and B.MODULENR = 6 THEN 'Çek Girişi' " +
" when B.TRCODE = 2 and B.MODULENR = 6 THEN 'Senet Girişi' " +
" when B.TRCODE = 3 and B.MODULENR = 6 THEN 'Çek Çıkış Cari Hesaba' " +
" when B.TRCODE = 4 and B.MODULENR = 6 THEN 'Senet Çıkış Cari Hesaba' " +
" when B.TRCODE = 5 and B.MODULENR = 6 THEN 'Çek Çıkış Banka Tahsil' " +
" when B.TRCODE = 6 and B.MODULENR = 6 THEN 'Senet Çıkış Banka Tahsil' " +
" when B.TRCODE = 7 and B.MODULENR = 6 THEN 'Çek Çıkış Banka Teminat' " +
" when B.TRCODE = 8 and B.MODULENR = 6 THEN 'Senet Çıkış Banka Teminat' " +
" when B.TRCODE = 9 and B.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri çeki' " +
" when B.TRCODE = 10 and B.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri Senedi' " +
" when B.TRCODE = 11 and B.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Çekimiz' " +
" when B.TRCODE = 12 and B.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Senedimiz' " +
" when B.TRCODE = 13 and B.MODULENR = 6 THEN 'İşyerleri Arası İ.Bordrosu Müşteri Çeki' " +
" when B.TRCODE = 1 and B.MODULENR = 7 THEN 'Banka İşlem Fişi' " +
" when B.TRCODE = 2 and B.MODULENR = 7 THEN 'Banka Virman Fişi' " +
" when B.TRCODE = 3 and B.MODULENR = 7 THEN 'Gelen Havale / Eft' " +
" when B.TRCODE = 4 and B.MODULENR = 7 THEN 'Gönderilen Havale / Eft' " +
" when B.TRCODE = 5 and B.MODULENR = 7 THEN 'Banka Açılış Fişi' " +
" when B.TRCODE = 6 and B.MODULENR = 7 THEN 'Banka Kur Farkı Fişi' " +
" when B.TRCODE = 7 and B.MODULENR = 7 THEN 'Döviz Alış Belgesi' " +
" when B.TRCODE = 8 and B.MODULENR = 7 THEN 'Döviz Satış Belgesi' " +
" when B.TRCODE = 16 and B.MODULENR = 7 THEN 'Banka Alınan Hizmet Faturası' " +
" when B.TRCODE = 17 and B.MODULENR = 7 THEN 'Banka Verilen Hizmet Faturası' " +
" when B.TRCODE = 18 and B.MODULENR = 7 THEN 'Bankadan Çek Ödemesi' " +
" when B.TRCODE = 19 and B.MODULENR = 7 THEN 'Bankadan Senet Ödemesi' " +
" when B.TRCODE = 1 and B.MODULENR = 5 THEN 'Nakit Tahsilat' " +
" when B.TRCODE = 2 and B.MODULENR = 5 THEN 'Nakit Ödeme' " +
" when B.TRCODE = 3 and B.MODULENR = 5 THEN 'Borç Dekontu' " +
" when B.TRCODE = 4 and B.MODULENR = 5 THEN 'Alacak Dekontu' " +
" when B.TRCODE = 5 and B.MODULENR = 5 THEN 'Virman Işlemi' " +
" when B.TRCODE = 6 and B.MODULENR = 5 THEN 'Kur Farkı İşlemi' " +
" when B.TRCODE = 12 and B.MODULENR = 5 THEN 'Özel İşlem' " +
" when B.TRCODE = 20 and B.MODULENR = 5 THEN 'Gelen Havaleler' " +
" when B.TRCODE = 21 and B.MODULENR = 5 THEN 'Gönderilen Havaleler' " +
" when B.TRCODE = 31 and B.MODULENR = 5 THEN 'Mal Alım Faturası' " +
" when B.TRCODE = 32 and B.MODULENR = 5 THEN 'Perakende Satış İade Faturası' " +
" when B.TRCODE = 24 and B.MODULENR = 5 THEN 'Döviz Alış Belgesi' " +
" when B.TRCODE = 25 and B.MODULENR = 5 THEN 'Döviz Satış Belgesi' " +
" when B.TRCODE = 33 and B.MODULENR = 5 THEN 'Toptan Satış İade Faturası' " +
" when B.TRCODE = 34 and B.MODULENR = 5 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 35 and B.MODULENR = 5 THEN 'Alınan Proforma Faturası' " +
" when B.TRCODE = 36 and B.MODULENR = 5 THEN 'Alım İade Faturası' " +
" when B.TRCODE = 37 and B.MODULENR = 5 THEN 'Perakende Satış Faturası' " +
" when B.TRCODE = 38 and B.MODULENR = 5 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 39 and B.MODULENR = 5 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 40 and B.MODULENR = 5 THEN 'Verilen Proforma Faturası' " +
" when B.TRCODE = 41 and B.MODULENR = 5 THEN 'Verilen Vade Farkı Faturası' " +
" when B.TRCODE = 42 and B.MODULENR = 5 THEN 'Alınan Vade Farkı Faturası' " +
" when B.TRCODE = 43 and B.MODULENR = 5 THEN 'Alınan Fiyat Farkı Faturası' " +
" when B.TRCODE = 44 and B.MODULENR = 5 THEN 'Verilen Fiyat Farkı Faturası' " +
" when B.TRCODE = 46 and B.MODULENR = 5 THEN 'Alınan Serbest Meslek Makbuzu' " +
" when B.TRCODE = 28 and B.MODULENR = 5 THEN 'Banka Alınan Hizmet Faturası' " +
" when B.TRCODE = 56 and B.MODULENR = 5 THEN 'Müsthsil Makbuzu' " +
" when B.TRCODE = 61 and B.MODULENR = 5 THEN 'Çek Girişi' " +
" when B.TRCODE = 62 and B.MODULENR = 5 THEN 'Senet Girişi' " +
" when B.TRCODE = 63 and B.MODULENR = 5 THEN 'Çek Çıkış Cari Hesaba' " +
" when B.TRCODE = 64 and B.MODULENR = 5 THEN 'Senet Çıkış Cari Hesaba' " +
" when B.TRCODE = 70 and B.MODULENR = 5 THEN 'Kredik Kartı Fişi' " +
" when B.TRCODE = 71 and B.MODULENR = 5 THEN 'Kredik Kartı İade Fişi' " +
" when B.TRCODE = 14 and B.MODULENR = 5 THEN 'Açılış Fişi' " +
" when B.TRCODE = 2 and B.MODULENR = 4 THEN 'Perakende Satış İade' " +
" when B.TRCODE = 3 and B.MODULENR = 4 THEN 'Toptan Satış İade' " +
" when B.TRCODE = 7 and B.MODULENR = 4 THEN 'Perakede Satış Faturası' " +
" when B.TRCODE = 8 and B.MODULENR = 4 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 9 and B.MODULENR = 4 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 10 and B.MODULENR = 4 THEN 'Verilen Proforma Faturası' " +
" when B.TRCODE = 14 and B.MODULENR = 4 THEN 'Verilen Fiyat Farkı Faturası' " +
" when B.TRCODE = 1 and B.MODULENR = 4 THEN 'Mal Alım Faturası' " +
" when B.TRCODE = 4 and B.MODULENR = 4 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 5 and B.MODULENR = 4 THEN 'Alınan Proforma Faturası' " +
" when B.TRCODE = 6 and B.MODULENR = 4 THEN 'Alım İade Faturası' " +
" when B.TRCODE = 13 and B.MODULENR = 4 THEN 'Alınan Fiyat Farkı Faturası' " +
" when B.TRCODE = 41 and B.MODULENR = 4 THEN 'Verilen Vade Farkı Faturası' " +
" when B.TRCODE = 42 and B.MODULENR = 4 THEN 'Alınan Vade Farkı Faturası' " +
" when B.TRCODE = 26 and B.MODULENR = 4 THEN 'Müstahsil Makbuzu' " +
" when B.TRCODE = 1 and B.MODULENR = 3 THEN 'Ödemeli Satış Siparişi' " +
" when B.TRCODE = 2 and B.MODULENR = 3 THEN 'Ödemeli Satınalma Siparişi' " +
" when B.TRCODE = 3 and B.MODULENR = 61 THEN 'Borç Dekontu' " +
" when B.TRCODE = 4 and B.MODULENR = 61 THEN 'Alacak Dekontu' " +
" WHEN B.MODULENR = 5 then 'Açılış Fişi' end AS KAPAMAISLEMI " +
"      ,MAX(mer.FICHENO) KAPATILANFATURA " +
"      ,MAX(CL.LOGICALREF) + '-' + MAX(C.LOGICALREF)CREF_ " +
"      ,MAX(B.DATE_) FATURAVADETARIHI " +
" FROM #PAYTRANSTAHTAKDET1 C  " +
" INNER JOIN #PAYTRANSTAHTAKDET1 B ON B.CROSSREF = C.LOGICALREF   " +
" INNER JOIN #CLCARDTAHTAKDET1 CL ON B.CARDREF = CL.LOGICALREF AND C.CARDREF=CL.LOGICALREF  " +
" INNER JOIN #CLFLINETAHTAKDET1 CL1 ON B.CARDREF=CL1.CLIENTREF  AND CL.LOGICALREF=CL1.CLIENTREF AND (((CL1.SOURCEFREF=B.FICHEREF) AND B.MODULENR<>5)OR  " +
" ((CL1.LOGICALREF = B.FICHEREF)AND B.MODULENR<>4))  " +
" INNER JOIN #CLFLINETAHTAKDET1 CLF ON C.CARDREF=CLF.CLIENTREF AND   " +
" CL.LOGICALREF = CLF.CLIENTREF AND((CLF.SOURCEFREF = C.FICHEREF) " +
" OR(CLF.LOGICALREF = C.FICHEREF)AND C.MODULENR = 5) " +
" LEFT OUTER JOIN #INVOICE1 MER ON CL1.CLIENTREF=MER.CLIENTREF AND B.FICHEREF=MER.LOGICALREF  " +
" LEFT JOIN #PAYPLANS1 PP ON PP.LOGICALREF=CL1.PAYDEFREF  " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PROJECT PR ON MER.PROJECTREF = PR.LOGICALREF " +
" WHERE(C.CANCELLED = 0) AND(B.SIGN = 0) AND(C.SIGN = 1) " +
" AND CL.ACTIVE IN ( " + AnaForm.aktifKayilar + ")" +
" AND((B.MODULENR = 4 AND CL1.DEVIRPROCDATE IS NULL) " +
" OR(B.MODULENR<>4 AND CL1.DEVIRPROCDATE IS NOT NULL) " +
" OR(C.MODULENR > 0 AND C.TRCODE > 0) " +
"       )  " +
" and(CL1.SIGN = 0) AND(CLF.SIGN = 1) " +
" AND C.PROCDATE BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' " +
" AND(0 = 1 " +
" OR(PR.CODE = '1') " +
" OR(PR.CODE IS NULL AND C.MODULENR = 5) " +
" OR(PR.CODE IS NULL AND CL1.MODULENR = 5) " +
" OR((C.MODULENR = 10 AND C.TRCODE = 1)) " +
" OR((C.MODULENR = 7 AND C.TRCODE = 3)/*AND (BNL.SPECODE NOT LIKE '%KK%')*/ )  " +
" OR((C.MODULENR = 6 AND C.TRCODE = 1) )  " +
" OR((C.MODULENR = 6 AND C.TRCODE = 2) )  " +
" OR((C.MODULENR = 5 AND C.TRCODE = 5) )  " +
" OR((C.MODULENR = 5 AND C.TRCODE = 70) /*OR (BNL.SPECODE LIKE '%KK%')*/ )  " +
" OR((C.MODULENR = 4 AND C.TRCODE = 4)OR(C.MODULENR = 5 AND C.TRCODE = 4)OR(C.MODULENR = 4 AND C.TRCODE = 3)OR(C.MODULENR = 5 AND C.TRCODE = 14) )  " +
" OR((C.MODULENR = 4 AND C.TRCODE = 1) )  " +
"      )  " +
" GROUP BY CL1.BRANCH, CL.CODE, CL.DEFINITION_, C.LOGICALREF,C.PROCDATE,B.TRCODE,B.MODULENR,C.TRCODE, C.MODULENR,B.PROCDATE,CL1.TRANNO,MER.SPECODE,CLF.DATE_,  " +
" MER.CYPHCODE,B.DATE_,C.DATE_,CL1.LINEEXP,CL1.TRCODE,B.APPROVENUM,CLF.SPECODE,CLF.CYPHCODE,B.DEVIRPROCDATE,CL1.DEVIRPROCDATE,CL1.DOCODE,CL1.DATE_ " +
" UNION " +
" SELECT CL1.BRANCH, " +
" CL.CODE KOD, CL.DEFINITION_ UNVAN, CL1.TRANNO FATURANO, NULL AS FATURATARIHI, B.PROCDATE AS TAHSILATTARIHI " +
"      ,'2' SIRA " +
"      ,CASE when B.TRCODE = 1 and B.MODULENR = 10 THEN 'Nakit Tahsilat' " +
" when B.TRCODE = 2 and B.MODULENR = 10 THEN 'Nakit Ödeme' " +
" when B.TRCODE = 11 and B.MODULENR = 10 THEN 'Cari Hesap Tahsilat' " +
" when B.TRCODE = 12 and B.MODULENR = 10 THEN 'Cari Hesap Ödeme' " +
" when B.TRCODE = 21 and B.MODULENR = 10 THEN 'Bankaya Yatırılan' " +
" when B.TRCODE = 12 and B.MODULENR = 10 THEN 'Bankadan Çekilen' " +
" when B.TRCODE = 31 and B.MODULENR = 10 THEN 'Satınalma Faturası' " +
" when B.TRCODE = 32 and B.MODULENR = 10 THEN 'Perakende Satış İade Faturası' " +
" when B.TRCODE = 33 and B.MODULENR = 10 THEN 'Toptan Satış İade Faturası' " +
" when B.TRCODE = 34 and B.MODULENR = 10 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 35 and B.MODULENR = 10 THEN 'Satınalma İade Faturası' " +
" when B.TRCODE = 36 and B.MODULENR = 10 THEN 'Perakende Satış Faturası' " +
" when B.TRCODE = 37 and B.MODULENR = 10 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 38 and B.MODULENR = 10 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 39 and B.MODULENR = 10 THEN 'Müstahsil Makbuzu' " +
" when B.TRCODE = 41 and B.MODULENR = 10 THEN 'Muh. Tahsil' " +
" when B.TRCODE = 42 and B.MODULENR = 10 THEN 'Muh. Tediye' " +
" when B.TRCODE = 61 and B.MODULENR = 10 THEN 'Çek Tahsili' " +
" when B.TRCODE = 62 and B.MODULENR = 10 THEN 'Senet Tahsili' " +
" when B.TRCODE = 63 and B.MODULENR = 10 THEN 'Çek Ödemesi' " +
" when B.TRCODE = 64 and B.MODULENR = 10 THEN 'Senet Ödemesi' " +
" when B.TRCODE = 71 and B.MODULENR = 10 THEN 'Açılış (Borç)' " +
" when B.TRCODE = 72 and B.MODULENR = 10 THEN 'Açılış (Alacak)' " +
" when B.TRCODE = 73 and B.MODULENR = 10 THEN 'Virman (Borç)' " +
" when B.TRCODE = 74 and B.MODULENR = 10 THEN 'Virman (Alacak)' " +
" when B.TRCODE = 75 and B.MODULENR = 10 THEN 'Gider Pusulası' " +
" when B.TRCODE = 76 and B.MODULENR = 10 THEN 'Verilen Serbest Mes' " +
" when B.TRCODE = 77 and B.MODULENR = 10 THEN 'Alınan Serbest Mes' " +
" when B.TRCODE = 1 and B.MODULENR = 6 THEN 'Çek Girişi' " +
" when B.TRCODE = 2 and B.MODULENR = 6 THEN 'Senet Girişi' " +
" when B.TRCODE = 3 and B.MODULENR = 6 THEN 'Çek Çıkış Cari Hesaba' " +
" when B.TRCODE = 4 and B.MODULENR = 6 THEN 'Senet Çıkış Cari Hesaba' " +
" when B.TRCODE = 5 and B.MODULENR = 6 THEN 'Çek Çıkış Banka Tahsil' " +
" when B.TRCODE = 6 and B.MODULENR = 6 THEN 'Senet Çıkış Banka Tahsil' " +
" when B.TRCODE = 7 and B.MODULENR = 6 THEN 'Çek Çıkış Banka Teminat' " +
" when B.TRCODE = 8 and B.MODULENR = 6 THEN 'Senet Çıkış Banka Teminat' " +
" when B.TRCODE = 9 and B.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri çeki' " +
" when B.TRCODE = 10 and B.MODULENR = 6 THEN 'İşlem Bordrosu Müşteri Senedi' " +
" when B.TRCODE = 11 and B.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Çekimiz' " +
" when B.TRCODE = 12 and B.MODULENR = 6 THEN 'İşlem Bordrosu Kendi Senedimiz' " +
" when B.TRCODE = 13 and B.MODULENR = 6 THEN 'İşyerleri Arası İ.Bordrosu Müşteri Çeki' " +
" when B.TRCODE = 1 and B.MODULENR = 7 THEN 'Banka İşlem Fişi' " +
" when B.TRCODE = 2 and B.MODULENR = 7 THEN 'Banka Virman Fişi' " +
" when B.TRCODE = 3 and B.MODULENR = 7 THEN 'Gelen Havale / Eft' " +
" when B.TRCODE = 4 and B.MODULENR = 7 THEN 'Gönderilen Havale / Eft' " +
" when B.TRCODE = 5 and B.MODULENR = 7 THEN 'Banka Açılış Fişi' " +
" when B.TRCODE = 6 and B.MODULENR = 7 THEN 'Banka Kur Farkı Fişi' " +
" when B.TRCODE = 7 and B.MODULENR = 7 THEN 'Döviz Alış Belgesi' " +
" when B.TRCODE = 8 and B.MODULENR = 7 THEN 'Döviz Satış Belgesi' " +
" when B.TRCODE = 16 and B.MODULENR = 7 THEN 'Banka Alınan Hizmet Faturası' " +
" when B.TRCODE = 17 and B.MODULENR = 7 THEN 'Banka Verilen Hizmet Faturası' " +
" when B.TRCODE = 18 and B.MODULENR = 7 THEN 'Bankadan Çek Ödemesi' " +
" when B.TRCODE = 19 and B.MODULENR = 7 THEN 'Bankadan Senet Ödemesi' " +
" when B.TRCODE = 1 and B.MODULENR = 5 THEN 'Nakit Tahsilat' " +
" when B.TRCODE = 2 and B.MODULENR = 5 THEN 'Nakit Ödeme' " +
" when B.TRCODE = 3 and B.MODULENR = 5 THEN 'Borç Dekontu' " +
" when B.TRCODE = 4 and B.MODULENR = 5 THEN 'Alacak Dekontu' " +
" when B.TRCODE = 5 and B.MODULENR = 5 THEN 'Virman Işlemi' " +
" when B.TRCODE = 6 and B.MODULENR = 5 THEN 'Kur Farkı İşlemi' " +
" when B.TRCODE = 12 and B.MODULENR = 5 THEN 'Özel İşlem' " +
" when B.TRCODE = 20 and B.MODULENR = 5 THEN 'Gelen Havaleler' " +
" when B.TRCODE = 21 and B.MODULENR = 5 THEN 'Gönderilen Havaleler' " +
" when B.TRCODE = 31 and B.MODULENR = 5 THEN 'Mal Alım Faturası' " +
" when B.TRCODE = 32 and B.MODULENR = 5 THEN 'Perakende Satış İade Faturası' " +
" when B.TRCODE = 24 and B.MODULENR = 5 THEN 'Döviz Alış Belgesi' " +
" when B.TRCODE = 25 and B.MODULENR = 5 THEN 'Döviz Satış Belgesi' " +
" when B.TRCODE = 33 and B.MODULENR = 5 THEN 'Toptan Satış İade Faturası' " +
" when B.TRCODE = 34 and B.MODULENR = 5 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 35 and B.MODULENR = 5 THEN 'Alınan Proforma Faturası' " +
" when B.TRCODE = 36 and B.MODULENR = 5 THEN 'Alım İade Faturası' " +
" when B.TRCODE = 37 and B.MODULENR = 5 THEN 'Perakende Satış Faturası' " +
" when B.TRCODE = 38 and B.MODULENR = 5 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 39 and B.MODULENR = 5 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 40 and B.MODULENR = 5 THEN 'Verilen Proforma Faturası' " +
" when B.TRCODE = 41 and B.MODULENR = 5 THEN 'Verilen Vade Farkı Faturası' " +
" when B.TRCODE = 42 and B.MODULENR = 5 THEN 'Alınan Vade Farkı Faturası' " +
" when B.TRCODE = 43 and B.MODULENR = 5 THEN 'Alınan Fiyat Farkı Faturası' " +
" when B.TRCODE = 44 and B.MODULENR = 5 THEN 'Verilen Fiyat Farkı Faturası' " +
" when B.TRCODE = 46 and B.MODULENR = 5 THEN 'Alınan Serbest Meslek Makbuzu' " +
" when B.TRCODE = 28 and B.MODULENR = 5 THEN 'Banka Alınan Hizmet Faturası' " +
" when B.TRCODE = 56 and B.MODULENR = 5 THEN 'Müsthsil Makbuzu' " +
" when B.TRCODE = 61 and B.MODULENR = 5 THEN 'Çek Girişi' " +
" when B.TRCODE = 62 and B.MODULENR = 5 THEN 'Senet Girişi' " +
" when B.TRCODE = 63 and B.MODULENR = 5 THEN 'Çek Çıkış Cari Hesaba' " +
" when B.TRCODE = 64 and B.MODULENR = 5 THEN 'Senet Çıkış Cari Hesaba' " +
" when B.TRCODE = 70 and B.MODULENR = 5 THEN 'Kredik Kartı Fişi' " +
" when B.TRCODE = 71 and B.MODULENR = 5 THEN 'Kredik Kartı İade Fişi' " +
" when B.TRCODE = 14 and B.MODULENR = 5 THEN 'Açılış Fişi' " +
" when B.TRCODE = 2 and B.MODULENR = 4 THEN 'Perakende Satış İade' " +
" when B.TRCODE = 3 and B.MODULENR = 4 THEN 'Toptan Satış İade' " +
" when B.TRCODE = 7 and B.MODULENR = 4 THEN 'Perakede Satış Faturası' " +
" when B.TRCODE = 8 and B.MODULENR = 4 THEN 'Toptan Satış Faturası' " +
" when B.TRCODE = 9 and B.MODULENR = 4 THEN 'Verilen Hizmet Faturası' " +
" when B.TRCODE = 10 and B.MODULENR = 4 THEN 'Verilen Proforma Faturası' " +
" when B.TRCODE = 14 and B.MODULENR = 4 THEN 'Verilen Fiyat Farkı Faturası' " +
" when B.TRCODE = 1 and B.MODULENR = 4 THEN 'Mal Alım Faturası' " +
" when B.TRCODE = 4 and B.MODULENR = 4 THEN 'Alınan Hizmet Faturası' " +
" when B.TRCODE = 5 and B.MODULENR = 4 THEN 'Alınan Proforma Faturası' " +
" when B.TRCODE = 6 and B.MODULENR = 4 THEN 'Alım İade Faturası' " +
" when B.TRCODE = 13 and B.MODULENR = 4 THEN 'Alınan Fiyat Farkı Faturası' " +
" when B.TRCODE = 41 and B.MODULENR = 4 THEN 'Verilen Vade Farkı Faturası' " +
" when B.TRCODE = 42 and B.MODULENR = 4 THEN 'Alınan Vade Farkı Faturası' " +
" when B.TRCODE = 26 and B.MODULENR = 4 THEN 'Müstahsil Makbuzu' " +
" when B.TRCODE = 1 and B.MODULENR = 3 THEN 'Ödemeli Satış Siparişi' " +
" when B.TRCODE = 2 and B.MODULENR = 3 THEN 'Ödemeli Satınalma Siparişi' " +
" when B.TRCODE = 3 and B.MODULENR = 61 THEN 'Borç Dekontu' " +
" when B.TRCODE = 4 and B.MODULENR = 61 THEN 'Alacak Dekontu' end AS TAHSILSEKLI " +
"      ,B.TOTAL * (CASE WHEN B.TRRATE = 0 THEN 1 ELSE B.TRRATE END) AS TASILATTUTARI  " +
"      ,CASE WHEN(B.TRCURR> 0) AND B.TRCURR<>160 THEN B.TOTAL ELSE 0 END AS TahTutDvz " +
"      ,B.TRCURR AS DOVIZTURU " +
"      ,CASE WHEN B.TRCURR = 1 THEN 'USD' WHEN B.TRCURR = 10 THEN 'EUR' ELSE 'TL' END DOVIZ  " +
"      ,CASE WHEN(B.TRCURR) NOT IN(0,160) THEN(B.TRRATE)  ELSE NULL END ISLEMKURU  " +
"      ,0  AS BAREM_,null VADE,null VADEDENSAPMA,null  TOPLAMVADE,null  TAHSILATHIZI,null ISKONTO,null ACIKLAMA " +
"      ,B.DATE_ NAKITEDONUS, null KAPAMAISLEMI ,null KAPATILANFATURA " +
"      ,CL.LOGICALREF + '-' + B.LOGICALREF ASD " +
"      ,null FATURAVADETARIHI " +
" FROM #PAYTRANSTAHTAKDET1 B  " +
" INNER JOIN #CLCARDTAHTAKDET1 CL ON B.CARDREF = CL.LOGICALREF  " +
" INNER JOIN #CLFLINETAHTAKDET1 CL1 ON B.CARDREF=CL1.CLIENTREF  AND CL.LOGICALREF=CL1.CLIENTREF AND (((CL1.SOURCEFREF=B.FICHEREF) AND B.MODULENR<>5)OR  " +
" ((CL1.LOGICALREF = B.FICHEREF)AND B.MODULENR<>4))  " +
" LEFT OUTER JOIN #INVOICE1 MER ON CL1.CLIENTREF=MER.CLIENTREF AND B.FICHEREF=MER.LOGICALREF  " +
" WHERE 1 = 1 " +
" AND CL.ACTIVE IN (" + AnaForm.aktifKayilar + ") " +
" AND(0 = 1 " +
" OR 1 = 1 " +
" OR((B.MODULENR = 10 AND B.TRCODE = 1)) " +
" OR((B.MODULENR = 7 AND B.TRCODE = 3) )  " +
" OR((B.MODULENR = 6 AND B.TRCODE = 1) )  " +
" OR((B.MODULENR = 6 AND B.TRCODE = 2) )  " +
" OR((B.MODULENR = 5 AND B.TRCODE = 5) )  " +
" OR((B.MODULENR = 5 AND B.TRCODE = 70) )  " +
" OR((B.MODULENR = 4 AND B.TRCODE = 4)OR(B.MODULENR = 5 AND B.TRCODE = 4)OR(B.MODULENR = 4 AND B.TRCODE = 3)OR(B.MODULENR = 5 AND B.TRCODE = 14) )  " +
" OR((B.MODULENR = 4 AND B.TRCODE = 1) )  " +
"      )  " +
" AND B.PROCDATE BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' " +
" AND B.PAID = 0 AND B.SIGN = 1 " +
" AND MER.LOGICALREF IS NULL " +
"      )A ) AS KAPALIFATURALAR  " +
"       /* AÇIK FATURALAR */  " +
" SELECT MAX(SOURCEFREF)SOURCEFREF,MAX(LOGICALREF)LOGICALREF,MAX(TRADINGGRP)TRADINGGRP,MAX(BRANCH)BRANCH,CLIENTREF " +
"      ,SUM(CASE WHEN SIGN = 0 THEN AMOUNT ELSE - AMOUNT END)TOPLAM " +
" INTO #CFLRISK FROM  " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE(NoLock) " +
" WHERE CANCELLED = 0 AND STATUS = 0 " +
" GROUP BY /*SOURCEFREF,*/CLIENTREF  " +
" SELECT * INTO #CLFLINERISKDETAY FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE(NoLock)   " +
" SELECT * INTO #PTTRANSRISKDETAY FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_PAYTRANS(NoLock)    " +
" SELECT * INTO #CLCARDRISKDETAY FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD(NoLock)   " +
" SELECT * INTO #ACIKFATURALAR FROM (  " +
" select  BRANCH, KOD,UNVAN, 'Açık İşlem' ISLEMTIPI,FATURANO,FATURATARIHI , NULL TAHSILATTARIHI,'' TAHSILSEKLI,TUTAR,TUTARDOVIZ, KUR DOVIZ, CASE WHEN DOVIZTUTAR<>0 THEN TUTAR/ DOVIZTUTAR ELSE 0 END ISLEMKURU, VADEGUNSAYISI VADEGUN,KALANGUN * -1 VADEDENSAPMA, ISNULL(VADEGUNSAYISI, 0) + KALANGUN * -1 AS TOPLAMVADE, ACIKLAMA, '' KAPAMAISLEMI,'' KAPATILANFATURA , VADE FATURAVADETARIHI, DOVIZTURU  " +
" from(  " +
"      /******************************   PEŞİN ÖDEMELER ********************************/  " +
" SELECT * FROM(  " +
" SELECT CF.BRANCH, MAX(PT.TRCURR) AS DOVIZTURU, MAX(PT.TRCURR)TRCURR, 0 PLOGICAL, 0 MN, '' BANKA,  " +
" '' BELGENO " +
"      , '' FATURANO " +
"      , 'Önceki Ödemeler Sonrası Kur Farkı' ISLEMTIPI " +
"      , '' PC,  " +
" 'MAX(CL.CODE)' AS KOD, 'MAX(CL.DEFINITION_)' AS UNVAN,  " +
" NULL AS FATURATARIHI,  " +
" 'Önceki Ödemeler Sonrası Kur Farkı' AS ACIKLAMA " +
"      , MAX(TOPLAM) - ISNULL(Sum(case when PT.SIGN = 0 THEN PT.TOTAL* CASE WHEN PT.TRRATE = 0 AND PT.TRCURR IN(0,160) THEN 1 ELSE(CASE WHEN ISNULL(PT.TRRATE, 0) = 0 THEN(CF.AMOUNT / NULLIF(CF.TRNET, 0)) ELSE PT.TRRATE END) END ELSE   -PT.TOTAL * CASE WHEN PT.TRRATE = 0 AND PT.TRCURR IN(0,160) THEN 1 ELSE(CASE WHEN ISNULL(PT.TRRATE, 0) = 0 THEN(CF.AMOUNT / NULLIF(CF.TRNET, 0)) ELSE PT.TRRATE END) END END),0.00)   " +
" AS TUTAR " +
"      ,NULL VADE,  " +
" NULL AS GERCEKVADE,  " +
" 0 VADEGUNSAYISI,  " +
" 0 KALANGUN,  " +
" 0 GERCEKVADEGUNSAYISI,  " +
" 0 GERCEKKALANGUN,  " +
" 'Alacak' TIP " +
"      ,'' KUR " +
"      ,'' OZELKOD " +
"      ,0.01 ARATOPLAM, 0 ARAVADE,sum(PT.TOTAL) TUTARDOVIZ " +
"      ,'' PPCODE,0 INVOICEREF,0 MODULENR " +
"      ,0 AS DOVIZTUTAR,'' TICISLEM " +
" FROM  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_PAYTRANS PT(NoLock)  " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE(NoLock) CF ON(PT.PAID= 0) AND CF.STATUS = 0  AND(PT.PAIDINCASH = 0) " +
" AND(((CF.SOURCEFREF = PT.FICHEREF) AND PT.MODULENR<>5) " +
" OR((CF.LOGICALREF = PT.FICHEREF) AND PT.MODULENR<>4) )  " +
" AND PT.CARDREF = CF.CLIENTREF " +
" LEFT JOIN #CFLRISK CFL ON PT.CARDREF=CFL.CLIENTREF   " +
" where(PT.PAID = 0 AND PT.PAIDINCASH = 0) AND CF.CANCELLED = 0 " +
" AND(PT.MODULENR = CF.MODULENR OR PT.LOGICALREF IS NULL) " +
" AND(((CF.SOURCEFREF = PT.FICHEREF)AND PT.MODULENR<>5) " +
" OR((CF.LOGICALREF = PT.FICHEREF)AND PT.MODULENR<>4) " +
" OR(CF.MODULENR = 5 AND CF.TRCODE = 6))  " +
" group by CF.BRANCH, PT.CARDREF) A WHERE A.TRCURR > 0 " +
" union ALL " +
" SELECT CF.BRANCH, 0 AS DOVIZTURU, 0 TRCURR,PT.LOGICALREF PTREF,(CF.LOGICALREF)MN " +
"      ,B1.DEFINITION_ AS BANKA " +
"      ,CASE WHEN INV.DOCODE IS NULL THEN CF.DOCODE ELSE INV.DOCODE END DOCODE " +
"      , CASE WHEN INV.FICHENO IS NULL THEN CF.TRANNO ELSE INV.FICHENO END faturano " +
"      ,CASE WHEN CF.TRCODE = 1 then 'Nakit Tahsilat' " +
" WHEN CF.TRCODE = 2 then 'Nakit ödeme' " +
" WHEN CF.TRCODE = 3 AND CF.MODULENR = 61 then 'İade Çek' " +
" WHEN CF.TRCODE = 3 AND CF.MODULENR = 62 then 'İade Senet' " +
" WHEN CF.TRCODE = 4 AND CF.MODULENR = 61 then 'İade Çek Giriş' " +
" WHEN CF.TRCODE = 4 AND CF.MODULENR = 62 then 'İade Senet Giriş' " +
" WHEN CF.TRCODE = 3 then 'Borç Dekontu' " +
" WHEN CF.TRCODE = 4 then 'Alacak Dekontu' " +
" WHEN CF.TRCODE = 5 then 'Virman Işlemi' " +
" WHEN CF.TRCODE = 6 then 'Kurfark işlemi' " +
" WHEN CF.TRCODE = 12 then 'Özel İşlem' " +
" WHEN CF.TRCODE = 14 then 'Açılış Fişi' " +
" WHEN CF.TRCODE = 20 then 'Gelen Havale' " +
" WHEN CF.TRCODE = 21 then 'Gönderilen Havale' " +
" WHEN CF.TRCODE = 24 then 'Döviz Alış Belgesi' " +
" WHEN CF.TRCODE = 25 then 'Döviz Satış belgesi' " +
" WHEN CF.TRCODE = 28 then 'Alınan Hizmet Faturası' " +
" WHEN CF.TRCODE = 29 then 'Verilen Hizmet Faturası' " +
" WHEN CF.TRCODE = 31 then 'Satınalma Faturası' " +
" WHEN CF.TRCODE = 32 then 'Perakende İade Faturası' " +
" WHEN CF.TRCODE = 33 then 'Toptan Satış İade Faturası' " +
" WHEN CF.TRCODE = 34 then 'Alınan Hizmet Faturasıurası' " +
" WHEN CF.TRCODE = 35 then 'Alınan Proforma Faturası' " +
" WHEN CF.TRCODE = 36 then 'Alınan İade Faturası' " +
" WHEN CF.TRCODE = 37 then 'Perakende Satış Faturası' " +
" WHEN CF.TRCODE = 38 then 'Toptan Satış Faturası' " +
" WHEN CF.TRCODE = 39 then 'Verilen Hizmet Faturasıurası' " +
" WHEN CF.TRCODE = 40 then 'Verilen proforma Faturası' " +
" WHEN CF.TRCODE = 41 then 'Verilen vade farkı Faturası' " +
" WHEN CF.TRCODE = 42 then 'Alınan Vade farkı Faturası' " +
" WHEN CF.TRCODE = 43 then 'Alınan Fiyat Farkı Faturası' " +
" WHEN CF.TRCODE = 44 then 'Verilen fiyat farkı Faturası' " +
" WHEN CF.TRCODE = 45 then 'Verilen Serbest Meslek Makbuzu' " +
" WHEN CF.TRCODE = 46 then 'Alınan Serbest Meslek Makbuzu' " +
" WHEN CF.TRCODE = 56 then 'Müsthsil makbuzu' " +
" WHEN CF.TRCODE = 61 then 'Çek girişi' " +
" WHEN CF.TRCODE = 62 then 'Senet girişi' " +
" WHEN CF.TRCODE = 63 then 'Çek çıkış cari hesaba' " +
" WHEN CF.TRCODE = 64 then 'Senet çıkış cari hesaba' " +
" WHEN CF.TRCODE = 70 then 'Kredi Kartı Fişi' " +
" WHEN CF.TRCODE = 71 then 'Kredi Kartı İade Fişi' " +
" WHEN CF.TRCODE = 72 then 'Firma Kredi Kartı Fişi' " +
" WHEN CF.TRCODE = 73 then 'Firma Kredi Kartı İade Fişi' " +
" WHEN CF.TRCODE = 81 then 'Ödemeli Satış Siparişi' " +
" WHEN CF.TRCODE = 82 then 'Ödemeli Satınalma Siparişi' " +
" WHEN CF.TRCODE = 64 then 'Senet çıkış cari hesaba' else 'Diğer' end iTipi  " +
"      ,CASE WHEN INV.LOGICALREF IS NULL THEN PR2.CODE ELSE PR.CODE END AS PC,  " +
" CL.CODE AS CARINO, CL.DEFINITION_ AS UNVANI,  " +
" CASE WHEN CF.MODULENR = 5 and CF.DEVIRPROCDATE IS NOT NULL THEN CF.DEVIRPROCDATE ELSE CF.DATE_ END AS FATURATARIHI,  " +
" CF.LINEEXP AS aciklama  " +
"      ,ISNULL(PT.TOTAL * (CASE WHEN PT.TRCURR = 0 THEN 1 ELSE(CASE WHEN ISNULL(PT.TRRATE, 0) = 0 THEN(CF.AMOUNT / NULLIF(CF.TRNET, 0)) ELSE PT.TRRATE END) END),0) +(CASE WHEN CF.MODULENR = 5 AND CF.TRCODE = 6 THEN CASE WHEN CF.SIGN = 0 THEN CF.AMOUNT ELSE +CF.AMOUNT END ELSE 0 END)      " +
" AS TUTAR,  " +
" PT.DATE_ AS VADE,(PT.DATE_/*+ISNULL(DEF.NUMFLDS1,0)*/) AS GERCEKVADE,  " +
" CASE WHEN CF.MODULENR = 5 then DATEDIFF(dd, CF.DEVIRPROCDATE, PT.DATE_) else DATEDIFF(dd, CF.DATE_, PT.DATE_) end AS VADEGUNSAYISI,  " +
" DATEDIFF(dd,'" + AnaForm.bitisTarihi + "', PT.DATE_) AS KALANGUN,  " +
" DATEDIFF(dd, CF.DATE_, PT.DATE_)/*+ISNULL(DEF.NUMFLDS1,0)*/ AS GERCEKVADEGUNSAYISI  " +
"      , DATEDIFF(dd, '" + AnaForm.bitisTarihi + "', PT.DATE_)/*+ISNULL(DEF.NUMFLDS1,0)*/ AS GERCEKKALANGUN,  " +
" CASE WHEN CF.SIGN = 1 THEN 'Borç' ELSE 'Alacak' END AS TIP " +
"      ,CASE WHEN(LC.CURCODE = '') or(LC.CURCODE is null) THEN 'TL' ELSE LC.CURCODE END Kuru " +
"      ,CASE WHEN INV.SPECODE IS NULL THEN CF.SPECODE ELSE INV.SPECODE END SPECODE " +
"      ,0.01 Aratoplam, 0 aravade,PT.TOTAL TutarDVZ  " +
"      ,PP.CODE PPCODE, CF.SOURCEFREF INVOICEREF, CF.MODULENR " +
"      ,CASE WHEN PT.TRCURR IN(0,160) THEN 0 ELSE PT.TOTAL END AS DOVIZTUTAR  " +
"      ,INV.TRADINGGRP TICISLEM  " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE CF(NoLock)  " +
" INNER JOIN(SELECT * FROM #CLCARDRISKDETAY   " +
" WHERE ACTIVE IN (" + AnaForm.aktifKayilar + ") " +
"        ) CL ON /*CL.ACTIVE=0 AND*/ CL.LOGICALREF = CF.CLIENTREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_PAYTRANS PT(NoLock) ON PT.CARDREF = CF.CLIENTREF " +
" AND(PT.PAID = 0)   AND(PT.PAIDINCASH = 0) " +
" AND(((CF.SOURCEFREF = PT.FICHEREF) AND PT.MODULENR<>5) " +
" OR((CF.LOGICALREF = PT.FICHEREF) AND PT.MODULENR<>4) )  " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYPLANS PP(NoLock) ON PP.LOGICALREF = CF.PAYDEFREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_INVOICE INV(NoLock) ON(INV.LOGICALREF = CF.SOURCEFREF AND INV.CLIENTREF = CL.LOGICALREF AND PT.MODULENR = 4) " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_STLINE SL(NoLock) ON SL.INVOICEREF = INV.LOGICALREF AND SL.INVOICELNNO = 1 " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_DEFNFLDSTRANV DF2(NoLock) ON SL.ORDFICHEREF = DF2.PARENTREF AND DF2.MODULENR = 8 " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_BANKACC AS B1(NoLock) ON B1.LOGICALREF = PT.BANKACCREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PROJECT PR(NoLock) ON INV.PROJECTREF = PR.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PROJECT PR2(NoLock) ON CF.CLPRJREF = PR2.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.L_CURRENCYLIST LC ON LC.CURTYPE = PT.TRCURR AND LC.FIRMNR = '" + AnaForm.firma + "' " +
" WHERE CL.ACTIVE IN (" + AnaForm.aktifKayilar + ") " +
" AND CF.CANCELLED = 0 AND CF.STATUS = 0 AND((PT.PAID = 0 AND PT.PAIDINCASH = 0) )  " +
" AND(PT.MODULENR = CF.MODULENR OR PT.LOGICALREF IS NULL) " +
" AND(((CF.SOURCEFREF = PT.FICHEREF)AND PT.MODULENR<>5) " +
" OR((CF.LOGICALREF = PT.FICHEREF)AND PT.MODULENR<>4) " +
" OR(CF.MODULENR = 5 AND CF.TRCODE = 6) " +
"      )  " +
" AND((PT.FICHEREF = CF.SOURCEFREF AND CF.TRCODE IN(61, 62)) OR CF.TRCODE NOT IN(61, 62))  " +
"      )a " +
" WHERE(a.Tutar < 0 OR a.Tutar > 0) " +
" AND KOD NOT LIKE 'MAX%' ) AS ACIKFATURALAR  " +
"  /* AÇIK FATURALAR BITIS */  " +
"     /* FATURA URUN LISTESI BAŞLANLAGIÇ */  " +
" SELECT LOGICALREF, VATINC," +
" SATIRTIPI,FATURANO, Convert(date, [FATURATARIHI]) as FATURATARIHI, CARIKODU, CARIADI,  " +
" URUNKODU, URUN, MIKTAR , FIYAT, KDV,INDIRIMTOPLAMI, TUTAR,    KDVTOPLAM, NETTOPLAM, VADE,FATURAACIKLAMA, KUR,   " +
" DOVIZFIYAT,ISNULL(DOVIZKDV, 0) DOVIZKDV,ISNULL(DOVIZTUTAR, 0)DOVIZTUTAR,DOVIZINDIRIMTOPLAM,DOVIZMASRAFTOPLAM,DOVIZKDVTOPLAM,ISNULL(DOVIZNETTOPLAM, 0) DOVIZNETTOPLAM,DOVIZ,RAPORLAMADOVIZ,RAPORLAMADOVIZFIYAT,RAPORLAMADOVIZKURU,RAPORLAMADOVIZTOPLAM " +
" INTO #FATURALISTESI FROM (  " +
" Select * From(SELECT STL.LOGICALREF, STL.VATINC," +
" MAX(STL.AMOUNT) MIKTAR,  " +
" MAX(CASE WHEN LINETYPE IN(0, 1) THEN AB.CODE ELSE '' END) BIRIM " +
"   , MAX(STL.INVOICEREF) INVOICEREF " +
"   , MAX(STL.INVOICELNNO) LINENO_, max(STL.LINETYPE) LINETYPE " +
"   , max(case  " +
" when STL.TRCODE IN(7,8)AND LINETYPE IN(0) THEN  'Satış' " +
" when STL.TRCODE IN(7,8)AND LINETYPE IN(1) THEN  'Promosyon' " +
" when STL.TRCODE IN(7,8)AND LINETYPE IN(2) THEN  'Satış İndirim' " +
" when STL.TRCODE IN(7,8)AND LINETYPE IN(3) THEN  'Masraf' " +
" WHEN STL.TRCODE IN(3)AND LINETYPE IN(0, 1) then 'Satış İade' " +
" when STL.TRCODE IN(3)AND LINETYPE IN(2) THEN  'Satış İ.İndirim' " +
" WHEN STL.TRCODE IN(1,26)AND LINETYPE IN(0, 1) then 'Alış' " +
" WHEN STL.TRCODE IN(1,26)AND LINETYPE IN(2) then 'Alış İndirim' " +
" WHEN STL.TRCODE IN(3) then 'Alış İade' " +
" WHEN STL.TRCODE IN(4) and LINETYPE IN(4) then 'Alınan Hizmet Faturası' " +
" WHEN STL.TRCODE IN(3)AND LINETYPE IN(2) then 'Alış İ.İndirim' " +
" WHEN STL.TRCODE IN(9)AND LINETYPE IN(4) then 'Verilen Hizmet Faturası' " +
"   else 'Tanımsız' end) SATIRTIPI,max(STL.VAT)KDVORANI,  " +
" max(INV.FICHENO) FATURANO,max(INV.DATE_) FATURATARIHI " +
"   ,MAX(CLC.CODE) CARIKODU, MAX(CLC.DEFINITION_) CARIADI " +
"   ,SUM(CASE WHEN STL.TRCODE IN(7, 8, 1, 26, 9, 4)AND STL.LINETYPE IN(3) THEN(STL.TOTAL) " +
" WHEN STL.TRCODE IN(3)AND STL.LINETYPE IN(3) THEN - (STL.TOTAL)ELSE 0 END) AS MASRAF  " +
"   ,max(CASE WHEN STL.LINETYPE IN(0, 1) THEN  ITS.CODE " +
" WHEN STL.LINETYPE IN(3)   THEN  EMH.CODE " +
" WHEN STL.LINETYPE IN(4)   THEN  SRV.CODE " +
" WHEN STL.LINETYPE IN(2)   THEN   DC.CODE   ELSE '' END) URUNKODU " +
"   ,max(CASE WHEN STL.LINETYPE IN(0, 1) THEN  ITS.NAME " +
" WHEN STL.LINETYPE IN(3)   THEN  EMH.DEFINITION_ " +
" WHEN STL.LINETYPE IN(4)   THEN  SRV.DEFINITION_ " +
" WHEN STL.LINETYPE IN(2)   THEN  DC.DEFINITION_   ELSE '' END) URUN " +
"   ,CASE WHEN SUM(STL.AMOUNT / AB.CONVFACT1 * AB2.CONVFACT1 / AB2.CONVFACT2) IS NULL  " +
" THEN SUM(STL.AMOUNT) ELSE SUM(STL.AMOUNT/ AB.CONVFACT1 * AB2.CONVFACT1 / AB2.CONVFACT2 ) END MIKTAR_  " +
"   ,SUM(STL.PRICE) FIYAT " +
"   ,SUM(CASE WHEN STL.LINETYPE IN(0, 3, 4/*,1*/) THEN STL.VATAMNT ELSE 0 END) KDV " +
"   ,SUM(CASE WHEN STL.TRCODE IN(7, 8, 1, 26, 9, 4)AND STL.LINETYPE IN(0, 4) THEN(STL.TOTAL / 1) " +
" WHEN STL.TRCODE IN(3)AND STL.LINETYPE IN(0, 4) THEN - (STL.TOTAL / 1)ELSE 0 END) AS TUTAR  " +
"   ,MAX(INV.TOTALDISCOUNTS) INDIRIMTOPLAMI,  " +
" MAX(INV.TOTALEXPENSES) MASRAFTOPLAM " +
"   ,MAX(INV.TOTALvat) KDVToplam,MAX(INV.NETTOTAL) NETTOPLAM " +
"   ,MAX(PYP.CODE) VADE " +
"   ,SUM(CASE WHEN STL.TRCODE IN(7, 8, 1, 26,4)  THEN(CASE WHEN STL.LINETYPE IN(1, 2) THEN  STL.TOTAL ELSE 0 END) " +
" WHEN STL.TRCODE IN(3)    THEN(CASE WHEN STL.LINETYPE IN(1, 2) THEN - STL.TOTAL ELSE 0 END) ELSE 0 END) AS INDIRIM  " +
"   ,sum(CASE WHEN STL.TRCODE IN(1, 26, 7, 8) AND STL.TRCODE NOT IN(3, 6) THEN " +
" DATEDIFF(DAY, STL.DATE_, CASE WHEN PYL.YEAR_ > '' THEN CAST(PYL.YEAR_ + '-' + PYL.MOUNTH + '-' + PYL.DAY_ AS DATETIME) " +
" WHEN LEFT(PYL.DAY_, 1) = '+' THEN STL.DATE_ + CAST(REPLACE(PYL.DAY_, '+', '') AS INTEGER) ELSE NULL  END) " +
"   /**(CASE WHEN STL.LINETYPE=0 THEN STL.TOTAL/1 ELSE 0 END)*/ELSE 0 END) AS VADEGUN  " +
"   ,MAX(INV.GENEXP1) + ' ' + MAX(INV.GENEXP2) + ' ' + MAX(INV.GENEXP3) + ' ' + MAX(INV.GENEXP4) + ' ' + MAX(INV.GENEXP5) + ' ' + MAX(INV.GENEXP6) FATURAACIKLAMA " +
"   ,MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END) KUR " +
"   ,SUM(CASE WHEN STL.TRCODE IN(7, 8, 1, 26, 9, 4)AND STL.LINETYPE IN(3) THEN(STL.TOTAL) " +
" WHEN STL.TRCODE IN(3)AND STL.LINETYPE IN(3) THEN - (STL.TOTAL)ELSE 0 END) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) AS DOVIZMASRAF  " +
"   ,SUM(STL.PRICE) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) DOVIZFIYAT " +
"   ,SUM(CASE WHEN STL.LINETYPE IN(0, 3, 4) THEN STL.VATAMNT ELSE 0 END) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) DOVIZKDV " +
"   ,SUM(CASE WHEN STL.TRCODE IN(7, 8, 1, 26, 9, 4)AND STL.LINETYPE IN(0, 4) THEN(STL.TOTAL / 1) " +
" WHEN STL.TRCODE IN(3)AND STL.LINETYPE IN(0/*,1*/) THEN - (STL.TOTAL / 1)ELSE 0 END) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) AS DOVIZTUTAR  " +
"   ,MAX(INV.TOTALDISCOUNTS) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) DOVIZINDIRIMTOPLAM " +
"   ,MAX(INV.TOTALEXPENSES) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) DOVIZMASRAFTOPLAM " +
"   ,MAX(INV.TOTALvat) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0) DOVIZKDVTOPLAM " +
"   ,MAX(INV.NETTOTAL) / NULLIF(MAX(CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0)  DOVIZNETTOPLAM " +
"   ,ISNULL(MAX(LC.CURCODE), 'TL') DOVIZ " +
"   ,MAX(case when STL.PRCURR = 20 THEN 'EUR' " +
" WHEN STL.PRCURR = 1 THEN 'USD' " +
" WHEN STL.PRCURR IN(0,160) THEN 'TL' " +
" ELSE '' END) RAPORLAMADOVIZ " +
"   ,MAX(CASE WHEN STL.PRCURR IN(0, 160) THEN NULL ELSE STL.PRPRICE END) RAPORLAMADOVIZFIYAT " +
"   ,MAX(CASE WHEN STL.PRRATE IN(0, 160) THEN NULL ELSE STL.PRRATE END) RAPORLAMADOVIZKURU " +
"   ,MAX(CASE WHEN STL.PRRATE IN(0, 160) THEN NULL ELSE STL.AMOUNT * STL.PRPRICE END) RAPORLAMADOVIZTOPLAM " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_STLINE STL(NOLOCK)  " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS(NOLOCK) ON ITS.LOGICALREF = STL.STOCKREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_DECARDS DC ON DC.LOGICALREF = STL.STOCKREF AND DC.CARDTYPE IN(1,2) AND STL.LINETYPE = 2 " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_INVOICE INV(NOLOCK) ON STL.INVOICEREF = INV.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PROJECT PRJ(NOLOCK) ON INV.PROJECTREF = PRJ.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYPLANS PYP(NOLOCK) ON INV.PAYDEFREF = PYP.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_SRVCARD SRV ON STL.STOCKREF = SRV.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_EMUHACC EMH ON STL.ACCOUNTREF = EMH.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_EMUHACC AC ON AC.LOGICALREF = STL.ACCOUNTREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYLINES PYL ON PYL.PAYPLANREF = PYP.LOGICALREF AND PYL.LINENO_ = 1 " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CLC(NOLOCK) ON STL.CLIENTREF = CLC.LOGICALREF " +
" LEFT JOIN(SELECT UL.MAINUNIT, IM.CONVFACT1, IM.CONVFACT2, UL.CODE, IM.ITEMREF, UL.LOGICALREF ULREF, IM.GROSSWEIGHT BRUTAGIRLIK " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITMUNITA IM " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETL UL ON UL.LOGICALREF = IM.UNITLINEREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETF UF ON UL.UNITSETREF = UF.LOGICALREF " +
"                     ) AB ON AB.ITEMREF = ITS.LOGICALREF AND AB.ULREF = STL.UOMREF " +
" LEFT JOIN(SELECT UL.MAINUNIT, IM.CONVFACT1, IM.CONVFACT2, UL.CODE, IM.ITEMREF, UL.LOGICALREF ULREF " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITMUNITA IM " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETL UL ON UL.LOGICALREF = IM.UNITLINEREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETF UF ON UL.UNITSETREF = UF.LOGICALREF " +
" WHERE UL.CODE IN('KG', '') " +
"                      ) AB2 ON AB2.ITEMREF = ITS.LOGICALREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CRDACREF CA(NOLOCK) ON CA.CARDREF = CLC.LOGICALREF AND CA.TRCODE = 5 " +
" LEFT JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_EMUHACC EM(NOLOCK) ON EM.LOGICALREF = CA.ACCOUNTREF " +
" LEFT JOIN " + AnaForm.db + ".dbo.L_CURRENCYLIST LC(NoLock) on LC.CURTYPE = STL.TRCURR AND LC.FIRMNR = '" + AnaForm.firma + "' " +
" WHERE STL.CANCELLED = 0 " +
" AND STL.TRCODE IN(1,26,3,7,8,4, 9)  " +
" AND STL.LINETYPE IN(0,1,2,3,    4)  " +
" AND(AB2.CONVFACT1 IS NOT NULL OR STL.LINETYPE IN(0, 1, 2, 3, 4)) " + araSorguUrun +
"   " +
" GROUP BY STL.LOGICALREF,STL.PRRATE ,STL.VATINC" +
"   ) a " +
"    )as FATURALAR; " +
"     /* FATURA URUN LISTESI BİTİŞ */  " +
    " SELECT *    " +
" INTO #FATURABASLIK FROM( " +
" SELECT " +
" INV.LOGICALREF LOGICALREF , " +
" INV.BRANCH, " +
" CASE when INV.BRANCH = '0' THEN 'Merkez' " +
" when INV.BRANCH = '2' THEN 'Tavşanlı' " +
" ELSE 'HATALI İŞYERİ' " +
" END  AS ISYERI,  " +
" INV.date_ AS TARIH, " +
" CL.CODE AS CARIKODU, " +
" CL.TAXNR + ' ' + CL.TCKNO AS VERGITCNO, " +
" CL.DEFINITION_ AS CARIUNVANI, " +
" cl.SPECODE5 as OZELKOD5,  " +
" INV.FICHENO AS FATURANO, " +
" INV.DOCODE AS BELGEKODU, " +
" CASE when INV.EINVOICE = '1' THEN 'E-Fatura' " +
" when INV.EINVOICE = '0' THEN 'Kağıt' " +
" when INV.EINVOICE = '3' THEN 'E-Arşiv (İnternet)' " +
" when INV.EINVOICE = '2' THEN 'E-Arşiv' " +
" when INV.EINVOICE = '4' THEN 'E-Mühtahsil Fatura' " +
" else 'Hatalı Fatura Tipi' end As EFATURA, " +
" CASE " +
" when INV.ESTATUS = '0' THEN 'GİB e gönderilecek' " +
" when INV.ESTATUS = '1' THEN 'Onaya Gönderildi' " +
" when INV.ESTATUS = '2' THEN 'Onaylandı' " +
" when INV.ESTATUS = '3' THEN 'Paketlendi' " +
" when INV.ESTATUS = '4' THEN 'Gib e Gönderildi' " +
" when INV.ESTATUS = '5' THEN 'Gib e Göndeerilmedi' " +
" when INV.ESTATUS = '6' THEN 'Gib de İşlendi Alıcıya iletilecek' " +
" when INV.ESTATUS = '7' THEN 'Gib de işlenemedi' " +
" when INV.ESTATUS = '8' THEN 'Alıcıya Gönderildi' " +
" when INV.ESTATUS = '9' THEN 'Alıcıya Gönderilemedi' " +
" when INV.ESTATUS = '10' THEN 'Alıcıya İşlendi. Başarıyla tamamlandı' " +
" when INV.ESTATUS = '11' THEN 'Alıcıda İşlenemedi' " +
" when INV.ESTATUS = '12' THEN 'Kabul edildi' " +
" when INV.ESTATUS = '13' THEN 'Reddedildi' " +
" when INV.ESTATUS = '14' THEN 'İade edildi' " +
" when INV.ESTATUS = '15' THEN 'Sunucuya iletildi. İşlenmeyi bekliyor' " +
" when INV.ESTATUS = '16' THEN 'Sunucuda mühürlendi' " +
" when INV.ESTATUS = '17' THEN 'Sunucuda zarflandı' " +
" when INV.ESTATUS = '18' THEN 'Sunucuda hata alındı' " +
" when INV.ESTATUS = '19' THEN 'Alındı' " +
" when INV.ESTATUS = '20' THEN 'Kabul edildi' " +
" when INV.ESTATUS = '21' THEN 'Reddedildi. Yanıt oluşturulamadı' " +
" when INV.ESTATUS = '22' THEN 'Sunucuya gönderildi' " +
" when INV.ESTATUS = '23' THEN 'Harii yollardan (kep,noter) iptal edildi' " +
" when INV.ESTATUS = '24' THEN 'İrsaliye yanıtı alındı' " +
" when INV.ESTATUS = '25' THEN 'Alındı, İrsaliye yanıtı oluşturuldu' " +
" else 'Hatalı Fatura Statüsü' end As EFATURASTATU, " +
" CASE " +
" WHEN INV.TRCODE = '1' THEN 'Satınalma Faturası' " +
" when INV.TRCODE = '2' THEN 'Perakenda Satış İade Faturası' " +
" when INV.TRCODE = '3' THEN 'Toptan Satış İade Faturası' " +
" when INV.TRCODE = '4' THEN 'Alınan Hizmet Faturası' " +
" when INV.TRCODE = '6' THEN 'Satınalma İade Faturası' " +
" when INV.TRCODE = '7' THEN 'Perakende Satış Faturası' " +
" when INV.TRCODE = '8' THEN 'Toptan Satış Faturası' " +
" when INV.TRCODE = '9' THEN 'Verilen Hizmet Faturası' " +
" when INV.TRCODE = '10' THEN 'Verilen Proforma Faturası' " +
" when INV.TRCODE = '11' THEN 'Verilen Vade Farkı Faturası' " +
" when INV.TRCODE = '14' THEN 'Satış Fiyat Farkı Faturası' " +
" when INV.TRCODE = '26' THEN 'Müstahsil Makbuzu' " +
" else 'Hatalı Fatura Türü' end As FaturaTuru, " +
" INV.GENEXP1 AS PLAKA, " +
" INV.TOTALVAT AS TOPLAMKDV, " +
" INV.GROSSTOTAL     NETTUTAR,  " +
" INV.NETTOTAL TOPLAMTUTAR , " +
" CASE WHEN INV.TRCURR NOT IN(0, 160) AND INV.TRRATE<>0 THEN INV.REPORTNET / INV.TRRATE ELSE INV.NETTOTAL END AS TOPLAMTUTARDOVIZ, " +
" CASE WHEN INV.TRCURR IN(0,160) THEN 'TL' " +
" WHEN INV.TRCURR NOT IN(0, 160) AND INV.TRRATE = 0 THEN 'TL' " +
" WHEN INV.TRCURR IN(1) THEN 'USD' " +
" WHEN INV.TRCURR IN(20) THEN 'EUR' " +
" ELSE 'DİĞER' " +
" END " +
" AS DOVIZ, " +
" INV.TRRATE, " +
" INV.TRCURR " +
" FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_INVOICE INV  " +
" JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CL ON CL.LOGICALREF = INV.CLIENTREF " +
"  ) AS FATURABASLIK ";

                #endregion


                if (rgRaporTuru.SelectedIndex > -1 && (rgRaporTuru.Properties.Items[rgRaporTuru.SelectedIndex].Description) == "Fatura Bazlı")
                {
                    Tablo = tablo;
                    grid.BringToFront();
                    grid.Dock = DockStyle.Fill;
                    grid.DataSource = null;


                    sorgu3 += " SELECT CLC.LOGICALREF, ISLEM.* FROM(   " +
" SELECT  FL.LOGICALREF AS FTLOGICALREF, KF.*, CASE WHEN KF.DOVIZ<>'TL' THEN KF.TUTARDOVIZ * KF.VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00 ELSE KF.TUTAR* KF.VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000 END AS VADEFARKI " +
"             , CASE WHEN VADEDENSAPMA > " + txtVadedenSapma.Text + " THEN " +
" CASE WHEN KF.DOVIZ<>'TL' THEN KF.TUTARDOVIZ* KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00 ELSE KF.TUTAR* KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000 END " +
" ELSE 0 END AS VADEFARKI2 " +
" FROM #KAPALIFATURALAR KF  " + 
" LEFT JOIN #FATURABASLIK FL ON FL.CARIKODU= KF.KOD AND FL.FATURANO = KF.KAPATILANFATURA " + 
" UNION ALL " +
" SELECT FL.LOGICALREF AS FTLOGICALREF, AF.*, CASE WHEN AF.VADEDENSAPMA > 0 THEN AF.TUTARDOVIZ* AF.VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama')/ 3000.00 ELSE  0  END AS VADEFARKI " +
"             , CASE WHEN AF.VADEDENSAPMA > " + txtVadedenSapma.Text + " THEN " +
" CASE WHEN AF.VADEDENSAPMA > 0 THEN AF.TUTARDOVIZ* AF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama')/ 3000.00 ELSE  0  END " +
" ELSE 0 END AS VADEFARKI2 " +
" FROM #ACIKFATURALAR AF " + 
" LEFT JOIN #FATURABASLIK FL ON FL.CARIKODU= AF.KOD AND FL.FATURANO = AF.FATURANO) AS ISLEM   " + 
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CLC ON CLC.CODE = ISLEM.KOD  WHERE 1 = 1 "  +araSorguCari;



                    DataTable dt11 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(sorgu3, bgl.baglanti());
                    da1.SelectCommand.CommandTimeout = 0;
                    da1.Fill(dt11);
                    grid.DataSource = dt11;
                }

                if (rgRaporTuru.SelectedIndex > -1 && (rgRaporTuru.Properties.Items[rgRaporTuru.SelectedIndex].Description) == "Ürün Bazlı")
                {


                    Tablo = tablo1;
                    grid1.BringToFront();
                    grid1.Dock = DockStyle.Fill;
                    grid1.DataSource = null;
                    sorgu3 += " SELECT KF.ISLEMTIPI,KF.TAHSILATTARIHI, FL.*, KF.VADEDENSAPMA, KF.TOPLAMVADE,  " +
     " KF.TUTAR, " +
     " KF.TUTARDOVIZ, " +
     " KF.DOVIZ " +
     "   ,case WHEN KF.VADEDENSAPMA>0 THEN  CASE WHEN    KF.DOVIZ<> 'TL'  THEN  " +
     " CONVERT(DECIMAL(18, 2), (((FL.DOVIZTUTAR + CASE WHEN VATINC=0 THEN FL.DOVIZKDV ELSE 0 END) / FL.DOVIZNETTOPLAM) * KF.TUTARDOVIZ * VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) " +
     " ELSE CONVERT(DECIMAL(18, 2), (((FL.TUTAR +  CASE WHEN VATINC=0 THEN FL.KDV ELSE 0 END) / FL.NETTOPLAM) * KF.TUTAR * VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) END ELSE 0 END  AS VADEFARKI " +
     " ,case WHEN KF.VADEDENSAPMA>" + txtVadedenSapma.Text + " THEN  CASE WHEN    KF.DOVIZ<> 'TL'  THEN   " +
     " CONVERT(DECIMAL(18, 2), (((FL.DOVIZTUTAR + CASE WHEN VATINC=0 THEN FL.DOVIZKDV ELSE 0 END) / FL.DOVIZNETTOPLAM) * KF.TUTARDOVIZ * KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00))  " +
     " ELSE CONVERT(DECIMAL(18, 2), (((FL.TUTAR +  CASE WHEN VATINC=0 THEN FL.KDV ELSE 0 END) / FL.NETTOPLAM) * KF.TUTAR * KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) END ELSE 0 END  AS VADEFARKI2  " +
     " FROM " +
     "  #FATURALISTESI FL  " +
     " JOIN #ACIKFATURALAR KF ON KF.KOD = FL.CARIKODU AND KF.FATURANO =  FL.FaturaNo " +
     " WHERE 1 = 1 " +
     " UNION ALL " +
     " SELECT KF.ISLEMTIPI,KF.TAHSILATTARIHI, FL.*, KF.VADEDENSAPMA, KF.TOPLAMVADE,  " +
     " KF.TUTAR, " +
     " KF.TUTARDOVIZ, " +
     " KF.DOVIZ " +
     "    ,CASE WHEN    KF.DOVIZ<> 'TL'  THEN " +
     " CONVERT(DECIMAL(18, 2), (((FL.DOVIZTUTAR +  CASE WHEN VATINC=0 THEN FL.DOVIZKDV ELSE 0 END ) / FL.DOVIZNETTOPLAM) * KF.TUTARDOVIZ * VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) " +
     " ELSE CONVERT(DECIMAL(18, 2), (((FL.TUTAR +  CASE WHEN VATINC=0 THEN  FL.KDV ELSE 0 END) / FL.NETTOPLAM) * KF.TUTAR * VADEDENSAPMA * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) END AS VADEFARKI " +
     " ,CASE WHEN  KF.VADEDENSAPMA>" + txtVadedenSapma.Text + " THEN CASE WHEN    KF.DOVIZ<> 'TL'  THEN  " +
     " CONVERT(DECIMAL(18, 2), (((FL.DOVIZTUTAR +  CASE WHEN VATINC=0 THEN FL.DOVIZKDV ELSE 0 END ) / FL.DOVIZNETTOPLAM) * KF.TUTARDOVIZ * KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00))  " +
     " ELSE CONVERT(DECIMAL(18, 2), (((FL.TUTAR +  CASE WHEN VATINC=0 THEN  FL.KDV ELSE 0 END) / FL.NETTOPLAM) * KF.TUTAR * KF.TOPLAMVADE * (Select top 1 convert(decimal(18, 3), ParametreDegeri) from XCubeCrmDb.dbo.HesaplamaParametreleri where ParametreAdi = 'Vade Farkı Hesaplama') / 3000.00)) END ELSE 0 END  AS VADEFARKI2 " +
     " FROM " +
     "  #FATURALISTESI FL  " +
     " JOIN #KAPALIFATURALAR KF ON KF.KOD = FL.CARIKODU AND KF.KAPATILANFATURA =  FL.FaturaNo ";
                    grid.Visible = false;
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());
                    da.SelectCommand.CommandTimeout = 0;
                    da.Fill(dt1);
                    grid1.DataSource = dt1;

                }






                // AnaForm frm = new AnaForm();



             
        }


        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;

            BaseKartTuru = KartTuru.BorcAlacakFaturaListesi;
        }

        private void rgRaporTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}