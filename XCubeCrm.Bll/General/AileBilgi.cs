using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class AileBilgiBll : BaseGenelBll<AileBilgi>, IBaseGenelBll, IBaseCommonBll
    {
        public AileBilgiBll() : base(KartTuru.AileBilgi) { }
        public AileBilgiBll(Control ctrl) : base(ctrl, KartTuru.AileBilgi) { }
    }
}