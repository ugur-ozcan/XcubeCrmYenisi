
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
using XCubeCrm.UI.Win.Forms.Raporlar.njoy;
using XCubeCrm.UI.Win.Forms.Raporlar.NJOY;
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
        public static string ozelKod2 = "", urunOzelKod2 = "";
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



        public static string aktifKayilar = "1", aktifKayitlarUrun = "1";
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






            Listele();
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarButtonItem btn:
                        btn.ItemClick += Buttonlar_ItemClick;

                        break;
                }

            }


        }

        // Değişkenler
        //string secilenIl = "", secilenCari = "", secilenCariGrup = "", secilenCariTur = "", secilenIlce;
        List<string> secilenCariOk1 = new List<string>();
        List<string> secilenCariOk2 = new List<string>();
        List<string> secilenCariOk3 = new List<string>();
        List<string> secilenCariOk4 = new List<string>();
        List<string> secilenCariOk5 = new List<string>();
        public static List<string> secilenLokasyon = new List<string>();
        List<string> secilenCari = new List<string>();
        List<string> secilenCariGrup = new List<string>();
        List<string> secilenCariTur = new List<string>();
        List<string> secilenStok = new List<string>();
        List<string> secilenStokCins = new List<string>();
        List<string> secilenStokGrup = new List<string>();
        List<string> secilenStokOzelKod1 = new List<string>();
        List<string> secilenStokOzelKod2 = new List<string>();
        List<string> secilenStokOzelKod3 = new List<string>();
        List<string> secilenStokOzelKod4 = new List<string>();
        List<string> secilenStokOzelKod5 = new List<string>();
        List<string> secilenStokOzelKod6 = new List<string>();
        List<string> secilenStokOzelKod7 = new List<string>();
        List<string> secilenStokOzelKod8 = new List<string>();
        List<string> secilenStokOzelKod9 = new List<string>();
        

        private void Listele()
        {
            // Başlangıç tarihlerini ayarla
            dtBaslangicTarihi.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtBitisTarihi.Value = new DateTime(DateTime.Now.Year, 12, 31);


            dtBaslangicTarihi.Value = DateTime.Today.AddHours(6);
            dtBitisTarihi.Value = DateTime.Today.AddDays(1).AddHours(5).AddMinutes(59);


            // gridLookUpEditLokasyon yapılandırma
            SetupGridLookUpEdit(
                gridLookUpEditLokasyon,
                "select ID,AD from  LOKASYON",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
            { "ID", false },         // Görünmeyecek
            { "AD", true }     // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenLokasyon = values // Seçilen değerleri listeye ata
            );



            // gridLookUpEditCari yapılandırma
            SetupGridLookUpEdit(
                gridLookUpEditCari,
                " select C.ID, CT.AD AS CARITUR, C.KOD, C.AD AS CARI, CG.AD AS CARIGRUP, " +
                " CKO1.AD COK1," +
                " CKO2.AD COK2," +
                " CKO3.AD COK3," +
                " CKO4.AD COK4," +
                " CKO5.AD COK5 " +
                " from CARI c " +
                " LEFT JOIN CARI_GRUP CG ON CG.ID = C.CARI_GRUP " +
                " LEFT JOIN CARI_TUR CT ON CT.ID = C.CARI_TUR " +
                " LEFT JOIN CARI_OZEL_KOD_1 CKO1 ON CKO1.ID = C.CARI_OZEL_KOD_1 " +
                " LEFT JOIN CARI_OZEL_KOD_1 CKO2 ON CKO2.ID = C.CARI_OZEL_KOD_2 " +
                " LEFT JOIN CARI_OZEL_KOD_1 CKO3 ON CKO3.ID = C.CARI_OZEL_KOD_3 " +
                " LEFT JOIN CARI_OZEL_KOD_1 CKO4 ON CKO4.ID = C.CARI_OZEL_KOD_4 " +
                " LEFT JOIN CARI_OZEL_KOD_1 CKO5 ON CKO5.ID = C.CARI_OZEL_KOD_5 " +
                "WHERE C.AKTIF IN (" + aktifKayilar + ") ORDER BY C.AD",
                "ID", // ValueMember
                "CARI", // DisplayMember
                new Dictionary<string, bool>
                {
            { "ID", false },         // Görünmeyecek
            { "CARITUR", true },     // Görünecek
            { "KOD", true },         // Görünecek
            { "CARI", true },        // Görünecek
            { "CARIGRUP", true },    // Görünecek
            { "COK1", true },    // Görünecek
            { "COK2", true },    // Görünecek
            { "COK3", true },    // Görünecek
            { "COK4", true },    // Görünecek
            { "COK5", true }    // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCari = values // Seçilen değerleri listeye ata
            );

            // Diğer GridLookUpEdit kontrolleri yapılandırma
            SetupGridLookUpEdit(
                gridLookUpEditCariGrup,
                "SELECT ID, AD FROM CARI_GRUP WHERE AKTIF IN (" + aktifKayilar + ") ORDER BY AD",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
            { "ID", false }, // Görünmeyecek
            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCariGrup = values // Seçilen değerleri listeye ata
            );
            SetupGridLookUpEdit(
               gridLookUpEditCariOzelKod1,
               "select CKO1.ID,  CKO1.KOD, CKO1.AD FROM  CARI_OZEL_KOD_1 CKO1",
               "ID", // ValueMember
               "AD", // DisplayMember
               new Dictionary<string, bool>
               {
            { "ID", false }, // Görünmeyecek
            { "KOD", true }, // Görünecek

            { "AD", true }   // Görünecek
               },
               true, // ValueMember'a göre seçim yapılacak
               (values) => secilenCariOk1 = values // Seçilen değerleri listeye ata
           );


            SetupGridLookUpEdit(
                gridLookUpEditCariOzelKod2,
                "select CKO1.ID,  CKO1.KOD, CKO1.AD FROM  CARI_OZEL_KOD_2 CKO1",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                { "ID", false }, // Görünmeyecek
                { "KOD", true }, // Görünecek
                { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCariOk2 = values // Seçilen değerleri listeye ata
              );


            SetupGridLookUpEdit(
                gridLookUpEditCariOzelKod3,
                "select CKO1.ID,  CKO1.KOD, CKO1.AD FROM  CARI_OZEL_KOD_3 CKO1",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                            { "ID", false }, // Görünmeyecek
                            { "KOD", true }, // Görünecek
                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCariOk3 = values // Seçilen değerleri listeye ata
                );

                            SetupGridLookUpEdit(
                gridLookUpEditCariOzelKod4,
                "select CKO1.ID,  CKO1.KOD, CKO1.AD FROM  CARI_OZEL_KOD_4 CKO1",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                            { "ID", false }, // Görünmeyecek
                            { "KOD", true }, // Görünecek
                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCariOk4 = values // Seçilen değerleri listeye ata
                );

                            SetupGridLookUpEdit(
                gridLookUpEditCariOzelKod5,
                "select CKO1.ID,  CKO1.KOD, CKO1.AD FROM  CARI_OZEL_KOD_5 CKO1",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                            { "ID", false }, // Görünmeyecek
                            { "KOD", true }, // Görünecek
                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenCariOk5 = values // Seçilen değerleri listeye ata
                );


            SetupGridLookUpEdit(
               gridLookUpEditCariTur,
                "SELECT ID, AD FROM CARI_TUR",
               "ID", // ValueMember
               "AD", // DisplayMember
               new Dictionary<string, bool>
               {
    { "ID", false }, // Görünmeyecek
    { "AD", true }   // Görünecek
               },
               false, // DisplayMember'a göre seçim yapılacak
               (values) => secilenCariTur = values // Seçilen değerleri listeye ata
           );


            // gridLookUpEditCari yapılandırma
            SetupGridLookUpEdit(
                gridLookUpEditStok,
                "select S.ID,S.KOD,S.AD, SG.AD AS STOKGRUP,SC.AD AS STOKCINS,SOK1.AD OK1,SOK2.AD OK2,SOK3.AD OK3, SOK3.AD OK3, SOK4.AD OK4, SOK5.AD OK5, SOK6.AD OK6, SOK7.AD OK7, SOK8.AD OK8, SOK9.AD OK9  from STOK S  " + 
  " LEFT JOIN STOK_GRUP AS SG ON SG.ID = S.STOK_GRUP " +
  " LEFT JOIN STOK_CINSI AS SC ON SC.ID = S.STOK_CINSI " +
  " LEFT JOIN STOK_OZEL_KOD_1 AS SOK1 ON SOK1.ID = S.STOK_OZEL_KOD_1 " +
  " LEFT JOIN STOK_OZEL_KOD_2 AS SOK2 ON SOK2.ID = S.STOK_OZEL_KOD_2 " +
  " LEFT JOIN STOK_OZEL_KOD_3 AS SOK3 ON SOK3.ID = S.STOK_OZEL_KOD_3 " +
  " LEFT JOIN STOK_OZEL_KOD_4 AS SOK4 ON SOK4.ID = S.STOK_OZEL_KOD_4 " +
  " LEFT JOIN STOK_OZEL_KOD_5 AS SOK5 ON SOK5.ID = S.STOK_OZEL_KOD_5 " +
  " LEFT JOIN STOK_OZEL_KOD_6 AS SOK6 ON SOK6.ID = S.STOK_OZEL_KOD_6 " +
  " LEFT JOIN STOK_OZEL_KOD_7 AS SOK7 ON SOK7.ID = S.STOK_OZEL_KOD_7 " +
  " LEFT JOIN STOK_OZEL_KOD_8 AS SOK8 ON SOK8.ID = S.STOK_OZEL_KOD_8 " +
  " LEFT JOIN STOK_OZEL_KOD_9 AS SOK9 ON SOK9.ID = S.STOK_OZEL_KOD_9 " + 
                "WHERE S.AKTIF IN (" + aktifKayilar + ") ORDER BY SG.AD,S.AD",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
            { "ID", false },         // Görünmeyecek
            { "KOD", true },     // Görünecek
            { "AD", true },         // Görünecek
            { "STOKGRUP", true },        // Görünecek
            { "STOKCINS", true },    // Görünecek
            { "OK1", true },    // Görünecek
            { "OK2", true },    // Görünecek
            { "OK3", true },    // Görünecek
            { "OK4", true },    // Görünecek
            { "OK5", true },    // Görünecek
            { "OK6", true },    // Görünecek
            { "OK7", true },    // Görünecek
            { "OK8", true },    // Görünecek
            { "OK9", true }    // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStok = values // Seçilen değerleri listeye ata
            );

            SetupGridLookUpEdit(
                gridLookUpEditStokGrup,
                "select ID,AD from STOK_GRUP where AKTIF IN (" + aktifKayilar + ")",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokGrup = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokCins,
                "select ID,AD from STOK_CINSI",
                "ID", // ValueMember
                "AD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokCins = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod1,
                "select ID,KOD,AD from STOK_OZEL_KOD_1",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod1 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod1,
                "select ID,KOD,AD from STOK_OZEL_KOD_1",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod1 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod1,
                "select ID,KOD,AD from STOK_OZEL_KOD_1",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod1 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod1,
                "select ID,KOD,AD from STOK_OZEL_KOD_1",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod1 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod1,
                "select ID,KOD,AD from STOK_OZEL_KOD_1",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod1 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod2,
                "select ID,KOD,AD from STOK_OZEL_KOD_2",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod2 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod3,
                "select ID,KOD,AD from STOK_OZEL_KOD_3",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod3 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod4,
                "select ID,KOD,AD from STOK_OZEL_KOD_4",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod4 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod5,
                "select ID,KOD,AD from STOK_OZEL_KOD_5",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod5 = values // Seçilen değerleri listeye ata
                );

            SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod6,
                "select ID,KOD,AD from STOK_OZEL_KOD_6",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod6 = values // Seçilen değerleri listeye ata
                );
                        SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod7,
                "select ID,KOD,AD from STOK_OZEL_KOD_7",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod7 = values // Seçilen değerleri listeye ata
                );
                        SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod8,
                "select ID,KOD,AD from STOK_OZEL_KOD_8",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod8 = values // Seçilen değerleri listeye ata
                );
                        SetupGridLookUpEdit(
                gridLookUpEditStokOzelKod9,
                "select ID,KOD,AD from STOK_OZEL_KOD_9",
                "ID", // ValueMember
                "KOD", // DisplayMember
                new Dictionary<string, bool>
                {
                                            { "ID", false }, // Görünmeyecek
                                            { "KOD", true }, // Görünmeyecek
                                            { "AD", true }   // Görünecek
                },
                true, // ValueMember'a göre seçim yapılacak
                (values) => secilenStokOzelKod9 = values // Seçilen değerleri listeye ata
                );


        }




        private void SetupGridLookUpEdit(
    GridLookUpEdit gridLookUpEdit, // Kontrol
    string query,                  // SQL sorgusu
    string valueMember,            // Değer sütunu (ValueMember)
    string displayMember,          // Görünen sütun (DisplayMember)
    Dictionary<string, bool> columnVisibility, // Sütun görünürlük ayarları
    bool useValueMember,           // Seçim ValueMember'a göre mi yapılacak?
    Action<List<string>> setVariable) // Seçilen değerleri kaydetmek için fonksiyon
        {
            // Veritabanından verileri al
            DataTable dataTable = GetDataFromQuery(query);

            // GridLookUpEdit'in veri kaynağını ayarla
            gridLookUpEdit.Properties.DataSource = dataTable;
            gridLookUpEdit.Properties.DisplayMember = displayMember; // Görünen alan
            gridLookUpEdit.Properties.ValueMember = valueMember;     // Değer alanı
            gridLookUpEdit.Properties.NullText = "";     // Text alanı


            gridLookUpEdit.EditValue = null;

            var view = gridLookUpEdit.Properties.View;
            view.OptionsSelection.MultiSelect = true; // Çoklu seçim aktif
            view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect; // Checkbox ile seçim
            view.OptionsView.ShowIndicator = false;  // Satır numaralarını gizle
            view.OptionsView.ColumnAutoWidth = false; // Sütun genişliklerini manuel ayarla

            // Sütun görünürlüğü ve sıralamasını ayarla
            foreach (var column in columnVisibility)
            {
                var gridColumn = view.Columns.AddField(column.Key);
                gridColumn.Visible = column.Value; // Görünürlük durumu
                gridColumn.VisibleIndex = column.Value ? view.Columns.Count : -1; // Sıralama
            }

            // Kolon genişliklerini ayarla
            view.BestFitColumns();

            // SelectionChanged olayı bağlama
            view.SelectionChanged += (s, e) =>
            {
                var selectedRows = view.GetSelectedRows(); // Seçilen tüm satırları al
                List<string> selectedValues = new List<string>();

                foreach (var rowHandle in selectedRows)
                {
                    var value = view.GetRowCellValue(rowHandle, useValueMember ? valueMember : displayMember)?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        selectedValues.Add(value); // Seçilen değerleri listeye ekle
                    }
                }

                if (selectedValues.Count > 0)
                {
                    gridLookUpEdit.BackColor = Color.LightGreen; // Seçim varsa yeşil arka plan
                }
                else
                {
                    gridLookUpEdit.BackColor = SystemColors.Window; // Varsayılan renk
                }

                setVariable(selectedValues); // Seçilen değerleri dışarı aktar
            };

            // EditValueChanged olayı bağlama
            gridLookUpEdit.EditValueChanged += (s, e) =>
            {
                if (gridLookUpEdit.EditValue != null)
                {
                    gridLookUpEdit.BackColor = Color.LightGreen; // Seçim varsa yeşil arka plan
                }
                else
                {
                    gridLookUpEdit.BackColor = SystemColors.Window; // Varsayılan renk
                }
            };
        }




        // EditValueChanged Olayı
        private void GridLookUpEdit_EditValueChanged(GridLookUpEdit gridLookUpEdit, string displayMember, Action<List<string>> setVariable)
        {

            if (gridLookUpEdit.EditValue != null)
            {
                gridLookUpEdit.BackColor = Color.LightGreen; // Yeşil arka plan
            }
            else
            {
                gridLookUpEdit.BackColor = SystemColors.Window; // Varsayılan renk
            }
        }

        // SelectionChanged Olayı (Çoklu Seçimler için)
        private void GridLookUpEdit_SelectionChanged(GridLookUpEdit gridLookUpEdit, DevExpress.XtraGrid.Views.Grid.GridView view, string selectedField, Action<List<string>> setVariable)
        {
            var selectedRows = view.GetSelectedRows(); // Seçilen tüm satırları al
            List<string> selectedValues = new List<string>();

            foreach (var rowHandle in selectedRows)
            {
                var value = view.GetRowCellValue(rowHandle, selectedField)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    selectedValues.Add(value); // Seçilen değerleri listeye ekle
                }
            }

            if (selectedValues.Count > 0)
            {
                gridLookUpEdit.BackColor = Color.LightGreen; // Seçim varsa yeşil arka plan
                setVariable(selectedValues); // Listeyi değişkene ata
            }
            else
            {
                gridLookUpEdit.BackColor = SystemColors.Window; // Varsayılan renk
                setVariable(new List<string>()); // Listeyi temizle
            }
        }


        // Veritabanı Sorgu İşleyici
        private DataTable GetDataFromQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=UGUROZCAN\SQL2022;Initial Catalog=AYAN24;Uid=SA;Password=LOGO"))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }





        private void btnTemizle_Click(object sender, EventArgs e)
        {
 

            gridLookUpEditLokasyon.EditValue = null;
            gridLookUpEditLokasyonView.ClearSelection();
            gridLookUpEditLokasyon.Clear(); 

            gridLookUpEditCari.EditValue = null;
            gridLookUpEditCariView.ClearSelection();
            gridLookUpEditCari.Clear();

            gridLookUpEditCariGrup.EditValue = null;
            gridLookUpEditCariGrupView.ClearSelection();
            gridLookUpEditCariGrup.Clear();
            
            gridLookUpEditCariTur.EditValue = null;
            gridLookUpEditCariTurView.ClearSelection();
            gridLookUpEditCariTur.Clear();

            gridLookUpEditCariOzelKod1.EditValue = null;
            gridLookUpEditCariOzelKod1View.ClearSelection();
            gridLookUpEditCariOzelKod1.Clear();
            
            gridLookUpEditCariOzelKod2.EditValue = null;
            gridLookUpEditCariOzelKod2View.ClearSelection();
            gridLookUpEditCariOzelKod2.Clear();
            
            gridLookUpEditCariOzelKod3.EditValue = null;
            gridLookUpEditCariOzelKod3View.ClearSelection();
            gridLookUpEditCariOzelKod3.Clear();
            
            gridLookUpEditCariOzelKod4.EditValue = null;
            gridLookUpEditCariOzelKod4View.ClearSelection();
            gridLookUpEditCariOzelKod5.Clear();
            
            gridLookUpEditCariOzelKod5.EditValue = null;
            gridLookUpEditCariOzelKod5View.ClearSelection();
            gridLookUpEditCariOzelKod5.Clear();

            gridLookUpEditStok.EditValue = null;
            gridLookUpEditStokView.ClearSelection();
            gridLookUpEditStok.Clear();
            
            gridLookUpEditStokGrup.EditValue = null;
            gridLookUpEditStokGrupView.ClearSelection();
            gridLookUpEditStokGrup.Clear();
            
            gridLookUpEditStokCins.EditValue = null;
            gridLookUpEditStokCinsView.ClearSelection();
            gridLookUpEditStokCins.Clear();  
            
            gridLookUpEditStokOzelKod1.EditValue = null;
            gridLookUpEditStokOzelKod1View.ClearSelection();
            gridLookUpEditStokOzelKod1.Clear();

            gridLookUpEditStokOzelKod2.EditValue = null;
            gridLookUpEditStokOzelKod2View.ClearSelection();
            gridLookUpEditStokOzelKod2.Clear();

            gridLookUpEditStokOzelKod3.EditValue = null;
            gridLookUpEditStokOzelKod3View.ClearSelection();
            gridLookUpEditStokOzelKod3.Clear();

            gridLookUpEditStokOzelKod4.EditValue = null;
            gridLookUpEditStokOzelKod4View.ClearSelection();
            gridLookUpEditStokOzelKod4.Clear();

            gridLookUpEditStokOzelKod5.EditValue = null;
            gridLookUpEditStokOzelKod5View.ClearSelection();
            gridLookUpEditStokOzelKod5.Clear();

            gridLookUpEditStokOzelKod6.EditValue = null;
            gridLookUpEditStokOzelKod6View.ClearSelection();
            gridLookUpEditStokOzelKod6.Clear();

            gridLookUpEditStokOzelKod7.EditValue = null;
            gridLookUpEditStokOzelKod7View.ClearSelection();
            gridLookUpEditStokOzelKod7.Clear();

            gridLookUpEditStokOzelKod8.EditValue = null;
            gridLookUpEditStokOzelKod8View.ClearSelection();
            gridLookUpEditStokOzelKod8.Clear();

            gridLookUpEditStokOzelKod9.EditValue = null;
            gridLookUpEditStokOzelKod9View.ClearSelection();
            gridLookUpEditStokOzelKod9.Clear();




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
            else if (e.Item == btnFisDetayOdemeRaporu)
            {
                ShowReportListForms<FisDetayOdemeRaporu>.ShowReportListForm(KartTuru.FisDetayOdemeRaporu);
            }
            else if (e.Item == btnZRaporu)
            {
                ShowReportListForms<ZRaporu>.ShowReportListForm(KartTuru.ZRaporuAl);
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

        private void mySimpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
       $"Seçilen Cari: {string.Join(", ", secilenCari)} \n" +
       $"Seçilen Cari Tür : {string.Join(", ", secilenCariTur)} \n" +
        $"Seçilen Lokasyon: {string.Join(", ", secilenLokasyon)} \n" +
        $"Seçilen Cari Özel Kod 1 : {string.Join(", ", secilenCariOk1)} \n" +
       $"Seçilen Cari Özel Kod 2: {string.Join(", ", secilenCariOk2)} \n" +
       $"Seçilen Cari Özel Kod 3: {string.Join(", ", secilenCariOk3)} \n" +
       $"Seçilen Cari Özel Kod 4: {string.Join(", ", secilenCariOk4)} \n" +
       $"Seçilen Cari Özel Kod 5: {string.Join(", ", secilenCariOk5)} \n" +
       $"Seçilen Cari Grup: {string.Join(", ", secilenCariGrup)}",
       "Seçilen Değerler"
   );
        }

        private void btnDegerleriGoster_Click(object sender, EventArgs e)
        {



            MessageBox.Show(
                    $"Seçilen Cari: {string.Join(", ", secilenCari)}\n" +
                    $"Seçilen Cari Grup: {string.Join(", ", secilenCariGrup)}",
                    "Seçilen Değerler"
                          );



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



        private void dtBitisTarihi_ValueChanged(object sender, EventArgs e)
        {
            bitisTarihi = dtBitisTarihi.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }




        private void dtBaslangicTarihi_ValueChanged(object sender, EventArgs e)
        {
            baslangicTarihi = dtBaslangicTarihi.Value.ToString("yyyy-MM-dd HH:mm:ss");
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



        private void chcAktifKayitlar_CheckStateChanged(object sender, EventArgs e)
        {

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
