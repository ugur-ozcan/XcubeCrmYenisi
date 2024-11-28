using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCubeCrm.Common.Enums
{
    public enum KartTuru : byte
    {

        [Description("Okul Kartı")]
        Okul = 1,
        [Description("İl Kartı")]
        Il = 2,
        [Description("İlçe Kartı")]
        Ilce = 3,
        [Description("Filtre Kartı")]
        Filtre = 4,
        [Description("Aile Bilgi Kartı")]
        AileBilgi = 5,
        [Description("İptal Nedeni Kartı")]
        IptalNedeni = 6,
        [Description("Yabancı Dil Kartı")]
        YabanciDil = 7,
        [Description("Teşvik Kartı")]
        Tesvik = 8,
        [Description("Kontenjan Kartı")]
        Kontenjan = 9,
        [Description("Rehber Kartı")]
        Rehber = 10,
        [Description("Sınıf Grup Kartı")]
        SinifGrup = 11,
        [Description("Meslek Kartı")]
        Meslek = 12,
        [Description("Yakınlık Kartı")]
        Yakinlik = 13,
        [Description("İş Yeri Kartı")]
        IsYeri = 14,
        [Description("Görev Kartı")]
        Gorev = 15,
        [Description("İndirim Türü Kartı")]
        IndirimTuru = 16,
        [Description("Evrak Kartı")]
        Evrak = 17,
        [Description("Promosyon Kartı")]
        Promosyon = 18,
        [Description("Servis Yeri Kartı")]
        Servis = 19,
        [Description("Sınıf Kartı")]
        Sinif = 20,
        [Description("Hizmet Türü Kartı")]
        HizmetTuru = 21,
        [Description("Hizmet Kartı")]
        Hizmet = 22,
        [Description("Özel Kod Kartı")]
        OzelKod = 23,
        [Description("Kasa Kartı")]
        Kasa = 24,
        [Description("Banka Kartı")]
        Banka = 25,
        [Description("Banka Şube Kartı")]
        BankaSube = 26,
        [Description("Avukat Kartı")]
        Avukat = 27,
        [Description("Cari Kartı")]
        Cari = 28,
        [Description("Ödeme Türü Kartı")]
        OdemeTuru = 29,
        [Description("Banka Hesap Kartı")]
        BankaHesap = 30,




        [Description("Parametreler")]
        Parametreler = 31,
        [Description("Öğrenci Kartı")]
        Ogrenci = 32,
        [Description("Tip Kartı")]
        Tip = 33,
        [Description("Rapor1")]
        Rapor1 = 34,

        [Description("CariBakiyeler")]
        CariBakiyeler = 35,
        [Description("MuhasebeHesapKoduFarkliOlanlar")]
        MuhasebeHesapKoduFarkliOlanlar = 36,


        [Description("NumaralamaKontrol")]
        NumaralamaKontrol = 37,
        [Description("KurFarki")]
        KurFarki = 38,
        [Description("Açık Faturalar")]
        AcikFatura = 39,
        [Description("Rapor")]
        Rapor = 39,
        [Description("Rapor Tasarım")]
        RaporTasarim = 40,
        [Description("Okul Kartı Raporu")]
        OkulKartiRaporu = 41,

        [Description("Mutabakat Raporu")]
        MutabakatRaporu = 42,
        [Description("UrunHareketleri")]
        UrunHareketleri = 43,
        [Description("StokSonHareketTarihleri")]
        StokSonHareketTarihleri = 44,
        [Description("AmbarToplamlari")]
        AmbarToplamlari = 45,
        [Description("BorcAlacakFaturaListesi")]
        BorcAlacakFaturaListesi = 46,
        [Description("CariHareketler")]
        CariHareketler = 47,
        [Description("AcikSatinalmaSiparisleri")]
        AcikSatinalmaSiparisleri = 48,
        [Description("AcikSatisSiparisleri")]
        AcikSatisSiparisleri = 49,
        [Description("Tanimlar")]
        Tanimlar = 50,
        [Description("HesaplamaParametreleri")]
        HesaplamaParametreleri = 51,
        [Description("Firma")]
        Firma = 51,
        [Description("Kullanıcı")]
        Kullanici = 52,
        [Description("Satış Fiyat Listesi")]
        SatisFiyatListesi = 53,
        [Description("Stok İhtiyaç Listesi")]
        StokIhtiyacListesi = 54,
        [Description("AnaMuhasebeOnMuhasebeCariBakiyeKontrolu")]
        AnaMuhasebeOnMuhasebeCariBakiyeKontrolu = 55,
        [Description("AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay")]
        AnaMuhasebeOnMuhasebeCariBakiyeKontroluDetay = 56,
        [Description("AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu")]
        AnaMuhasebeOnMuhasebeBankaBakiyeKontrolu = 57,
        [Description("AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay")]
        AnaMuhasebeOnMuhasebeBankaBakiyeKontroluDetay = 58,
        [Description("Mutabakat")]
        Mutabakat = 59,
        [Description("FisDetayOdemeRaporu")]
        FisDetayOdemeRaporu = 60,
        [Description("ZRaporuAl")]
        ZRaporuAl = 61,

    }
}
 