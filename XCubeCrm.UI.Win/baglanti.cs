using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.GenelForms;

namespace XCubeCrm.UI.Win
{
    class sqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=" + GirisForms.dbSunucuAdi + ";Initial Catalog=" + GirisForms.dbDatabaseAdi + ";Uid=" + GirisForms.dbKullaniciAdi + ";Password= " + GirisForms.dbSifre);

            //SqlConnection baglan = new SqlConnection(@"Data Source=UGUROZCAN\SQL2022;Initial Catalog=godb;Uid=SA;Password=LOGO");
            //SqlConnection baglan = new SqlConnection(@"Data Source=AYAZAGRI-PC;Initial Catalog=GOWINGS;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            //SqlConnection baglan = new SqlConnection(@"Data Source=MUHASEBE-PC\SQLEXPRESS;Initial Catalog=LOGODB;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            baglan.Close();
            baglan.Open();
            return baglan;

        }

        public SqlConnection baglantiXCubeCrm1()
        {
       
            SqlConnection baglan = new SqlConnection(@"Data Source=SERVER;Initial Catalog=GODB;Uid=ugur;Password=Aa123456");
            //SqlConnection baglan = new SqlConnection(@"Data Source=AYAZAGRI-PC;Initial Catalog=GOWINGS;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");

            //SqlConnection baglan = new SqlConnection(@"Data Source=MUHASEBE-PC\SQLEXPRESS;Initial Catalog=LOGODB;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");

            baglan.Close();
            baglan.Open();
            return baglan;
            baglan.Close();

        }
        public SqlConnection baglantiNJOY()
        {
            // SqlConnection baglan = new SqlConnection(@"Data Source=" + GirisForms.dbSunucuAdi + ";Initial Catalog=" + GirisForms.dbDatabaseAdi + ";Uid=" + GirisForms.dbKullaniciAdi + ";Password= " + GirisForms.dbSifre);

            SqlConnection baglan = new SqlConnection(@"Data Source=UGUROZCAN\SQL2022;Initial Catalog=njoyTEST;Uid=SA;Password=LOGO");
            //SqlConnection baglan = new SqlConnection(@"Data Source=AYAZAGRI-PC;Initial Catalog=GOWINGS;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            //SqlConnection baglan = new SqlConnection(@"Data Source=MUHASEBE-PC\SQLEXPRESS;Initial Catalog=LOGODB;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
      
            return baglan;

        }
        public SqlConnection baglantiUzakSunucu()
        {

            SqlConnection baglan = new SqlConnection(@"Data Source=94.73.170.5;Initial Catalog=u6149474_db441;Uid=u6149474_user441;Password=2fe38w3-:Uj=C-EB");
            //SqlConnection baglan = new SqlConnection(@"Data Source=AYAZAGRI-PC;Initial Catalog=GOWINGS;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            //SqlConnection baglan = new SqlConnection(@"Data Source=MUHASEBE-PC\SQLEXPRESS;Initial Catalog=LOGODB;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            baglan.Close();
            baglan.Open();
            return baglan;

        }

        public SqlConnection baglantIniDosyasi()
        {

            SqlConnection baglan = new SqlConnection(@"Data Source="+ AnaForm.SunucuAdi + ";Initial Catalog="+ AnaForm.DatabaseAdi + ";Uid=" + AnaForm.KullaniciAdi +";Password= " + AnaForm.Sifre );
            //SqlConnection baglan = new SqlConnection(@"Data Source=AYAZAGRI-PC;Initial Catalog=GOWINGS;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            //SqlConnection baglan = new SqlConnection(@"Data Source=MUHASEBE-PC\SQLEXPRESS;Initial Catalog=LOGODB;Uid=XCubeCrm;Password=Q7zjJ-TMA8+5K");
            baglan.Close();
            baglan.Open();
            return baglan;

        }
    }
}