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
using System.Diagnostics;
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
using XCubeCrm.UI.Win.Show;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        string araSorguIsyeri = "";
         public AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay()
        {
 
            InitializeComponent();
         }
        protected override void Listele()
        {
             
            string sorgu = " SELECT *, SUM(BORC + ALACAK) OVER(ORDER BY TARIH) AS BAKIYE FROM( " +
    " SELECT DATE_  AS TARIH, " +
    " SUM(CASE SIGN WHEN 0 THEN - 1 * (AMOUNT - COSTTOT) ELSE 0 END) BORC, " +
    " SUM(CASE SIGN WHEN 1 THEN   1 * (AMOUNT - COSTTOT) ELSE 0 END)  ALACAK " +
    " FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_BNFLINE WHERE " +
    " BNACCREF = " + Id + "   AND CANCELLED = 0 AND DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' " +
    " GROUP BY DATE_ " + 
    "  ) AS AAA " ;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.baglanti());

            grid.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;




            string sorgu2 = " SELECT *, SUM(BORC + ALACAK) OVER(ORDER BY TARIH) AS BAKIYE FROM( " +
            " SELECT DATE_ AS TARIH, " +
" SUM(CASE SIGN WHEN 0 THEN - 1 * DEBIT ELSE 0 END) BORC, " +
" SUM(CASE SIGN WHEN 1 THEN CREDIT ELSE 0 END) ALACAK " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE WHERE DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND  CANCELLED = 0 AND ACCOUNTREF = ( " +
"    ISNULL((SELECT ACCOUNTREF FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF WHERE TYP = 1 AND TRCODE IN(6, 18) AND CARDREF = " + Id + "), 0)) " + 
" GROUP BY DATE_ ) AAA " ;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2, bgl.baglanti());

            grid2.DataSource = null;
            da2.SelectCommand.CommandTimeout = 0;
            da2.Fill(dt2);
            grid2.DataSource = dt2;



        }


        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
             
            BaseKartTuru = KartTuru.AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay;
         }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void tablo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedGridView = (GridView)sender;
            if (selectedGridView.SelectedRowsCount > 0)
            {
                Tablo = selectedGridView;
                
            }
        }

        private void tablo2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedGridView = (GridView)sender;
            if (selectedGridView.SelectedRowsCount > 0)
            {
                Tablo = selectedGridView;
            }
        }

        private void tablo2_Click(object sender, EventArgs e)
        {
            Tablo = tablo2;
        }
    }
}