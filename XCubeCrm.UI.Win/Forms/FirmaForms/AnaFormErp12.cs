
using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils.Gesture;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.Export;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;
using XCubeCrm.UI.Win.Forms.AileBilgiForms;
using XCubeCrm.UI.Win.Forms.BaseReport;
using XCubeCrm.UI.Win.Forms.FirmaForms;
using XCubeCrm.UI.Win.Forms.HesaplamaParametleriForms;
using XCubeCrm.UI.Win.Forms.IlForms;
using XCubeCrm.UI.Win.Forms.OkulForms;
using XCubeCrm.UI.Win.Forms.Raporlar.Muhasebe;
using XCubeCrm.UI.Win.Forms.Raporlar.Sevkiyat;
using XCubeCrm.UI.Win.Forms.TipForms;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Show;
using static DevExpress.Diagram.Core.Native.Either;
using static XCubeCrm.UI.Win.Forms.BaglantiAyarlari;
namespace XCubeCrm.UI.Win.GenelForms
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string DonemAdi = "Dönem Bilgisi Bekleniyor";
        public static string SubeAdi = "";
        public static string KullaniciAdi = "";
        public static string Sifre = "";
        public static string FirmaBilgi = "";
        public static string SunucuAdi = "";
        public static string DatabaseAdi = "";
        public static string baslangicTarihi = "";
        public static string bitisTarihi = "";
        public static string dovizTuru = "";
        public static string satisElemani = "";
        public static string isyeri = "";
        public static string ambar = "";
        public static string ozelKod = "", urunOzelKod = "";
        public static string ozelKod2 = "", AnaForm = "";
        public static string ozelKod3 = "", urunOzelKod3 = "";
        public static string ozelKod4 = "", urunOzelKod4 = "";
        public static string ozelKod5 = "", urunOzelKod5 = "";
        public static string yetkiKodu = "";
        public static string urunGrup = "", urunTip = "";


        public string kullaniciad = string.Empty;
        public string personelAd = string.Empty;
        public int kullaniciID = 0;
        int yil = 0;
        bool girisKontrolEt = true;



        public static string aktifKayilar = "0", aktifKayitlarUrun = "0";
        public static string cariLogicalref = "", urunLogicalref = "";

        sqlBaglanti bgl = new sqlBaglanti();
        public static string db = "";
        public static string firma = "";
        public static string donem = "";
        string araSorgu = "";


        public AnaForm(string firmaS, string donemS)
        {
            InitializeComponent();
            iniOku();
            firma = firmaS;
            donem = donemS;
            EventsLoad();
     
            //MessageBox.Show("Kullanici adı: " + KullaniciAdi + Environment.NewLine + "Şifre: " + Sifre + Environment.NewLine + "Sunucu : " + SunucuAdi + Environment.NewLine + "Şifre :" + Sifre);

        }

        private bool iniOku()
        {

            try
            {
                if (File.Exists(Application.StartupPath + @"\Ayarlar.ini"))
                {
                    INIKaydet ini = new INIKaydet(Application.StartupPath + @"\Ayarlar.ini");

                    KullaniciAdi = Sifreleme.coz(ini.Oku("KullaniciAdi", "Kullanıcı Adı"), "Ha9UL_6ja31.");
                    Sifre = Sifreleme.coz(ini.Oku("Sifre", "Şifre"), "Ha9UL_6ja31.");
                    SunucuAdi = Sifreleme.coz(ini.Oku("Sunucu", "SunucuIp"), "Ha9UL_6ja31.");
                    DatabaseAdi = Sifreleme.coz(ini.Oku("Veritabani", "VeritabanıAdı"), "Ha9UL_6ja31.");
                    FirmaBilgi = Sifreleme.coz(ini.Oku("Firma", "Firma"), "Ha9UL_6ja31.");
                    donem = Sifreleme.coz(ini.Oku("Donem", "Donem"), "Ha9UL_6ja31.");
                    db = DatabaseAdi;
                    return true;
                }
                else
                {
                    this.Hide();
                    return false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("ini dosyası hasarlı" + hata.Message);
                Application.Exit();
                return false;
            }

        }
        private void EventsLoad()
        {
            List<string> tempList = new List<string>();

            DataTable dt = new DataTable();
            string sorgu = " SELECT LCP.LOGICALREF, LCF.NR AS FIRMANO, '0'+ CONVERT(char,LCP.NR) AS DONEM, LCF.NAME AS FIRMA  FROM " + AnaForm.db + ".DBO.L_CAPIFIRM LCF " +
                                " JOIN  " + AnaForm.db + ".DBO.L_CAPIPERIOD LCP ON LCF.NR=LCP.FIRMNR " +
                                " ORDER BY LCP.BEGDATE DESC,LCF.NR ASC";

            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int idVer = 0;
            while (dr.Read())
            {
                // MessageBox.Show(dr[0].ToString() + " - " + dr[1].ToString());
                tempList.Add(dr[1].ToString() + " - " + dr[3].ToString());
            }

            //Assign the List<> to the ComboBoxEdit  
            (cmbFirmaSecimi.Edit as RepositoryItemComboBox).Items.AddRange(tempList);

            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarButtonItem btn:
                        btn.ItemClick += Buttonlar_ItemClick;

                        break;
                }

            }


            Listele();

        }

        void Listele()
        {


            //      



            dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 31);


            AktifKayitlariListele();
            CariHesapListele();
            YetkiKoduListele();
            OzelKodListele();
            OzelKod2Listele();
            OzelKod3Listele();
            OzelKod4Listele();
            OzelKod5Listele();
            DovizTuruListele();
            SatisElemaniListele();
            AktifKayitlariListeleUrun();
            UrunListele();
            OzelKodListeleUrun();
            OzelKodListeleUrun2();
            OzelKodListeleUrun3();
            OzelKodListeleUrun4();
            OzelKodListeleUrun5();
            UrunGrupListele();
            UrunTipListele();
            IsyeriListele();
            AmbarListele();
        }
        void AktifKayitlariListele()
        {
            if (hchCariAktifKayitlar.Checked)
            {
                aktifKayilar = "0";
            }
            else
            {
                aktifKayilar = "0,1";
            }
        }
        void CariHesapListele()
        {
            DataTable dtCariHesap = new DataTable();
            string sorguCariHesap = " SELECT LOGICALREF, " +
                                    " CODE KOD, " +
                                    " DEFINITION_ UNVAN, " +
                                    " case CARDTYPE when 1 then 'Alıcı' " +
                                    " when 2 then 'Satıcı' " +
                                    " when 3 then 'Alıcı/Satıcı' " +
                                    " else 'Hatalı' end As CARITIP, " +
                                    " CYPHCODE YETKIKODU, " +
                                    " SPECODE OZELKOD, " +
                                    " SPECODE2 OZELKOD2, " +
                                    " SPECODE3 OZELKOD3, " +
                                    " SPECODE4 OZELKOD4, " +
                                    " SPECODE5 OZELKOD5, " +
                                    " (SELECT TOP 1 SLS.CODE FROM  " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_SLSCLREL SL " +
                                    " JOIN " + AnaForm.db + ".DBO.LG_SLSMAN SLS ON SL.CLIENTREF = CL.LOGICALREF AND SL.SALESMANREF = SLS.LOGICALREF AND SLS.FIRMNR = " + AnaForm.firma + " ORDER BY  SL.LOGICALREF DESC )SATISELEMANI " +
                                    " FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_CLCARD CL where ACTIVE  IN (  " + aktifKayilar + ") ORDER BY DEFINITION_";
            SqlDataAdapter daCariHesap = new SqlDataAdapter(sorguCariHesap, bgl.baglanti());
            daCariHesap.Fill(dtCariHesap);

            cmbCariHesap.Properties.DataSource = dtCariHesap;
            cmbCariHesap.Properties.DisplayMember = "UNVAN";
            cmbCariHesap.Properties.ValueMember = "LOGICALREF";
            cmbCariHesap.EditValue = null;
            grdCariHesap.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < grdCariHesap.Columns.Count; i++) grdCariHesap.Columns[i].BestFit();
        }
        void YetkiKoduListele()
        {
            DataTable dtYetkiKod = new DataTable();
            string sorguYetkiKod = "select DISTINCT(CYPHCODE) YETKIKODU from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN (  " + aktifKayilar + ")" +
                  "ORDER BY CYPHCODE";
            SqlDataAdapter daYetkiKod = new SqlDataAdapter(sorguYetkiKod, bgl.baglanti());
            daYetkiKod.Fill(dtYetkiKod);

            cmbCariYetkiKodu.Properties.DataSource = dtYetkiKod;
            cmbCariYetkiKodu.Properties.DisplayMember = "YETKIKODU";
            cmbCariYetkiKodu.Properties.ValueMember = "YETKIKODU";
            cmbCariYetkiKodu.EditValue = null;
        }
        void OzelKodListele()
        {
            DataTable dtOzelKod = new DataTable();
            string sorguOzelKod = "select DISTINCT(SPECODE) OZELKOD from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN (  " + aktifKayilar + ")" +
                 " ORDER BY SPECODE";
            SqlDataAdapter daOzelKod = new SqlDataAdapter(sorguOzelKod, bgl.baglanti());
            daOzelKod.Fill(dtOzelKod);

            cmbCariOzelKod.Properties.DataSource = dtOzelKod;
            cmbCariOzelKod.Properties.DisplayMember = "OZELKOD";
            cmbCariOzelKod.Properties.ValueMember = "OZELKOD";
            cmbCariOzelKod.EditValue = null;
            cmbCariOzelKod.Properties.NullText = "Özel Kod Seçiniz";
        }
        void OzelKod2Listele()
        {

            DataTable dtOzelKod2 = new DataTable();
            SqlDataAdapter daOzelKod2 = new SqlDataAdapter("select DISTINCT(SPECODE2) OZELKOD2 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN (" + aktifKayilar + ")" +
                 " ORDER BY SPECODE2", bgl.baglanti());
            daOzelKod2.Fill(dtOzelKod2);

            cmbCariOzelKod2.Properties.DataSource = dtOzelKod2;
            cmbCariOzelKod2.Properties.DisplayMember = "OZELKOD2";
            cmbCariOzelKod2.Properties.ValueMember = "OZELKOD2";
            cmbCariOzelKod2.EditValue = null;
        }

        void OzelKod3Listele()
        {
            DataTable dtOzelKod3 = new DataTable();
            SqlDataAdapter daOzelKod3 = new SqlDataAdapter("select DISTINCT(SPECODE3) OZELKOD3 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN ( " + aktifKayilar + ")" +
                 "  ORDER BY SPECODE3", bgl.baglanti());
            daOzelKod3.Fill(dtOzelKod3);

            cmbCariOzelKod3.Properties.DataSource = dtOzelKod3;
            cmbCariOzelKod3.Properties.DisplayMember = "OZELKOD3";
            cmbCariOzelKod3.Properties.ValueMember = "OZELKOD3";
            cmbCariOzelKod3.EditValue = null;
        }
        void OzelKod4Listele()
        {
            DataTable dtOzelKod4 = new DataTable();
            SqlDataAdapter daOzelKod4 = new SqlDataAdapter("select DISTINCT(SPECODE4) OZELKOD4 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN ( " + aktifKayilar + ")" +
                 " ORDER BY SPECODE4", bgl.baglanti());
            daOzelKod4.Fill(dtOzelKod4);

            cmbCariOzelKod4.Properties.DataSource = dtOzelKod4;
            cmbCariOzelKod4.Properties.DisplayMember = "OZELKOD4";
            cmbCariOzelKod4.Properties.ValueMember = "OZELKOD4";
            cmbCariOzelKod4.EditValue = null;
        }
        void OzelKod5Listele()
        {
            DataTable dtOzelKod5 = new DataTable();
            SqlDataAdapter daOzelKod5 = new SqlDataAdapter("select DISTINCT(SPECODE5) OZELKOD5 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD WHERE  ACTIVE IN ( " + aktifKayilar + ")" +
                 " ORDER BY SPECODE5", bgl.baglanti());
            daOzelKod5.Fill(dtOzelKod5);

            cmbCariOzelKod5.Properties.DataSource = dtOzelKod5;
            cmbCariOzelKod5.Properties.DisplayMember = "OZELKOD5";
            cmbCariOzelKod5.Properties.ValueMember = "OZELKOD5";
            cmbCariOzelKod5.EditValue = null;
        }
        void DovizTuruListele()
        {
            cmbDovizTuru.Clear();
            DataTable dtDovizTuru = new DataTable();
            string sorguDovizTuru = " SELECT * FROM( " +
                                   " SELECT DISTINCT(convert(nvarchar, KUR.CURTYPE)) KURNO, KUR.CURNAME   AS DOVIZTURU, " +
                                   " (SELECT COUNT(*) FROM " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_INVOICE WHERE TRCURR = CURTYPE) AS SAYI " +
                                   " FROM " + AnaForm.db + ".dbo.L_CURRENCYLIST KUR " +
                                   " LEFT JOIN " + AnaForm.db + ".DBO.LG_" + AnaForm.firma + "_" + AnaForm.donem + "_STFICHE STF ON STF.TRCURR = KUR.LOGICALREF " +
                                   " WHERE kur.FIRMNR = " + AnaForm.firma + " AND KUR.CURNAME NOT IN('Türk Lirası') " +
                                   " UNION ALL " +
                                   " SELECT '0,160','Türk Lirası',50000 " +
                                   " ) AS AAA " +
                                   " ORDER BY AAA.SAYI DESC, AAA.DOVIZTURU ";
            SqlDataAdapter daDovizTuru = new SqlDataAdapter(sorguDovizTuru, bgl.baglanti());
            daDovizTuru.Fill(dtDovizTuru);

            cmbDovizTuru.Properties.DataSource = dtDovizTuru;
            cmbDovizTuru.Properties.DisplayMember = "DOVIZTURU";
            cmbDovizTuru.Properties.ValueMember = "KURNO";
            cmbDovizTuru.EditValue = null;

        }
        void SatisElemaniListele()
        {
            DataTable dtSatisElemani = new DataTable();
            string sorguSatisElemani = "select DISTINCT(SL.LOGICALREF)LOGICALREF ,SL.CODE KOD, SL.DEFINITION_ AS SATISELEMANI from    " + AnaForm.db + ".dbo.[LG_SLSMAN]  SL " +
                                        " INNER JOIN " + AnaForm.db + ".dbo.[LG_" + AnaForm.firma + "_SLSCLREL] SC ON SC.SALESMANREF=SL.LOGICALREF " +
                                        " LEFT JOIN  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CL ON CL.LOGICALREF=SC.CLIENTREF  AND CL.ACTIVE IN(" + aktifKayilar + ") select DISTINCT(SL.LOGICALREF),SL.CODE Kod, SL.DEFINITION_ AS SATISELEMANI from    " + AnaForm.db + ".dbo.[LG_SLSMAN]  SL " +
                                        " INNER JOIN " + AnaForm.db + ".dbo.[LG_" + AnaForm.firma + "_SLSCLREL] SC ON SC.SALESMANREF=SL.LOGICALREF " +
                                        " LEFT JOIN  " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_CLCARD CL ON CL.LOGICALREF=SC.CLIENTREF  AND CL.ACTIVE IN ( " + aktifKayilar + ") " +
                                        " WHERE sl.FIRMNR=" + AnaForm.firma + " order by SL.DEFINITION_";
            SqlDataAdapter daSatisElemani = new SqlDataAdapter(sorguSatisElemani, bgl.baglanti());
            daSatisElemani.Fill(dtSatisElemani);

            cmbCariSatisElemani.Properties.DataSource = dtSatisElemani;
            cmbCariSatisElemani.Properties.DisplayMember = "SatisElemani";
            cmbCariSatisElemani.Properties.ValueMember = "LOGICALREF";
            cmbCariSatisElemani.EditValue = null;
            cmbCariSatisElemani.Properties.NullText = "Satış Elemanı Seçiniz";
        }

        void AktifKayitlariListeleUrun()
        {
            if (chcStokAktifKayitlar.Checked)
            {
                aktifKayitlarUrun = "0";
            }
            else
            {
                aktifKayitlarUrun = "0,1";
            }
        }
        void UrunListele()
        {
            DataTable dtUrun = new DataTable();
            string sorguUrun = " SELECT LOGICALREF , " +
                                    " CODE KOD, " +
                                    " NAME AS URUNADI, " +
                                    " NAME3 AS URUNADI2, " +
                                    " NAME4 AS URUNADI3, " +
                                    " CASE " +
                                    " WHEN ITS.CARDTYPE = 1 THEN 'Ticari Mal ' " +
                                    " WHEN ITS.CARDTYPE = 2 THEN 'Karma Koli' " +
                                    " WHEN ITS.CARDTYPE = 3 THEN 'Depozitolu Mal' " +
                                    " WHEN ITS.CARDTYPE = 4 THEN 'Sabit Kıymet' " +
                                    " WHEN ITS.CARDTYPE = 10 THEN 'Ham Madde' " +
                                    " WHEN ITS.CARDTYPE = 11 THEN 'Yarı Mamul' " +
                                    " WHEN ITS.CARDTYPE = 12 THEN 'Mamul' " +
                                    " WHEN ITS.CARDTYPE = 13 THEN 'Tüketim Malı' " +
                                    " WHEN ITS.CARDTYPE = 20 THEN 'Genel Malzeme Sınıfı' " +
                                    " ELSE '' END URUNTIP, " +
                                    " STGRPCODE GRUPKODU, " +
                                    " SPECODE OZELKOD, " +
                                    " SPECODE2 OZELKOD2, " +
                                    " SPECODE3 OZELKOD3, " +
                                    " SPECODE4 OZELKOD4, " +
                                    " SPECODE5 OZELKOD5 " +
                                    "  FROM " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS where ITS.ACTIVE IN ( " + aktifKayitlarUrun + ")";
            SqlDataAdapter daUrun = new SqlDataAdapter(sorguUrun, bgl.baglanti());
            daUrun.Fill(dtUrun);

            cmbStokUrun.Properties.DataSource = dtUrun;
            cmbStokUrun.Properties.DisplayMember = "URUNADI";
            cmbStokUrun.Properties.ValueMember = "LOGICALREF";
            cmbStokUrun.EditValue = null;
            grdUrun.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < grdUrun.Columns.Count; i++) grdUrun.Columns[i].BestFit();

        }

        void OzelKodListeleUrun()
        {
            DataTable dtUrunOzelKod = new DataTable();
            string sorguUrunOzelKod = "select DISTINCT(SPECODE) OZELKOD from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY SPECODE";
            SqlDataAdapter daUrunOzelKod = new SqlDataAdapter(sorguUrunOzelKod, bgl.baglanti());
            daUrunOzelKod.Fill(dtUrunOzelKod);

            cmbUrunOzelKod.Properties.DataSource = dtUrunOzelKod;
            cmbUrunOzelKod.Properties.DisplayMember = "OZELKOD";
            cmbUrunOzelKod.Properties.ValueMember = "OZELKOD";
            cmbUrunOzelKod.EditValue = null;
        }

        void OzelKodListeleUrun2()
        {
            DataTable dtAnaForm = new DataTable();
            string sorguAnaForm = "select DISTINCT(SPECODE2) OZELKOD2 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY SPECODE2";
            SqlDataAdapter daAnaForm = new SqlDataAdapter(sorguAnaForm, bgl.baglanti());
            daAnaForm.Fill(dtAnaForm);

            cmbStokAnaForm.Properties.DataSource = dtAnaForm;
            cmbStokAnaForm.Properties.DisplayMember = "OZELKOD2";
            cmbStokAnaForm.Properties.ValueMember = "OZELKOD2";
            cmbStokAnaForm.EditValue = null;
        }

        void OzelKodListeleUrun3()
        {
            DataTable dtUrunOzelKod3 = new DataTable();
            string sorguUrunOzelKod3 = "select DISTINCT(SPECODE3) OZELKOD3 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY SPECODE3";
            SqlDataAdapter daUrunOzelKod3 = new SqlDataAdapter(sorguUrunOzelKod3, bgl.baglanti());
            daUrunOzelKod3.Fill(dtUrunOzelKod3);

            cmbStokUrunOzelKod3.Properties.DataSource = dtUrunOzelKod3;
            cmbStokUrunOzelKod3.Properties.DisplayMember = "OZELKOD3";
            cmbStokUrunOzelKod3.Properties.ValueMember = "OZELKOD3";
            cmbStokUrunOzelKod3.EditValue = null;
        }

        void OzelKodListeleUrun4()
        {
            DataTable dtUrunOzelKod4 = new DataTable();
            string sorguUrunOzelKod4 = "select DISTINCT(SPECODE4) OZELKOD4 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY SPECODE4";
            SqlDataAdapter daUrunOzelKod4 = new SqlDataAdapter(sorguUrunOzelKod4, bgl.baglanti());
            daUrunOzelKod4.Fill(dtUrunOzelKod4);

            cmbStokUrunOzelKod4.Properties.DataSource = dtUrunOzelKod4;
            cmbStokUrunOzelKod4.Properties.DisplayMember = "OZELKOD4";
            cmbStokUrunOzelKod4.Properties.ValueMember = "OZELKOD4";
            cmbStokUrunOzelKod4.EditValue = null;
        }

        void OzelKodListeleUrun5()
        {
            DataTable dtUrunOzelKod5 = new DataTable();
            string sorguUrunOzelKod5 = "select DISTINCT(SPECODE5) OZELKOD5 from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY SPECODE5";
            SqlDataAdapter daUrunOzelKod5 = new SqlDataAdapter(sorguUrunOzelKod5, bgl.baglanti());
            daUrunOzelKod5.Fill(dtUrunOzelKod5);

            cmbStokUrunOzelKod5.Properties.DataSource = dtUrunOzelKod5;
            cmbStokUrunOzelKod5.Properties.DisplayMember = "OZELKOD5";
            cmbStokUrunOzelKod5.Properties.ValueMember = "OZELKOD5";
            cmbStokUrunOzelKod5.EditValue = null;
        }


        void UrunTipListele()
        {
            DataTable dtUrunTip = new DataTable();
            string sorguUrunTip = "select DISTINCT(ITS.CARDTYPE) AS LOGICALREF, " +
                                " CASE " +
                                " WHEN ITS.CARDTYPE = 1 THEN 'Ticari Mal ' " +
                                " WHEN ITS.CARDTYPE = 2 THEN 'Karma Koli' " +
                                " WHEN ITS.CARDTYPE = 3 THEN 'Depozitolu Mal' " +
                                " WHEN ITS.CARDTYPE = 4 THEN 'Sabit Kıymet' " +
                                " WHEN ITS.CARDTYPE = 10 THEN 'Ham Madde' " +
                                " WHEN ITS.CARDTYPE = 11 THEN 'Yarı Mamul' " +
                                " WHEN ITS.CARDTYPE = 12 THEN 'Mamul' " +
                                " WHEN ITS.CARDTYPE = 13 THEN 'Tüketim Malı' " +
                                " WHEN ITS.CARDTYPE = 20 THEN 'Genel Malzeme Sınıfı' " +
                                " ELSE '' END URUNTIP from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY CARDTYPE";
            SqlDataAdapter daUrunTip = new SqlDataAdapter(sorguUrunTip, bgl.baglanti());
            daUrunTip.Fill(dtUrunTip);

            cmbStokUrunTip.Properties.DataSource = dtUrunTip;
            cmbStokUrunTip.Properties.DisplayMember = "URUNTIP";
            cmbStokUrunTip.Properties.ValueMember = "LOGICALREF";
            cmbStokUrunTip.EditValue = null;
        }

        void UrunGrupListele()
        {
            DataTable dtUrunGrup = new DataTable();
            string sorguUrunGrup = "select DISTINCT(ITS.STGRPCODE) AS GRUPKOD " +
                               " from " + AnaForm.db + ".dbo.LG_" + AnaForm.firma + "_ITEMS ITS WHERE  ACTIVE IN (  " + aktifKayitlarUrun + ")" +
                 " ORDER BY ITS.STGRPCODE";
            SqlDataAdapter daUrunGrup = new SqlDataAdapter(sorguUrunGrup, bgl.baglanti());
            daUrunGrup.Fill(dtUrunGrup);

            cmbStokGrupKodu.Properties.DataSource = dtUrunGrup;
            cmbStokGrupKodu.Properties.DisplayMember = "GRUPKOD";
            cmbStokGrupKodu.Properties.ValueMember = "GRUPKOD";
            cmbStokGrupKodu.EditValue = null;

        }

        void IsyeriListele()
        {
            DataTable dtIsyeri = new DataTable();
            string sorguIsyeri = "SELECT NR ISYERINR,NAME ISYERIADI  FROM  " + AnaForm.db + ".dbo.L_CAPIDIV WHERE FIRMNR ='" + AnaForm.firma + "'";

            SqlDataAdapter daIsyeri = new SqlDataAdapter(sorguIsyeri, bgl.baglanti());
            daIsyeri.Fill(dtIsyeri);

            cmbIsyeri.Properties.DataSource = dtIsyeri;
            cmbIsyeri.Properties.DisplayMember = "ISYERIADI";
            cmbIsyeri.Properties.ValueMember = "ISYERINR";
            cmbIsyeri.EditValue = null;

        }


        private void cmbIsyeri_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbIsyeri.Text.Contains("Seçim ") == false || isyeri == "")
            {
                grdIsyeri.ClearSelection();
                cmbIsyeri.Clear();
                cmbIsyeri.Properties.NullText = "Seçim Yapınız";
                cmbIsyeri.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbIsyeri.BackColor = default(Color);
                cmbIsyeri.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbIsyeri.Properties.DataSource = null;
                cmbIsyeri.SelectedText = "";
                cmbIsyeri.Clear();
                IsyeriListele();
                cmbIsyeri.DeselectAll();
            }
        }



        //ozelKod5 += cmbCariOzelKod5.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod5.Properties.ValueMember).ToString() + "','";
        //        cmbCariOzelKod5.Properties.NullText = "Seçim Yapıldı";
        //        cmbCariOzelKod5.Properties.NullValuePrompt = "Seçim Yapıldı";
        //        cmbCariOzelKod5.BackColor = Color.LightGreen;
        //        cmbCariOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        //    }
        //    if (ozelKod5.Length > 1)
        //    {
        //        ozelKod5 = "'" + ozelKod5.Substring(0, ozelKod5.Length - 2);
        private void cmbIsyeri_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            isyeri = "";
            int[] selfacrows = cmbIsyeri.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                isyeri += cmbIsyeri.Properties.View.GetRowCellValue(ndx, cmbIsyeri.Properties.ValueMember).ToString() + ",";
                cmbIsyeri.Properties.NullText = "Seçim Yapıldı";
                cmbIsyeri.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbIsyeri.BackColor = Color.LightGreen;
                cmbIsyeri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            }
            isyeri = isyeri.TrimEnd(',');
            if (cmbIsyeri.Text.Contains("Seçim ") == false || isyeri == "")
            {
                grdIsyeri.ClearSelection();
                cmbIsyeri.Clear();
                cmbIsyeri.Properties.NullText = "Seçim Yapınız";
                cmbIsyeri.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbIsyeri.BackColor = default(Color);
                cmbIsyeri.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbIsyeri.Properties.DataSource = null;
                cmbIsyeri.SelectedText = "";
                cmbIsyeri.Clear();
                IsyeriListele();
                cmbIsyeri.DeselectAll();
            }
            AmbarListele();
        }

        void AmbarListele()
        {
            DataTable dtAmbar = new DataTable();
            string sorguAmbar = "SELECT NR AMBARNR, NAME AMBARADI FROM " + AnaForm.db + ".DBO.L_CAPIWHOUSE WHERE FIRMNR ='" + AnaForm.firma + "'";
            if (isyeri != "")
            {
                sorguAmbar += " AND DIVISNR IN (" + isyeri + ")";
            }
            SqlDataAdapter daAmbar = new SqlDataAdapter(sorguAmbar, bgl.baglanti());
            daAmbar.Fill(dtAmbar);

            cmbAmbar.Properties.DataSource = dtAmbar;
            cmbAmbar.Properties.DisplayMember = "AMBARADI";
            cmbAmbar.Properties.ValueMember = "AMBARNR";
            cmbAmbar.EditValue = null;

        }

        private void cmbAmbar_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbAmbar.Text.Contains("Seçim ") == false || ambar == "")
            {
                grdAmbar.ClearSelection();
                cmbAmbar.Clear();
                cmbAmbar.Properties.NullText = "Seçim Yapınız";
                cmbAmbar.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbAmbar.BackColor = default(Color);
                cmbAmbar.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbAmbar.Properties.DataSource = null;
                cmbAmbar.SelectedText = "";
                cmbAmbar.Clear();
                AmbarListele();
                cmbAmbar.DeselectAll();
            }
        }

        private void cmbAmbar_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ambar = "";
            int[] selfacrows = cmbAmbar.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ambar += cmbAmbar.Properties.View.GetRowCellValue(ndx, cmbAmbar.Properties.ValueMember).ToString() + ",";
                cmbAmbar.Properties.NullText = "Seçim Yapıldı";
                cmbAmbar.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbAmbar.BackColor = Color.LightGreen;
                cmbAmbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            }
            ambar = ambar.TrimEnd(',');
            if (cmbAmbar.Text.Contains("Seçim ") == false || ambar == "")
            {
                grdAmbar.ClearSelection();
                cmbAmbar.Clear();
                cmbAmbar.Properties.NullText = "Seçim Yapınız";
                cmbAmbar.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbAmbar.BackColor = default(Color);
                cmbAmbar.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbAmbar.Properties.DataSource = null;
                cmbAmbar.SelectedText = "";
                cmbAmbar.Clear();
                AmbarListele();
                cmbAmbar.DeselectAll();
            }
        }



        private void Buttonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnOkulKartlari)
            {
                ShowListForms<OkulListForm>.ShowListForm(KartTuru.Okul);
            }
            else if (e.Item == btnIlKartlari)
            {
                ShowListForms<IlListForm>.ShowListForm(KartTuru.Il);
            }
            else if (e.Item == btnTipKartlari)
            {
                ShowListForms<TipListForm>.ShowListForm(KartTuru.Tip);
            }
            else if (e.Item == btnAileBilgiKartlari)
            {
                ShowListForms<AileBilgiListForm>.ShowListForm(KartTuru.AileBilgi);
            }
            else if (e.Item == Rapor1)
            {
                ShowReportListForms<Rapor1>.ShowReportListForm(KartTuru.Rapor1);
            }
            else if (e.Item == btnCariBakiyeler)
            {
                ShowReportListForms<CariBakiyeler>.ShowReportListForm(KartTuru.CariBakiyeler);
            }
            else if (e.Item == btnMuhasebeHesapKoduFarkliOlanlar)
            {
                ShowReportListForms<MuhasebeHesapKoduFarkliOlanlar>.ShowReportListForm(KartTuru.MuhasebeHesapKoduFarkliOlanlar);
            }

            else if (e.Item == btnAtlayanNumaralar)
            {
                ShowReportListForms<NumaralamaKontrolu>.ShowReportListForm(KartTuru.NumaralamaKontrol);
            }


            else if (e.Item == btnKurFarki)
            {
                ShowReportListForms<KurFarkiHesaplama>.ShowReportListForm(KartTuru.KurFarki);
            }
            else if (e.Item == btnUrunHareketleri)
            {
                ShowReportListForms<UrunHareketleri>.ShowReportListForm(KartTuru.UrunHareketleri);
            }
            else if (e.Item == btnStokSonHareketleri)
            {
                ShowReportListForms<StokSonHareketTarihleri>.ShowReportListForm(KartTuru.StokSonHareketTarihleri);
            }
            else if (e.Item == btnAmbarToplamlari)
            {
                ShowReportListForms<AmbarToplamlari>.ShowReportListForm(KartTuru.AmbarToplamlari);
            }
            else if (e.Item == btnVadeFarkiHesaplama)
            {
                ShowReportListForms<BorcAlacakFaturalar>.ShowReportListForm(KartTuru.BorcAlacakFaturaListesi);
            }
            else if (e.Item == btnCariHareketler)
            {
                ShowReportListForms<CariHareketler>.ShowReportListForm(KartTuru.CariHareketler);
            }
            else if (e.Item == btnAcikSatinalmaSiparisleri)
            {
                ShowReportListForms<AcikSatinalmaSiparisleri>.ShowReportListForm(KartTuru.AcikSatinalmaSiparisleri);
            }
            else if (e.Item == btnAcikSatisSiparisleri)
            {
                ShowReportListForms<AcikSatisSiparisleri>.ShowReportListForm(KartTuru.AcikSatisSiparisleri);
            }
            else if (e.Item == btnTanimlar)
            {

                ShowListForms<HesaplamaParametleriListForm>.ShowListForm(KartTuru.HesaplamaParametreleri);
            }
            else if (e.Item == btnFirmaBilgileri)
            {

                ShowListForms<FirmaListForm>.ShowListForm(KartTuru.Firma);
            }
            else if (e.Item == btnSatisFiyatListesi)
            {
                ShowReportListForms<SatisFiyatListesi>.ShowReportListForm(KartTuru.SatisFiyatListesi);
            }
            else if (e.Item == btnStokIhtiyacListesi)
            {
                ShowReportListForms<StokIhtiyacListesi>.ShowReportListForm(KartTuru.StokIhtiyacListesi);
            }
            else if (e.Item == btnAnaMuhasebeOnMuhasebeCariBakiyeKontrolu)
            {
                ShowReportListForms<AnaMuhasebeOnMuhasebeCariBakiyeKontrolu>.ShowReportListForm(KartTuru.AnaMuhasebeOnMuhasebeCariBakiyeKontrolu);
            }
            else if (e.Item == btnAnaMuhasebeOnMuhasebeBankaiBakiyeKontrolu)
            {
                ShowReportListForms<AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu>.ShowReportListForm(KartTuru.AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu);
            }
            else if (e.Item == btnGdoluHammadde)
            {
                // ShowReportListForms<GdoLuHammadde>.ShowReportListForm(KartTuru.GdoLuHammadde);
            }
            else if (e.Item == btnMutabakat)
            {
                ShowReportListForms<MutabakatRaporu>.ShowReportListForm(KartTuru.MutabakatRaporu);
            }
        }

        private void btnOkulKartlari_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTest_ItemClick(object sender, ItemClickEventArgs e)
        {


            string sorgu3 = " select * from godb.dbo.lg_224_clcard";

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgu3, bgl.baglanti());

            myGridControl1.DataSource = null;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt1);
            myGridControl1.DataSource = dt1;





            string sorgu31 = " select * from godb.dbo.lg_224_clcard";

            DataTable dt11 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(sorgu31, bgl.baglanti());

            myGridControl1.DataSource = null;
            da1.SelectCommand.CommandTimeout = 0;
            da1.Fill(dt11);
            myGridControl2.DataSource = dt11;
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

        private void cmbFirmaSecimi_EditValueChanged(object sender, EventArgs e)
        {
            firma = (cmbFirmaSecimi.EditValue.ToString().Substring(0, 3));
            Listele();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtBitisTarihi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {



            string secilenler = "";
            //MessageBox.Show(cmbOzelKod.Properties.View.GetSelectedRows().ToList());


            int[] selfacrows = cmbCariOzelKod.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                secilenler += cmbCariOzelKod.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod.Properties.ValueMember).ToString() + ",";
            }
            secilenler = secilenler.TrimEnd(',');

            //MessageBox.Show(secilenler);
        }

        private void dtBitisTarihi_ValueChanged(object sender, EventArgs e)
        {
            bitisTarihi = dtBitisTarihi.Value.ToString("yyyy-MM-dd");
        }





        private void cmbDovizTuru_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            dovizTuru = "";
            int[] selfacrows = cmbDovizTuru.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {

                dovizTuru += cmbDovizTuru.Properties.View.GetRowCellValue(ndx, cmbDovizTuru.Properties.ValueMember).ToString() + ",";
                cmbDovizTuru.Properties.NullText = "Seçim Yapıldı";
                cmbDovizTuru.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbDovizTuru.BackColor = Color.LightGreen;
                cmbDovizTuru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);


                //cmbDovizTuru.MaskBox.SetEditValue(null, "test", true);
            }
            dovizTuru = dovizTuru.TrimEnd(',');

            if (cmbDovizTuru.Text.Contains("Seçim ") == false || dovizTuru == "")
            {
                grdDovizTuru.ClearSelection();
                cmbDovizTuru.Clear();
                // cmbDovizTuru.Text = null;

                cmbDovizTuru.Properties.NullText = "Seçim Yapınız";
                cmbDovizTuru.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbDovizTuru.BackColor = default(Color);
                cmbDovizTuru.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbDovizTuru.Properties.DataSource = null;
                cmbDovizTuru.SelectedText = "";
                cmbDovizTuru.Clear();
                DovizTuruListele();
                cmbDovizTuru.DeselectAll();
            }


        }


        private void cmbDovizTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbDovizTuru.Text.Contains("Seçim ") == false || dovizTuru == "")
            {
                grdDovizTuru.ClearSelection();
                cmbDovizTuru.Clear();
                cmbDovizTuru.Properties.NullText = "Seçim Yapınız";
                cmbDovizTuru.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbDovizTuru.BackColor = default(Color);
                cmbDovizTuru.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbDovizTuru.Properties.DataSource = null;
                cmbDovizTuru.SelectedText = "";
                cmbDovizTuru.Clear();
                DovizTuruListele();
                cmbDovizTuru.DeselectAll();
            }
        }

        private void cmbSatisElemani_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariSatisElemani.Text.Contains("Seçim ") == false || satisElemani == "")
            {
                grdSatisElemani.ClearSelection();
                cmbCariSatisElemani.Clear();
                cmbCariSatisElemani.Properties.NullText = "Seçim Yapınız";
                cmbCariSatisElemani.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariSatisElemani.BackColor = default(Color);
                cmbCariSatisElemani.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbCariSatisElemani.Properties.DataSource = null;
                cmbCariSatisElemani.SelectedText = "";
                cmbCariSatisElemani.Clear();
                SatisElemaniListele();
                cmbCariSatisElemani.DeselectAll();
            }

        }

        private void cmbSatisElemani_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            satisElemani = "";
            int[] selfacrows = cmbCariSatisElemani.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                satisElemani += cmbCariSatisElemani.Properties.View.GetRowCellValue(ndx, cmbCariSatisElemani.Properties.ValueMember).ToString() + ",";
                cmbCariSatisElemani.Properties.NullText = "Seçim Yapıldı";
                cmbCariSatisElemani.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariSatisElemani.BackColor = Color.LightGreen;
                cmbCariSatisElemani.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            }
            satisElemani = satisElemani.TrimEnd(',');
            if (cmbCariSatisElemani.Text.Contains("Seçim ") == false || satisElemani == "")
            {
                grdSatisElemani.ClearSelection();
                cmbCariSatisElemani.Clear();
                cmbCariSatisElemani.Properties.NullText = "Seçim Yapınız";
                cmbCariSatisElemani.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariSatisElemani.BackColor = default(Color);
                cmbCariSatisElemani.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbCariSatisElemani.Properties.DataSource = null;
                cmbCariSatisElemani.SelectedText = "";
                cmbCariSatisElemani.Clear();
                SatisElemaniListele();
                cmbCariSatisElemani.DeselectAll();
            }
        }

        private void cmbOzelKod5_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariOzelKod5.Text.Contains("Seçim ") == false || ozelKod5 == "")
            {
                grdOzelKod5.ClearSelection();
                cmbCariOzelKod5.Clear();
                cmbCariOzelKod5.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod5.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod5.BackColor = default(Color);
                cmbCariOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbCariOzelKod5.Properties.DataSource = null;
                cmbCariOzelKod5.SelectedText = "";
                cmbCariOzelKod5.Clear();
                OzelKod5Listele();
                cmbCariOzelKod5.DeselectAll();
            }
        }

        private void cmbOzelKod5_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ozelKod5 = "";
            int[] selfacrows = cmbCariOzelKod5.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ozelKod5 += cmbCariOzelKod5.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod5.Properties.ValueMember).ToString() + "','";
                cmbCariOzelKod5.Properties.NullText = "Seçim Yapıldı";
                cmbCariOzelKod5.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariOzelKod5.BackColor = Color.LightGreen;
                cmbCariOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            }
            if (ozelKod5.Length > 1)
            {
                ozelKod5 = "'" + ozelKod5.Substring(0, ozelKod5.Length - 2);
            }
            if (cmbCariOzelKod5.Text.Contains("Seçim ") == false || ozelKod5 == "")
            {
                grdOzelKod5.ClearSelection();
                cmbCariOzelKod5.Clear();
                cmbCariOzelKod5.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod5.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod5.BackColor = default(Color);
                cmbCariOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.25F);
                cmbCariOzelKod5.Properties.DataSource = null;
                cmbCariOzelKod5.SelectedText = "";
                cmbCariOzelKod5.Clear();
                OzelKod5Listele();
                cmbCariOzelKod5.DeselectAll();
            }
        }

        private void cmbOzelKod4_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariOzelKod4.Text.Contains("Seçim ") == false || ozelKod4 == "")
            {
                grdOzelKod4.ClearSelection();
                cmbCariOzelKod4.Clear();
                cmbCariOzelKod4.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod4.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod4.BackColor = default(Color);
                cmbCariOzelKod4.Font = new System.Drawing.Font("Tahoma", 8.24F);
                cmbCariOzelKod4.Properties.DataSource = null;
                cmbCariOzelKod4.SelectedText = "";
                cmbCariOzelKod4.Clear();
                OzelKod4Listele();
                cmbCariOzelKod4.DeselectAll();
            }
        }

        private void cmbOzelKod4_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ozelKod4 = "";
            int[] selfacrows = cmbCariOzelKod4.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ozelKod4 += cmbCariOzelKod4.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod4.Properties.ValueMember).ToString() + "','";
                cmbCariOzelKod4.Properties.NullText = "Seçim Yapıldı";
                cmbCariOzelKod4.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariOzelKod4.BackColor = Color.LightGreen;
                cmbCariOzelKod4.Font = new System.Drawing.Font("Tahoma", 8.24F, System.Drawing.FontStyle.Bold);
            }
            if (ozelKod4.Length > 1)
            {
                ozelKod4 = "'" + ozelKod4.Substring(0, ozelKod4.Length - 2);
            }
            if (cmbCariOzelKod4.Text.Contains("Seçim ") == false || ozelKod4 == "")
            {
                grdOzelKod4.ClearSelection();
                cmbCariOzelKod4.Clear();
                cmbCariOzelKod4.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod4.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod4.BackColor = default(Color);
                cmbCariOzelKod4.Font = new System.Drawing.Font("Tahoma", 8.24F);
                cmbCariOzelKod4.Properties.DataSource = null;
                cmbCariOzelKod4.SelectedText = "";
                cmbCariOzelKod4.Clear();
                OzelKod4Listele();
                cmbCariOzelKod4.DeselectAll();
            }
        }

        private void cmbOzelKod3_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariOzelKod3.Text.Contains("Seçim ") == false || ozelKod3 == "")
            {
                grdOzelKod3.ClearSelection();
                cmbCariOzelKod3.Clear();
                cmbCariOzelKod3.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod3.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod3.BackColor = default(Color);
                cmbCariOzelKod3.Font = new System.Drawing.Font("Tahoma", 8.23F);
                cmbCariOzelKod3.Properties.DataSource = null;
                cmbCariOzelKod3.SelectedText = "";
                cmbCariOzelKod3.Clear();
                OzelKod3Listele();
                cmbCariOzelKod3.DeselectAll();
            }
        }

        private void cmbOzelKod3_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ozelKod3 = "";
            int[] selfacrows = cmbCariOzelKod3.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ozelKod3 += cmbCariOzelKod3.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod3.Properties.ValueMember).ToString() + "','";
                cmbCariOzelKod3.Properties.NullText = "Seçim Yapıldı";
                cmbCariOzelKod3.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariOzelKod3.BackColor = Color.LightGreen;
                cmbCariOzelKod3.Font = new System.Drawing.Font("Tahoma", 8.23F, System.Drawing.FontStyle.Bold);
            }
            if (ozelKod3.Length > 1)
            {
                ozelKod3 = "'" + ozelKod3.Substring(0, ozelKod3.Length - 2);
            }
            if (cmbCariOzelKod3.Text.Contains("Seçim ") == false || ozelKod3 == "")
            {
                grdOzelKod3.ClearSelection();
                cmbCariOzelKod3.Clear();
                cmbCariOzelKod3.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod3.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod3.BackColor = default(Color);
                cmbCariOzelKod3.Font = new System.Drawing.Font("Tahoma", 8.23F);
                cmbCariOzelKod3.Properties.DataSource = null;
                cmbCariOzelKod3.SelectedText = "";
                cmbCariOzelKod3.Clear();
                OzelKod3Listele();
                cmbCariOzelKod3.DeselectAll();
            }
        }

        private void cmbOzelKod2_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariOzelKod2.Text.Contains("Seçim ") == false || ozelKod2 == "")
            {
                grdOzelKod2.ClearSelection();
                cmbCariOzelKod2.Clear();
                cmbCariOzelKod2.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod2.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod2.BackColor = default(Color);
                cmbCariOzelKod2.Font = new System.Drawing.Font("Tahoma", 8.22F);
                cmbCariOzelKod2.Properties.DataSource = null;
                cmbCariOzelKod2.SelectedText = "";
                cmbCariOzelKod2.Clear();
                OzelKod2Listele();
                cmbCariOzelKod2.DeselectAll();
            }
        }

        private void cmbOzelKod2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ozelKod2 = "";
            int[] selfacrows = cmbCariOzelKod2.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ozelKod2 += cmbCariOzelKod2.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod2.Properties.ValueMember).ToString() + "','";
                cmbCariOzelKod2.Properties.NullText = "Seçim Yapıldı";
                cmbCariOzelKod2.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariOzelKod2.BackColor = Color.LightGreen;
                cmbCariOzelKod2.Font = new System.Drawing.Font("Tahoma", 8.22F, System.Drawing.FontStyle.Bold);
            }
            if (ozelKod2.Length > 1)
            {
                ozelKod2 = "'" + ozelKod2.Substring(0, ozelKod2.Length - 2);
            }
            if (cmbCariOzelKod2.Text.Contains("Seçim ") == false || ozelKod2 == "")
            {
                grdOzelKod2.ClearSelection();
                cmbCariOzelKod2.Clear();
                cmbCariOzelKod2.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod2.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod2.BackColor = default(Color);
                cmbCariOzelKod2.Font = new System.Drawing.Font("Tahoma", 8.22F);
                cmbCariOzelKod2.Properties.DataSource = null;
                cmbCariOzelKod2.SelectedText = "";
                cmbCariOzelKod2.Clear();
                OzelKod2Listele();
                cmbCariOzelKod2.DeselectAll();
            }
        }

        private void cmbOzelKod_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariOzelKod.Text.Contains("Seçim ") == false || ozelKod == "")
            {
                grdOzelKod.ClearSelection();
                cmbCariOzelKod.Clear();
                cmbCariOzelKod.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod.BackColor = default(Color);
                cmbCariOzelKod.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariOzelKod.Properties.DataSource = null;
                cmbCariOzelKod.SelectedText = "";
                cmbCariOzelKod.Clear();
                OzelKodListele();
                cmbCariOzelKod.DeselectAll();
            }
        }

        private void cmbOzelKod_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            ozelKod = "";
            int[] selfacrows = cmbCariOzelKod.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                ozelKod += cmbCariOzelKod.Properties.View.GetRowCellValue(ndx, cmbCariOzelKod.Properties.ValueMember).ToString() + "','";
                cmbCariOzelKod.Properties.NullText = "Seçim Yapıldı";
                cmbCariOzelKod.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariOzelKod.BackColor = Color.LightGreen;
                cmbCariOzelKod.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (ozelKod.Length > 1)
            {
                ozelKod = "'" + ozelKod.Substring(0, ozelKod.Length - 2);
            }
            if (cmbCariOzelKod.Text.Contains("Seçim ") == false || ozelKod == "")
            {
                grdOzelKod.ClearSelection();
                cmbCariOzelKod.Clear();
                cmbCariOzelKod.Properties.NullText = "Seçim Yapınız";
                cmbCariOzelKod.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariOzelKod.BackColor = default(Color);
                cmbCariOzelKod.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariOzelKod.Properties.DataSource = null;
                cmbCariOzelKod.SelectedText = "";
                cmbCariOzelKod.Clear();
                OzelKodListele();
                cmbCariOzelKod.DeselectAll();
            }

        }

        private void cmbUrun_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbStokUrun.Text.Contains("Seçim ") == false || urunLogicalref == "")
            {
                grdUrun.ClearSelection();
                cmbStokUrun.Clear();
                cmbStokUrun.Properties.NullText = "Seçim Yapınız";
                cmbStokUrun.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrun.BackColor = default(Color);
                cmbStokUrun.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrun.Properties.DataSource = null;
                cmbStokUrun.SelectedText = "";
                cmbStokUrun.Clear();
                UrunListele();
                cmbStokUrun.DeselectAll();
            }
        }

        private void cmbUrun_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunLogicalref = "";
            int[] selfacrows = cmbStokUrun.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunLogicalref += cmbStokUrun.Properties.View.GetRowCellValue(ndx, cmbStokUrun.Properties.ValueMember).ToString() + ",";
                cmbStokUrun.Properties.NullText = "Seçim Yapıldı";
                cmbStokUrun.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokUrun.BackColor = Color.LightGreen;
                cmbStokUrun.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunLogicalref.Length > 1)
            {
                urunLogicalref = urunLogicalref.Substring(0, urunLogicalref.Length - 1);
            }
            if (cmbStokUrun.Text.Contains("Seçim ") == false || urunLogicalref == "")
            {
                grdUrun.ClearSelection();
                cmbStokUrun.Clear();
                cmbStokUrun.Properties.NullText = "Seçim Yapınız";
                cmbStokUrun.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrun.BackColor = default(Color);
                cmbStokUrun.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrun.Properties.DataSource = null;
                cmbStokUrun.SelectedText = "";
                cmbStokUrun.Clear();
                UrunListele();
                cmbStokUrun.DeselectAll();
            }
        }

        private void cmbUrunTip_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbStokUrunTip.Text.Contains("Seçim ") == false || urunTip == "")
            {
                grdUrunTip.ClearSelection();
                cmbStokUrunTip.Clear();
                cmbStokUrunTip.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunTip.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunTip.BackColor = default(Color);
                cmbStokUrunTip.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunTip.Properties.DataSource = null;
                cmbStokUrunTip.SelectedText = "";
                cmbStokUrunTip.Clear();
                UrunTipListele();
                cmbStokUrunTip.DeselectAll();
            }
        }

        private void cmbGrupKodu_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbStokGrupKodu.Text.Contains("Seçim ") == false || urunGrup == "")
            {
                grdGrupKodu.ClearSelection();
                cmbStokGrupKodu.Clear();
                cmbStokGrupKodu.Properties.NullText = "Seçim Yapınız";
                cmbStokGrupKodu.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokGrupKodu.BackColor = default(Color);
                cmbStokGrupKodu.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokGrupKodu.Properties.DataSource = null;
                cmbStokGrupKodu.SelectedText = "";
                cmbStokGrupKodu.Clear();
                UrunGrupListele();
                cmbStokGrupKodu.DeselectAll();
            }
        }

        private void cmbGrupKodu_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunGrup = "";
            int[] selfacrows = cmbStokGrupKodu.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunGrup += cmbStokGrupKodu.Properties.View.GetRowCellValue(ndx, cmbStokGrupKodu.Properties.ValueMember).ToString() + "','";
                cmbStokGrupKodu.Properties.NullText = "Seçim Yapıldı";
                cmbStokGrupKodu.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokGrupKodu.BackColor = Color.LightGreen;
                cmbStokGrupKodu.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunGrup.Length > 1)
            {
                urunGrup = "'" + urunGrup.Substring(0, urunGrup.Length - 2);
            }
            if (cmbStokGrupKodu.Text.Contains("Seçim ") == false || urunGrup == "")
            {
                grdGrupKodu.ClearSelection();
                cmbStokGrupKodu.Clear();
                cmbStokGrupKodu.Properties.NullText = "Seçim Yapınız";
                cmbStokGrupKodu.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokGrupKodu.BackColor = default(Color);
                cmbStokGrupKodu.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokGrupKodu.Properties.DataSource = null;
                cmbStokGrupKodu.SelectedText = "";
                cmbStokGrupKodu.Clear();
                UrunGrupListele();
                cmbStokGrupKodu.DeselectAll();
            }
        }

        private void cmbUrunOzelKod_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunOzelKod = "";
            int[] selfacrows = cmbUrunOzelKod.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunOzelKod += cmbUrunOzelKod.Properties.View.GetRowCellValue(ndx, cmbUrunOzelKod.Properties.ValueMember).ToString() + "','";
                cmbUrunOzelKod.Properties.NullText = "Seçim Yapıldı";
                cmbUrunOzelKod.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbUrunOzelKod.BackColor = Color.LightGreen;
                cmbUrunOzelKod.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunOzelKod.Length > 1)
            {
                urunOzelKod = "'" + urunOzelKod.Substring(0, urunOzelKod.Length - 2);
            }
            if (cmbUrunOzelKod.Text.Contains("Seçim ") == false || urunOzelKod == "")
            {
                grdUrunOzelKod.ClearSelection();
                cmbUrunOzelKod.Clear();
                cmbUrunOzelKod.Properties.NullText = "Seçim Yapınız";
                cmbUrunOzelKod.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbUrunOzelKod.BackColor = default(Color);
                cmbUrunOzelKod.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbUrunOzelKod.Properties.DataSource = null;
                cmbUrunOzelKod.SelectedText = "";
                cmbUrunOzelKod.Clear();
                OzelKodListeleUrun();
                cmbUrunOzelKod.DeselectAll();
            }
        }

        private void cmbUrunOzelKod_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbCariOzelKod.Text.Contains("Seçim ") == false || urunOzelKod == "")
            {
                grdUrunOzelKod.ClearSelection();
                cmbUrunOzelKod.Clear();
                cmbUrunOzelKod.Properties.NullText = "Seçim Yapınız";
                cmbUrunOzelKod.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbUrunOzelKod.BackColor = default(Color);
                cmbUrunOzelKod.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbUrunOzelKod.Properties.DataSource = null;
                cmbUrunOzelKod.SelectedText = "";
                cmbUrunOzelKod.Clear();
                OzelKodListeleUrun();
                cmbUrunOzelKod.DeselectAll();
            }
        }


        private void cmbAnaForm_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            AnaForm = "";
            int[] selfacrows = cmbStokAnaForm.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                AnaForm += cmbStokAnaForm.Properties.View.GetRowCellValue(ndx, cmbStokAnaForm.Properties.ValueMember).ToString() + "','";
                cmbStokAnaForm.Properties.NullText = "Seçim Yapıldı";
                cmbStokAnaForm.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokAnaForm.BackColor = Color.LightGreen;
                cmbStokAnaForm.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (AnaForm.Length > 1)
            {
                AnaForm = "'" + AnaForm.Substring(0, AnaForm.Length - 2);
            }
            if (cmbStokAnaForm.Text.Contains("Seçim ") == false || AnaForm == "")
            {
                grdAnaForm.ClearSelection();
                cmbStokAnaForm.Clear();
                cmbStokAnaForm.Properties.NullText = "Seçim Yapınız";
                cmbStokAnaForm.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokAnaForm.BackColor = default(Color);
                cmbStokAnaForm.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokAnaForm.Properties.DataSource = null;
                cmbStokAnaForm.SelectedText = "";
                cmbStokAnaForm.Clear();
                OzelKodListeleUrun2();
                cmbStokAnaForm.DeselectAll();
            }
        }

        private void cmbAnaForm_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbStokAnaForm.Text.Contains("Seçim ") == false || AnaForm == "")
            {
                grdAnaForm.ClearSelection();
                cmbStokAnaForm.Clear();
                cmbStokAnaForm.Properties.NullText = "Seçim Yapınız";
                cmbStokAnaForm.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokAnaForm.BackColor = default(Color);
                cmbStokAnaForm.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokAnaForm.Properties.DataSource = null;
                cmbStokAnaForm.SelectedText = "";
                cmbStokAnaForm.Clear();
                OzelKodListeleUrun2();
                cmbStokAnaForm.DeselectAll();
            }
        }

        private void cmbUrunOzelKod3_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunOzelKod3 = "";
            int[] selfacrows = cmbStokUrunOzelKod3.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunOzelKod3 += cmbStokUrunOzelKod3.Properties.View.GetRowCellValue(ndx, cmbStokUrunOzelKod3.Properties.ValueMember).ToString() + "','";
                cmbStokUrunOzelKod3.Properties.NullText = "Seçim Yapıldı";
                cmbStokUrunOzelKod3.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokUrunOzelKod3.BackColor = Color.LightGreen;
                cmbStokUrunOzelKod3.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunOzelKod3.Length > 1)
            {
                urunOzelKod3 = "'" + urunOzelKod3.Substring(0, urunOzelKod3.Length - 2);
            }
            if (cmbStokUrunOzelKod3.Text.Contains("Seçim ") == false || urunOzelKod3 == "")
            {
                grdUrunOzelKod3.ClearSelection();
                cmbStokUrunOzelKod3.Clear();
                cmbStokUrunOzelKod3.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod3.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod3.BackColor = default(Color);
                cmbStokUrunOzelKod3.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod3.Properties.DataSource = null;
                cmbStokUrunOzelKod3.SelectedText = "";
                cmbStokUrunOzelKod3.Clear();
                OzelKodListeleUrun3();
                cmbStokUrunOzelKod3.DeselectAll();
            }
        }

        private void cmbUrunOzelKod3_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbStokUrunOzelKod3.Text.Contains("Seçim ") == false || urunOzelKod3 == "")
            {
                grdUrunOzelKod3.ClearSelection();
                cmbStokUrunOzelKod3.Clear();
                cmbStokUrunOzelKod3.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod3.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod3.BackColor = default(Color);
                cmbStokUrunOzelKod3.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod3.Properties.DataSource = null;
                cmbStokUrunOzelKod3.SelectedText = "";
                cmbStokUrunOzelKod3.Clear();
                OzelKodListeleUrun3();
                cmbStokUrunOzelKod3.DeselectAll();
            }
        }

        private void cmbUrunOzelKod4_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunOzelKod4 = "";
            int[] selfacrows = cmbStokUrunOzelKod4.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunOzelKod4 += cmbStokUrunOzelKod4.Properties.View.GetRowCellValue(ndx, cmbStokUrunOzelKod4.Properties.ValueMember).ToString() + "','";
                cmbStokUrunOzelKod4.Properties.NullText = "Seçim Yapıldı";
                cmbStokUrunOzelKod4.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokUrunOzelKod4.BackColor = Color.LightGreen;
                cmbStokUrunOzelKod4.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunOzelKod4.Length > 1)
            {
                urunOzelKod4 = "'" + urunOzelKod4.Substring(0, urunOzelKod4.Length - 2);
            }
            if (cmbStokUrunOzelKod4.Text.Contains("Seçim ") == false || urunOzelKod4 == "")
            {
                grdUrunOzelKod4.ClearSelection();
                cmbStokUrunOzelKod4.Clear();
                cmbStokUrunOzelKod4.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod4.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod4.BackColor = default(Color);
                cmbStokUrunOzelKod4.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod4.Properties.DataSource = null;
                cmbStokUrunOzelKod4.SelectedText = "";
                cmbStokUrunOzelKod4.Clear();
                OzelKodListeleUrun4();
                cmbStokUrunOzelKod4.DeselectAll();
            }
        }

        private void cmbUrunOzelKod4_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbStokUrunOzelKod5.Text.Contains("Seçim ") == false || urunOzelKod5 == "")
            {
                grdUrunOzelKod4.ClearSelection();
                cmbStokUrunOzelKod4.Clear();
                cmbStokUrunOzelKod4.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod4.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod4.BackColor = default(Color);
                cmbStokUrunOzelKod4.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod4.Properties.DataSource = null;
                cmbStokUrunOzelKod4.SelectedText = "";
                cmbStokUrunOzelKod4.Clear();
                OzelKodListeleUrun4();
                cmbStokUrunOzelKod4.DeselectAll();
            }
        }
        private void cmbUrunOzelKod5_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunOzelKod5 = "";
            int[] selfacrows = cmbStokUrunOzelKod5.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunOzelKod5 += cmbStokUrunOzelKod5.Properties.View.GetRowCellValue(ndx, cmbStokUrunOzelKod5.Properties.ValueMember).ToString() + "','";
                cmbStokUrunOzelKod5.Properties.NullText = "Seçim Yapıldı";
                cmbStokUrunOzelKod5.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokUrunOzelKod5.BackColor = Color.LightGreen;
                cmbStokUrunOzelKod5.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (urunOzelKod5.Length > 1)
            {
                urunOzelKod5 = "'" + urunOzelKod5.Substring(0, urunOzelKod5.Length - 2);
            }
            if (cmbStokUrunOzelKod5.Text.Contains("Seçim ") == false || urunOzelKod5 == "")
            {
                grdUrunOzelKod5.ClearSelection();
                cmbStokUrunOzelKod5.Clear();
                cmbStokUrunOzelKod5.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod5.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod5.BackColor = default(Color);
                cmbStokUrunOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod5.Properties.DataSource = null;
                cmbStokUrunOzelKod5.SelectedText = "";
                cmbStokUrunOzelKod5.Clear();
                OzelKodListeleUrun5();
                cmbStokUrunOzelKod5.DeselectAll();
            }
        }

        private void cmbUrunOzelKod5_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbStokUrunOzelKod5.Text.Contains("Seçim ") == false || urunOzelKod5 == "")
            {
                grdUrunOzelKod5.ClearSelection();
                cmbStokUrunOzelKod5.Clear();
                cmbStokUrunOzelKod5.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunOzelKod5.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunOzelKod5.BackColor = default(Color);
                cmbStokUrunOzelKod5.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunOzelKod5.Properties.DataSource = null;
                cmbStokUrunOzelKod5.SelectedText = "";
                cmbStokUrunOzelKod5.Clear();
                OzelKodListeleUrun5();
                cmbStokUrunOzelKod5.DeselectAll();
            }
        }

        private void dtBaslangicTarihi_ValueChanged(object sender, EventArgs e)
        {
            baslangicTarihi = dtBaslangicTarihi.Value.ToString("yyyy-MM-dd");
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }
        enum ButtonTag { Cari, Tarih, Stok, Ambar, Doviz };
        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {


            Form activeChildForm = ActiveMdiChild;


            int k = 0;

            myDataLayoutControl1.SuspendLayout();
            int i = 1;
            string siralama = "";

            //foreach (BaseLayoutItem item in Root.Items)
            //{
            //    if (item is LayoutControlItem)
            //    {
            //        if (item.Tag == null || activeChildForm.Tag.ToString().Contains(item.Tag.ToString()))
            //        {
            //            i++;
            //            //item.Visibility = LayoutVisibility.Always;
            //            //item.Parent.Enabled = true;

            //            // item.OptionsTableLayoutItem.RowIndex = i++;
            //        }
            //        else
            //        {
            //            //item.Visibility = LayoutVisibility.Never;
            //           // item.Parent.Enabled = false;

            //         }
            //    }

            //}
            if (activeChildForm == null)
            {
                foreach (LayoutControlItem item in Root.Items)
                {
                    item.Enabled = true;
                    if (item.Control is GridLookUpEdit grd)
                    {
                        grd.BackColor = Color.White;
                    }
                }
                return;
            }
            if (activeChildForm.Tag != null)
            {


                foreach (LayoutControlItem item in Root.Items)
                {
                    if (item.Tag == null || activeChildForm.Tag.ToString().Contains(item.Tag.ToString()))
                    {
                        item.Enabled = true;
                        if (item.Control is GridLookUpEdit grd)
                        {
                            grd.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        item.Enabled = false;
                        if (item.Control is GridLookUpEdit grd)
                        {
                            grd.BackColor = Color.LightGray;
                        }
                    }
                }
            }


            //for (int j = 0; j < Root.Items.Count; j++)
            //{
            //    var item = Root.Items[j];
            //    if (item.Visibility == LayoutVisibility.Always)
            //    {
            //        item.OptionsTableLayoutItem.RowIndex = k++;
            //        siralama += "Eski Sıra: " + item.OptionsTableLayoutItem.RowIndex.ToString() + "-Adi: " + item.Name + " -Text: " + item.Text + " -YeniSira :" + k.ToString() + Environment.NewLine;

            //    }
            //}
            //MessageBox.Show(siralama);



        }


        private void HideAndShiftLayoutControlItem(LayoutControlItem itemToHide)
        {

        }

        private void cmbUrunTip_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            urunTip = "";
            int[] selfacrows = cmbStokUrunTip.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                urunTip += cmbStokUrunTip.Properties.View.GetRowCellValue(ndx, cmbStokUrunTip.Properties.ValueMember).ToString() + ",";
                cmbStokUrunTip.Properties.NullText = "Seçim Yapıldı";
                cmbStokUrunTip.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbStokUrunTip.BackColor = Color.LightGreen;
                cmbStokUrunTip.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            urunTip = urunTip.TrimEnd(',');
            if (cmbStokUrunTip.Text.Contains("Seçim ") == false || urunTip == "")
            {
                grdUrunTip.ClearSelection();
                cmbStokUrunTip.Clear();
                cmbStokUrunTip.Properties.NullText = "Seçim Yapınız";
                cmbStokUrunTip.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbStokUrunTip.BackColor = default(Color);
                cmbStokUrunTip.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbStokUrunTip.Properties.DataSource = null;
                cmbStokUrunTip.SelectedText = "";
                cmbStokUrunTip.Clear();
                UrunTipListele();
                cmbStokUrunTip.DeselectAll();
            }
        }

        private void cmbCariHesap_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            cariLogicalref = "";
            int[] selfacrows = cmbCariHesap.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                cariLogicalref += cmbCariHesap.Properties.View.GetRowCellValue(ndx, cmbCariHesap.Properties.ValueMember).ToString() + ",";
                cmbCariHesap.Properties.NullText = "Seçim Yapıldı";
                cmbCariHesap.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariHesap.BackColor = Color.LightGreen;
                cmbCariHesap.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            cariLogicalref = cariLogicalref.TrimEnd(',');
            if (cmbCariHesap.Text.Contains("Seçim ") == false || cariLogicalref == "")
            {
                grdCariHesap.ClearSelection();
                cmbCariHesap.Clear();
                cmbCariHesap.Properties.NullText = "Seçim Yapınız";
                cmbCariHesap.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariHesap.BackColor = default(Color);
                cmbCariHesap.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariHesap.Properties.DataSource = null;
                cmbCariHesap.SelectedText = "";
                cmbCariHesap.Clear();
                CariHesapListele();
                cmbCariHesap.DeselectAll();
            }
        }

        private void cmbCariHesap_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariHesap.Text.Contains("Seçim ") == false || cariLogicalref == "")
            {
                grdCariHesap.ClearSelection();
                cmbCariHesap.Clear();
                cmbCariHesap.Properties.NullText = "Seçim Yapınız";
                cmbCariHesap.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariHesap.BackColor = default(Color);
                cmbCariHesap.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariHesap.Properties.DataSource = null;
                cmbCariHesap.SelectedText = "";
                cmbCariHesap.Clear();
                CariHesapListele();
                cmbCariHesap.DeselectAll();
            }
        }

        private void chcAktifKayitlar_CheckStateChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            satisElemani = "";
            cmbSatisElemani_EditValueChanged(sender, e);
            cariLogicalref = "";
            cmbCariHesap_EditValueChanged(sender, e);
            yetkiKodu = "";
            cmbYetkiKodu_EditValueChanged(sender, e);
            ozelKod = "";
            cmbOzelKod_EditValueChanged(sender, e);
            ozelKod2 = "";
            cmbOzelKod2_EditValueChanged(sender, e);
            ozelKod3 = "";
            cmbOzelKod3_EditValueChanged(sender, e);
            ozelKod4 = "";
            cmbOzelKod4_EditValueChanged(sender, e);
            ozelKod5 = "";
            cmbOzelKod5_EditValueChanged(sender, e);
            dovizTuru = "";
            cmbDovizTuru_EditValueChanged(sender, e);
            hchCariAktifKayitlar.Checked = true;
            chcAktifKayitlar_CheckStateChanged(sender, e);
            urunLogicalref = "";
            cmbUrun_EditValueChanged(sender, e);
            urunTip = "";
            cmbUrunTip_EditValueChanged(sender, e);
            urunGrup = "";
            cmbGrupKodu_EditValueChanged(sender, e);
            urunOzelKod = "";
            AnaForm = "";
            urunOzelKod3 = "";
            urunOzelKod4 = "";
            urunOzelKod5 = "";
            cmbUrunOzelKod_EditValueChanged(sender, e);
            cmbAnaForm_EditValueChanged(sender, e);
            cmbUrunOzelKod3_EditValueChanged(sender, e);
            cmbUrunOzelKod4_EditValueChanged(sender, e);
            cmbUrunOzelKod5_EditValueChanged(sender, e);

            Listele();

        }

        private void cmbYetkiKodu_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCariYetkiKodu.Text.Contains("Seçim ") == false || yetkiKodu == "")
            {
                grdYetkiKodu.ClearSelection();
                cmbCariYetkiKodu.Clear();
                cmbCariYetkiKodu.Properties.NullText = "Seçim Yapınız";
                cmbCariYetkiKodu.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariYetkiKodu.BackColor = default(Color);
                cmbCariYetkiKodu.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariYetkiKodu.Properties.DataSource = null;
                cmbCariYetkiKodu.SelectedText = "";
                cmbCariYetkiKodu.Clear();
                YetkiKoduListele();
                cmbCariYetkiKodu.DeselectAll();
            }
        }

        private void cmbYetkiKodu_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            yetkiKodu = "";
            int[] selfacrows = cmbCariYetkiKodu.Properties.View.GetSelectedRows();
            foreach (int ndx in selfacrows)
            {
                yetkiKodu += cmbCariYetkiKodu.Properties.View.GetRowCellValue(ndx, cmbCariYetkiKodu.Properties.ValueMember).ToString() + "','";
                cmbCariYetkiKodu.Properties.NullText = "Seçim Yapıldı";
                cmbCariYetkiKodu.Properties.NullValuePrompt = "Seçim Yapıldı";
                cmbCariYetkiKodu.BackColor = Color.LightGreen;
                cmbCariYetkiKodu.Font = new System.Drawing.Font("Tahoma", 9.2F, System.Drawing.FontStyle.Bold); ;
            }
            if (yetkiKodu.Length > 1)
            {
                yetkiKodu = "'" + yetkiKodu.Substring(0, yetkiKodu.Length - 2);
            }
            if (cmbCariYetkiKodu.Text.Contains("Seçim ") == false || yetkiKodu == "")
            {
                grdYetkiKodu.ClearSelection();
                cmbCariYetkiKodu.Clear();
                cmbCariYetkiKodu.Properties.NullText = "Seçim Yapınız";
                cmbCariYetkiKodu.Properties.NullValuePrompt = "Seçim Yapınız";
                cmbCariYetkiKodu.BackColor = default(Color);
                cmbCariYetkiKodu.Font = new System.Drawing.Font("Tahoma", 8.2F, System.Drawing.FontStyle.Bold); ;
                cmbCariYetkiKodu.Properties.DataSource = null;
                cmbCariYetkiKodu.SelectedText = "";
                cmbCariYetkiKodu.Clear();
                YetkiKoduListele();
                cmbCariYetkiKodu.DeselectAll();
            }
        }

        private void cntTarihFiltre_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ToolStripItem clickedItem = e.ClickedItem;
            string itemName = clickedItem.Text;

            if (itemName == "Bugün")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
            else if (itemName == "Bu Ay")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
            }
            else if (itemName == "Yıllık")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 31);
            }
            else if (itemName == "1. Çeyrek")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 4, 1).AddDays(-1);
            }
            else if (itemName == "2. Çeyrek")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 4, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 7, 1).AddDays(-1);
            }
            else if (itemName == "3. Çeyrek")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 7, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 10, 1).AddDays(-1);
            }
            else if (itemName == "4. Çeyrek")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 10, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 31);
            }
            else if (itemName == "Ocak")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 2, 1).AddDays(-1);
            }
            else if (itemName == "Şubat")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 2, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 3, 1).AddDays(-1);
            }
            else if (itemName == "Mart")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 3, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 4, 1).AddDays(-1);
            }
            else if (itemName == "Nisan")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 4, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 5, 1).AddDays(-1);
            }
            else if (itemName == "Mayıs")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 5, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 6, 1).AddDays(-1);
            }
            else if (itemName == "Haziran")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 6, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 7, 1).AddDays(-1);
            }
            else if (itemName == "Temmuz")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 7, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 8, 1).AddDays(-1);
            }
            else if (itemName == "Ağustos")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 8, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 9, 1).AddDays(-1);
            }
            else if (itemName == "Eylül")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 9, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 10, 1).AddDays(-1);
            }
            else if (itemName == "Ekim")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 10, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 11, 1).AddDays(-1);
            }
            else if (itemName == "Kasım")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 11, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 1).AddDays(-1);
            }
            else if (itemName == "Aralık")
            {
                dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 12, 1);
                dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 31);

            }
        }
    }
}
