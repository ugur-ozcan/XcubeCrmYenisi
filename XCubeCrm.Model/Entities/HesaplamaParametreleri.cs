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
    public class HesaplamaParametreleri : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Parametre Adı Giriniz", "txtParametreAdi")]
        public string ParametreAdi { get; set; }

        [StringLength(500)]
        public string ParametreDegeri { get; set; }

        [StringLength(500)]
        public string ParametreAciklama { get; set; }
    }
}
