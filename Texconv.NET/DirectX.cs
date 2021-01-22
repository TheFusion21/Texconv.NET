using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexconvNET
{

    public static partial class DirectX
    {

        public enum CRESULT
        {
            OK,
            INVALIDARG
        }

        public static bool IsValid(DXGI_FORMAT fmt)
        {
            return ((ulong)fmt >= 1 && (ulong)fmt <= 190);
        }
        public static bool IsCompressed(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsPacked(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_YUY2: // 4:2:2 8-bit
                case DXGI_FORMAT.DXGI_FORMAT_Y210: // 4:2:2 10-bit
                case DXGI_FORMAT.DXGI_FORMAT_Y216: // 4:2:2 16-bit
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsVideo(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_AYUV:
                case DXGI_FORMAT.DXGI_FORMAT_Y410:
                case DXGI_FORMAT.DXGI_FORMAT_Y416:
                case DXGI_FORMAT.DXGI_FORMAT_NV12:
                case DXGI_FORMAT.DXGI_FORMAT_P010:
                case DXGI_FORMAT.DXGI_FORMAT_P016:
                case DXGI_FORMAT.DXGI_FORMAT_YUY2:
                case DXGI_FORMAT.DXGI_FORMAT_Y210:
                case DXGI_FORMAT.DXGI_FORMAT_Y216:
                case DXGI_FORMAT.DXGI_FORMAT_NV11:
                // These video formats can be used with the 3D pipeline through special view mappings

                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
                case DXGI_FORMAT.DXGI_FORMAT_AI44:
                case DXGI_FORMAT.DXGI_FORMAT_IA44:
                case DXGI_FORMAT.DXGI_FORMAT_P8:
                case DXGI_FORMAT.DXGI_FORMAT_A8P8:
                // These are limited use video formats not usable in any way by the 3D pipeline

                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:
                    // These video formats are for JPEG Hardware decode (DXGI 1.4)
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsPlanar(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_NV12:      // 4:2:0 8-bit
                case DXGI_FORMAT.DXGI_FORMAT_P010:      // 4:2:0 10-bit
                case DXGI_FORMAT.DXGI_FORMAT_P016:      // 4:2:0 16-bit
                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:// 4:2:0 8-bit
                case DXGI_FORMAT.DXGI_FORMAT_NV11:      // 4:1:1 8-bit

                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:// 4:2:2 8-bit
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:// 4:4:0 8-bit
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:// 4:4:4 8-bit
                                                                 // These are JPEG Hardware decode formats (DXGI 1.4)

                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    // These are Xbox One platform specific types
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsPalettized(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_AI44:
                case DXGI_FORMAT.DXGI_FORMAT_IA44:
                case DXGI_FORMAT.DXGI_FORMAT_P8:
                case DXGI_FORMAT.DXGI_FORMAT_A8P8:
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsDepthStencil(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_D16_UNORM:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsSRGB(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    return true;

                default:
                    return false;
            }
        }
        public static bool IsTypeless(DXGI_FORMAT fmt, bool partialTypeless = true)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                    return true;

                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    return partialTypeless;

                default:
                    return false;
            }
        }

        public static bool HasAlpha(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_AYUV:
                case DXGI_FORMAT.DXGI_FORMAT_Y410:
                case DXGI_FORMAT.DXGI_FORMAT_Y416:
                case DXGI_FORMAT.DXGI_FORMAT_AI44:
                case DXGI_FORMAT.DXGI_FORMAT_IA44:
                case DXGI_FORMAT.DXGI_FORMAT_A8P8:
                case DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_7E3_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_6E4_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_SNORM_A2_UNORM:
                    return true;

                default:
                    return false;
            }
        }

        public static ulong BitsPerPixel(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT:
                    return 128;

                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT:
                    return 96;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_Y416:
                case DXGI_FORMAT.DXGI_FORMAT_Y210:
                case DXGI_FORMAT.DXGI_FORMAT_Y216:
                    return 64;

                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_AYUV:
                case DXGI_FORMAT.DXGI_FORMAT_Y410:
                case DXGI_FORMAT.DXGI_FORMAT_YUY2:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_7E3_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_6E4_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_SNORM_A2_UNORM:
                    return 32;

                case DXGI_FORMAT.DXGI_FORMAT_P010:
                case DXGI_FORMAT.DXGI_FORMAT_P016:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:
                    return 24;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_D16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_A8P8:
                case DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:
                    return 16;

                case DXGI_FORMAT.DXGI_FORMAT_NV12:
                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
                case DXGI_FORMAT.DXGI_FORMAT_NV11:
                    return 12;

                case DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_AI44:
                case DXGI_FORMAT.DXGI_FORMAT_IA44:
                case DXGI_FORMAT.DXGI_FORMAT_P8:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R4G4_UNORM:
                    return 8;

                case DXGI_FORMAT.DXGI_FORMAT_R1_UNORM:
                    return 1;

                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                    return 4;

                default:
                    return 0;
            }
        }

        public static ulong BitsPerColor(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_SINT:
                    return 32;

                case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT:
                    return 24;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_D16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                case DXGI_FORMAT.DXGI_FORMAT_Y416:
                case DXGI_FORMAT.DXGI_FORMAT_P016:
                case DXGI_FORMAT.DXGI_FORMAT_Y216:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    return 16;

                case DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP:
                    return 14;

                case DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT:
                    return 11;

                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_Y410:
                case DXGI_FORMAT.DXGI_FORMAT_P010:
                case DXGI_FORMAT.DXGI_FORMAT_Y210:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_7E3_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_6E4_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_SNORM_A2_UNORM:
                    return 10;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SINT:
                case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_AYUV:
                case DXGI_FORMAT.DXGI_FORMAT_NV12:
                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
                case DXGI_FORMAT.DXGI_FORMAT_YUY2:
                case DXGI_FORMAT.DXGI_FORMAT_NV11:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:
                    return 8;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    return 7;

                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM:
                    return 6;

                case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
                    return 5;

                case DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R4G4_UNORM:
                    return 4;

                case DXGI_FORMAT.DXGI_FORMAT_R1_UNORM:
                    return 1;

                case DXGI_FORMAT.DXGI_FORMAT_AI44:
                case DXGI_FORMAT.DXGI_FORMAT_IA44:
                case DXGI_FORMAT.DXGI_FORMAT_P8:
                case DXGI_FORMAT.DXGI_FORMAT_A8P8:
                // Palettized formats return 0 for this function

                default:
                    return 0;
            }
        }

        public enum FORMAT_TYPE
        {
            FORMAT_TYPE_TYPELESS,
            FORMAT_TYPE_FLOAT,
            FORMAT_TYPE_UNORM,
            FORMAT_TYPE_SNORM,
            FORMAT_TYPE_UINT,
            FORMAT_TYPE_SINT,
        }

        public static FORMAT_TYPE FormatDataType(DXGI_FORMAT fmt)
        {
            var cflags = _GetConvertFlags(fmt);
            switch (cflags & (uint)(CONVERT_FLAGS.CONVF_FLOAT | CONVERT_FLAGS.CONVF_UNORM | CONVERT_FLAGS.CONVF_UINT | CONVERT_FLAGS.CONVF_SNORM | CONVERT_FLAGS.CONVF_SINT))
            {
                case (uint)CONVERT_FLAGS.CONVF_FLOAT:
                    return FORMAT_TYPE.FORMAT_TYPE_FLOAT;

                case (uint)CONVERT_FLAGS.CONVF_UNORM:
                    return FORMAT_TYPE.FORMAT_TYPE_UNORM;

                case (uint)CONVERT_FLAGS.CONVF_UINT:
                    return FORMAT_TYPE.FORMAT_TYPE_UINT;

                case (uint)CONVERT_FLAGS.CONVF_SNORM:
                    return FORMAT_TYPE.FORMAT_TYPE_SNORM;

                case (uint)CONVERT_FLAGS.CONVF_SINT:
                    return FORMAT_TYPE.FORMAT_TYPE_SINT;

                default:
                    return FORMAT_TYPE.FORMAT_TYPE_TYPELESS;
            }
        }

        public enum CP_FLAGS : ulong
        {
            CP_FLAGS_NONE = 0x0,      // Normal operation
            CP_FLAGS_LEGACY_DWORD = 0x1,      // Assume pitch is DWORD aligned instead of BYTE aligned
            CP_FLAGS_PARAGRAPH = 0x2,      // Assume pitch is 16-byte aligned instead of BYTE aligned
            CP_FLAGS_YMM = 0x4,      // Assume pitch is 32-byte aligned instead of BYTE aligned
            CP_FLAGS_ZMM = 0x8,      // Assume pitch is 64-byte aligned instead of BYTE aligned
            CP_FLAGS_PAGE4K = 0x200,    // Assume pitch is 4096-byte aligned instead of BYTE aligned
            CP_FLAGS_BAD_DXTN_TAILS = 0x1000,   // BC formats with malformed mipchain blocks smaller than 4x4
            CP_FLAGS_24BPP = 0x10000,  // Override with a legacy 24 bits-per-pixel format size
            CP_FLAGS_16BPP = 0x20000,  // Override with a legacy 16 bits-per-pixel format size
            CP_FLAGS_8BPP = 0x40000,  // Override with a legacy 8 bits-per-pixel format size
        }

        public static CRESULT ComputePitch(DXGI_FORMAT fmt, ulong width, ulong height, out ulong rowPitch, out ulong slicePitch, CP_FLAGS flags = CP_FLAGS.CP_FLAGS_NONE)
        {
            ulong pitch;
            ulong slice;

            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                    {
                        if (TexUtils.FlagNotZero(flags, CP_FLAGS.CP_FLAGS_BAD_DXTN_TAILS))
                        {
                            ulong nbw = width >> 2;
                            ulong nbh = height >> 2;
                            pitch = Math.Max(1U, nbw * 8U);
                            slice = Math.Max(1U, pitch * nbh);
                        }
                        else
                        {
                            ulong nbw = Math.Max(1U, (width + 3U) / 4U);
                            ulong nbh = Math.Max(1U, (height + 3U) / 4U);
                            pitch = nbw * 8U;
                            slice = pitch * nbh;
                        }
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    {
                        if (TexUtils.FlagNotZero(flags, CP_FLAGS.CP_FLAGS_BAD_DXTN_TAILS))
                        {
                            ulong nbw = width >> 2;
                            ulong nbh = height >> 2;
                            pitch = Math.Max(1U, nbw * 16U);
                            slice = Math.Max(1U, pitch * nbh);
                        }
                        else
                        {
                            ulong nbw = Math.Max(1U, (width + 3U) / 4U);
                            ulong nbh = Math.Max(1U, (height + 3U) / 4U);
                            pitch = nbw * 16U;
                            slice = pitch * nbh;
                        }
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_YUY2:
                    {
                        pitch = ((width + 1U) >> 1) * 4U;
                        slice = pitch * height;
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_Y210:
                case DXGI_FORMAT.DXGI_FORMAT_Y216:
                    {
                        pitch = ((width + 1U) >> 1) * 8U;
                        slice = pitch * height;
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_NV12:
                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
                    {
                        pitch = ((width + 1U) >> 1) * 2U;
                        slice = pitch * (height + ((height + 1U) >> 1));
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_P010:
                case DXGI_FORMAT.DXGI_FORMAT_P016:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    {
                        pitch = ((width + 1U) >> 1) * 4U;
                        slice = pitch * (height + ((height + 1U) >> 1));
                    }
                    break;
                case DXGI_FORMAT.DXGI_FORMAT_NV11:
                    {
                        pitch = ((width + 3U) >> 2) * 4U;
                        slice = pitch * height * 2U;
                    }
                    break;
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:
                    {
                        pitch = ((width + 1U) >> 1) * 2U;
                        slice = pitch * height * 2U;
                    }
                    break;
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:
                    {
                        pitch = width;
                        slice = pitch * (height + (((height + 1U) >> 1) * 2U));
                    }
                    break;
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:
                    {
                        pitch = width;
                        slice = pitch * (height + ((height >> 1) * 4U));
                    }
                    break;
                default:
                    {
                        ulong bpp = 0;
                        if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_24BPP))
                            bpp = 24;
                        else if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_16BPP))
                            bpp = 16;
                        else if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_8BPP))
                            bpp = 8;
                        else
                            bpp = BitsPerPixel(fmt);

                        if (bpp == 0)
                        {
                            //Have to asign shit to these value because of fucking out marker
                            rowPitch = ulong.MaxValue;
                            slicePitch = ulong.MaxValue;
                            return CRESULT.INVALIDARG;
                        }
                        if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_LEGACY_DWORD)
                        || TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_PARAGRAPH)
                        || TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_YMM)
                        || TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_ZMM)
                        || TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_PAGE4K))
                        {
                            if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_PAGE4K))
                            {
                                pitch = ((width * bpp + 32767U) / 32768U) * 4096U;
                            }
                            else if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_ZMM))
                            {
                                pitch = ((width * bpp + 511U) / 512U) * 64U;
                            }
                            else if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_YMM))
                            {
                                pitch = ((width * bpp + 255U) / 256U) * 32U;
                            }
                            else if (TexUtils.HasFlag(flags, CP_FLAGS.CP_FLAGS_PARAGRAPH))
                            {
                                pitch = ((width * bpp + 127U) / 128U) * 16U;
                            }
                            else
                            {
                                pitch = ((width * bpp + 31U) / 32U) * sizeof(uint);
                            }
                        }
                        else
                        {
                            pitch = (width * bpp + 7U) / 8U;
                        }
                        slice = pitch * height;
                    }
                    break;

            }

            rowPitch = pitch;
            slicePitch = slice;

            return CRESULT.OK;
        }

        public static ulong ComputeScanlines(DXGI_FORMAT fmt, ulong height)
        {
            switch(fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    return Math.Max(1U, (height * 3U) / 4U);
                case DXGI_FORMAT.DXGI_FORMAT_NV11:
                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_P208:
                    return height * 2;

                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V208:
                    return height + (((height + 1) >> 1) * 2);

                case (DXGI_FORMAT)Defines.WIN10_DXGI_FORMAT_V408:
                    return height + ((height >> 1) * 4);

                case DXGI_FORMAT.DXGI_FORMAT_NV12:
                case DXGI_FORMAT.DXGI_FORMAT_P010:
                case DXGI_FORMAT.DXGI_FORMAT_P016:
                case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_D16_UNORM_S8_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R16_UNORM_X8_TYPELESS:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_X16_TYPELESS_G8_UINT:
                    return height + ((height + 1) >> 1);

                default:
                    return height;
            }
        }

        public static DXGI_FORMAT MakeSRGB(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB;

                default:
                    return fmt;
            }
        }
        public static DXGI_FORMAT MakeTypeless(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_7E3_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_6E4_A2_FLOAT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R10G10B10_SNORM_A2_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R32_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT:
                case DXGI_FORMAT.DXGI_FORMAT_D16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R16_SINT:
                    return DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_UINT:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SNORM:
                case DXGI_FORMAT.DXGI_FORMAT_R8_SINT:
                case (DXGI_FORMAT)Defines.XBOX_DXGI_FORMAT_R4G4_UNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM:
                    return DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16:
                case DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16:
                    return DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB:
                    return DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS;

                default:
                    return fmt;
            }
        }
        public static DXGI_FORMAT MakeTypelessUNORM(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R8_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM;

                default:
                    return fmt;
            }
        }
        public static DXGI_FORMAT MakeTypelessFLOAT(DXGI_FORMAT fmt)
        {
            switch (fmt)
            {
                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT;

                case DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS:
                    return DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT;

                default:
                    return fmt;
            }
        }

        public enum TEX_DIMENSION
        {
            TEX_DIMENSION_TEXTURE1D = 2,
            TEX_DIMENSION_TEXTURE2D = 3,
            TEX_DIMENSION_TEXTURE3D = 4,
        }

        public enum TEX_MISC_FLAG : ulong
        // Subset here matches D3D10_RESOURCE_MISC_FLAG and D3D11_RESOURCE_MISC_FLAG
        {
            TEX_MISC_TEXTURECUBE = 0x4L,
        };

        public enum TEX_MISC_FLAG2 : ulong
        {
            TEX_MISC2_ALPHA_MODE_MASK = 0x7L,
        };

        public enum TEX_ALPHA_MODE
        // Matches DDS_ALPHA_MODE, encoded in MISC_FLAGS2
        {
            TEX_ALPHA_MODE_UNKNOWN = 0,
            TEX_ALPHA_MODE_STRAIGHT = 1,
            TEX_ALPHA_MODE_PREMULTIPLIED = 2,
            TEX_ALPHA_MODE_OPAQUE = 3,
            TEX_ALPHA_MODE_CUSTOM = 4,
        };

        public struct TexMetadata
        {
            public ulong width;
            public ulong height;
            public ulong depth;
            public ulong arraySize;
            public ulong mipLevels;
            public ulong miscFlags;
            public ulong miscFlags2;
            public DXGI_FORMAT format;
            public TEX_DIMENSION dimension;

            public ulong ComputeIndex(ulong mip, ulong item, ulong slice)
            {
                if (mip >= mipLevels)
                    return ulong.MaxValue;

                switch(dimension)
                {
                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE1D:
                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE2D:
                        if (slice > 0)
                            return ulong.MaxValue;
                        if (item >= arraySize)
                            return ulong.MaxValue;
                        return (item * mipLevels + mip);

                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE3D:
                        if (item > 0)
                            return ulong.MaxValue;
                        else
                        {
                            ulong index = 0;
                            ulong d = depth;

                            for(ulong level = 0;level < mip;++level)
                            {
                                index += d;
                                if (d > 1)
                                    d >>= 1;
                            }
                            if (slice >= d)
                                return ulong.MaxValue;

                            index += slice;

                            return index;
                        }
                    default:
                        return ulong.MaxValue;
                }
            }

            public bool IsCubemap()
            {
                return TexUtils.HasFlag(miscFlags, (ulong)TEX_MISC_FLAG.TEX_MISC_TEXTURECUBE);
            }

            public bool IsPMAlpha()
            {
                return (miscFlags2 & (ulong)TEX_MISC_FLAG2.TEX_MISC2_ALPHA_MODE_MASK) == (ulong)TEX_ALPHA_MODE.TEX_ALPHA_MODE_PREMULTIPLIED;
            }

            public void SetAlphaMode(TEX_ALPHA_MODE mode)
            {
                miscFlags2 &= ~(ulong)TEX_MISC_FLAG2.TEX_MISC2_ALPHA_MODE_MASK;
                miscFlags2 |= (ulong)mode;
            }

            public bool IsVolumemap()
            {
                return dimension == TEX_DIMENSION.TEX_DIMENSION_TEXTURE3D;
            }
        }

        public enum DDS_FLAGS : ulong
        {
            DDS_FLAGS_NONE                  = 0x0,

            DDS_FLAGS_LEGACY_DWORD          = 0x1,
                // Assume pitch is DWORD aligned instead of BYTE aligned (used by some legacy DDS files)

            DDS_FLAGS_NO_LEGACY_EXPANSION   = 0x2,
                // Do not implicitly convert legacy formats that result in larger pixel sizes (24 bpp, 3:3:2, A8L8, A4L4, P8, A8P8)

            DDS_FLAGS_NO_R10B10G10A2_FIXUP  = 0x4,
                // Do not use work-around for long-standing D3DX DDS file format issue which reversed the 10:10:10:2 color order masks

            DDS_FLAGS_FORCE_RGB             = 0x8,
                // Convert DXGI 1.1 BGR formats to DXGI_FORMAT_R8G8B8A8_UNORM to avoid use of optional WDDM 1.1 formats

            DDS_FLAGS_NO_16BPP              = 0x10,
                // Conversions avoid use of 565, 5551, and 4444 formats and instead expand to 8888 to avoid use of optional WDDM 1.2 formats

            DDS_FLAGS_EXPAND_LUMINANCE      = 0x20,
                // When loading legacy luminance formats expand replicating the color channels rather than leaving them packed (L8, L16, A8L8)

            DDS_FLAGS_BAD_DXTN_TAILS        = 0x40,
                // Some older DXTn DDS files incorrectly handle mipchain tails for blocks smaller than 4x4

            DDS_FLAGS_FORCE_DX10_EXT        = 0x10000,
                // Always use the 'DX10' header extension for DDS writer (i.e. don't try to write DX9 compatible DDS files)

            DDS_FLAGS_FORCE_DX10_EXT_MISC2  = 0x20000,
                // DDS_FLAGS_FORCE_DX10_EXT including miscFlags2 information (result may not be compatible with D3DX10 or D3DX11)

            DDS_FLAGS_FORCE_DX9_LEGACY      = 0x40000,
                // Force use of legacy header for DDS writer (will fail if unable to write as such)

            DDS_FLAGS_ALLOW_LARGE_FILES     = 0x1000000,
                // Enables the loader to read large dimension .dds files (i.e. greater than known hardware requirements)
        };

        public enum TGA_FLAGS : ulong
        {
            TGA_FLAGS_NONE                 = 0x0,

            TGA_FLAGS_BGR                  = 0x1,
                // 24bpp files are returned as BGRX; 32bpp files are returned as BGRA

            TGA_FLAGS_ALLOW_ALL_ZERO_ALPHA = 0x2,
                // If the loaded image has an all zero alpha channel, normally we assume it should be opaque. This flag leaves it alone.

            TGA_FLAGS_IGNORE_SRGB          = 0x10,
                // Ignores sRGB TGA 2.0 metadata if present in the file

            TGA_FLAGS_FORCE_SRGB           = 0x20,
                // Writes sRGB metadata into the file reguardless of format (TGA 2.0 only)

            TGA_FLAGS_FORCE_LINEAR         = 0x40,
                // Writes linear gamma metadata into the file reguardless of format (TGA 2.0 only)

            TGA_FLAGS_DEFAULT_SRGB         = 0x80,
                // If no colorspace is specified in TGA 2.0 metadata, assume sRGB
        };

        public enum WIC_FLAGS : ulong
        {
            WIC_FLAGS_NONE = 0x0,

            WIC_FLAGS_FORCE_RGB = 0x1,
                // Loads DXGI 1.1 BGR formats as DXGI_FORMAT_R8G8B8A8_UNORM to avoid use of optional WDDM 1.1 formats

            WIC_FLAGS_NO_X2_BIAS = 0x2,
                // Loads DXGI 1.1 X2 10:10:10:2 format as DXGI_FORMAT_R10G10B10A2_UNORM

            WIC_FLAGS_NO_16BPP = 0x4,
                // Loads 565, 5551, and 4444 formats as 8888 to avoid use of optional WDDM 1.2 formats

            WIC_FLAGS_ALLOW_MONO = 0x8,
                // Loads 1-bit monochrome (black & white) as R1_UNORM rather than 8-bit grayscale

            WIC_FLAGS_ALL_FRAMES = 0x10,
                // Loads all images in a multi-frame file, converting/resizing to match the first frame as needed, defaults to 0th frame otherwise

            WIC_FLAGS_IGNORE_SRGB = 0x20,
                // Ignores sRGB metadata if present in the file

            WIC_FLAGS_FORCE_SRGB = 0x40,
                // Writes sRGB metadata into the file reguardless of format

            WIC_FLAGS_FORCE_LINEAR = 0x80,
                // Writes linear gamma metadata into the file reguardless of format

            WIC_FLAGS_DEFAULT_SRGB = 0x100,
                // If no colorspace is specified, assume sRGB

            WIC_FLAGS_DITHER = 0x10000,
                // Use ordered 4x4 dithering for any required conversions

            WIC_FLAGS_DITHER_DIFFUSION = 0x20000,
                // Use error-diffusion dithering for any required conversions

            WIC_FLAGS_FILTER_POINT = 0x100000,
            WIC_FLAGS_FILTER_LINEAR = 0x200000,
            WIC_FLAGS_FILTER_CUBIC = 0x300000,
            WIC_FLAGS_FILTER_FANT = 0x400000, // Combination of Linear and Box filter
                // Filtering mode to use for any required image resizing (only needed when loading arrays of differently sized images; defaults to Fant)
        };
    }

}
