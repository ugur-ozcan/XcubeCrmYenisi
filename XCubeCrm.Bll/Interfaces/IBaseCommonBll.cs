using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Bll.Interfaces
{
    public interface IBaseCommonBll
    {
        bool Delete(BaseEntity entity);
    }
}
