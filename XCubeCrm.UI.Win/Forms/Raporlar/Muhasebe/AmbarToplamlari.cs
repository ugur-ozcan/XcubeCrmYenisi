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
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class AmbarToplamlari : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        string araSorguIsyeri = "";
        public AmbarToplamlari( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
            araSorgu = "";
            araSorguIsyeri = "";
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
                araSorgu += "AND ITS.SPECODE IN (" + AnaForm.urunOzelKod.Replace("'","''") + ")";
            }
            if (AnaForm.urunOzelKod2 != "")
            {
                araSorgu += "AND ITS.SPECODE2 IN (" + AnaForm.urunOzelKod2.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod3 != "")
            {
                araSorgu += "AND ITS.SPECODE3 IN ("+ AnaForm.urunOzelKod3.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod4 != "")
            {
                araSorgu += "AND ITS.SPECODE4 IN ("+ AnaForm.urunOzelKod4.Replace("'", "''") + ")";
            }
            if (AnaForm.urunOzelKod5 != "")
            {
                araSorgu += "AND ITS.SPECODE5 IN ("+ AnaForm.urunOzelKod5.Replace("'", "''") + ")";
            }
            if (AnaForm.urunGrup != "")
            {
                araSorgu += "AND ITS.STGRPCODE IN ("+ AnaForm.urunGrup.Replace("'", "''") + ")";
            }
            if (AnaForm.urunTip != "")
            {
                araSorgu += "AND ITS.CARDTYPE IN (" + AnaForm.urunTip + ")";
            }

            if (AnaForm.isyeri != "")
            {
                araSorguIsyeri += "AND L_CAP.DIVISNR IN (" + AnaForm.isyeri + ")";
            }
            if (AnaForm.ambar != "")
            {
                araSorguIsyeri += "AND L_CAP.NR IN (" + AnaForm.ambar + ")";
            }
            string sorgu3 = "DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX), @tarih nvarchar(20), @firma nvarchar(3)='"+  AnaForm.firma + "',@bitistarihi nvarchar(25)='" + AnaForm.bitisTarihi+"'; " + 
"SELECT @columns = STUFF((SELECT ',' + QUOTENAME(NAME)   " + 
"                        FROM " + AnaForm.db + ".dbo.L_CAPIWHOUSE L_CAP where L_CAP.FIRMNR ='"+ AnaForm.firma + "' " + araSorguIsyeri +
"                        FOR XML PATH(''), TYPE " +
"                        ).value('.', 'NVARCHAR(MAX)') " + 
"                        ,1,1,''); " +
" SET @sql = ' " +
" SELECT URUNKODU,URUNADI, ' + @columns + ' " +
" FROM(" +
" SELECT     ITS.CODE URUNKODU, ITS.NAME URUNADI, L_CAP.NAME AS NAME, SUM(STINVTOT.ONHAND) AS MIKTAR " +
" FROM " + AnaForm.db + ".dbo.LV_"+ AnaForm.firma + "_"+ AnaForm.donem + "_STINVTOT AS STINVTOT LEFT OUTER JOIN " +
AnaForm.db + ".dbo.LG_"+ AnaForm.firma + "_ITEMS AS ITS ON STINVTOT.STOCKREF = ITS.LOGICALREF " +
" LEFT OUTER JOIN " + AnaForm.db + ".dbo.L_CAPIWHOUSE L_CAP ON L_CAP.NR = STINVTOT.INVENNO AND L_CAP.FIRMNR = ' + @firma +' " + 
" WHERE     (ITS.CARDTYPE = 1)  and STINVTOT.DATE_<= ''" + AnaForm.bitisTarihi + "'' " + araSorgu +
" GROUP BY ITS.CODE, ITS.NAME,L_CAP.NAME, ITS.CARDTYPE " +
" HAVING      (SUM(STINVTOT.ONHAND) <> 0) " +
" ) as SourceTable " +
" PIVOT(" +
"    SUM(MIKTAR) " +
"    FOR NAME IN (' + @columns + ') " +
" ) AS PivotTable; '; " +
" EXEC sp_executesql @sql;" ;





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
            raporTuru = "Stok,Ambar";
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}