using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexconvNET
{
    public static class DDS
    {
        public const uint DDS_MAGIC = 0x20534444;

        public const uint DDS_FOURCC       = 0x00000004; // DDPF_FOURCC
        public const uint DDS_RGB          = 0x00000040; // DDPF_RGB
        public const uint DDS_RGBA         = DDS_RGB | DDS_ALPHAPIXELS; // DDPF_RGB | DDPF_ALPHAPIXELS
        public const uint DDS_LUMINANCE    = 0x00020000; // DDPF_LUMINANCE
        public const uint DDS_LUMINANCEA   = DDS_LUMINANCE | DDS_ALPHAPIXELS; // DDPF_LUMINANCE | DDPF_ALPHAPIXELS
        public const uint DDS_ALPHAPIXELS  = 0x00000001; // DDPF_ALPHAPIXELS
        public const uint DDS_ALPHA        = 0x00000002; // DDPF_ALPHA
        public const uint DDS_PAL8         = 0x00000020; // DDPF_PALETTEINDEXED8
        public const uint DDS_PAL8A        = DDS_PAL8 | DDS_ALPHAPIXELS; // DDPF_PALETTEINDEXED8 | DDPF_ALPHAPIXELS
        public const uint DDS_BUMPDUDV     = 0x00080000; // DDPF_BUMPDUDV

        public const uint DDS_HEADER_FLAGS_TEXTURE        = 0x00001007;  // DDSD_CAPS | DDSD_HEIGHT | DDSD_WIDTH | DDSD_PIXELFORMAT
        public const uint DDS_HEADER_FLAGS_MIPMAP         = 0x00020000;  // DDSD_MIPMAPCOUNT
        public const uint DDS_HEADER_FLAGS_VOLUME         = 0x00800000;  // DDSD_DEPTH
        public const uint DDS_HEADER_FLAGS_PITCH          = 0x00000008;  // DDSD_PITCH
        public const uint DDS_HEADER_FLAGS_LINEARSIZE     = 0x00080000;  // DDSD_LINEARSIZE

        public const uint DDS_HEIGHT = 0x00000002; // DDSD_HEIGHT
        public const uint DDS_WIDTH =  0x00000004; // DDSD_WIDTH

        public const uint DDS_SURFACE_FLAGS_TEXTURE = 0x00001000; // DDSCAPS_TEXTURE
        public const uint DDS_SURFACE_FLAGS_MIPMAP  = 0x00400008; // DDSCAPS_COMPLEX | DDSCAPS_MIPMAP
        public const uint DDS_SURFACE_FLAGS_CUBEMAP = 0x00000008; // DDSCAPS_COMPLEX

        public const uint DDS_CUBEMAP_POSITIVEX = 0x00000600; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEX
        public const uint DDS_CUBEMAP_NEGATIVEX = 0x00000a00; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEX
        public const uint DDS_CUBEMAP_POSITIVEY = 0x00001200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEY
        public const uint DDS_CUBEMAP_NEGATIVEY = 0x00002200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEY
        public const uint DDS_CUBEMAP_POSITIVEZ = 0x00004200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEZ
        public const uint DDS_CUBEMAP_NEGATIVEZ = 0x00008200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEZ

        public const uint DDS_CUBEMAP_ALLFACES = (DDS_CUBEMAP_POSITIVEX | DDS_CUBEMAP_NEGATIVEX |
                                                   DDS_CUBEMAP_POSITIVEY | DDS_CUBEMAP_NEGATIVEY |
                                                   DDS_CUBEMAP_POSITIVEZ | DDS_CUBEMAP_NEGATIVEZ);

        public const uint DDS_CUBEMAP = 0x00000200; // DDSCAPS2_CUBEMAP

        public const uint DDS_FLAGS_VOLUME = 0x00200000; // DDSCAPS2_VOLUME

        public static uint MAKEFOURCC(char ch0, char ch1, char ch2, char ch3)
        {
            return (uint)(ch0 | ch1 << 8 | ch2 << 16 | ch3 << 24);
        }

        public const uint DDS_PIXELFORMAT_SIZE = 32;
        public struct DDS_PIXELFORMAT
        {
            public uint size;
            public uint flags;
            public uint fourCC;
            public uint RGBBitCount;
            public uint RBitMask;
            public uint GBitMask;
            public uint BBitMask;
            public uint ABitMask;

            public DDS_PIXELFORMAT(uint iflags, uint ifourCC, uint RGBBCount, uint rm, uint gm, uint bm, uint am)
            {
                size = DDS_PIXELFORMAT_SIZE;
                flags = iflags;
                fourCC = ifourCC;
                RGBBitCount = RGBBCount;
                RBitMask = rm;
                GBitMask = gm;
                BBitMask = bm;
                ABitMask = am;
            }
        }

        public static readonly DDS_PIXELFORMAT DDSPF_DXT1 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D','X','T','1'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_DXT2 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D','X','T','2'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_DXT3 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D', 'X', 'T', '3'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_DXT4 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D', 'X', 'T', '4'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_DXT5 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D', 'X', 'T', '5'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_BC4_UNORM =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('B', 'C', '4', 'U'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_BC4_SNORM =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('B', 'C', '4', 'S'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_BC5_UNORM =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('B', 'C', '5', 'U'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_BC5_SNORM =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('B', 'C', '5', 'S'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_R8G8_B8G8 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('R', 'G', 'B', 'G'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_G8R8_G8B8 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('G', 'R', 'G', 'B'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_YUY2 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('Y', 'U', 'Y', '2'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_UYVY =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('U', 'Y', 'V', 'Y'), 0, 0, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8R8G8B8 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 32, 0x00ff0000, 0x0000ff00, 0x000000ff, 0xff000000 );

        public static readonly DDS_PIXELFORMAT DDSPF_X8R8G8B8 =
            new DDS_PIXELFORMAT( DDS_RGB,  0, 32, 0x00ff0000, 0x0000ff00, 0x000000ff, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8B8G8R8 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 32, 0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000 );

        public static readonly DDS_PIXELFORMAT DDSPF_X8B8G8R8 =
            new DDS_PIXELFORMAT( DDS_RGB,  0, 32, 0x000000ff, 0x0000ff00, 0x00ff0000, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_G16R16 =
            new DDS_PIXELFORMAT( DDS_RGB,  0, 32, 0x0000ffff, 0xffff0000, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_R5G6B5 =
            new DDS_PIXELFORMAT( DDS_RGB, 0, 16, 0xf800, 0x07e0, 0x001f, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A1R5G5B5 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 16, 0x7c00, 0x03e0, 0x001f, 0x8000 );

        public static readonly DDS_PIXELFORMAT DDSPF_X1R5G5B5 =
            new DDS_PIXELFORMAT( DDS_RGB, 0, 16, 0x7c00, 0x03e0, 0x001f, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A4R4G4B4 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 16, 0x0f00, 0x00f0, 0x000f, 0xf000 );

        public static readonly DDS_PIXELFORMAT DDSPF_X4R4G4B4 =
            new DDS_PIXELFORMAT( DDS_RGB, 0, 16, 0x0f00, 0x00f0, 0x000f, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_R8G8B8 =
            new DDS_PIXELFORMAT( DDS_RGB, 0, 24, 0xff0000, 0x00ff00, 0x0000ff, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8R3G3B2 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 16, 0x00e0, 0x001c, 0x0003, 0xff00 );

        public static readonly DDS_PIXELFORMAT DDSPF_R3G3B2 =
            new DDS_PIXELFORMAT( DDS_RGB, 0, 8, 0xe0, 0x1c, 0x03, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A4L4 =
            new DDS_PIXELFORMAT( DDS_LUMINANCEA, 0, 8, 0x0f, 0, 0, 0xf0 );

        public static readonly DDS_PIXELFORMAT DDSPF_L8 =
            new DDS_PIXELFORMAT( DDS_LUMINANCE, 0,  8, 0xff, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_L16 =
            new DDS_PIXELFORMAT( DDS_LUMINANCE, 0, 16, 0xffff, 0, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8L8 =
            new DDS_PIXELFORMAT( DDS_LUMINANCEA, 0, 16, 0x00ff, 0, 0, 0xff00 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8L8_ALT =
            new DDS_PIXELFORMAT( DDS_LUMINANCEA, 0, 8, 0x00ff, 0, 0, 0xff00 );

        public static readonly DDS_PIXELFORMAT DDSPF_A8 =
            new DDS_PIXELFORMAT( DDS_ALPHA, 0, 8, 0, 0, 0, 0xff );

        public static readonly DDS_PIXELFORMAT DDSPF_V8U8 =
            new DDS_PIXELFORMAT( DDS_BUMPDUDV, 0, 16, 0x00ff, 0xff00, 0, 0 );

        public static readonly DDS_PIXELFORMAT DDSPF_Q8W8V8U8 =
            new DDS_PIXELFORMAT( DDS_BUMPDUDV, 0, 32, 0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000 );

        public static readonly DDS_PIXELFORMAT DDSPF_V16U16 =
            new DDS_PIXELFORMAT( DDS_BUMPDUDV, 0, 32, 0x0000ffff, 0xffff0000, 0, 0 );

        // D3DFMT_A2R10G10B10/D3DFMT_A2B10G10R10 should be written using DX10 extension to avoid D3DX 10:10:10:2 reversal issue
        public static readonly DDS_PIXELFORMAT DDSPF_A2R10G10B10 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 32, 0x000003ff, 0x000ffc00, 0x3ff00000, 0xc0000000 );
        public static readonly DDS_PIXELFORMAT DDSPF_A2B10G10R10 =
            new DDS_PIXELFORMAT( DDS_RGBA, 0, 32, 0x3ff00000, 0x000ffc00, 0x000003ff, 0xc0000000 );

        // We do not support the following legacy Direct3D 9 formats:
        // DDSPF_A2W10V10U10 = new DDS_PIXELFORMAT( DDS_BUMPDUDV, 0, 32, 0x3ff00000, 0x000ffc00, 0x000003ff, 0xc0000000 );
        // DDSPF_L6V5U5 = new DDS_PIXELFORMAT( DDS_BUMPLUMINANCE, 0, 16, 0x001f, 0x03e0, 0xfc00, 0 );
        // DDSPF_X8L8V8U8 = new DDS_PIXELFORMAT( DDS_BUMPLUMINANCE, 0, 32, 0x000000ff, 0x0000ff00, 0x00ff0000, 0 );

        // This indicates the DDS_HEADER_DXT10 extension is present (the format is in dxgiFormat)
        public static readonly DDS_PIXELFORMAT DDSPF_DX10 =
            new DDS_PIXELFORMAT( DDS_FOURCC, MAKEFOURCC('D', 'X', '1', '0'), 0, 0, 0, 0, 0 );

        public enum DDS_RESOURCE_DIMENSION : uint
        {
            DDS_DIMENSION_TEXTURE1D = 2,
            DDS_DIMENSION_TEXTURE2D = 3,
            DDS_DIMENSION_TEXTURE3D = 4,
        };

        // Subset here matches D3D10_RESOURCE_MISC_FLAG and D3D11_RESOURCE_MISC_FLAG
        public enum DDS_RESOURCE_MISC_FLAG : ulong
        {
            DDS_RESOURCE_MISC_TEXTURECUBE = 0x4L,
        };

        public enum DDS_MISC_FLAGS2 : ulong
        {
            DDS_MISC_FLAGS2_ALPHA_MODE_MASK = 0x7L,
        };

        public enum DDS_ALPHA_MODE : uint
        {
            DDS_ALPHA_MODE_UNKNOWN = 0,
            DDS_ALPHA_MODE_STRAIGHT = 1,
            DDS_ALPHA_MODE_PREMULTIPLIED = 2,
            DDS_ALPHA_MODE_OPAQUE = 3,
            DDS_ALPHA_MODE_CUSTOM = 4,
        };

        public const uint DDS_HEADER_SIZE = 124;
        public struct DDS_HEADER
        {
            public uint size;
            public uint flags;
            public uint height;
            public uint width;
            public uint pitchOrLinearSize;
            public uint depth;
            public uint mipMapCount;
            public uint reserved1;
            public uint reserved2;
            public uint reserved3;
            public uint reserved4;
            public uint reserved5;
            public uint reserved6;
            public uint reserved7;
            public uint reserved8;
            public uint reserved9;
            public uint reserved10;
            public uint reserved11;
            public DDS_PIXELFORMAT ddspf;
            public uint caps;
            public uint caps2;
            public uint caps3;
            public uint caps4;
            public uint reserved12;
        }

        public const uint DDS_HEADER_DXT10_SIZE = 20;
        public struct DDS_HEADER_DXT10
        {
            public DXGI_FORMAT dxgiFormat;
            public uint resourceDimension;
            public uint miscFlag;
            public uint arraySize;
            public uint miscFlag2;
        }
    }
}
