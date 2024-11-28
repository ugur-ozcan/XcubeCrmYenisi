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
    public class Mutabakat : BaseEntityDurum
    {
        public string CariKod { get; set; }

        public string CariUnvan { get; set; }

        [Required]
        public DateTime MutabakatTarihi { get; set; }

        public decimal Bakiye120TL { get; set; }
        public decimal Bakiye120USD { get; set; }
        public decimal Bakiye120EURO { get; set; }
        public decimal Bakiye320TL { get; set; }
        public decimal Bakiye320USD { get; set; }
        public decimal Bakiye320USDTL { get; set; }
        public decimal Bakiye320EURO { get; set; }
        public decimal Bakiye320EUROTL { get; set; }


    }
}