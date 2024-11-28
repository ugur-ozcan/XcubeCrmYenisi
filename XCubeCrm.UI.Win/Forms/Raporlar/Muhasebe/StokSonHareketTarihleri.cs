using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class StokSonHareketTarihleri : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        public StokSonHareketTarihleri( )
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

            string sorgu3 = " WITH SonHareketler AS( " +
" SELECT STL.*, " +
" ROW_NUMBER() OVER(PARTITION BY STOCKREF ORDER BY STL.DATE_ DESC) AS rn " +
" FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem + "_STLINE STL  where STL.DATE_ BETWEEN '" + AnaForm.baslangicTarihi +"' AND '" + AnaForm.bitisTarihi +"'" +
" ) " +
" SELECT ITS.LOGICALREF Id, ITS.CODE KOD, ITS.NAME URUNADI, " +
" case ITS.ACTIVE " +
" when 1 then 'Pasif' " +
" else 'Aktif' end as DURUM, " +
" AMBARM.MIKTAR TOPLAMSTOK, " +
" DATE_ AS SONHAREKETTARIHI,  " +
" SH.AMOUNT MIKTAR, " +
" CASE WHEN TRCODE = 7 AND BILLED = 0 THEN 'Perakande Satış İrsaliyesi' " +
" WHEN TRCODE = 7 AND BILLED = 1 THEN 'Perakande Satış Faturası' " +
" WHEN TRCODE = 8 AND BILLED = 0 THEN 'Toptan Satış İrsaliyesi' " +
" WHEN TRCODE = 8 AND BILLED = 1 THEN 'Toptan Satış Faturası' " +
" WHEN TRCODE = 2 AND BILLED = 0 THEN 'Perakande Satış İade İrsaliyesi' " +
" WHEN TRCODE = 2 AND BILLED = 1 THEN 'Perakande Satış İade Faturası' " +
" WHEN TRCODE = 3 AND BILLED = 0 THEN 'Toptan Satış İade İrsaliyesi' " +
" WHEN TRCODE = 3 AND BILLED = 1 THEN 'Toptan Satış İade Faturası' " +
" WHEN TRCODE = 1 AND BILLED = 1 THEN 'Satınalma Faturası' " +
" WHEN TRCODE = 1 AND BILLED = 0 THEN 'Satınalma İrsaliyesi' " +
" WHEN TRCODE = 4 THEN 'Konsinye Çıkış İade İrsaliyesi' " +
" WHEN TRCODE = 5 THEN 'Konsinye Giriş İrsaliyesi' " +
" WHEN TRCODE = 6 AND BILLED = 0 THEN 'Satınalma İade İrsaliyesi' " +
" WHEN TRCODE = 6 AND BILLED = 1 THEN 'Satınalma İade Faturası' " +
" WHEN TRCODE = 9 THEN 'Konsinye Çıkış İrsaliyesi' " +
" WHEN TRCODE = 10 THEN 'Konsinye Giriş İade İrsaliyesi' " +
" WHEN TRCODE = 11 THEN 'Fire Fişi' " +
" WHEN TRCODE = 12 THEN 'Sarf Fişi' " +
" WHEN TRCODE = 13 THEN 'Üretimden Giriş Fişi' " +
" WHEN TRCODE = 14 THEN 'Devir Fişi' " +
" WHEN TRCODE = 25 THEN 'Ambar Fişi' " +
" WHEN TRCODE = 26 THEN 'Muhtahsil İrsaliyesi' " +
" WHEN TRCODE = 50 THEN 'Sayım Fazlası Fişi' " +
" WHEN TRCODE = 51 THEN 'Sayım Eksiği Fişi' ELSE '' END As HAREKETTIP " +
"  , SH.RN " +
" FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_ITEMS ITS " +
" LEFT    JOIN SonHareketler SH WITH(NOLOCK) ON ITS.LOGICALREF = SH.STOCKREF " +
" LEFT JOIN(SELECT SUM(ONHAND) MIKTAR, STOCKREF FROM " + AnaForm.db +  ".dbo.LV_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STINVTOT  WHERE INVENNO = -1 GROUP BY STOCKREF) " +
" AMBARM   ON ITS.LOGICALREF = AMBARM.STOCKREF " +
" WHERE " +
" (SH.rn = 1 OR SH.RN IS NULL ) " +
" ORDER BY ITS.CODE " ;





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
             
            BaseKartTuru = KartTuru.StokSonHareketTarihleri;
        }

          
    }
}