using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities.Dto
{
    public class RaporL : BaseEntity
    {
        public string RaporAdi { get; set; }
        public string Aciklama { get; set; }
    }
}