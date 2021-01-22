using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexconvNET
{
    public static class TexUtils
    {
        public static bool HasFlag<T>(T flags, T flag)
        {
            return ((dynamic)flags & (dynamic)flag) == (dynamic)flag;
        }

        public static bool FlagNotZero<T>(T flags, T flag)
        {
            return ((dynamic)flags & (dynamic)flag) != 0;
        }

        public static T[] CopyToTypeArray<T, T2>(T2[] array, int s1, int s2)
        {
            T[] tarray = new T[array.Length / s1 * s2];
            Buffer.BlockCopy(array, 0, tarray, 0, array.Length);
            return tarray;
        }
    }
}
