using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities
{
    public class Kullanici : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Kullanıcı Adı", "txtKullaniciAdi")]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(50), ZorunluAlan("Şifre ", "txtSifre")]
        public string Sifre { get; set; }
        [Required, StringLength(50), ZorunluAlan("Telefon No ", "txtTelefonNo")]
        public string TelefonNo { get; set; }
        [Required, StringLength(50), ZorunluAlan("E-Mail Adresi ", "txtEMail")]
        public string EMail { get; set; }

    }
}