using XCubeCrm.Bll.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities;
using XCubeCrm.Data.Context;
using System.Windows.Forms;
using XCubeCrm.Model.Entities.Base;
using System.Linq.Expressions;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.Common.Enums;
using XCubeCrm.Bll.Interfaces;

namespace XCubeCrm.Bll.General
{
    public class HesaplamaParametreleriBll : BaseGenelBll<HesaplamaParametreleri>, IBaseGenelBll, IBaseCommonBll
    {
        public HesaplamaParametreleriBll() : base(KartTuru.HesaplamaParametreleri) { }
        public HesaplamaParametreleriBll(Control ctrl) : base(ctrl, KartTuru.HesaplamaParametreleri) { }
    }
}
