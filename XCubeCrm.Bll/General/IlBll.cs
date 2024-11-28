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
    public class IlBll : BaseGenelBll<Il>, IBaseGenelBll, IBaseCommonBll
    {
        public IlBll() : base( KartTuru.Il) { }
        public IlBll(Control ctrl) : base(ctrl,KartTuru.Il) { }
         
    }
}
