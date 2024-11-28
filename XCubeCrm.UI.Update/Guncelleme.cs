using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCubeCrm.UI.Update
{
    public partial class Guncelleme : Form
    {
        string appPath = Application.StartupPath + "\\XCubeCrm.UI.Win.exe";
        string appPathrar = Application.StartupPath + "\\XCubeCrm.zip";
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

            //Process.Start("taskkill", "/F /IM XCubeCrm.UI.Win.exe");


            using (var archive = ZipFile.OpenRead(appPathrar))
            {

                foreach (var file in archive.Entries)
                {
                    var completeFileName = Path.Combine(Application.StartupPath, file.FullName);
                    var directory = Path.GetDirectoryName(completeFileName);

                    if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
                        Directory.CreateDirectory(directory);

                    if (file.Name != "")
                        file.ExtractToFile(completeFileName, true);
                }

            }

            Process ExecFile = Process.Start(appPath);
            ExecFile.WaitForExit();

        }


        public static void ExtractToDirectory(string archiveFileName, string destinationDirectoryName, bool overwrite)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://www.burpos.com/XCubeCrm.zip"), appPathrar);
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(bytes) * num).ToString() + suf[place];
        }

        private void Guncelleme_Load(object sender, EventArgs e)
        {

        }
    }
}
