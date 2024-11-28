using DevExpress.Utils.FormShadow;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.UI.Win.Forms.OkulForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Navigators;
using XCubeCrm.UI.Win.Show;

namespace XCubeCrm.UI.Win.Forms.BaseReport
{
    public partial class Rapor1 : BaseReportListForm
    {
       
        sqlBaglanti bgl = new sqlBaglanti();
        public Rapor1(  )
        {
       
            InitializeComponent();
        }
        protected override void Listele()
        {
            string sorgu = " SELECT A.LOGICALREF Id, ";
            //sorgu += " 'BakiyeFarklar - ' + convert(nvarchar(50), ROW_NUMBER() OVER(ORDER BY CariKodOn desc)) as Kod,";
            //sorgu += " CariKodOn, CariUnvanOn, MuhasebeKod, MuhasebeUnvan, ISNULL ";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_EMFLINE F";
            //sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.TRCODE = 1 AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeAcilis,";
            //sorgu += " ISNULL ";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_EMFLINE F";
            //sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeBakiye, isNULL";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_CLFLINE C";
            //sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF AND C.TRCODE = 14), 0) AS CariAcilis, isNULL";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_CLFLINE C";
            //sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF), 0) AS CariBakiye";
            //sorgu += " FROM(SELECT     LOGICALREF, CODE AS CariKodOn, DEFINITION_ AS CariUnvanOn,";
            //sorgu += " (SELECT     MK.CODE ";
            //sorgu += " FROM         " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_EMUHACC MK ";
            //sorgu += " WHERE      MK.LOGICALREF =";
            //sorgu += " (SELECT     B.ACCOUNTREF ";
            //sorgu += " FROM         " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CRDACREF B ";
            //sorgu += " WHERE(B.TRCODE = 5) AND CK.LOGICALREF = B.CARDREF)) AS MuhasebeKod,";
            //sorgu += " (SELECT     MK.DEFINITION_ ";
            //sorgu += " FROM         " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_EMUHACC MK";
            //sorgu += " WHERE      MK.LOGICALREF =";
            //sorgu += " (SELECT     B.ACCOUNTREF ";
            //sorgu += " FROM         " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CRDACREF B";
            //sorgu += " WHERE(B.TRCODE = 5) AND CK.LOGICALREF = B.CARDREF)) AS MuhasebeUnvan";
            //sorgu += " FROM         " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CLCARD CK) A ";
            //sorgu += " WHERE ISNULL ";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(F.DEBIT - F.CREDIT)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_EMFLINE F";
            //sorgu += " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.ACCOUNTCODE = A.MuhasebeKod), 0) <>";
            //sorgu += " isNULL ";
            //sorgu += " ((SELECT     CONVERT(DECIMAL(18, 2), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) ";
            //sorgu += " FROM        " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_CLFLINE C";
            //sorgu += " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF), 0) ";

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
            BaseKartTuru = KartTuru.Rapor1;
    


        }
    }
}