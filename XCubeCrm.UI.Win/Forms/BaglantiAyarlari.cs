using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.UI.Win.Functions;

namespace XCubeCrm.UI.Win.Forms
{
    public partial class BaglantiAyarlari : Form
    {
        public BaglantiAyarlari()
        {
            InitializeComponent();
        }
        string sifre = "";
        public class INIKaydet
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public INIKaydet(string dosyaYolu)
            {
                DOSYAYOLU = dosyaYolu;
            }
            private string DOSYAYOLU = String.Empty;
            public string Varsayilan { get; set; }
            public string Oku(string bolum, string ayaradi)
            {
                Varsayilan = Varsayilan ?? string.Empty;
                StringBuilder StrBuild = new StringBuilder(256);
                GetPrivateProfileString(bolum, ayaradi, Varsayilan, StrBuild, 255, DOSYAYOLU);
                return StrBuild.ToString();
            }
            public long Yaz(string bolum, string ayaradi, string deger)
            {
                return WritePrivateProfileString(bolum, ayaradi, deger, DOSYAYOLU);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            INIKaydet ini = new INIKaydet(Application.StartupPath + @"\Ayarlar.ini");
            ;

            ini.Yaz("KullaniciAdi", "Kullanıcı Adı", Sifreleme.sifrele(txtKullaniciAdi.Text, "Ha9UL_6ja31."));
            ini.Yaz("Sifre", "Şifre", Sifreleme.sifrele(txtSifre.Text, "Ha9UL_6ja31."));
            ini.Yaz("Sunucu", "SunucuIp", Sifreleme.sifrele(txtSunucuAdi.Text, "Ha9UL_6ja31."));
            ini.Yaz("Veritabani", "VeritabanıAdı", Sifreleme.sifrele(txtDatabaseAdi.Text, "Ha9UL_6ja31."));
            ini.Yaz("Firma", "Firma", Sifreleme.sifrele(txtFirma.Text, "Ha9UL_6ja31."));
            ini.Yaz("Donem", "Donem", Sifreleme.sifrele(txtDonem.Text, "Ha9UL_6ja31."));


            // Güncellemek istediğiniz connection string'in adı
            string connectionStringName = "XCubeCrmContext";

            // Yeni connection string değeri
            string newConnectionStringValue = "Data Source=" + txtSunucuAdi.Text   + " ; Initial Catalog=XCubeCrmDB1; User Id=" + txtKullaniciAdi.Text + "; Password=" + txtSifre.Text;

            // Mevcut configuration dosyasını yüklüyoruz
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Connection strings bölümünü alıyoruz
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            // Connection string'i güncelleme
            var connectionString = connectionStringsSection.ConnectionStrings[connectionStringName];
            if (connectionString != null)
            {
                connectionString.ConnectionString = newConnectionStringValue;
            }
            else
            {
                // Connection string mevcut değilse, yeni bir tane ekliyoruz
                connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings(connectionStringName, newConnectionStringValue));
            }

            // Yapılandırmayı kaydediyoruz
            config.Save(ConfigurationSaveMode.Modified);

            // Yapılandırma değişikliklerini uygulamak için yeniden yükleme yapıyoruz
            ConfigurationManager.RefreshSection("connectionStrings");

            MessageBox.Show("Connection string başarıyla güncellendi.");


            MessageBox.Show("Ayarlar kayıt altına alındı" );




        }

        private void btnVeriGetir_Click(object sender, EventArgs e)
        {

            try
            {
                if (File.Exists(Application.StartupPath + @"\Ayarlar.ini"))
                {
                    INIKaydet ini = new INIKaydet(Application.StartupPath + @"\Ayarlar.ini");

                    txtKullaniciAdi.Text = Sifreleme.coz(ini.Oku("KullaniciAdi", "Kullanıcı Adı"), "Ha9UL_6ja31.");
                    txtSifre.Text = Sifreleme.coz(ini.Oku("Sifre", "Şifre"), "Ha9UL_6ja31.");
                    sifre =txtSifre.Text;
                    txtSunucuAdi.Text = Sifreleme.coz(ini.Oku("Sunucu", "SunucuIp"), "Ha9UL_6ja31.");
                    txtDatabaseAdi.Text = Sifreleme.coz(ini.Oku("Veritabani", "VeritabanıAdı"), "Ha9UL_6ja31.");
                    txtFirma.Text = Sifreleme.coz(ini.Oku("Firma", "Firma"), "Ha9UL_6ja31.");
                    txtDonem.Text = Sifreleme.coz(ini.Oku("Donem", "Donem"), "Ha9UL_6ja31.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("ini dosyası hasarlı" + hata.Message);
            }
        }

        private void txtSifre_Properties_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(sifre);
        }
    }
}
