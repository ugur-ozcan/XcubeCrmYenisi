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
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.GenelForms;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class MuhasebeHesapKoduFarkliOlanlar : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        public MuhasebeHesapKoduFarkliOlanlar( )
        {
           
            InitializeComponent();
        }
        protected override void Listele()
        {
            string sorgu = "SELECT " +
                " Id=CLCARD.LOGICALREF, " +
                " [Kod]=CLCARD.CODE, " +
                " [Unvan]=CLCARD.DEFINITION_, " +
                " KayıtTarihi = CLCARD.CAPIBLOCK_CREADEDDATE, " +
                " [MuhasebeKod]= ISNULL((SELECT CODE FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_EMUHACC WHERE LOGICALREF=(SELECT ACCOUNTREF FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CRDACREF WHERE  TRCODE=5 AND  CLCARD.LOGICALREF=CARDREF)),0) " +
                " FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CLCARD AS CLCARD " +
                " WHERE  CLCARD.CODE <> ISNULL((SELECT CODE FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_EMUHACC WHERE LOGICALREF=(SELECT ACCOUNTREF FROM " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_CRDACREF WHERE TRCODE=5 AND  CLCARD.LOGICALREF=CARDREF)),0)";
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
            BaseKartTuru = KartTuru.CariBakiyeler;



        }
    }
}