using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCubeCrm.UI.Update
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void getUpdate()
        {

            Application.Run(new XCubeCrm.UI.Update.Guncelleme());

        }
        private Boolean checkUpdate()
        {
            Process.Start("taskkill", "/F /IM XCubeCrm.UI.Win.exe");
            Boolean versionStatu;
            try
            {
                WebRequest wr = WebRequest.Create(new Uri("http://www.burpos.com/versiyon.txt"));
                WebResponse ws = wr.GetResponse();
                StreamReader sr = new StreamReader(ws.GetResponseStream());

                string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //string currentVersions = Type.GetType( XCubeCrm.UI.Win).Assembly.GetName().Version.ToString();


                var versionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\XCubeCrm.UI.Win.exe");
                string version = versionInfo.FileVersion;



                string newVersion = sr.ReadToEnd();
                if (version.Contains(newVersion))
                {
                    versionStatu = false;
                }
                else
                {
                    versionStatu = true;
                }

            }
            catch { versionStatu = false; }
            return versionStatu;
        }
        string appPath = Application.StartupPath + "\\XCubeCrm.UI.Win.exe";
        private void askUpdate()
        {

             

            if (checkUpdate())
            {
                DialogResult dr = MessageBox.Show("Yeni Güncelleme bulundu, yüklemek ister misiniz? ", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                if (dr == DialogResult.Yes)
                {

                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(getUpdate));
                    thread.Start();

                }
                else
                {
                    RunProcessWait();
                    Process ExecFile = Process.Start(appPath);
                    ExecFile.WaitForExit();
                }


            }
            else
            {
                RunProcessWait();
                Process ExecFile = Process.Start(appPath);
                ExecFile.WaitForExit();
            }
        }
        void RunProcessWait()
        {
            Process ExecFile = Process.Start(appPath);
            ExecFile.WaitForExit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            askUpdate();

        }
    }
}
