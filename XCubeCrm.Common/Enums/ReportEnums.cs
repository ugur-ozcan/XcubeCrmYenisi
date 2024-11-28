using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCubeCrm.Common.Enums
{
    public enum RaporTuru
    {
        StokRaporu = 1,
        CariRaporu = 2,
        SatisRaporu = 3,
        AmbarRaporu = 4
    }

    public enum RaporParametreTuru
    {
        Tarih = 1,
        Ambar = 2,
        Cari = 3,
        Urun = 4,
        Karma = 5
    }

    public enum RaporCiktiFomati
    {
        Excel = 1,
        Pdf = 2,
        Word = 3,
        Html = 4
    }
}