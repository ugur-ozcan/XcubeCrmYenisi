using System;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities
{
    public class ReportParameter : BaseEntity
    {
        public string RaporAdi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public long? AmbarId { get; set; }
        public long? CariId { get; set; }
        public string CariGrup { get; set; }
        public long? UrunId { get; set; }
        public string UrunGrup { get; set; }
        public bool TarihFiltresiAktif { get; set; }
        public bool AmbarFiltresiAktif { get; set; }
        public bool CariFiltresiAktif { get; set; }
        public bool UrunFiltresiAktif { get; set; }
        public string FilterString { get; set; }
        public string KullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
