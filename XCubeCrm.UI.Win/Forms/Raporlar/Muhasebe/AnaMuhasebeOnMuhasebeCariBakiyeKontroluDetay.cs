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
using XCubeCrm.UI.Win.Show;
using static DevExpress.Diagram.Core.Native.Either;
using static DevExpress.XtraEditors.TextEdit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        string araSorguIsyeri = "";
         public AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay()
        {
 
            InitializeComponent();
         }
        protected override void Listele()
        {
             
            string sorgu = " SELECT *,SUM(BORC+ALACAK) OVER (ORDER BY TARIH) AS BAKIYE FROM ( " +
                 " SELECT DATE_ AS TARIH, SUM(BORC) BORC, SUM(ALACAK) ALACAK, SUM(TUTAR) AS TUTAR FROM( " +
 " SELECT     C.DATE_, CASE SIGN WHEN 0 THEN  ROUND(AMOUNT, 3) ELSE 0 END  BORC, " +
 " CASE  SIGN WHEN 1 THEN  ROUND(-1 * AMOUNT, 2) ELSE 0 END  ALACAK, " +
 "  CASE SIGN WHEN 0 THEN  ROUND(AMOUNT, 2) ELSE  ROUND(-1 * AMOUNT, 2) END TUTAR " + 
 "  FROM " + AnaForm.db +".DBO.LG_" + AnaForm.firma +"_" +AnaForm.donem + "_CLFLINE C " +
 "  WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = " + Id + ") AS AAA " +
 "  GROUP BY DATE_ )AS BBB" ;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.baglanti());

            grid.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;




            string sorgu2 = "  SELECT *,SUM(BORC+ALACAK) OVER (ORDER BY TARIH) AS BAKIYE FROM ( " +
                "  SELECT  F.DATE_ TARIH,  " +
 " CASE F.SIGN WHEN 0 THEN ROUND((F.DEBIT -F.CREDIT),3) ELSE 0 END AS BORC, " +
 " CASE F.SIGN WHEN 1 THEN ROUND((F.DEBIT -F.CREDIT),3) ELSE 0 END AS ALACAK , " +
 " CASE SIGN WHEN 0 THEN ROUND((F.DEBIT -F.CREDIT),3) ELSE ROUND(-1 * (F.DEBIT - F.CREDIT),3) END TUTAR " +
 " FROM " + AnaForm.db +".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE F " +
 " WHERE F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.ACCOUNTREF = (SELECT ACCOUNTREF FROM " + AnaForm.db +".DBO.LG_" + AnaForm.firma + "_CRDACREF WHERE CARDREF = " + Id + " AND TRCODE = 5)) AS BBBB ";

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
             
            BaseKartTuru = KartTuru.AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay;
         }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
           // ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay2>.ShowReportDialogListForm();
            //ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay>.ShowDialogListForm(KartTuru.AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay, 55);
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