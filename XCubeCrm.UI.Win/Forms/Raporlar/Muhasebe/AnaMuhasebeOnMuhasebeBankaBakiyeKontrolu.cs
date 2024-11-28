using DevExpress.CodeParser;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Native.Templates;
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
using Telerik.WinControls.Extensions;
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
    public partial class AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        string araSorguIsyeri = "";
        public AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu( )
        {
 
            InitializeComponent();
        }
        protected override void Listele()
        {
             
        string sorgu = " SELECT tablo.*, tablo.ONMUHASEBEBAKIYE-tablo.MUHASEBETUTARI AS FARK FROM( " +
"     SELECT SUBE.LOGICALREF, (SELECT CODE FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_BNCARD WHERE LOGICALREF= SUBE.BANKREF)BANKAKODU, " +
"     (SELECT DEFINITION_ FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_BNCARD WHERE LOGICALREF=SUBE.BANKREF)BANKAADI, " +
"     SUBE.CODE SUBEKODU, SUBE.DEFINITION_ SUBEADI, " +
"     ISNULL(ROUND((SELECT SUM(TOPLAM) FROM( " +
"     SELECT SUM(AMOUNT-COSTTOT) TOPLAM FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_01_BNFLINE WHERE DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND  " +
"     BANKREF=SUBE.BANKREF AND BNACCREF=SUBE.LOGICALREF AND SIGN=0 AND CANCELLED = 0 " +
" UNION ALL " +
"     SELECT -SUM(AMOUNT+COSTTOT)TOPLAM FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_BNFLINE WHERE  DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND  " +
"     BANKREF=SUBE.BANKREF AND BNACCREF=SUBE.LOGICALREF AND SIGN=1 AND CANCELLED = 0 )A),4),0)ONMUHASEBEBAKIYE, " +
"     (SELECT CODE FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_EMUHACC WHERE LOGICALREF=( " +
"     ISNULL((SELECT ACCOUNTREF FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF WHERE TYP= 1 AND TRCODE IN(6,18) AND CARDREF = SUBE.LOGICALREF),0)))MUHASEBEKODU, " +
"     (SELECT DEFINITION_ FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_EMUHACC WHERE LOGICALREF=( " +
"     ISNULL((SELECT ACCOUNTREF FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF WHERE TYP= 1 AND TRCODE IN(6,18) AND CARDREF = SUBE.LOGICALREF),0)))MUHASEBEHESABI, " +
"     (SELECT ISNULL(ROUND(SUM(DEBIT-CREDIT),2),0)TUTAR FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE WHERE DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND CANCELLED=0 AND ACCOUNTREF = ( " +
" ISNULL((SELECT ACCOUNTREF FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF WHERE TYP = 1 AND TRCODE IN(6, 18) AND CARDREF = SUBE.LOGICALREF), 0)))MUHASEBETUTARI " +
" FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_BANKACC SUBE WHERE ACTIVE= 0) tablo ORDER BY tablo.BANKAADI, tablo.SUBEADI ";


        DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.baglanti());

            grid.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;




        }

         
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
             
            BaseKartTuru = KartTuru.AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu;
         }

        private void grid_DoubleClick(object sender, EventArgs e)
        {

            int idsi = (int)(tablo.GetFocusedRowCellValue("LOGICALREF"));
            if (tablo.FocusedRowHandle < 1) return; 
           


            //ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay>.ShowReportDialogListForm();
            ShowReportListForms<AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay>.ShowDialogListForm(KartTuru.AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay, idsi );

        }
    }
}