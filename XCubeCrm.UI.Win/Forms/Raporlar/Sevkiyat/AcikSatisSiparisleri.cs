using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Sevkiyat
{
    public partial class AcikSatisSiparisleri : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public AcikSatisSiparisleri( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
            araSorgu = "";
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
                araSorgu += "AND ORF.TRCURR IN (" + AnaForm.dovizTuru + ")";
            }
            if (AnaForm.satisElemani != "")
            {
                araSorgu += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma +  "_SLSCLREL SL  " +
" JOIN " + AnaForm.db + ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma +  " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma +  "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
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
                araSorgu += " AND ORFL.SOURCEINDEX  IN ( SELECT DISTINCT(NR) FROM " + AnaForm.db + ".DBO.L_CAPIWHOUSE WHERE FIRMNR ='" + AnaForm.firma + "' AND DIVISNR IN (   " + AnaForm.isyeri + "))";
            }
            if (AnaForm.ambar != "")
            {
                araSorgu += " AND ORFL.SOURCEINDEX  IN (" + AnaForm.ambar + ")";
            }
            string sorgu3 = "  SELECT "  +
"  ORFL.LOGICALREF Id, "  +
"  ORF.FICHENO AS SiparisNo, "  +
"  CONVERT(DATETIME, ORF.CAPIBLOCK_CREADEDDATE, 104) AS SIPARISTARIHI, "  +
"  CONVERT(date, ORFL.DUEDATE, 104) AS SEVKTARIHI, "  +
"  dateDiff(day, CONVERT(DATETIME, ORF.CAPIBLOCK_CREADEDDATE, 104), convert(date, getdate())) as GECENGUN, "  +
"  LCAPI.NAME AS AMBAR,  "  +
"  CLC.CODE AS CARIKOD,  "  +
"  CLC.DEFINITION_ AS CARIUNVAN,  "  +
"  ORF.DOCODE AS BELGENO, "  +
"  ORF.DOCODE  OZELKOD, "  +
"  ISNULL(ORF.GENEXP1, '1') + ' ' + "  +
"  ISNULL(ORF.GENEXP2, '') + ' ' + "  +
"  ISNULL(ORF.GENEXP3, '') + ' ' + "  +
"  ISNULL(ORF.GENEXP4, '') + ' ' + "  +
"  ISNULL(ORF.GENEXP5, '') + ' ' + "  +
"  ISNULL(ORF.GENEXP6, '') AS SIPARISACIKLAMA,  "  +
"  KUL.NAME AS SIPARISIOLUSTURANKULLANICI, "  +
"  ISNULL((SINFO.ADDR1 + ' ' + SINFO.ADDR2), (CLC.ADDR1 + ' ' + CLC.ADDR2))  AS SEVKADRESI,  "  +
"  ISNULL(SINFO.TOWN, CLC.TOWN) AS ILCE, "  +
"  ISNULL(SINFO.CITY, CLC.CITY)AS SEHIR,  "  +
"  ITS.CODE AS URUKOD,  "  +
"  ITS.NAME AS URUNADI,  "  +
"  ISNULL(ROUND((SELECT SUM(ONHAND) AS Expr1 FROM      " + AnaForm.db + ".dbo.LV_" + AnaForm.firma + "_" + AnaForm.donem + "_GNTOTST "  +
"  WHERE(STOCKREF = ITS.LOGICALREF) AND(INVENNO IN(ORFL.SOURCEINDEX))), 0), 0) AS DEPOTOPLAMI,  "  +
"  ORFL.AMOUNT AS SIPARISMIKTARI,  "  +
"  ORFL.SHIPPEDAMOUNT AS KARSILANANMIKTAR, "  +
"  ORFL.AMOUNT - ORFL.SHIPPEDAMOUNT AS ACIKSIPARIS, "  +
"  (SELECT TOP(1) NAME FROM      " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETL WHERE(LOGICALREF = ORFL.UOMREF)) AS BIRIM,  "  +
"  ROUND(CASE WHEN ORFL.PRCURR = 0 THEN ORFL.PRICE WHEN ORFL.PRCURR = 160 THEN ORFL.PRICE ELSE ISNULL(ORFL.PRICE / NULLIF(ORFL.PRRATE, 0), 0) END, 4) AS FIYAT,  "  +
"  CASE WHEN ORFL.PRCURR = 0 THEN 'TL' WHEN ORFL.PRCURR = 160 THEN 'TL' WHEN ORFL.PRCURR = 1 THEN '$' WHEN ORFL.PRCURR = 20 THEN '€' END AS DOVIZ,  "  +
"  PYP.DEFINITION_ AS VADE  "  +
"  FROM     " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CLC INNER JOIN "  +
"  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE ORFL ON CLC.LOGICALREF = ORFL.CLIENTREF "  +
"  INNER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS  ON ORFL.STOCKREF = ITS.LOGICALREF "  +
"  INNER JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ORF ON ORFL.ORDFICHEREF = ORF.LOGICALREF "  +
"  LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYPLANS PYP ON ORF.PAYDEFREF = PYP.LOGICALREF "  +
"  LEFT OUTER JOIN " + AnaForm.db + ".dbo.L_CAPIWHOUSE LCAPI  WITH(NOLOCK) ON LCAPI.NR = ORFL.SOURCEINDEX AND LCAPI.FIRMNR = '" + AnaForm.firma + "' "  +
"  LEFT OUTER JOIN " + AnaForm.db + ".dbo.L_CAPIUSER AS KUL ON  ORF.CAPIBLOCK_CREATEDBY = KUL.NR "  +
"  LEFT OUTER JOIN  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_SHIPINFO SINFO ON ORF.SHIPINFOREF = SINFO.LOGICALREF "  +
"  LEFT OUTER JOIN  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLRNUMS CLRNUMS ON CLC.LOGICALREF = CLRNUMS.CLCARDREF "  +
"  WHERE(ORFL.TRCODE = 1) " + araSorgu +" and(ORF.LOGICALREF IN "  +
"  (SELECT ORDFICHEREF "  +
"  FROM(SELECT ORDFICHEREF, SUM(AMOUNT) AS AMOUNT, SUM(CASE SIGN(OTRNS.CLOSED) WHEN 1 THEN OTRNS.AMOUNT ELSE 0 END) AS CLOSEDAMOUNT, SUM(CASE SIGN((OTRNS.SHIPPEDAMOUNT - OTRNS.AMOUNT)) "  +
"  WHEN 1 THEN OTRNS.AMOUNT ELSE OTRNS.SHIPPEDAMOUNT END) AS SHIPPEDAMOUNT "  +
"  FROM      " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE AS OTRNS "  +
"  WHERE(LINETYPE NOT IN(2, 3, 7)  AND OTRNS.STOCKREF = ORFL.STOCKREF) "  + araSorgu +
"  GROUP BY ORDFICHEREF) AS TEMP "  +
"  WHERE(SHIPPEDAMOUNT = 0) AND(AMOUNT<> CLOSEDAMOUNT) OR "  +
"  (SHIPPEDAMOUNT<> 0) AND(AMOUNT > SHIPPEDAMOUNT + CLOSEDAMOUNT) AND(AMOUNT<> CLOSEDAMOUNT))) AND(ORFL.AMOUNT - ORFL.SHIPPEDAMOUNT > 0) "  ;




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
             
            BaseKartTuru = KartTuru.AcikSatinalmaSiparisleri;
        }

          
    }
}