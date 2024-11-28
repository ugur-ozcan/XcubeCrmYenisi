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
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.GenelForms;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class GdoluHammadde : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        public GdoluHammadde( )
        {
           
            InitializeComponent();
        }
        protected override void Listele()
        {
            
            string sorgu3 = " SELECT * FROM NumaralamaKontrol  NRM  " +
 " WHERE Numara NOT IN (SELECT FICHENO FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE ) AND FisTuru = 'Fatura' " +
 " UNION ALL " +
 " select LOGICALREF,LOGICALREF,FICHENO,'FATURA',1 from " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE INV WHERE FICHENO NOT IN (SELECT NUMARA FROM NumaralamaKontrol)  AND TRCODE IN  (6,7,8,9,10,14) " +
 " UNION ALL  " +
 " SELECT * FROM NumaralamaKontrol NRM  " +
 " WHERE Numara NOT IN (SELECT FICHENO FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE ) AND FisTuru = 'İrsaliye' " +
 " UNION ALL " +
 " select  LOGICALREF,LOGICALREF,FICHENO,'İrsaliye',1 from " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE INV WHERE FICHENO NOT IN (SELECT NUMARA FROM NumaralamaKontrol)  AND TRCODE IN  (2,4,6,7,8,9,25,26) ";


            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());


            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;



            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(sorgu3, bgl.baglanti());

            da1.SelectCommand.CommandTimeout = 0;
            da1.Fill(dt2);
            grid2.DataSource = dt2;
        }
    }
}
