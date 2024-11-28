using XCubeCrm.Common.Enums;
using XCubeCrm.Common.Messages;
using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using DevExpress.XtraGrid;


namespace XCubeCrm.UI.Win.Functions
{
    public static class FileFunctions
    {
        public static void FormSablonKaydet(this string sablonAdi, int left, int top, int width, int height, FormWindowState windowState)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\Şablon Dosyaları"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Şablon Dosyaları");

                var settings = new XmlWriterSettings { Indent = true };
                var writer = XmlWriter.Create(Application.StartupPath + @"\Şablon Dosyaları\" + sablonAdi + "_location.xml", settings);
                writer.WriteStartDocument();
                writer.WriteComment("XCubeCrm tarafından oluşturuldu.");
                writer.WriteStartElement("Tablo");
                writer.WriteStartElement("Location");
                writer.WriteAttributeString("Left", left.ToString());
                writer.WriteAttributeString("Top", top.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("FormSize");
                if (windowState == FormWindowState.Maximized)
                {
                    writer.WriteAttributeString("Width", "-1");
                    writer.WriteAttributeString("Height", "-1");
                }
                else
                {
                    writer.WriteAttributeString("width", width.ToString());
                    writer.WriteAttributeString("height", height.ToString());
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
        }
        public static void FormSablonYukle(this string sablonAdi, XtraForm frm)
        {
            var list = new List<string>();
            try
            {
                if (File.Exists(Application.StartupPath + $@"\Şablon Dosyaları\{sablonAdi}_location.xml"))
                {
                    var reader = XmlReader.Create(Application.StartupPath + $@"\Şablon Dosyaları\{sablonAdi}_location.xml");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Location")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                        else if (reader.NodeType == XmlNodeType.Element && reader.Name == "FormSize")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                    }
                    reader.Close();
                    reader.Dispose();

                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
            if (list.Count <= 0) return;

            frm.Location = new Point(int.Parse(list[0]), int.Parse(list[1]));

            if (list[2] == "-1" && list[3] == "-1")
                frm.WindowState = FormWindowState.Maximized;
            else
                frm.Size = new Size(int.Parse(list[2]), int.Parse(list[3]));
        }
        public static void TabloSablonKaydet(this GridView tablo, string sablonAdi)
        {
            try
            {
                tablo.ClearColumnsFilter();
                if (!Directory.Exists(Application.StartupPath + @"\Şablon Dosyaları"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Şablon Dosyaları");

                tablo.SaveLayoutToXml(Application.StartupPath + $@"\Şablon Dosyaları\{sablonAdi}.xml");
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
        }
        public static void TabloSablonYukle(this GridView tablo, string sablonAdi)
        {
            try
            {
                if (File.Exists(Application.StartupPath + $@"\Şablon Dosyaları\{sablonAdi}.xml"))
                    tablo.RestoreLayoutFromXml(Application.StartupPath + $@"\Şablon Dosyaları\{sablonAdi}.xml");

            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
        }
        public static void TabloDisariAktar(this GridView tablo, string dosyaAdii, DosyaTuru dosyaTuru, string dosyaFormati, string excellSayfaAdi = null)
        {
            if (Messages.DosyaAktarimMesaji(dosyaFormati) != DialogResult.Yes) return;

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            var dosyaAdi = dosyaAdii;
            var filePath =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +  "\\"+dosyaAdi;

            switch (dosyaTuru)
            {
                case DosyaTuru.ExcellStandart:
                    {

                        var options = new XlsxExportOptionsEx();

                        options.ExportType = ExportType.Default;
                        options.SheetName = excellSayfaAdi;
                       
                        options.TextExportMode = TextExportMode.Text;
                        filePath = filePath + ".Xlsx";
                        tablo.ExportToXlsx(filePath, options);

                         

                    }
                    break;

                case DosyaTuru.ExcellFormatli:
                    {

                        var options = new XlsxExportOptionsEx
                        {
                            ExportType = ExportType.WYSIWYG,
                            SheetName = excellSayfaAdi,
                            TextExportMode = TextExportMode.Text
                        };
                        filePath = filePath + ".Xlsx";
                        tablo.ExportToXlsx(filePath, options);
                    }
                    break;
                case DosyaTuru.ExcellFormatsiz:
                    {
                        var options = new CsvExportOptionsEx
                        {
                            ExportType = ExportType.WYSIWYG,
                            TextExportMode = TextExportMode.Text
                        };
                        filePath = filePath + ".Csv";
                        tablo.ExportToCsv(filePath, options);
                    }
                    break;
                case DosyaTuru.WordDosyasi:
                    filePath = filePath + ".Docx";
                    MessageBox.Show(tablo.ViewCaption.ToString());
                    tablo.ExportToDocx(filePath);
                    break;

                case DosyaTuru.PdfDosyasi:
                    filePath = filePath + ".Pdf";
                    tablo.ExportToPdf(filePath);
                    break;

                case DosyaTuru.TextDosyasi:
                    var opt = new TextExportOptions { TextExportMode = TextExportMode.Text };
                    filePath = filePath + ".Txt";
                    tablo.ExportToText(filePath, opt);
                    break;
            }

            if (!File.Exists(filePath))
            {
                Messages.HataMesaji("Dosya aktarımı olurken bir hata meydana geldi. Dosya oluşamadı. Ağlaaa kudurrrr xdddd");
                return;
            }

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
