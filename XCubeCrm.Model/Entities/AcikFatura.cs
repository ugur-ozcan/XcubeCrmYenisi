using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Attributes;
using XCubeCrm.Model.Entities.Base;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace XCubeCrm.Model.Entities
{
    public class AcikFatura : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [StringLength(300)]
        public string Unvan { get; set; }

        [StringLength(30)]
        public string FaturaNo { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public DateTime TahsilatTarihi { get; set; }
        [StringLength(100)]
        public string IslemTipi { get; set; }
        public decimal Tutar {  get; set; }
        public int VadedenSapma { get; set; }
        public int ToplamVade {  get; set; }
        public int TahsilatHizi { get; set; }
        [StringLength(300)]
        public string Aciklama { get; set; }
        public DateTime NakiteDonus { get; set; }
        [StringLength(100)]
        public string KapamaIslemi { get; set; }
        [StringLength(30)]
        public string KapatilanFatura { get; set; }
        public decimal TutarDobiz { get; set; }
        public decimal IslemKuru { get; set; }

        [StringLength(5)]
        public string Doviz { get; set; }
 
        public DateTime Vade { get; set; }
        [StringLength(30)]
        public string Tip { get; set; }
        [StringLength(30)]
        public string BorCTipi { get; set; }
    }
}
