using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities
{
    public class Parametreler : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required, StringLength(150), ZorunluAlan("Parametre Başlığı Giriniz", "txtParametreBasligi")]
        public string ParametreBaslik { get; set; }
        public long TipId { get; set; }
        [Required, StringLength(150), ZorunluAlan("Parametre Değeri Giriniz", "txtParametreDegeri")]

        public string ParametreDegeri { get; set; }

        public string Firma { get; set; }
        public Tip Tip { get; set; }
    }
}
 