using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Office.API.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.Doc;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Extensions;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class MutabakatRaporu : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public MutabakatRaporu( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
            araSorgu = "";
             
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
            if (AnaForm.satisElemani != "")
            {
                araSorgu += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_SLSCLREL SL  " +
" JOIN " + AnaForm.db + ".DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma + " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }
           

            string sorgu3 = " SELECT " +
 " Id,   " +
 " KOD,    " +
 " UNVAN, " +
 " VERGIDAIRE, " +
 " VERGINO, " +
 " TCNO, " +
 " TELNRS1, " +
 " TELNRS2, " +
 " YETKILI, " +
 " MAIL, " +
 " PERIYOT, " +
 " CONVERT(DECIMAL(18, 3), Borc) - CONVERT(DECIMAL(18, 3), Alacak) as BAKIYE,       " +
 " CONVERT(DECIMAL(18, 3), TlBorc) - CONVERT(DECIMAL(18, 3), TlAlacak) AS TLBAKIYE,    " +
 " CONVERT(DECIMAL(18, 3), UsdBorc) - CONVERT(DECIMAL(18, 3), UsdAlacak) AS USDBAKIYE,  " +
 " CONVERT(DECIMAL(18, 3), UsdYerelBorc) - CONVERT(DECIMAL(18, 3), UsdYerelAlacak) AS USDYERELBAKIYE,   " +
 " CONVERT(DECIMAL(18, 3), EuroBorc) - CONVERT(DECIMAL(18, 3), EuroAlacak) AS EUROBAKIYE,      " +
 " CONVERT(DECIMAL(18, 3), EuroYerelBorc) - CONVERT(DECIMAL(18, 3), EuroYerelAlacak) AS EUROYERELBAKIYE " +
 " FROM(    " +
 " SELECT " +
 " Id,   " +
 " Kod,    " +
 " Unvan,  " +
 " VERGIDAIRE,  " +
 " VERGINO, " +
 " TCNO, " +
 " TELNRS1, " +
 " TELNRS2, " +
 " YETKILI, " +
 " MAIL, " +
 " PERIYOT, " +
 " COALESCE(SUM(BORÇ), 0)Borc,    " +
 " COALESCE(SUM(Alacak), 0)Alacak,    " +
 " COALESCE(SUM([TlBorc]), 0)[TlBorc],    " +
 " COALESCE(SUM([TlAlacak]), 0)[TlAlacak],    " +
 " COALESCE(SUM([UsdBorc]), 0)[UsdBorc],    " +
 " COALESCE(SUM([UsdAlacak]), 0)[UsdAlacak],    " +
 " COALESCE(SUM([EuroBorc]), 0)[EuroBorc],    " +
 " COALESCE(SUM([EuroAlacak]), 0)[EuroAlacak],    " +
 " COALESCE(SUM([UsdYerelBorc]), 0)[UsdYerelBorc],    " +
 " COALESCE(SUM([UsdYerelAlacak]), 0)[UsdYerelAlacak],    " +
 " COALESCE(SUM([EuroYerelBorc]), 0)[EuroYerelBorc],    " +
 " COALESCE(SUM([EuroYerelAlacak]), 0)[EuroYerelAlacak],    " +
 " COALESCE(SUM([GBPYerelBorc]), 0)[GBPYerelBorc],    " +
 " COALESCE(SUM([GBPYerelAlacak]), 0)[GBPYerelAlacak],    " +
 " COALESCE(SUM([CHFYerelBorc]), 0)[CHFYerelBORÇ],    " +
 " COALESCE(SUM([CHFYerelAlacak]), 0)[CHFYerelAlacak] " +
 " FROM(    " +
 " SELECT " +
 " CLFL.DATE_ TARIH,    " +
  " CLC.LOGICALREF Id,   " +
 " CLC.CODE AS Kod,    " +
 " CLC.DEFINITION_ AS Unvan,  " +
 " CLC.TAXOFFICE VERGIDAIRE,  " +
 " CLC.TAXNR AS VERGINO, " +
 " CLC.TCKNO AS TCNO, " +
 " CLC.TELNRS1 TELNRS1, " +
 " CLC.TELNRS2 TELNRS2, " +
 " CLC.INCHARGE AS YETKILI, " +
 " CLC.EMAILADDR AS MAIL, " +
 " INCHTELEXTNUMS1 AS PERIYOT, " +
 " CASE WHEN CLFL.MONTH_ IS NULL THEN MONTH(CLFL.DATE_) ELSE CLFL.MONTH_ END AY,    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 THEN CLFL.AMOUNT END, 0) AS[BORÇ],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 THEN CLFL.AMOUNT END, 0) AS[Alacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 THEN CLFL.AMOUNT END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 THEN CLFL.AMOUNT END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) AS[TlBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) AS[TlAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(0, 160) THEN CLFL.TRNET END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Tl Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) AS[UsdBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) AS[UsdAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.TRNET END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Usd Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) AS[EuroBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) AS[EuroAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.TRNET END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[Euro Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) AS[UsdYerelBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) AS[UsdYerelAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[UsdYerel Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) AS[EuroYerelBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) AS[EuroYerelAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(20) THEN CLFL.AMOUNT END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[EuroYerel Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) AS[GBPYerelBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) AS[GBPYerelAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(17) THEN CLFL.AMOUNT END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[GBPYerel Bakiye],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0) AS[CHFYerelBorc],    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0) AS[CHFYerelAlacak],    " +
 " CAST(SUM(COALESCE(CASE WHEN CLFL.SIGN = 0 AND CLFL.TRCURR IN(1) THEN CLFL.AMOUNT END, 0) -    " +
 " COALESCE(CASE WHEN CLFL.SIGN = 1 AND CLFL.TRCURR IN(11) THEN CLFL.AMOUNT END, 0)) " +
 " OVER(PARTITION BY CLFL.CLIENTREF ORDER BY CLFL.DATE_, CLFL.FTIME, CLFL.LOGICALREF) AS decimal(38, 2))[CHFYerel Bakiye] " +
 " FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE AS CLFL LEFT OUTER JOIN " +
   AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD AS CLC ON CLFL.CLIENTREF = CLC.LOGICALREF " +
 " WHERE(CLFL.CANCELLED = 0) AND(CLC.ACTIVE = 0) AND(CLFL.PAIDINCASH = 0) " +
 " and CLFL.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND  '" + AnaForm.bitisTarihi + "' " + araSorgu + 
 "                  ) AS TMP " +
 " GROUP BY " +
 " ID,   " +
 " Kod,    " +
 " Unvan, " +
 " VERGIDAIRE,  " +
 " VERGINO, " +
 " TCNO, " +
 " TELNRS1, " +
 " TELNRS2, " +
 " YETKILI, " +
 " MAIL, " +
 " PERIYOT " +
 "    ) AS Bakiye    " +
 " ORDER BY Unvan " ;






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
             
            BaseKartTuru = KartTuru.MutabakatRaporu;
        }

          
    }
}