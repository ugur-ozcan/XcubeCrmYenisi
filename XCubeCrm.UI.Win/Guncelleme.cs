using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Zip.Extensions;

namespace XCubeCrm.UI.Win
{
    public partial class Guncelleme : Form
    {
        string appPath = Application.StartupPath + "\\XCubeCrm.UI.Update.exe";
        string appPathrar = Application.StartupPath + "\\Update.zip";
        public Guncelleme()
        {

            InitializeComponent();
        }

        private void ProgressChanged(object sneder, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label2.Text = "Downloading...   " + BytesToString(e.BytesReceived) + " / " + BytesToString(e.TotalBytesToReceive);
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            label2.Text = "Güncelleme var";


            //ZipFile.ExtractToDirectory(appPathrar, Application.StartupPath);
            //System.Diagnostics.Process.Start(appPath);

            //Process.Start("taskkill", "/F /IM Update.exe");


            using (var archive = ZipFile.OpenRead(appPathrar))
            {

                foreach (var file in archive.Entries)
                {
                    var completeFileName = Path.Combine(Application.StartupPath, file.FullName);
                    var directory = Path.GetDirectoryName(completeFileName);

                    if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
                        Directory.CreateDirectory(directory);

                    if (file.Name != string.Empty)
                        file.ExtractToFile(completeFileName, true);
                    this.Hide();
                }

            }




        }


        public static void ExtractToDirectory(string archiveFileName, string destinationDirectoryName, bool overwrite)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
            timer1.Stop();
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://www.burpos.com/Update.zip"), appPathrar);
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
            return (Math.Sign(bytes) * num).ToString() + suf[place];
        }

        private void Guncelleme_Load(object sender, EventArgs e)
        {

        }

        private void Guncelleme_Load_1(object sender, EventArgs e)
        {

        }
    }
}
