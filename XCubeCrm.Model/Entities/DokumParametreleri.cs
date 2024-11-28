using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base.Interfaces;
 

namespace XCubeCrm.Model.Entities
{
    public class DokumParametreleri : IBaseEntity
    {
        public string RaporBaslik { get; set; }
        public EvetHayir BaslikEkle { get; set; }
        public RaporuKagidaSigdirmaTuru RaporuKagidaSigdir { get; set; }
        public YazdirmaYonu YazdirmaYonu { get; set; }
        public EvetHayir YatayCizgileriGoster { get; set; }
        public EvetHayir DikeyCizgileriGoster { get; set; }
        public EvetHayir SutunBasliklariniGoster { get; set; }
        public string YaziciAdi { get; set; }
        public int KopyaSayisi { get; set; }
        public DokumSekli DokumSekli { get; set; }

    }
}
