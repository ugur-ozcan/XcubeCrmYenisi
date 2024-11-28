using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCubeCrm.UI.Win.Functions
{
    public static class Extensions
    {
        public static bool IsNumeric(this Type type)
        {
            return type == typeof(int) ||
                   type == typeof(long) ||
                   type == typeof(float) ||
                   type == typeof(double) ||
                   type == typeof(decimal) ||
                   type == typeof(short) ||
                   type == typeof(byte) ||
                   type == typeof(sbyte) ||
                   type == typeof(uint) ||
                   type == typeof(ulong) ||
                   type == typeof(ushort);
        }
    }
}
