using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Model.Entities.Base;

namespace XCubeCrm.UI.Win.Functions
{
    public class FilterFunctions
    {
        public static Expression<Func<T, bool>> Filtre<T>(bool aktifKartlariGoster) where T : BaseEntityDurum
        {
            return x => x.Durum == aktifKartlariGoster;

        }
        public static Expression<Func<T, bool>> Filtre<T>(long id) where T : BaseEntity
        {
            return x => x.Id == id;
        }
    }
}
