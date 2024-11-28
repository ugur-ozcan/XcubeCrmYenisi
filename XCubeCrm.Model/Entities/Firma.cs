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
    public class Firma : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(150), ZorunluAlan("Firma Adı", "txtFirmaAdi")]
        public string FirmaAdi { get; set; }

        [Required, StringLength(50), ZorunluAlan("Vergi No", "txtVergiNo")]
        public string VergiNo { get; set; }
        public byte[] ResimData { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
