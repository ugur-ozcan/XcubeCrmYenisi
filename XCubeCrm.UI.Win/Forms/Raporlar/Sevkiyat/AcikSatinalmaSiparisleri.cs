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
    public partial class AcikSatinalmaSiparisleri : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public AcikSatinalmaSiparisleri( )
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
            string sorgu3 = " select " +
" ORFL.LOGICALREF Id, " +
" ORFL.ORDFICHEREF, " +
" ORF.CLIENTREF, " +
" ITS.LOGICALREF AS URUNID,  " +
" DATEDIFF(day, ORFL.DUEDATE, GETDATE()) as KALANGUN, " +
" CASE WHEN ORF.TRCODE = 1 THEN 'Satış/Pazarlama Siparişleri' " +
" WHEN ORF.TRCODE = 2 THEN 'Alış/Satınalma Siparişleri'ELSE 'Diğer' END AS SIPARISTURU, " +
" ORF.DATE_ as SIPARISTARIHI, " +
" ORFL.DUEDATE AS TESLIMTARIHI, " +
" ORF.FICHENO as SIPARISNO, " +
" ORF.DOCODE AS BELGENO, " +
" ORF.GENEXP1 + '-' + ORF.GENEXP2 + '-' + '-' + ORF.GENEXP3 + '-' + ORF.GENEXP4 + '-' + ORF.GENEXP5 + '-' + ORF.GENEXP6 AS SIPARISACIKLAMA, " +
" CLC.CODE AS CARIKOD, " +
" CLC.DEFINITION_ AS UNVAN, " +
" ITS.CODE as URUNKOD, " +
" ITS.NAME as URUNADI, " +
" ORFL.AMOUNT as SIPARISMIKTARI, " +
" ORFL.SHIPPEDAMOUNT as SEVKEDILENMIKTAR, " +
" ISNULL((SELECT SUM(ORP.MAINMEETAMNT) FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORDPEGGING ORP WHERE  ORP.PARENTREF = ORFL.LOGICALREF AND  PURORDLNREF   IN( " +
" select ORFLL.LOGICALREF from " + AnaForm.db + ".DBO.lg_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE ORFLL " +
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ORFF ON ORFF.LOGICALREF = ORFLL.ORDFICHEREF " +
" WHERE   LINETYPE NOT IN(2, 3, 7) AND ORFLL.CLOSED = 0  AND " +
" (ORFLL.AMOUNT - ORFLL.SHIPPEDAMOUNT > 0)) " +
"           ),0) REZERVESATISSIPARISI, " +
" KIMEGIDECEK =  " +
" STUFF(((SELECT LEFT(DEFINITION_, 15) + ' - ' AS ASDD FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CLCC WHERE LOGICALREF IN " +
" (SELECT  SUPPLIERREF  FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORDPEGGING ORP WHERE  ORP.PARENTREF = ORFL.LOGICALREF AND  PURORDLNREF   IN( " +
" select ORFLL.LOGICALREF from " + AnaForm.db + ".DBO.lg_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE ORFLL " +
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ORFF ON ORFF.LOGICALREF = ORFLL.ORDFICHEREF " +
" WHERE   LINETYPE NOT IN(2, 3, 7) AND ORFLL.CLOSED = 0  AND " +
" (ORFLL.AMOUNT - ORFLL.SHIPPEDAMOUNT > 0)))   FOR XML PATH(''), TYPE)).value('.', 'NVARCHAR(MAX)'), 1, 0, '') ,  " +
" KIMEGIDECEKSEVKTARIHI =   " +
" STUFF(( " +
" (SELECT CONVERT(NVARCHAR, CONVERT(DATE, DUEDATE)) + ' - '  FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE WHERE LOGICALREF IN " +
" (SELECT  PURORDLNREF FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORDPEGGING ORP " +
" WHERE PARENTREF = ORFL.LOGICALREF) " +
" AND   LINETYPE NOT IN(2, 3, 7) AND CLOSED = 0  AND " +
" (AMOUNT - SHIPPEDAMOUNT > 0) FOR XML PATH(''))), 1, 0, '') , " +
" ORFL.AMOUNT - (ORFL.SHIPPEDAMOUNT) as 'REZERVESIZ_KALAN_BEKLEYEN_MIKTAR', " +
" ORFL.AMOUNT - (ORFL.SHIPPEDAMOUNT + " +
" ISNULL((SELECT SUM(ORP.MAINMEETAMNT) FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORDPEGGING ORP WHERE  ORP.PARENTREF = ORFL.LOGICALREF AND  PURORDLNREF   IN( " +
" select ORFLL.LOGICALREF from " + AnaForm.db + ".DBO.lg_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE ORFLL " +
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ORFF ON ORFF.LOGICALREF = ORFLL.ORDFICHEREF " +
" WHERE   LINETYPE NOT IN(2, 3, 7) AND ORFLL.CLOSED = 0  AND " +
" (ORFLL.AMOUNT - ORFLL.SHIPPEDAMOUNT > 0))), 0)) as KALANBEKLEYEN_MIKTAR, " +
" BIRIM.CODE AS ANABIRIM, " +
" ORFL.LINEEXP AS SIPARISSATIRACIKLAMA, " +
" CONVERT(DECIMAL(18, 3), ORFL.PRICE) AS FIYAT, " +
" CONVERT(DECIMAL(18, 3), (ROUND(CASE WHEN ORFL.PRCURR = 0 THEN ORFL.PRICE WHEN ORFL.PRCURR = 160 THEN ORFL.PRICE ELSE ISNULL(ORFL.PRICE / NULLIF(ORFL.PRRATE, 0), 0) END, 4))) AS DOVIZLIFIYAT,  " +
" CASE WHEN ORFL.PRCURR = 0 THEN 'TL' WHEN ORFL.PRCURR = 160 THEN 'TL' WHEN ORFL.PRCURR = 1 THEN 'USD' WHEN ORFL.PRCURR = 20 THEN 'EUR' END AS DOVIZ, " +
" ORFL.PRRATE AS SATIRKURU, " +
" ORFL.TRRATE AS FISKURU, " +
" ORFL.TOTAL AS 'TUTAR_TL', " +
" PYP.CODE AS 'VADE' " +
" FROM " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE ORFL ON ORFL.STOCKREF = ITS.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ORF ON ORF.LOGICALREF = ORFL.ORDFICHEREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CLC ON ORF.CLIENTREF = CLC.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_PAYPLANS PYP ON PYP.LOGICALREF = ORF.PAYDEFREF " +
" LEFT OUTER JOIN  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_UNITSETL AS BIRIM ON(BIRIM.UNITSETREF= ITS.UNITSETREF) " +
" WHERE ITS.ACTIVE = 0 AND ORF.CANCELLED = 0 " + araSorgu + " AND ORF.STATUS = 4 AND " + 
" CLC.ACTIVE = 0 AND ORFL.TRCODE = 2 AND ORFL.CLOSED = 0 AND ORFL.AMOUNT - ORFL.SHIPPEDAMOUNT > 0 AND BIRIM.MAINUNIT = 1 and ITS.CARDTYPE In(1,2,3,4,10,11,12,13,20,21) " +
araSorgu;




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