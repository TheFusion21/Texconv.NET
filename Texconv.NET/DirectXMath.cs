using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexconvNET
{
    public static class DirectXMath
    {
        public class XMUINT4
        {
            public uint r, g, b, a;
        }
        public class XMUINT3
        {
            public uint r, g, b;
        }
        public class XMUINT2
        {
            public uint r, g;
        }

        public class XMINT4
        {
            public int r, g, b, a;
        }
        public class XMINT3
        {
            public int r, g, b;
        }
        public class XMINT2
        {
            public int r, g;
        }

        public class XMFLOAT3
        {
            public float r, g, b;
        }
        public class XMFLOAT2
        {
            public float r, g;
        }
        public class XMVECTOR
        {
            public float r, g, b, a;
        }

        public class XMHALF4
        {
            public Half r, g, b, a;
        }

        public class XMUSHORTN4
        {
            public ushort r, g, b, a;
        }
        public class XMSHORTN4
        {
            public short r, g, b, a;
        }

        public class XMUSHORT4
        {
            public ushort r, g, b, a;
        }
        public class XMSHORT4
        {
            public short r, g, b, a;
        }

        public static bool LOAD_SCANLINE<T>(ulong size, Func<T[], XMVECTOR> func, ref byte[] pSource, ref XMVECTOR[] pDestination)
        {
            return false;
        }

        public static XMVECTOR XMLoadUInt4(XMUINT4[] pSource)
        {
            return new XMVECTOR();
        }

        public static XMVECTOR XMLoadSInt4(XMINT4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadFloat3(XMFLOAT3[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadUInt3(XMUINT3[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadSInt3(XMINT3[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadHalf4(XMHALF4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadUShortN4(XMUSHORTN4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadUShort4(XMUSHORT4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadShortN4(XMSHORTN4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadShort4(XMSHORT4[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadFloat2(XMFLOAT2[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadUInt2(XMUINT2[] pSource)
        {
            return new XMVECTOR();
        }
        public static XMVECTOR XMLoadSInt2(XMINT2[] pSource)
        {
            return new XMVECTOR();
        }
    }
}
