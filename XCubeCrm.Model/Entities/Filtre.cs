using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities
{
    public class Filtre : BaseEntity
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required, StringLength(100), ZorunluAlan("Filtre Adı", "txtFiltreAdi")]
        public string FiltreAdi { get; set; }
        [Required, StringLength(1000), ZorunluAlan("Filtre Adı", "txtFiltreMetni")]
        public string FiltreMetni { get; set; }
        [Required,]
        public KartTuru KartTuru { get; set; }

        // Yeni eklenecek alanlar
        public string KolonAyarlari { get; set; }  // Kolon genişlikleri, sıralama vs.
        public string KolonGizlilik { get; set; }  // Hangi kolonların gizli/görünür olduğu
        public string KolonSiralama { get; set; }  // Kolonların sıralama düzeni
    }
}