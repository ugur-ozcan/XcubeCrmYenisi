using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class FirmaBll : BaseGenelBll<Firma>, IBaseGenelBll, IBaseCommonBll
    {
        public FirmaBll() : base(KartTuru.Firma) { }
        public FirmaBll(Control ctrl) : base(ctrl, KartTuru.Firma) { }
    }
}