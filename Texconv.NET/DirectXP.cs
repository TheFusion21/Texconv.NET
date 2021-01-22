using System;
using static TexconvNET.DirectXMath;
using static TexconvNET.Texconv;

namespace TexconvNET
{
    public static partial class DirectX
    {
        enum TEXP_SCANLINE_FLAGS : uint
        {
            TEXP_SCANLINE_NONE          = 0,
            TEXP_SCANLINE_SETALPHA      = 0x1,  // Set alpha channel to known opaque value
            TEXP_SCANLINE_LEGACY        = 0x2,  // Enables specific legacy format conversion cases
        };

        enum CONVERT_FLAGS : uint
        {
            CONVF_FLOAT = 0x1,
            CONVF_UNORM = 0x2,
            CONVF_UINT = 0x4,
            CONVF_SNORM = 0x8,
            CONVF_SINT = 0x10,
            CONVF_DEPTH = 0x20,
            CONVF_STENCIL = 0x40,
            CONVF_SHAREDEXP = 0x80,
            CONVF_BGR = 0x100,
            CONVF_XR = 0x200,
            CONVF_PACKED = 0x400,
            CONVF_BC = 0x800,
            CONVF_YUV = 0x1000,
            CONVF_POS_ONLY = 0x2000,
            CONVF_R = 0x10000,
            CONVF_G = 0x20000,
            CONVF_B = 0x40000,
            CONVF_A = 0x80000,
            CONVF_RGB_MASK = 0x70000,
            CONVF_RGBA_MASK = 0xF0000,
        }

        public struct ConvertData
        {
            public DXGI_FORMAT format;
            public ulong dataSize;
            public uint flags;

            public ConvertData(DXGI_FORMAT fmt, ulong dSize, uint flgs)
            {
                format = fmt;
                dataSize = dSize;
                flags = flgs;
            }
        }

        public static readonly ConvertData[] g_ConvertTable =
        {
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT,           32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT,            32, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT,            32, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,              32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT,               32, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT,               32, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT,           16, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM,           16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT,            16, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM,           16, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT,            16, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT,                 32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT,                  32, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G  )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT,                  32, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G  )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT,         32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_DEPTH | CONVERT_FLAGS.CONVF_STENCIL )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM,            10, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT,             10, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT,              10, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_POS_ONLY | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,           8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT,                 8, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM,                8, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT,                 8, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT,                 16, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM,                 16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT,                  16, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM,                 16, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT,                  16, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT,                    32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_DEPTH )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT,                    32, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32_UINT,                     32, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R32_SINT,                     32, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,            32, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_DEPTH | CONVERT_FLAGS.CONVF_STENCIL )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM,                    8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT,                     8, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM,                    8, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT,                     8, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT,                    16, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_D16_UNORM,                    16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_DEPTH )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16_UNORM,                    16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16_UINT,                     16, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16_SNORM,                    16, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R16_SINT,                     16, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8_UNORM,                      8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8_UINT,                       8, (uint)(CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8_SNORM,                      8, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8_SINT,                       8, (uint)(CONVERT_FLAGS.CONVF_SINT | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_A8_UNORM,                      8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R1_UNORM,                      1, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP,            9, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_SHAREDEXP | CONVERT_FLAGS.CONVF_POS_ONLY | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM,               8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_PACKED | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM,               8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_PACKED | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM,                  5, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM,                5, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BGR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BGR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,   10, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_XR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,           8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BGR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,           8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BGR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16,                    16, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16,                    16, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM,                     8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB,                8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BC | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_AYUV,                          8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_Y410,                         10, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_Y416,                         16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_YUY2,                          8, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_PACKED | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_Y210,                         10, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_PACKED | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_Y216,                         16, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_YUV | CONVERT_FLAGS.CONVF_PACKED | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B )),
            new ConvertData( DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM,                4, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_BGR | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_7E3_A2_FLOAT,  10, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_POS_ONLY | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_6E4_A2_FLOAT,  10, (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_POS_ONLY | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_SNORM_A2_UNORM,10, (uint)(CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G | CONVERT_FLAGS.CONVF_B | CONVERT_FLAGS.CONVF_A )),
            new ConvertData( (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R4G4_UNORM,               4, (uint)(CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_R | CONVERT_FLAGS.CONVF_G )),
        };

        public static int ConvertCompare(ConvertData l, ConvertData r)
        {
            if (l.format == r.format)
                return 0;
            else
                return(l.format < r.format) ? -1 : 1;
        }
        public static uint _GetConvertFlags(DXGI_FORMAT fmt)
        {
            DXGI_FORMAT lastValue = g_ConvertTable[g_ConvertTable.Length-1].format;


            ConvertData key = new ConvertData(fmt, 0, 0);

            ConvertData cd = key;//just so it has something assigned we use bool anyway
            bool found = false;
            foreach(var data in g_ConvertTable)
            {
                if (ConvertCompare(key, data) == 0)
                {
                    cd = data;
                    found = true;
                    break;
                }
            }
            return found ? cd.flags : 0;

        }

        public static bool _IsAlphaAllOpaqueBC(Image cImage)
        {
            if (cImage.pixels == null)
                return false;

            DXGI_FORMAT cformat;
            switch(cImage.format)
            {
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS: cformat = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM; break;
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS: cformat = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM; break;
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS: cformat = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM; break;
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS: cformat = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM; break;
                default: cformat = cImage.format; break;
            }


            return true;
        }

        
        public static bool _LoadScanline(ref XMVECTOR[] pDestination, ulong count, byte[] pSource, ulong size, DXGI_FORMAT format)
        {
            switch (format)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT:
                    { 
                        var msize = (size > 16 * count) ? 16 * count : size;//16 bytes for 4 float components
                        pDestination = new XMVECTOR[msize / 16];
                        Array.Copy(pSource, pDestination, (int)msize / 16);
                        return true;
                    }
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT:
                    return LOAD_SCANLINE<XMUINT4>(sizeof(uint)*4, XMLoadUInt4, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT:
                    return LOAD_SCANLINE<XMINT4>(sizeof(int) * 4, XMLoadSInt4, ref pSource, ref pDestination);

                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT:
                    return LOAD_SCANLINE<XMFLOAT3>(sizeof(float) * 3, XMLoadFloat3, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT:
                    return LOAD_SCANLINE<XMUINT3>(sizeof(uint) * 3, XMLoadUInt3, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT:
                    return LOAD_SCANLINE<XMINT3>(sizeof(int) * 3, XMLoadSInt3, ref pSource, ref pDestination);

                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT:
                    return LOAD_SCANLINE<XMHALF4>(2 * 4, XMLoadHalf4, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                    return LOAD_SCANLINE<XMUSHORTN4>(sizeof(ushort)* 4, XMLoadUShortN4, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                    return LOAD_SCANLINE<XMUSHORT4>(sizeof(ushort)* 4, XMLoadUShort4, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                    return LOAD_SCANLINE<XMSHORTN4>(sizeof(short)* 4, XMLoadShortN4, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT:
                    return LOAD_SCANLINE<XMSHORT4>(sizeof(short)* 4, XMLoadShort4, ref pSource, ref pDestination);

                case DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT:
                    return LOAD_SCANLINE<XMFLOAT2>(sizeof(float) * 2, XMLoadFloat2, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT:
                    return LOAD_SCANLINE<XMUINT2>(sizeof(uint) * 2, XMLoadUInt2, ref pSource, ref pDestination);
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT:
                    return LOAD_SCANLINE<XMINT2>(sizeof(int) * 2, XMLoadSInt2, ref pSource, ref pDestination);

                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT:
                    {
                        ulong psize = sizeof(float) + sizeof(uint);
                        if(size > psize)
                        {
                            var pfloatArray = TexUtils.CopyToTypeArray<float, byte>(pSource, sizeof(byte), sizeof(float));
                            int k = 0;
                            for (int icount = 0; icount < (int)(size - psize + 1); icount += (int)psize)
                            {
                                if (pDestination.Length < icount) break;
                                pDestination[icount] = new XMVECTOR
                                {
                                    r = pfloatArray[0],
                                    g = pfloatArray[k + 1],
                                    b = 0.0f,
                                    a = 1.0f
                                };

                                k += 2;
                            }
                            return true;
                        }
                    }
                    return false;
            }
            pDestination = null;
            return false;
        }
    }
}
