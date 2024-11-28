using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.UI.Win.Forms.BaseForms;
using XCubeCrm.UI.Win.GenelForms;

namespace XCubeCrm.UI.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

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
            Application.Run(new GirisForms());
     
        }
    }
}
