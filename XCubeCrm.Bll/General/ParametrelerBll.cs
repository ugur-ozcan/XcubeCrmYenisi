using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class ParametrelerBll : BaseGenelBll<Parametreler>, IBaseCommonBll
    {
        public ParametrelerBll() : base( KartTuru.Parametreler) { }
        public ParametrelerBll(Control ctrl) : base(ctrl,KartTuru.Parametreler) { }
    }
}
