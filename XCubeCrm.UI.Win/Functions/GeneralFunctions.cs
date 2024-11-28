using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Common.Messages;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.UI.Win.Forms.UserControls.Controls;

namespace XCubeCrm.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView tablo)
        {
            // MessageBox.Show(tablo.GetFocusedRowCellValue("Id").ToString());
            long idsi=(long)(tablo.GetFocusedRowCellValue("Id"));
            if (tablo.FocusedRowHandle > -1) return (long)idsi;
            Messages.KartSecmemeUyariMesaji();
            return -1;
        }


        public static T GetRow<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(tablo.FocusedRowHandle);

            if (mesajVer)
                Messages.KartSecmemeUyariMesaji();

            return default(T);
        }

        public static T GetRow<T>(this GridView tablo, int rowHandle)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(rowHandle);
            Messages.KartSecmemeUyariMesaji();
            tablo.FocusedRowHandle = 0;  //seçim yapılan list formlarda filtre sekmesi yoksa silinebilir sonradan eklendi.
            return default(T);
        }
        public static void SagMenuGoster(this MouseEventArgs e, PopupMenu sagMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            sagMenu.ShowPopup(Control.MousePosition);
        }
        public static byte[] ResimYukle()    //ÖNEMLİ
        {
            var dialog = new OpenFileDialog
            {
                Title = "Resim Seç",
                Filter = "Resim Dosyaları (*.bmp, *.gif, *.jpg, *.png)|*.bmp; *.gif; *.jpg; *.png|Bmp Dosyaları|*.bmp|Gif Dosyaları|*.gif|Jpg Dosyları|*.jpg|Png Dosyaları|*.png",
                InitialDirectory = @"C:\"
            };

            byte[] Resim()
            {
                using (var stream = new MemoryStream())
                {
                    Image.FromFile(dialog.FileName).Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }

            return dialog.ShowDialog() != DialogResult.OK ? null : Resim();
        }
        public static void ShowPopupMenu(this MouseEventArgs e, PopupMenu popupMenu)
        {
            if (e.Button != MouseButtons.Right) return; //mouse sağ tuşu değilse return yap
            popupMenu.ShowPopup(Control.MousePosition);  //mouse nerdeyse orda aç
        }
        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T oldEntity, T currentEntity)
        {


            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty; // ?? means  'null ise'

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentValue.ToString()))
                        currentValue = new byte[] { 0 };

                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                    {
                        return VeriDegisimYeri.Alan;
                    }
                }
                else if (!currentValue.Equals(oldValue))
                    return VeriDegisimYeri.Alan;
            }
            return VeriDegisimYeri.VeriDegisimiYok;
        }

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var butonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnGeriAl.Enabled = butonEnabledDurumu;
            btnYeni.Enabled = !butonEnabledDurumu;
            btnSil.Enabled = !butonEnabledDurumu;

        }
        public static void ButtonEnabledDurumu<T>(BarButtonItem btnKaydet, BarButtonItem btnFarkliKaydet, BarButtonItem btnSil, IslemTuru islemTuru, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var butonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = butonEnabledDurumu;
            btnFarkliKaydet.Enabled = islemTuru != IslemTuru.EntityInsert;
            btnSil.Enabled = !butonEnabledDurumu;

        }

        public static long IdOlustur(this IslemTuru islemTuru, BaseEntity selectedEntity)
        {

            string SifirEkle(string deger)
            {
                if (deger.Length == 1) return "0" + deger;
                return deger;
            }

            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;

                }
                return deger;
            }
            string Id()
            {
                var yil = SifirEkle(DateTime.Now.Date.Year.ToString());
                var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var milisn = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var random = SifirEkle(new Random().Next(0, 99).ToString());

                return yil + ay + gun + saat + dakika + saniye + milisn + random;
            }
            var id = Id();
            return islemTuru == IslemTuru.EntityUpdate ? selectedEntity.Id : long.Parse(Id());
        }
        public static void ControlEnabledChange(this MyButtonEdit baseEdit, Control prmEdit)
        {
            switch (prmEdit)
            {
                case MyButtonEdit edt: //edt MyButtonEdit tipinde ise
                    edt.Enabled = baseEdit.Id.HasValue && baseEdit.Id > 0;
                    edt.Id = null;
                    edt.EditValue = null;
                    break;
            }
        }

        public static void RowFocus(this GridView tablo, string aranacakKolon, object aranacakDeger)
        {
            var rowHandle = 0;

            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);

                if (aranacakDeger.Equals(bulunanDeger)) rowHandle = i;
            }
            tablo.FocusedRowHandle = rowHandle;
        }

        public static void RowFocus(this GridView tablo, int rowhandle)
        {
            if (rowhandle <= 0) return;
            if (rowhandle == tablo.RowCount - 1)
            {
                tablo.FocusedRowHandle = rowhandle;
            }
            else
            {
                tablo.FocusedRowHandle = rowhandle - 1;
            }
        }

        public static List<string> YazicilariListele()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }

        public static string DefaultYazici()
        {
            var settings = new PrinterSettings();
            return settings.PrinterName;
        }
        public static void CreateDropDownMenu(this BarButtonItem baseButton, BarItem[] buttonItems)
        {
            baseButton.ButtonStyle = BarButtonStyle.CheckDropDown;
            var popupMenu = new PopupMenu();
            buttonItems.ForEach(x => x.Visibility = BarItemVisibility.Always);
            popupMenu.ItemLinks.AddRange(buttonItems);
            baseButton.DropDownControl = popupMenu;
        }
        public static MemoryStream ReportToStream(this XtraReport rapor)
        {
            var stream = new MemoryStream();
            rapor.SaveLayout(stream);  //rapor dizaynı kayıt edilir
            return stream;
        }


        public static MyXtraReport StreamToReport(this MemoryStream stream)
        {
            return (MyXtraReport)XtraReport.FromStream(stream, true);
        }

        public static MemoryStream ByteToStream(this byte[] report)
        {
            return new MemoryStream(report);
        }

    }

}
