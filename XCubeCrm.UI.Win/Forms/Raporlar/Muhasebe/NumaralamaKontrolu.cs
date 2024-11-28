using DevExpress.CodeParser;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Concurrent;
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
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid;
using XCubeCrm.UI.Win.GenelForms;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe
{
    public partial class NumaralamaKontrolu : BaseReportListForm
    {
        sqlBaglanti bgl = new sqlBaglanti();
        public NumaralamaKontrolu()
        {
            InitializeComponent();
        }
        protected override void Listele()
        {
            string insert = "truncate table XCubeCrmDB.Dbo.NumaralamaKontrol;";
            DataTable dt = new DataTable();
            string sorgu = "  select DISTINCT (SEGMENTS1_SEGSTART) Seri ,'Fatura' Tip , (SELECT TOP 1 SUBSTRING(FICHENO,8,9) FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE WHERE FICHENO LIKE SEGMENTS1_SEGSTART+'%'  ORDER BY FICHENO DESC  ) as SonNumara   from " + AnaForm.db +  ".DBO.L_LDOCNUM WHERE FIRMID = " + AnaForm.firma +  "  AND APPMODULE IN (35, 44,47)" + Environment.NewLine;
            sorgu += " union all " + Environment.NewLine;
            sorgu += "  select DISTINCT (SEGMENTS1_SEGSTART) Seri ,'İrsaliye' Tip , (SELECT TOP 1 SUBSTRING(FICHENO,8,9) FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE WHERE FICHENO LIKE SEGMENTS1_SEGSTART+'%'  ORDER BY FICHENO DESC  ) as SonNumara from " + AnaForm.db +  ".DBO.L_LDOCNUM WHERE FIRMID = " + AnaForm.firma +  "  AND APPMODULE IN (46)";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int idVer = 0;
            while (dr.Read())
            {
                if (dr[2].ToString() != "")
                {
                     


                    for (int i = 1; i <= int.Parse(dr[2].ToString()); i++)
                    {
                        idVer++;
                        insert += "insert into XCubeCrmDB.dbo.NumaralamaKontrol values (" + idVer.ToString() + ",'" + idVer.ToString() + "','" + DokuzBasamakYap(dr[0].ToString() + DateTime.Now.Year.ToString(), i.ToString()) + "'" + ",'" + dr[1].ToString() + "',1);  " + Environment.NewLine; //dr[1].ToString() +" - " +DokuzBasamakYap(dr[0].ToString(),i.ToString()));
                    }
                }


            }
            SqlCommand komut2 = new SqlCommand(insert, bgl.baglanti());
            komut2.ExecuteNonQuery();
            string sorgu3 = " WITH AtlayanNumara AS( " +
" SELECT Id, Kod,Numara,FisTuru,'Numara Atlama' Hata FROM XCubeCrmDB.dbo.NumaralamaKontrol NRM   " +
" WHERE Numara NOT IN(SELECT FICHENO FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE WHERE len(FICHENO) = 16) AND FisTuru = 'Fatura' " +
" UNION ALL " +
" select LOGICALREF,LOGICALREF,FICHENO,'Fatura','Numara Atlama' Hata from  " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE INV WHERE FICHENO NOT IN(SELECT NUMARA FROM XCubeCrmDB.dbo.NumaralamaKontrol)  AND TRCODE IN(6, 7, 8, 9, 10, 14) " +
" UNION ALL " +
" SELECT Id, Kod,Numara,FisTuru,'Numara Atlama' Hata FROM XCubeCrmDB.dbo.NumaralamaKontrol NRM   " +
" WHERE Numara NOT IN(SELECT FICHENO FROM " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE  WHERE len(FICHENO) = 16) AND FisTuru = 'İrsaliye' " +
" UNION ALL " +
" select  LOGICALREF,LOGICALREF,FICHENO,'İrsaliye','Numara Atlama' Hata from  " + AnaForm.db +  ".DBO.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE INV WHERE FICHENO NOT IN(SELECT NUMARA FROM XCubeCrmDB.dbo.NumaralamaKontrol)  AND TRCODE IN(2, 4, 6, 7, 8, 9, 25, 26) " +
"  ) " +
" , " +
" FişBilgileri AS( " +
" SELECT " +
" 	LOGICALREF, " +
" LEFT(FICHENO, 3) AS SERI, " +
" SUBSTRING(FICHENO, 4, 16) AS NUMARA, " +
" 		 'Fatura' as TIP, " +
" 		 'Tarih Atlama' as HATA, " +
" DATE_ AS TARIH, " +
" LAG(DATE_) OVER(PARTITION BY LEFT(FICHENO, 3) ORDER BY  SUBSTRING(FICHENO, 4, 16)) AS ONCEKITARIH " +
" FROM " +
" " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_INVOICE WHERE TRCODE IN(6, 7, 8, 9) " +
" 		 UNION ALL " +
" 		     SELECT " +
" 			 LOGICALREF, " +
" LEFT(FICHENO, 3) AS SERI, " +
" SUBSTRING(FICHENO, 4, 16) AS NUMARA, " +
" 		 'İrsaliye' as TIP, " +
" 		 'Tarih Atlama' as HATA, " +
" DATE_ AS TARIH, " +
" LAG(DATE_) OVER(PARTITION BY LEFT(FICHENO, 3) ORDER BY  SUBSTRING(FICHENO, 4, 16)) AS ONCEKITARIH " +
" FROM " +
" " + AnaForm.db +  ".dbo.LG_" + AnaForm.firma +  "_" + AnaForm.donem +  "_STFICHE WHERE TRCODE IN(6, 7, 8, 9) AND LEN(FICHENO) = 16 " +
" ) " +
" SELECT * FROM AtlayanNumara " +
" UNION ALL " +
" SELECT " +
" LOGICALREF AS Id, " +
" LOGICALREF AS Kod, " +
" SERI + NUMARA as Numara, " +
" 	TIP FisTuru, " +
" 	HATA Tip  " +
" FROM " +
" FişBilgileri " +
" WHERE " +
" TARIH < ONCEKITARIH ";
 ;


            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());


            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            grid.DataSource = dt1;



            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(sorgu, bgl.baglanti());

            da1.SelectCommand.CommandTimeout = 0;
            da1.Fill(dt2);
            grid1.DataSource = dt2;
        }

        string SifirEkle(string deger)
        {
            if (deger.Length == 1) return "0" + deger;
            return deger;
        }

        string DokuzBasamakYap(string seri, string deger)
        {
            switch (deger.Length)
            {
                case 1:
                    return seri + "00000000" + deger;
                case 2:
                    return seri + "0000000" + deger;
                case 3:
                    return seri + "000000" + deger;
                case 4:
                    return seri + "00000" + deger;
                case 5:
                    return seri + "0000" + deger;
                case 6:
                    return seri + "000" + deger;
                case 7:
                    return seri + "00" + deger;
                case 8:
                    return seri + "0" + deger;
                case 9:
                    return seri + deger;

            }
            return seri + deger;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            if (tablo1.FocusedRowHandle > 0)
            {
                Tablo = tablo1;

            }
            BaseKartTuru = KartTuru.NumaralamaKontrol;
        }

        protected override void GridKontrolEt()
        {
            //string aaa = "";
            //Tablo = tablo;
            //if (tablo1.SelectedRowsCount > 0)
            //{
            //    Tablo = tablo1;
            //    aaa = "tablo1";


            //}
            //else if (tablo.SelectedRowsCount > 0)
            //{
            //    Tablo = tablo;
            //    aaa = "tablo";

            //}
            //MessageBox.Show(aaa);
        }

        private void tablo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedGridView = (GridView)sender;
            if (selectedGridView.SelectedRowsCount > 0)
            {
                Tablo = selectedGridView;
            }
        }

        private void tablo1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedGridView = (GridView)sender;
            if (selectedGridView.SelectedRowsCount > 0)
            {
                Tablo = selectedGridView;
            }
        }

        private void UpdateSelectedGridView()
        {

        }
    }
}