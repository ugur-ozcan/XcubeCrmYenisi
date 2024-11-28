using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class AcikFaturaBll : BaseGenelBll<AcikFatura>, IBaseGenelBll, IBaseCommonBll
    {
        public AcikFaturaBll() : base(KartTuru.AcikFatura) { }
        public AcikFaturaBll(Control ctrl) : base(ctrl, KartTuru.AcikFatura) { }
    }
}