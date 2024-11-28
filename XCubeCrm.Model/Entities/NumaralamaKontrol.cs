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
    public class NumaralamaKontrol : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(16), ZorunluAlan("Numara", "txtNumaralama")]
        public string Numara { get; set; }


        [StringLength(16), ZorunluAlan("Fiş Türü", "txtFisTuru")]
        public string FisTuru { get; set; }
    }
}
