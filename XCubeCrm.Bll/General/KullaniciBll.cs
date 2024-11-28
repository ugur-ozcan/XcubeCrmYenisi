using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class KullaniciBll : BaseGenelBll<Kullanici>, IBaseGenelBll, IBaseCommonBll
    {
        public KullaniciBll() : base(KartTuru.Kullanici) { }
        public KullaniciBll(Control ctrl) : base(ctrl, KartTuru.Kullanici) { }
    }
}