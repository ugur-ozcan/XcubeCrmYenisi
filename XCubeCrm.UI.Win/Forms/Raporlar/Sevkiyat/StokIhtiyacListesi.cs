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
    public partial class StokIhtiyacListesi : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public StokIhtiyacListesi( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
            araSorgu = "";
             
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
                araSorgu += " AND L_CAP.NR  IN ( SELECT DISTINCT(NR) FROM " + AnaForm.db + ".DBO.L_CAPIWHOUSE WHERE FIRMNR ='" + AnaForm.firma + "' AND DIVISNR IN (   " + AnaForm.isyeri + "))";
            }
            if (AnaForm.ambar != "")
            {
                araSorgu += " AND L_CAP.NR  IN (" + AnaForm.ambar + ")";
            }

            string eklemeSorgusu = " INSERT INTO " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_INVDEF  " +
" SELECT " +
" w.NR AS AmbarID, i.LOGICALREF AS ProductID, 0,0,0,0,NULL,0,0,0,0,0,0,0,0 " +
" FROM " +
" " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_ITEMS i " +
" CROSS JOIN " +
" " + AnaForm.db + ".DBO.L_CAPIWHOUSE w " +
" LEFT JOIN " +
" " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_INVDEF d " +
" ON i.LOGICALREF = d.ITEMREF " +
" AND w.NR = d.INVENNO " +
" WHERE " +
" d.ITEMREF IS NULL " +
" and w.FIRMNR = " + AnaForm.firma + " " +
" AND i.ACTIVE = 0 " +
" ORDER BY i.LOGICALREF ";

            SqlCommand komut = new SqlCommand(eklemeSorgusu, bgl.baglanti());

            //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
            komut.ExecuteNonQuery();
            string sorgu3 = string.Empty;




              sorgu3 = " WITH Sales AS( " +
" SELECT " +
" SL.STOCKREF AS STOCKREF, " +
" SL.SOURCEINDEX AS DEPONO, " +
" SUM(CASE WHEN SL.TRCODE IN(7, 8) THEN SL.AMOUNT ELSE 0 END) AS TOTAL_SALES " +
" FROM " + AnaForm.db + ".DBO.lg_" + AnaForm.firma + "_" + AnaForm.donem + "_STLINE SL " +
" GROUP BY SL.STOCKREF, SL.SOURCEINDEX " +
" ), " +
" Orders AS( " +
" SELECT " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.SOURCEINDEX DEPONO, " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.STOCKREF, " +
" SUM(ISNULL(" + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.AMOUNT, 0) - ISNULL(" + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.SHIPPEDAMOUNT, 0)) AS PENDING_ORDERS " +
" FROM " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE " +
" INNER JOIN " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE ON " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.ORDFICHEREF = " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFICHE.LOGICALREF " +
" WHERE(" + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_ORFLINE.TRCODE = 1)    and(" + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFICHE.LOGICALREF IN " +
" (SELECT ORDFICHEREF " +
" FROM(SELECT ORDFICHEREF, SUM(AMOUNT) AS AMOUNT, SUM(CASE SIGN(OTRNS.CLOSED) WHEN 1 THEN OTRNS.AMOUNT ELSE 0 END) AS CLOSEDAMOUNT, SUM(CASE SIGN((OTRNS.SHIPPEDAMOUNT - OTRNS.AMOUNT)) " +
" WHEN 1 THEN OTRNS.AMOUNT ELSE OTRNS.SHIPPEDAMOUNT END) AS SHIPPEDAMOUNT " +
" FROM      " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE AS OTRNS " +
" WHERE(LINETYPE NOT IN(2, 3, 7)  AND OTRNS.STOCKREF = " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE.STOCKREF) " +
" GROUP BY ORDFICHEREF) AS TEMP " +
" WHERE(SHIPPEDAMOUNT = 0) AND(AMOUNT<> CLOSEDAMOUNT) OR " +
" (SHIPPEDAMOUNT<> 0) AND(AMOUNT > SHIPPEDAMOUNT + CLOSEDAMOUNT) AND(AMOUNT<> CLOSEDAMOUNT))) AND(" + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE.AMOUNT - " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE.SHIPPEDAMOUNT > 0) " +
" GROUP BY " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE.SOURCEINDEX, " +
" " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_01_ORFLINE.STOCKREF " +
" ), " +
" AcikSatinalmaSiparisi as ( " +
" select " +
" STOCKREF, " +
" SOURCEINDEX, " +
" SUM(AMOUNT - SHIPPEDAMOUNT) AS ACIKMIKTAR FROM[" + AnaForm.db + "].[dbo].LG_" + AnaForm.firma + "_01_ORFLINE " +
" WHERE  TRCODE = 2 AND CANCELLED = 0 " +
" AND((AMOUNT - SHIPPEDAMOUNT)) > 0 AND CLOSED = 0   AND LINETYPE = 0 " +
" GROUP BY STOCKREF, " +
" SOURCEINDEX " +
" ) " +
" SELECT * ,  (ELDEKISTOK + ACIKSATINALMASIPARISI) - (MINIMUMSTOK + BEKLEYENSIPARIS) as IHTIYAC FROM( " +
" SELECT " +
" L_CAP.NAME AS DEPO " +
"  , ITS.LOGICALREF " +
" , ITS.CODE AS URUNKOD " +
" , ITS.NAME URUNAD " +
" , INV.MINLEVEL MINIMUMSTOK " +
" , INV.MAXLEVEL MAXIMUMSTOK " +
"  , SUM(ISNULL(STI.ONHAND, 0)) AS ELDEKISTOK " +
"  , ISNULL(SLS.TOTAL_SALES, 0) AS SATIS " +
"  , ISNULL(ORD.PENDING_ORDERS, 0) BEKLEYENSIPARIS " +
"  , ISNULL(ASS.ACIKMIKTAR, 0) ACIKSATINALMASIPARISI " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_INVDEF INV " +
" JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_ITEMS ITS ON ITS.LOGICALREF = INV.ITEMREF " +
" JOIN " + AnaForm.db + ".DBO.L_CAPIWHOUSE L_CAP ON L_CAP.NR = INV.INVENNO AND L_CAP.FIRMNR = " + AnaForm.firma + " " +
" LEFT JOIN " + AnaForm.db + ".DBO.LV_" + AnaForm.firma + "_01_STINVTOT STI ON  INV.ITEMREF = STI.STOCKREF AND INV.INVENNO = STI.INVENNO " +
" LEFT JOIN Sales SLS ON SLS.DEPONO = INV.INVENNO AND SLS.STOCKREF = INV.ITEMREF " +
" LEFT JOIN Orders ORD ON ORD.DEPONO = INV.INVENNO AND ORD.STOCKREF = INV.ITEMREF " +
" LEFT JOIN AcikSatinalmaSiparisi ASS ON ASS.SOURCEINDEX = INV.INVENNO AND ASS.STOCKREF = INV.ITEMREF " +
" WHERE 1 = 1 " + araSorgu + 
" GROUP BY " +
" L_CAP.NAME " +
" , ITS.LOGICALREF " +
" , L_CAP.NR " +
" , ITS.CODE " +
" , ITS.NAME " +
" , INV.MINLEVEL " +
" , INV.MAXLEVEL " +
" , SLS.TOTAL_SALES " +
" , ORD.PENDING_ORDERS " +
" , ASS.ACIKMIKTAR " +
"  ) AS AAAA   " +
" ORDER BY ((ELDEKISTOK + ACIKSATINALMASIPARISI)  -(MINIMUMSTOK + BEKLEYENSIPARIS) ) DESC ";




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
             
            BaseKartTuru = KartTuru.StokIhtiyacListesi;
        }

          
    }
}