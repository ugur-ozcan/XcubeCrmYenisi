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
    public class NumaralamaKontrolBll : BaseGenelBll<NumaralamaKontrol>, IBaseGenelBll, IBaseCommonBll
    {
        public NumaralamaKontrolBll() : base(KartTuru.NumaralamaKontrol) { }
        public NumaralamaKontrolBll(Control ctrl) : base(ctrl, KartTuru.NumaralamaKontrol) { }
    }
}
