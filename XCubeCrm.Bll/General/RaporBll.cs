using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.Model.Entities;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Model.Entities.Dto;

namespace XCubeCrm.Bll.General
{
    public class RaporBll : BaseGenelBll<Rapor>, IBaseGenelBll, IBaseCommonBll
    {
        public RaporBll() : base(KartTuru.Rapor) { }

        public RaporBll(Control control) : base(control, KartTuru.Rapor) { }

        public override IEnumerable<BaseEntity> List(Expression<Func<Rapor, bool>> filter)
        {
            return BaseList(filter, x => new RaporL
            {
                Id = x.Id,
                Kod = x.Kod,
                RaporAdi = x.RaporAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}