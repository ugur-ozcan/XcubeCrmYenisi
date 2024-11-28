using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Bll.General;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.GenelForms;
using XCubeCrm.UI.Win.Show;


namespace XCubeCrm.UI.Win.Forms.AileBilgiForms
{
    public partial class AileBilgiListForm : BaseListForm
    {
        string donem = "01", firma = "224", db = "LOGODB";
        sqlBaglanti bgl = new sqlBaglanti();
        public AileBilgiListForm()
        {
            InitializeComponent();
            Bll = new AileBilgiBll();
            RaporMu = true;
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
           
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            FormShow = new ShowEditForms<AileBilgiEditForm>();
            Navigator = longNavigator1.Navigator;
        }
        protected override void Listele()
        {

            string sorgu =   " SELECT " +
 " A.LOGICALREF Id, " +
 " 'BakiyeFarklar - ' + convert(nvarchar(50), ROW_NUMBER() OVER(ORDER BY CariKodOn desc)) as Kod,  " +
 " CariKodOn, CariUnvanOn, MuhasebeKod,  " +
" MuhasebeUnvan,  " +
" ISNULL((SELECT     CONVERT(DECIMAL(18, 3), SUM(F.DEBIT - F.CREDIT)) " +
 " FROM         "+ AnaForm.db +  ".DBO.LG_"+ AnaForm.firma + "_"+ AnaForm.donem +  "_EMFLINE F " +
 " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.TRCODE = 1 AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeAcilis,  " +
 " ISNULL((SELECT     CONVERT(DECIMAL(18, 3), SUM(F.DEBIT - F.CREDIT)) " +
 " FROM         "+ AnaForm.db +  ".DBO.LG_"+ AnaForm.firma + "_"+ AnaForm.donem +  "_EMFLINE F " +
 " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.ACCOUNTCODE = A.MuhasebeKod), 0) AS MuhasebeBakiye,  " +
" isNULL((SELECT     CONVERT(DECIMAL(18, 3), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) " +
 " FROM         "+ AnaForm.db +  ".DBO.LG_"+ AnaForm.firma + "_"+ AnaForm.donem +  "_CLFLINE C " +
 " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF AND C.TRCODE = 14), 0) AS CariAcilis,  " +
" isNULL((SELECT     CONVERT(DECIMAL(18, 3), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) " +
 " FROM         " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem +  "_CLFLINE C " +
 " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF), 0) AS CariBakiye  " +
 " FROM(SELECT     LOGICALREF, CODE AS CariKodOn, DEFINITION_ AS CariUnvanOn,  " +
 " (SELECT     MK.CODE FROM          " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_EMUHACC MK " +
 " WHERE      MK.LOGICALREF =  " +
 " (SELECT     B.ACCOUNTREF " +
 " FROM          " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_CRDACREF B " +
 " WHERE(B.TRCODE = 5) AND CK.LOGICALREF = B.CARDREF)) AS MuhasebeKod,  " +
 " (SELECT     MK.DEFINITION_ " +
 " FROM          " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_EMUHACC MK  " +
 " WHERE      MK.LOGICALREF =  " +
 " (SELECT     B.ACCOUNTREF " +
 " FROM          " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_CRDACREF B  " +
 " WHERE(B.TRCODE = 5) AND CK.LOGICALREF = B.CARDREF)) AS MuhasebeUnvan  " +
 " FROM          " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_CLCARD CK) A " +
 " WHERE ISNULL " +
 " ((SELECT     CONVERT(DECIMAL(18, 3), SUM(F.DEBIT - F.CREDIT)) " +
 " FROM         " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.firma + "_EMFLINE F  " +
 " WHERE     F.CANCELLED = 0 AND F.DATE_ <= GETDATE() AND F.ACCOUNTCODE = A.MuhasebeKod), 0) <>  " +
 " isNULL " +
 " ((SELECT     CONVERT(DECIMAL(18, 3), SUM(CASE C.SIGN WHEN 0 THEN C.AMOUNT ELSE C.AMOUNT * -1 END)) " +
 " FROM         " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_CLFLINE C  " +
 " WHERE     C.CANCELLED = 0 AND C.DATE_ <= GETDATE() AND C.CLIENTREF = A.LOGICALREF), 0)   ";


            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.baglanti());

            grid.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;

            tablo.OptionsView.ColumnAutoWidth = false;
            tablo.GridControl.DataSource = dt1;
        }
    }
}