using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.Bll.Interfaces
{
    public interface IBaseGenelBll
    {
        bool Insert(BaseEntity entity);
        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
        string YeniKodVer();
    }
}
