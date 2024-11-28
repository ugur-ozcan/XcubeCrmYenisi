using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCubeCrm.UI.Win.GenelForms
{
    public partial class GirisForm : Form
    {
        sqlBaglanti bgl = new sqlBaglanti();

        public GirisForm()
        {
            InitializeComponent();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {


            byte[] imageData = new byte[1024];
            DataTable dt = new DataTable();
            SqlCommand komut = new SqlCommand("SELECT  top 1 ResimData FROM XCUBECRMDB.DBO.Firma", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();


            while (dr.Read())
            {
                imageData = (byte[])dr[0];

            }

            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }


            //askUpdate();
            Process.Start("taskkill", "/F /IM UpdateExe.exe");
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


            if (SystemInformation.ComputerName == "TUNAMUMCUOGLU")
            {
                btnGiris_Click(new Button(), new EventArgs());

            }

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getUpdate()
        {

            Application.Run(new XCubeCrm.UI.Win.Guncelleme());

        }

        private void askUpdate()
        {



        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
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
                //string currentVersions = Type.GetType( XCubeCrm.UI.Win).Assembly.GetName().Version.ToString();


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



            if (cmbFirma.Text == string.Empty)
            {
                MessageBox.Show("Yıl seçimi yapınız");
            }


            //if (kullanici != null)
            //{
            //    if (kullanici.Sifre.Equals(txtParola.Text))
            //    {
            //        frmGiris.




            //        //creating instance of main form
            //        Formlar.Crm mainForm = new Formlar.Crm(cmbFirma.Text.Substring(0, 3), isyeri);

            //        // creating event handler to catch the main form closed event
            //        // this will fire when mainForm closed
            //        mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed); //+= new FormClosedEventHandler(mainForm_FormClosed);

            //        mainForm.kullaniciad = txtKullaniciAdi.Text;
            //        mainForm.kullaniciID = kullanici.ID;
            //        kullaniciID = kullanici.ID.ToString();

            //        mainForm.personelAd = kullanici.Ad + " " + kullanici.Soyad;
            //        mainForm.Show();
            //        //hiding the current form
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kullanıcı Bilgilerini kontrol ediniz!");
            //        return;
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Kullanıcı bulunamadı!");
            //}

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

        private void txtKullaniciAdi_KeyUp(object sender, KeyEventArgs e)
        {
            CapslockDurumu();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void GirisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }

        private void GirisForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void GirisForm_MouseUp(object sender, MouseEventArgs e)
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
    }
}
