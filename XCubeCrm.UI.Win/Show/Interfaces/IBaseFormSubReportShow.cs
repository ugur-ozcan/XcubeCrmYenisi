using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Common.Enums;

namespace XCubeCrm.UI.Win.Show.Interfaces
{
    public interface IBaseFormSubReportShow
    {
        long ShowDialogSubForm(KartTuru kartTuru, long id);
    }
}
