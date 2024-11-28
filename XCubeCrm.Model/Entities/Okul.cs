using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities
{
    public class Okul : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Okul Adı", "txtOkulAdi")]
        public string OkulAdi { get; set; }

        [ZorunluAlan("İl Adı", "btnIl")]
        public long IlId { get; set; }

        [ZorunluAlan("İlçe Adı", "btnIlce")]
        public long IlceId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public Il Il { get; set; }

        public Ilce Ilce { get; set; }
    }
}
