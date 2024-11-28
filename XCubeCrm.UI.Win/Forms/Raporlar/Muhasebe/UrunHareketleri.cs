using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraDiagram.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Win32;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit.Fields;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
 using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static DevExpress.XtraEditors.TextEdit;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class UrunHareketleri : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public UrunHareketleri( )
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
                araSorgu += "AND STL.TRCURR IN (" + AnaForm.dovizTuru + ")";
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
            if (AnaForm.aktifKayitlarUrun != "")
            {
                araSorgu += "AND ITS.ACTIVE IN (" + AnaForm.aktifKayitlarUrun + ")";
            }
            if (AnaForm.urunLogicalref!="")
            {
                araSorgu += "AND ITS.LOGICALREF IN (" + AnaForm.urunLogicalref + ")";
            }
            if (AnaForm.urunOzelKod != "")
            {
                araSorgu += "AND ITS.SPECODE IN (" + AnaForm.urunOzelKod + ")";
            }
            if (AnaForm.urunOzelKod2 != "")
            {
                araSorgu += "AND ITS.SPECODE2 IN (" + AnaForm.urunOzelKod2 + ")";
            }
            if (AnaForm.urunOzelKod3 != "")
            {
                araSorgu += "AND ITS.SPECODE3 IN (" + AnaForm.urunOzelKod3 + ")";
            }
            if (AnaForm.urunOzelKod4 != "")
            {
                araSorgu += "AND ITS.SPECODE4 IN (" + AnaForm.urunOzelKod4 + ")";
            }
            if (AnaForm.urunOzelKod5 != "")
            {
                araSorgu += "AND ITS.SPECODE5 IN (" + AnaForm.urunOzelKod5 + ")";
            }
            if (AnaForm.urunGrup != "")
            {
                araSorgu += "AND ITS.STGRPCODE IN (" + AnaForm.urunGrup + ")";
            }
            if (AnaForm.urunTip != "")
            {
                araSorgu += "AND ITS.CARDTYPE IN (" + AnaForm.urunTip + ")";
            }
            if (AnaForm.isyeri != "")
            {
                araSorgu += " AND STL.SOURCEINDEX  IN ( SELECT DISTINCT(NR) FROM " + AnaForm.db + ".DBO.L_CAPIWHOUSE WHERE FIRMNR ='" + AnaForm.firma + "' AND DIVISNR IN (   " + AnaForm.isyeri + "))";
            }
            if (AnaForm.ambar != "")
            {
                araSorgu += " AND STL.SOURCEINDEX  IN (" + AnaForm.ambar + ")";
            }

            string sorgu3 = " SELECT TOP(100) PERCENT " +
" INV.LOGICALREF,  " +
" STF.LOGICALREF,  " +
" STL.LOGICALREF Id,   " +
" SL.DEFINITION_ AS FATURASATISELEMANI,  " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN ITS.CODE " +
" WHEN STL.LINETYPE IN(3)   THEN EMH.CODE " +
" WHEN STL.LINETYPE IN(4)   THEN SRV.CODE " +
" WHEN STL.LINETYPE IN(2)   THEN CASE WHEN DC.CODE IS NULL THEN ITS.CODE ELSE DC.CODE END ELSE '' END AS URUNKOD,   " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN ITS.NAME " +
" WHEN STL.LINETYPE IN(3)   THEN EMH.DEFINITION_ " +
" WHEN STL.LINETYPE IN(4)   THEN SRV.DEFINITION_ " +
" WHEN STL.LINETYPE IN(2)   THEN CASE WHEN DC.DEFINITION_ IS NULL THEN ITS.NAME ELSE DC.CODE END ELSE '' END AS URUNADI,    " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN ITS.NAME4 " +
" WHEN STL.LINETYPE IN(3)   THEN  '' " +
" WHEN STL.LINETYPE IN(4)   THEN  '' " +
" WHEN STL.LINETYPE IN(2)   THEN  '' END AS URUNADI3,    " +
" CASE " +
" WHEN ITS.CARDTYPE = 1 THEN 'Ticari Mal' " +
" WHEN ITS.CARDTYPE = 2 THEN 'Karma Koli' " +
" WHEN ITS.CARDTYPE = 3 THEN 'Depozitolu Mal' " +
" WHEN ITS.CARDTYPE = 4 THEN 'Sabit Kıymet' " +
" WHEN ITS.CARDTYPE = 10 THEN 'Ham Madde' " +
" WHEN ITS.CARDTYPE = 11 THEN 'Yarı Mamul' " +
" WHEN ITS.CARDTYPE = 12 THEN 'Mamul' " +
" WHEN ITS.CARDTYPE = 13 THEN 'Tüketim Malı' " +
" WHEN ITS.CARDTYPE = 20 THEN 'Genel Malzeme Sınıfı' " +
" ELSE '' END URUNTIP,  " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50), ITS.SPECODE  )  " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50), EMH.SPECODE)  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50), SRV.SPECODE )   " +
" WHEN STL.LINETYPE IN(2)   THEN CONVERT(NVARCHAR(50),   DC.SPECODE)   ELSE '' END AS URUNOZELKOD,      " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50), ITS.SPECODE2  )  " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50), EMH.SPECODE2)  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50), SRV.SPECODE2 )   " +
" WHEN STL.LINETYPE IN(2)   THEN ''   ELSE '' END AS URUNOZELKOD2,       " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50), ITS.SPECODE3  )  " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50), EMH.SPECODE3)  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50), SRV.SPECODE3 )   " +
" WHEN STL.LINETYPE IN(2)   THEN ''  ELSE '' END AS URUNOZELKOD3,    " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50), ITS.SPECODE4  )  " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50), EMH.SPECODE4)  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50), SRV.SPECODE4 )   " +
" WHEN STL.LINETYPE IN(2)   THEN ''  ELSE '' END AS URUNOZELKOD4,   " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50), ITS.SPECODE5  )  " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50), EMH.SPECODE5)  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50), SRV.SPECODE5 )   " +
" WHEN STL.LINETYPE IN(2)   THEN ''  ELSE '' END AS URUNOZELKOD5,   " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN CONVERT(NVARCHAR(50),ITS.STGRPCODE )   " +
" WHEN STL.LINETYPE IN(3)   THEN CONVERT(NVARCHAR(50),EMH.GROUPCODE  )  " +
" WHEN STL.LINETYPE IN(4)   THEN CONVERT(NVARCHAR(50),SRV.CPACODE  )  " +
" WHEN STL.LINETYPE IN(2)   THEN CONVERT(NVARCHAR(50),dc.GLOBALCODE)  ELSE ''   END AS GRUPKOD,       " +
" ISNULL(MARK.CODE, '') AS MARKA,  " +
" CLC.CODE AS CARIKOD,  " +
" CLC.DEFINITION_ AS UNVAN,   " +
" CAPIWHOUSE.NAME AS AMBARADI,   " +
" CLC.ADDR1 AS CARIADRES,  " +
" CLC.TOWN AS CARIIL,  " +
" CLC.CITY AS CARIILCE,  " +
" CLC.TELNRS1 AS TELNO1,  " +
" CLC.TELNRS2 AS TELNO2,  " +
" CLC.CELLPHONE AS CEPTEL,  " +
" CLC.WEBADDR AS WEBSITE,  " +
" CLC.SPECODE AS CARIOZELKOD,  " +
" CLC.SPECODE2 AS CARIOZELKOD2,  " +
" CLC.SPECODE3 AS CARIOZELKOD3,  " +
" CLC.SPECODE4 AS CARIOZELKOD4,  " +
" CLC.SPECODE5 AS CARIOZELKOD5,  " +
" STF.DOCODE AS IRSALIYEBELGENO,  " +
" convert(datetime, STF.CAPIBLOCK_CREADEDDATE)AS IRSALIYEKAYITZAMANI,  " +
" convert(date, STF.DATE_) AS IRSALIYETARIH,  " +
" STF.FICHENO AS IRSALIYENO,  " +
" INV.DOCODE AS FATURABELGENO,  " +
" convert(datetime, INV.CAPIBLOCK_CREADEDDATE)AS FATURAKAYITZAMANI,  " +
" INV.FICHENO AS FATURANO, " +
" CASE WHEN INV.EINVOICE = 1 THEN 'E-Fatura' ELSE 'Kağıt Fatura' END FATURATUR, " +
" convert(date, INV.DATE_) AS FATURATARIH,  " +
" CASE WHEN STL.IOCODE = 0 THEN 'Hizmet' " +
" WHEN STL.IOCODE = 1 THEN 'Giriş' " +
" WHEN STL.IOCODE = 2 THEN 'Ambar Giriş' " +
" WHEN STL.IOCODE = 3 THEN 'Ambar Çıkış' " +
" WHEN STL.IOCODE = 4 THEN 'Çıkış' " +
" ELSE '' END AS GIRISCIKIS,  " +
" CASE " +
" when STL.TRCODE IN(7,8)AND STL.LINETYPE IN(0) AND STL.BILLED = 1 THEN  'Satış Faturası' " +
" when STL.TRCODE IN(7,8)AND STL.LINETYPE IN(1) AND STL.BILLED = 1 THEN  'Promosyon Faturası' " +
" when STL.TRCODE IN(7,8)AND STL.LINETYPE IN(2) AND STL.BILLED = 1 THEN  'Satış İndirim Faturası' " +
" when STL.TRCODE IN(7,8)AND STL.LINETYPE IN(3) AND STL.BILLED = 1 THEN  'Masraf Faturası' " +
" when STL.TRCODE IN(3)AND STL.LINETYPE IN(0,1) AND STL.BILLED = 1 then 'Satış İade Faturası' " +
" when STL.TRCODE IN(3)AND STL.LINETYPE IN(2) AND STL.BILLED = 1 THEN  'Satış İade İndirim  Faturası' " +
" when STL.TRCODE IN(1)AND STL.LINETYPE IN(0,1) AND STL.BILLED = 1 then 'Alış Faturası' " +
" when STL.TRCODE IN(1)AND STL.LINETYPE IN(2) AND STL.BILLED = 1 then 'Alış İndirim Faturası' " +
" when STL.TRCODE IN(26)AND STL.LINETYPE IN(0,1) AND STL.BILLED = 1 then 'Mustahsil Faturası' " +
" when STL.TRCODE IN(26)AND STL.LINETYPE IN(2) AND STL.BILLED = 1 then 'Mustahsil İndirim Faturası' " +
" when STL.TRCODE IN(3) AND STL.BILLED = 1 then 'Alış İade Faturası' " +
" when STL.TRCODE IN(4) and STL.LINETYPE IN(4) AND STL.BILLED = 1 then 'Alınan Hizmet Faturası' " +
" when STL.TRCODE IN(3)AND STL.LINETYPE IN(2) AND STL.BILLED = 1 then 'Alış İ.İndirim Faturası' " +
" WHEN STL.TRCODE IN(9)AND STL.LINETYPE IN(4) AND STL.BILLED = 1 then 'Verilen Hizmet Faturası' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 0 AND STL.LINETYPE IN(0) THEN 'Perakande Satış İrsaliyesi' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 0 AND STL.LINETYPE IN(1) THEN 'Promosyon İrsaliyesi' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 0 AND STL.LINETYPE IN(2) THEN 'Satış İndirim İrsaliyesi' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 0 AND STL.LINETYPE IN(3) THEN 'Masraf İrsaliyesi' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 1 AND STL.LINETYPE IN(0) THEN 'Perakande Satış Faturası' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 1 AND STL.LINETYPE IN(1) THEN 'Promosyon Faturası' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 1 AND STL.LINETYPE IN(2) THEN 'Satış İndirim Faturası' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 1 AND STL.LINETYPE IN(3) THEN 'Masraf Faturası' " +
" WHEN STL.TRCODE IN(3)AND STL.LINETYPE IN(2) then 'Alış İade İndirim' " +
" WHEN STL.TRCODE = 7 AND STL.BILLED = 1 THEN 'Perakande Satış Faturası' " +
" WHEN STL.TRCODE = 8 AND STL.BILLED = 0 THEN 'Toptan Satış İrsaliyesi' " +
" WHEN STL.TRCODE = 8 AND STL.BILLED = 1 THEN 'Toptan Satış Faturası' " +
" WHEN STL.TRCODE = 2 AND STL.BILLED = 0 THEN 'Perakande Satış İade İrsaliyesi' " +
" WHEN STL.TRCODE = 2 AND STL.BILLED = 1 THEN 'Perakande Satış İade Faturası' " +
" WHEN STL.TRCODE = 3 AND STL.BILLED = 0 THEN 'Toptan Satış İade İrsaliyesi' " +
" WHEN STL.TRCODE = 3 AND STL.BILLED = 1 THEN 'Toptan Satış İade Faturası' " +
" WHEN STL.TRCODE = 1 AND STL.BILLED = 1 THEN 'Satınalma Faturası' " +
" WHEN STL.TRCODE = 1 AND STL.BILLED = 0 THEN 'Satınalma İrsaliyesi' " +
" WHEN STL.TRCODE IN(9)AND STL.LINETYPE IN(4) then 'Verilen Hizmet Faturası' " +
" WHEN STL.TRCODE IN(4)AND STL.LINETYPE IN(4) then 'Alınan Hizmet Faturası' " +
" WHEN STL.TRCODE = 4 THEN 'Konsinye Çıkış İade İrsaliyesi' " +
" WHEN STL.TRCODE = 5 THEN 'Konsinye Giriş İrsaliyesi' " +
" WHEN STL.TRCODE = 6 AND STL.BILLED = 0 THEN 'Satınalma İade İrsaliyesi' " +
" WHEN STL.TRCODE = 6 AND STL.BILLED = 1 THEN 'Satınalma İade Faturası' " +
" WHEN STL.TRCODE = 9 THEN 'Konsinye Çıkış İrsaliyesi' " +
" WHEN STL.TRCODE = 10 THEN 'Konsinye Giriş İade İrsaliyesi' " +
" WHEN STL.TRCODE = 11 THEN 'Fire Fişi' " +
" WHEN STL.TRCODE = 12 THEN 'Sarf Fişi' " +
" WHEN STL.TRCODE = 13 THEN 'Üretimden Giriş Fişi' " +
" WHEN STL.TRCODE = 14 THEN 'Devir Fişi' " +
" WHEN STL.TRCODE = 25 AND STL.IOCODE = 2  THEN 'AMBAR GİRİŞ' " +
" WHEN STL.TRCODE = 25 AND STL.IOCODE = 3  THEN 'AMBAR ÇIKIŞ' " +
" WHEN STL.TRCODE = 26 THEN 'Muhtahsil İrsaliyesi' " +
" WHEN STL.TRCODE = 50 THEN 'Sayım Fazlası Fişi' " +
" WHEN STL.TRCODE = 51 THEN 'Sayım Eksiği Fişi' ELSE '' END AS FISTURU,  " +
" CASE STL.LINETYPE " +
" WHEN 0 THEN 'Malzeme' " +
" WHEN 1 THEN 'Promosyon' " +
" WHEN 2 THEN 'İndirim' " +
" WHEN 3 THEN 'Masraf' " +
" WHEN 4 THEN 'Hizmet' " +
" WHEN 5 THEN 'Depozito' " +
" WHEN 6 THEN 'Karma Koli' " +
" WHEN 7 THEN 'Karma Koli Kalemi' " +
" WHEN 8 THEN 'Sabit Kıymet' " +
" WHEN 9 THEN 'Ek Malzeme' " +
" WHEN 10 THEN 'Malzeme sınıfı' " +
" WHEN 11 THEN 'Fason' ELSE '' END AS SATIRTURU,   " +
"  case when STL.IOCODE in (1, 2) then STL.AMOUNT " +
"       else STL.AMOUNT * -1 end AS MIKTAR,   " +
" CASE WHEN STL.LINETYPE IN(0,1) THEN AB.CODE " +
" WHEN STL.LINETYPE IN(4)   THEN AB3.CODE " +
" ELSE '' " +
" END AS BIRIM,       " +
" CASE STL.VATINC WHEN 1 THEN " +
" CONVERT(DECIMAL(18, 5), STL.PRICE) * ((100 - STL.VAT) / 100) " +
" ELSE " +
" CONVERT(DECIMAL(18, 5), STL.PRICE) " +
" END AS BIRIMFIYAT,  " +
" STL.VAT AS KDVORANI,  " +
" CASE STL.VATINC WHEN 0 THEN 'Hariç' WHEN 1 THEN 'Dahil' END AS KDVDAHILMI,  " +
" CONVERT(DECIMAL(18, 5), STL.VATAMNT / STL.AMOUNT) AS KDVTUTARI,  " +
" CONVERT(DECIMAL(18, 5), STL.DISTCOST / STL.AMOUNT) AS INDIRIM,  " +
" STL.TOTAL AS TUTAR,  " +
" STL.TOTAL + CASE STL.VATINC WHEN 0 THEN STL.VATAMNT WHEN 1 THEN 0 END AS KDVLITUTAR,  " +
" ISNULL(CONVERT(DECIMAL(18, 5), (STL.PRICE / NULLIF((CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END), 0))),CASE STL.VATINC WHEN 1 THEN " +
" CONVERT(DECIMAL(18, 5), STL.PRICE) * ((100 - STL.VAT) / 100) " +
" ELSE " +
" CONVERT(DECIMAL(18, 5), STL.PRICE) " +
" END) DOVIZFIYAT,  " +
" ISNULL(LC.CURCODE, 'TL') as DOVIZ,  " +
" (CASE WHEN STL.LINETYPE IN(0,3,4) THEN STL.VATAMNT ELSE 0 END)/ NULLIF((CASE WHEN INV.TRRATE = 0 THEN STL.PRRATE ELSE INV.TRRATE END),0) AS DOVIZKDV,  " +
" ISNULL(STF.GENEXP1, '') + ISNULL(INV.GENEXP1, '') + ' ' +     " +
" ISNULL(STF.GENEXP2, '') + ISNULL(INV.GENEXP2, '') + ' ' +     " +
" ISNULL(STF.GENEXP3, '') + ISNULL(INV.GENEXP3, '') + ' ' +    " +
" ISNULL(STF.GENEXP4, '') + ISNULL(INV.GENEXP4, '') + ' ' +    " +
" ISNULL(STF.GENEXP5, '') + ISNULL(INV.GENEXP5, '') + ' ' +    " +
" ISNULL(STF.GENEXP6, '') + ISNULL(INV.GENEXP6, '') AS FATURAACIKLAMASI,   " +
" PYP.DEFINITION_ AS FATURAVADE,  " +
" ORFICHE.FICHENO AS SIPARISNO,  " +
" PYP1.DEFINITION_ AS SIPARISVADE,  " +
" ORFICHE.GENEXP1 + ' ' + ORFICHE.GENEXP2 + ' ' + ORFICHE.GENEXP3 + ' ' + ORFICHE.GENEXP4 + ' ' + ORFICHE.GENEXP5 + ' ' + ORFICHE.GENEXP6 AS SIPARISACIKLAMA   " +

" FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STLINE AS STL WITH (NOLOCK)  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_ITEMS AS ITS WITH (NOLOCK) ON ITS.LOGICALREF = STL.STOCKREF  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_DECARDS DC ON DC.LOGICALREF = STL.STOCKREF AND DC.CARDTYPE IN (1,2) AND STL.LINETYPE=2 " +
" LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_EMUHACC EMH ON STL.ACCOUNTREF=EMH.LOGICALREF " +
" LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_SRVCARD SRV ON STL.STOCKREF=SRV.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.L_CAPIWHOUSE AS CAPIWHOUSE WITH (NOLOCK) ON CAPIWHOUSE.NR = STL.SOURCEINDEX AND CAPIWHOUSE.FIRMNR = '" + AnaForm.firma +  "'  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_UNITSETL AS UNITSETL1 WITH (NOLOCK) ON UNITSETL1.UNITSETREF = ITS.UNITSETREF AND UNITSETL1.MAINUNIT = 1  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_MARK AS MARK WITH (NOLOCK) ON ITS.MARKREF = MARK.LOGICALREF  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE AS INV WITH (NOLOCK) ON STL.INVOICEREF = INV.LOGICALREF  " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CLCARD AS CLC WITH (NOLOCK) ON STL.CLIENTREF = CLC.LOGICALREF  " +
"  LEFT OUTER  JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PAYPLANS ON  " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PAYPLANS.LOGICALREF = INV.PAYDEFREF " +
" LEFT OUTER JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE AS STF WITH (NOLOCK) ON STL.STFICHEREF = STF.LOGICALREF " +
" LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_ORFICHE ORFICHE  (NOLOCK) ON STL.ORDFICHEREF = ORFICHE.LOGICALREF " +
" LEFT OUTER  JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PAYPLANS PYP ON  PYP.LOGICALREF = INV.PAYDEFREF " +
" LEFT OUTER  JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_PAYPLANS PYP1 ON  PYP1.LOGICALREF = ORFICHE.PAYDEFREF " +
" left outer join " + AnaForm.db +  ".DBO.L_SHPAGENT on L_SHPAGENT.CODE=STF.SHPAGNCOD " +
" LEFT JOIN " + AnaForm.db +  ".dbo.L_CURRENCYLIST LC(NoLock) on LC.CURTYPE=STL.TRCURR AND LC.FIRMNR='" + AnaForm.firma +  "' " +
" LEFT JOIN " + AnaForm.db +  ".dbo.L_CAPIDIV L_CAPIDIV ON L_CAPIDIV.NR = INV.BRANCH AND L_CAPIDIV.FIRMNR ='" + AnaForm.firma +  "'  " +
" LEFT JOIN " + AnaForm.db +  ".dbo.L_CAPIDIV L_CAPIDIV1 ON L_CAPIDIV1.NR = STF.BRANCH AND L_CAPIDIV1.FIRMNR ='" + AnaForm.firma +  "' " +
" LEFT JOIN (SELECT UL.MAINUNIT,IM.CONVFACT1,IM.CONVFACT2, UL.CODE ,IM.ITEMREF,UL.LOGICALREF ULREF,IM.GROSSWEIGHT BRUTAGIRLIK " +
"    FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_ITMUNITA IM " +
"    LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_UNITSETL UL ON UL.LOGICALREF=IM.UNITLINEREF " +
"    LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_UNITSETF UF ON UL.UNITSETREF=UF.LOGICALREF " +
"     WHERE IM.CONVFACT1>0 AND IM.CONVFACT2>0 " +
"    ) AB ON AB.ITEMREF=ITS.LOGICALREF AND AB.ULREF=STL.UOMREF " +
" LEFT JOIN (SELECT UL.MAINUNIT, UL.CODE , UL.LOGICALREF ULREF " +
"    FROM  " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_UNITSETL UL  " +
"    LEFT JOIN " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_UNITSETF UF ON UL.UNITSETREF=UF.LOGICALREF " +
"    ) AB3 ON   AB3.ULREF=STL.UOMREF " +
" LEFT JOIN  " + AnaForm.db +  ".dbo.[LG_SLSMAN]  SL  ON SL.LOGICALREF = INV.SALESMANREF " +
" WHERE  STL.DATE_ between '" + AnaForm.baslangicTarihi + "' and '" + AnaForm.bitisTarihi + "' " +
araSorgu + 
" AND STL.STOCKREF <>0 " +
"  AND  STL.AMOUNT >0  " +
"  order by STL.DATE_ desc " ;


            grid.DataSource = null;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());

            
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;

           // AnaForm frm = new AnaForm();
          
             

           
        }

         
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
             
            BaseKartTuru = KartTuru.UrunHareketleri;
        }

          
    }
}