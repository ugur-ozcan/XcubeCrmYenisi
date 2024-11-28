using System.ComponentModel.DataAnnotations.Schema;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Model.Entities.Dto
{
    [NotMapped]
    public class OkulS : Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }

    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
