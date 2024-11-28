using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class MutabakatBll : BaseGenelBll<Mutabakat>, IBaseGenelBll, IBaseCommonBll
    {
        public MutabakatBll() : base(KartTuru.Mutabakat) { }
        public MutabakatBll(Control ctrl) : base(ctrl, KartTuru.Mutabakat) { }
    }
}