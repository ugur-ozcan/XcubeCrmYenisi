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
    public partial class AnaMuhasebeOnMuhasebeCariBakiyeKontrolu : BaseReportListForm 
    {
        sqlBaglanti bgl = new sqlBaglanti();
        string araSorgu = "";
        string araSorguIsyeri = "";
        public AnaMuhasebeOnMuhasebeCariBakiyeKontrolu( )
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
            if (AnaForm.satisElemani != "")
            {
                araSorgu += " and CLC.LOGICALREF IN (" + " SELECT   LOGICALREF FROM ( " +
" SELECT LOGICALREF,   " +
" (SELECT TOP 1 SL.SALESMANREF FROM   " + AnaForm.db + "DBO.LG_" + AnaForm.firma + "_SLSCLREL SL  " +
" JOIN  " + AnaForm.db + "DBO.LG_SLSMAN  SLS ON SL.CLIENTREF=CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR =" + AnaForm.firma + " ORDER BY  SL.LOGICALREF DESC ) AS SALESMANREF " +
" FROM  " + AnaForm.db + "DBO.LG_" + AnaForm.firma + "_CLCARD CL " +
" ) AS AAA WHERE AAA.SALESMANREF IN ( " + AnaForm.satisElemani + "))";
            }
            string sorgu = " SELECT A.LOGICALREF Id, ";
            sorgu += " 'BakiyeFarklar - ' + convert(nvarchar(50), ROW_NUMBER() OVER(ORDER BY CariKodOn desc)) as Kod,";
            sorgu += " CariKodOn, CariUnvanOn, MuhasebeKod, MuhasebeUnvan, ISNULL ";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE F";
            sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND F.TRCODE = 1 AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeAcilis,";
            sorgu += " ISNULL ";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE F";
            sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeBakiye, isNULL";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE C";
            sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND C.CLIENTREF = A.LOGICALREF AND C.TRCODE = 14), 0) AS CariAcilis, isNULL";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE C";
            sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND C.CLIENTREF = A.LOGICALREF), 0) AS CariBakiye";
            sorgu += " FROM(SELECT     LOGICALREF, CODE AS CariKodOn, DEFINITION_ AS CariUnvanOn,";
            sorgu += " (SELECT     MK.CODE ";
            sorgu += " FROM         " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_EMUHACC MK ";
            sorgu += " WHERE      MK.LOGICALREF =";
            sorgu += " (SELECT     B.ACCOUNTREF ";
            sorgu += " FROM         " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF B ";
            sorgu += " WHERE(B.TRCODE = 5) AND CLC.LOGICALREF = B.CARDREF)) AS MuhasebeKod,";
            sorgu += " (SELECT     MK.DEFINITION_ ";
            sorgu += " FROM         " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_EMUHACC MK";
            sorgu += " WHERE      MK.LOGICALREF =";
            sorgu += " (SELECT     B.ACCOUNTREF ";
            sorgu += " FROM         " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CRDACREF B";
            sorgu += " WHERE(B.TRCODE = 5) AND CLC.LOGICALREF = B.CARDREF)) AS MuhasebeUnvan";
            sorgu += " FROM         " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CLC WHERE 1=1 " + araSorgu + ") A ";
            sorgu += " WHERE ISNULL ";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_EMFLINE F";
            sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "' AND F.ACCOUNTCODE = A.MuhasebeKod), 0) <>";
            sorgu += " isNULL ";
            sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            sorgu += " FROM        " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_CLFLINE C";
            sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ BETWEEN '" + AnaForm.baslangicTarihi + "' AND '" + AnaForm.bitisTarihi + "'  AND C.CLIENTREF = A.LOGICALREF), 0) ";

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
             
            BaseKartTuru = KartTuru.AnaMuhasebeOnMuhasebeCariBakiyeKontrolu;
         }

        private void grid_DoubleClick(object sender, EventArgs e)
        {

            int idsi = (int)(tablo.GetFocusedRowCellValue("Id"));
            if (tablo.FocusedRowHandle < 1) return; 
           


            //ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay>.ShowReportDialogListForm();
            ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay>.ShowDialogListForm(KartTuru.AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay, idsi );

        }
    }
}