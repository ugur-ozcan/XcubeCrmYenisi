using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace XCubeCrm.Common.Messages
{

    public class Messages
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult EvetSeciliEvetHayirIptal(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult SilMesaj(string kartAdi)
        {
            return HayirSeciliEvetHayir($"Seçilen {kartAdi} silinecektir. Onaylıyor musun keke?", "Silme Onayı");
        }


        public static void UyariMesaji(string uyariMesaji)
        {
            XtraMessageBox.Show(uyariMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void KartSecmemeUyariMesaji()
        {
            UyariMesaji("Lütfen bir kayıt seçiniz.");
        }

        public static DialogResult KayitMesaj()
        {
            return EvetSeciliEvetHayir("Yapılan değişiklikler kaydedilsin mi?", "Kayıt Onay");

        }

        public static DialogResult KapanisMesaj()
        {
            return EvetSeciliEvetHayirIptal("Yapılan değişiklikler kaydedilsin mi?", "Çıkış Onay");

        }
        public static void MukerrerKayitHataMesaji(string alanAdi)
        {
            HataMesaji($"Girmiş olduğunuz {alanAdi} daha önce kullanılmıştır!");
        }

        public static void HataliVeriMesaji(string alanAdi)
        {
            HataMesaji($"{alanAdi} alanına geçerli bir değer girmelisiniz!");
        }

        public static DialogResult DosyaAktarimMesaji(string dosyaFormati)
        {
            return EvetSeciliEvetHayir($"İlgili tablo {dosyaFormati} olarak dışarı aktarılacaktır. Onaylıyor musunuz?", "Aktarım Onay");

        }

        public static DialogResult RaporuTasarimaGonderMesaj()
        {
            return HayirSeciliEvetHayir("Rapor Tasarım Görünümünde Açılacaktır. Onaylıyor musunuz?", "Onay");
        }

        public static DialogResult RaporKapatmaMesaj()
        {
            return HayirSeciliEvetHayir("Rapor Kapatılacaktır. Onaylıyor musunuz?", "Onay");
        }



    }
}
