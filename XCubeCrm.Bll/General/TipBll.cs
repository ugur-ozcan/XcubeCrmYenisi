using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCubeCrm.Bll.Base;
using XCubeCrm.Bll.Interfaces;
using XCubeCrm.Common.Enums;
using XCubeCrm.Data.Context;
using XCubeCrm.Model.Entities.Base;
using XCubeCrm.Model.Entities.Dto;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Bll.General
{
    public class TipBll : BaseGenelBll<Tip>, IBaseGenelBll, IBaseCommonBll
    {
        public TipBll() : base( KartTuru.Tip) { }
        public TipBll(Control ctrl) : base(ctrl,KartTuru.Tip) { }
         
    }
}
