using System;
using System.Linq;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class IlceBll :BaseGenelBll<Ilce>, IBaseCommonBll
    {
        public IlceBll() : base( KartTuru.Ilce) { }
        public IlceBll(Control ctrl) : base(ctrl,KartTuru.Ilce) { }

         
    }
}
