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




    }
}