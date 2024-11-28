using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCubeCrm.Common.Enums
{
    public enum YazdirmaSekli : byte
    {
        [Description("Tek Tek Yazdr")]
        TekTekYazdir = 1,
        [Description("Toplu Yazdır")]
        TopluYazdir = 2

    }
}
