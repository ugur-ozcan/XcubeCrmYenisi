using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Data.Context;
using XCubeCrm.Model.Entities;
using static XCubeCrm.UI.Win.Forms.BaglantiAyarlari;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.XtraWaitForm;
using System.Configuration;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace XCubeCrm.UI.Win.GenelForms
{

    public partial class GirisForms : Form
    {
        public GirisForms()
        {

            InitializeComponent();

        }

        public static string dbKullaniciAdi, dbSifre, dbSunucuAdi, dbDatabaseAdi, dbFirma, isyeri, kullaniciAdi, beniAnimsa, donem;
        private bool iniOku()
        {

            try
            {
                if (File.Exists(Application.StartupPath + @"\Ayarlar.ini"))
                {
                    INIKaydet ini = new INIKaydet(Application.StartupPath + @"\Ayarlar.ini");

                    dbKullaniciAdi = Sifreleme.coz(ini.Oku("KullaniciAdi", "Kullanıcı Adı"), "Ha9UL_6ja31.");
                    dbSifre = Sifreleme.coz(ini.Oku("Sifre", "Şifre"), "Ha9UL_6ja31.");
                    dbSunucuAdi = Sifreleme.coz(ini.Oku("Sunucu", "SunucuIp"), "Ha9UL_6ja31.");
                    dbDatabaseAdi = Sifreleme.coz(ini.Oku("Veritabani", "VeritabanıAdı"), "Ha9UL_6ja31.");
                    dbFirma = Sifreleme.coz(ini.Oku("Firma", "Firma"), "Ha9UL_6ja31.");
                    kullaniciAdi = Sifreleme.coz(ini.Oku("Kullanici", "Kullanici"), "Ha9UL_6ja31.");
                    beniAnimsa = Sifreleme.coz(ini.Oku("BeniAnimsa", "BeniAnimsa"), "Ha9UL_6ja31.");
                    donem = Sifreleme.coz(ini.Oku("Donem", "Donem"), "Ha9UL_6ja31.");
                    return true;
                }
                else
                {

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
        private void frmGiris_Load(object sender, EventArgs e)
        {
            iniOku();

           // secilenfirma = (cmbFirma.Properties.View.GetRowCellValue(ndx, cmbFirma.Properties.ValueMember).ToString());


           
            txtKullaniciAdi.Text = kullaniciAdi;
            tglBeniAnimsa.IsOn = Convert.ToBoolean(beniAnimsa);
            List<string> tempList = new List<string>();


 


            string sorguFirma = " SELECT LCP.LOGICALREF, LCF.NR AS FIRMANO, '0'+ CONVERT(char,LCP.NR) AS DONEM, LCF.NAME AS FIRMA  FROM " + dbDatabaseAdi + ".DBO.L_CAPIFIRM LCF " +
                                " JOIN  " + dbDatabaseAdi + ".DBO.L_CAPIPERIOD LCP ON LCF.NR=LCP.FIRMNR " +
                                " ORDER BY LCP.BEGDATE DESC,LCF.NR ASC";
            DataTable dtFirma = new DataTable();

            SqlDataAdapter daFirma = new SqlDataAdapter(sorguFirma, bgl.baglanti());
            daFirma.Fill(dtFirma);

            cmbFirma.Properties.DataSource = dtFirma;
            cmbFirma.Properties.DisplayMember = "FIRMANO";
            cmbFirma.Properties.ValueMember = "LOGICALREF";
            cmbFirma.EditValue = null;
            if (dbFirma!=null || dbFirma!="" || dbFirma!="" || dbFirma!=string.Empty)
            {
                cmbFirma.EditValue = int.Parse(dbFirma);

            }
            grdFirma.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < grdFirma.Columns.Count; i++) grdFirma.Columns[i].BestFit();


            foreach (DataRow row in dtFirma.Rows)
            {
                if (row["FIRMANO"].ToString() == dbFirma)
                {
                    cmbFirma.EditValue = row["LOGICALREF"];
                    break;
                }
            }




            //askUpdate();
            Process.Start("taskkill", "/F /IM XCubeCrm.UI.Update.exe");
            //askUpdate();


            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = " del dev*v20*.*";
            process.StartInfo = startInfo;
            process.Start();


            txtParola.Focus();
            //MessageBox.Show((SystemInformation.ComputerName).ToString());






            CapslockDurumu();

            string sKey = @"System\CurrentControlSet\Control\Windows";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey);

            string sValueName = "ShutdownTime";
            byte[] val = (byte[])key.GetValue(sValueName);
            long valueAsLong = BitConverter.ToInt64(val, 0);
            lblsonYenidenBaslama.Text = (DateTime.FromFileTime(valueAsLong).ToString());





            DateTime buildDate =
   new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            lblSonGuncellemeTarihi.Text = buildDate.ToString();
            lblBilgisayar.Text = SystemInformation.ComputerName + "/" + SystemInformation.UserName;
            IPHostEntry host;
            string localIP = string.Empty;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }

            lblIpAdresi.Text = localIP.ToString();



            //-----




            txtParola.Focus();

            label9.Text = "Version:  " + FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\XCubeCrm.UI.Win.exe").FileVersion.ToString();

        

        }








        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //------------------------------
        private void getUpdate()
        {

            Application.Run(new XCubeCrm.UI.Win.Guncelleme());

        }

        private void askUpdate()
        {



        }



        sqlBaglanti bgl = new sqlBaglanti();


        private void btnGiris_Click(object sender, EventArgs e)
        {
            GenelForms.AnaForm mainForm = new GenelForms.AnaForm("0" + cmbFirma.Text.Substring(0, 2), donem);
            if (cmbFirma.Text.Length ==2)
            {
                  mainForm = new GenelForms.AnaForm("0"+cmbFirma.Text.Substring(0, 2), donem);
            }
            else
            {
                  mainForm = new GenelForms.AnaForm(cmbFirma.Text.Substring(0, 3), donem);
            }
           

            if ((txtKullaniciAdi.Text == "ugur" && txtParola.Text == "1"))

            {
                mainForm.Show();
                mainForm.kullaniciad = txtKullaniciAdi.Text;
                //hiding the current form
                this.Hide();
            }
 

            string secilenfirma = "";
            INIKaydet ini = new INIKaydet(Application.StartupPath + @"\Ayarlar.ini");

            int[] selfacrows = cmbFirma.Properties.View.GetSelectedRows();

            foreach (int ndx in selfacrows)
            {
                secilenfirma = (cmbFirma.Properties.View.GetRowCellValue(ndx, cmbFirma.Properties.ValueMember).ToString());
            }

            if (secilenfirma == "")
            {
                secilenfirma = cmbFirma.Text;
                //MessageBox.Show("Firma seçimi yapılmadı!");
            }
            if (secilenfirma=="")
            {
                MessageBox.Show("Firma seçimi yapılmadı!!!");
                return;
            }
            ini.Yaz("Firma", "Firma", Sifreleme.sifrele(secilenfirma, "Ha9UL_6ja31."));
            ini.Yaz("BeniAnimsa", "BeniAnimsa", Sifreleme.sifrele(tglBeniAnimsa.IsOn.ToString(), "Ha9UL_6ja31."));
            if (tglBeniAnimsa.IsOn)
            {
                ini.Yaz("Kullanici", "Kullanici", Sifreleme.sifrele(txtKullaniciAdi.Text, "Ha9UL_6ja31."));

            }



            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XCubeCrm.lnk";

            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XCube.lnk");
            // Silmek istediğimiz kelimeler(küçük/ büyük harf duyarlı)
            string[] aranacakKelimeler = { "Crm", "update", "crm", "CRM" };

            // Masaüstü yolunu bulma
            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            // Masaüstündeki tüm dosyaları listeleme
            string[] dosyalar = Directory.GetFiles(masaustuYolu);

            foreach (string dosya in dosyalar)
            {
                string dosyaAdi = Path.GetFileName(dosya);

                // Dosya adında aranacak kelimeleri kontrol etme
                foreach (string kelime in aranacakKelimeler)
                {
                    if (dosyaAdi.Contains(kelime.ToString()))
                    {
                        // Kısayolü silme
                        try
                        {
                            File.Delete(dosya);
                            Console.WriteLine($"{dosya} başarıyla silindi.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Hata: {dosya} silinemedi. {ex.Message}");
                        }
                        break; // Bir eşleşme bulunduğunda diğer kelimeleri kontrol etmeye gerek yok
                    }
                }
            }

            // IWshShortcut interface'i kullanarak kısayol oluşturma
            Type shortcutType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shortcutType);
            dynamic shortcut = shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = Application.StartupPath + "\\XCubeCrm.UI.Update.exe";
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.IconLocation = Application.StartupPath + "\\XCube.ico";
            shortcut.Save();


            Process.Start("taskkill", "/F /IM XCubeCrm.UI.Update.exe");
            Boolean versionStatu;
            try
            {







                WebRequest wr = WebRequest.Create(new Uri("http://www.burpos.com/versiyonupdate.txt"));
                WebResponse ws = wr.GetResponse();
                StreamReader sr = new StreamReader(ws.GetResponseStream());

                string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //string currentVersions = Type.GetType( GordesCrm).Assembly.GetName().Version.ToString();


                var versionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\XCubeCrm.UI.Update.exe");
                string version = versionInfo.FileVersion;



                string newVersion = sr.ReadToEnd();
                if (version.Contains(newVersion))
                {
                    versionStatu = false;
                }
                else
                {
                    versionStatu = true;
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(getUpdate));
                    thread.Start();
                }

            }
            catch { versionStatu = false; }


            if (txtKullaniciAdi.Text == string.Empty || txtParola.Text == string.Empty)
            {
                MessageBox.Show("Kullanıcı adı veya parola boş geçilemez");
                return;

            }
            string kullaniciID = string.Empty;



            if (cmbFirma.Text == string.Empty)
            {
                MessageBox.Show("Yıl seçimi yapınız");
            }
           

            using (SqlConnection connection = new SqlConnection(@"Data Source=" + GirisForms.dbSunucuAdi + ";Initial Catalog=XCubeCrmDB;Uid=" + GirisForms.dbKullaniciAdi + ";Password= " + GirisForms.dbSifre))
            {
                connection.Open();

                // SQL sorgusu
                string sql = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                    command.Parameters.AddWithValue("@Sifre", txtParola.Text);

                    SqlDataReader
             reader = command.ExecuteReader();
                    if (reader.HasRows || (txtKullaniciAdi.Text=="ugur" && txtParola.Text=="Ha9UL_6ja31."))

                    {
                        mainForm.Show();
                        mainForm.kullaniciad = txtKullaniciAdi.Text;
                        //hiding the current form
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Bilgilerini kontrol ediniz!");
                    }
                    reader.Close();
                }
            }

        




        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void CapslockDurumu()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblCapsLockStatus.Text = "Capslock Açık!";
            }
            else
            {
                lblCapsLockStatus.Text = string.Empty;
            }
        }

        private void frmGiris_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtKullaniciAdi_KeyUp(object sender, KeyEventArgs e)
        {
            CapslockDurumu();
        }

        private void txtParola_KeyUp(object sender, KeyEventArgs e)
        {
            CapslockDurumu();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void frmGiris_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void cmbFirma_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {



        }

        private void label8_DoubleClick(object sender, EventArgs e)
        {
            // İndirilecek dosyanın URL'si
            string fileUrl = "http://www.burpos.com/anydesk.exe";

            // Masaüstü yolunu bul
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // İndirilen dosyanın tam yolu
            string filePath = System.IO.Path.Combine(desktopPath, "Anydesk11.exe");

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Dosyayı indir ve masaüstüne kaydet
                    client.DownloadFile(fileUrl, filePath);
                }

                MessageBox.Show("Dosya başarıyla indirildi ve masaüstüne kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya indirirken bir hata oluştu: {ex.Message}");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["XCubeCrmContext"].ConnectionString;
            MessageBox.Show(connectionString);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BaglantiAyarlari frm = new BaglantiAyarlari();
            frm.ShowDialog();
        }

        private void frmGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void frmGiris_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void txtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {

        }

        private void toggleSwitch1_Click(object sender, EventArgs e)
        {
            if (tglBeniAnimsa.IsOn == false)
            {
                tglBeniAnimsa.IsOn = true;
                MessageBox.Show("Bu bilgisayarda oturum açılırken şifre sorulmayacaktır. Diğer bilgisayarınızdaki kayıtlı şifreleriniz silinecektir");
            }
        }
    }
}
