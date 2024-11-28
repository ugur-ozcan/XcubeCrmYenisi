using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCubeCrm.Common.Enums
{
    public enum YazdirmaYonu : byte
    {
        [Description("Dikey")]
        Dikey = 1,
        [Description("Yatay")]
        Yatay = 2,
        [Description("Otomatik")]
        Otomatik = 3

    }
}
