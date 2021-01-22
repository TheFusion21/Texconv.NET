using System;
using System.Collections.Generic;
using System.IO;
using static TexconvNET.DirectX;

namespace TexconvNET
{
    public enum OPTIONS
    {
        OPT_RECURSIVE = 1,
        OPT_FILELIST,
        OPT_WIDTH,
        OPT_HEIGHT,
        OPT_MIPLEVELS,
        OPT_FORMAT,
        OPT_FILTER,
        OPT_SRGBI,
        OPT_SRGBO,
        OPT_SRGB,
        //OPT_PREFIX,
        //OPT_SUFFIX,
        //OPT_OUTPUTDIR,
        OPT_TOLOWER,
        OPT_OVERWRITE,
        OPT_FILETYPE,
        OPT_HFLIP,
        OPT_VFLIP,
        OPT_DDS_DWORD_ALIGN,
        OPT_DDS_BAD_DXTN_TAILS,
        //OPT_USE_DX10,
        //OPT_USE_DX9,
        OPT_TGA20,
        OPT_WIC_QUALITY,
        OPT_WIC_LOSSLESS,
        OPT_WIC_MULTIFRAME,
        //OPT_NOLOGO,
        OPT_TIMING,
        OPT_SEPALPHA,
        OPT_NO_WIC,
        OPT_TYPELESS_UNORM,
        OPT_TYPELESS_FLOAT,
        OPT_PREMUL_ALPHA,
        OPT_DEMUL_ALPHA,
        OPT_EXPAND_LUMINANCE,
        OPT_TA_WRAP,
        OPT_TA_MIRROR,
        OPT_FORCE_SINGLEPROC,
        //OPT_GPU,
        //OPT_NOGPU,
        //OPT_FEATURE_LEVEL,
        OPT_FIT_POWEROF2,
        OPT_ALPHA_THRESHOLD,
        OPT_ALPHA_WEIGHT,
        OPT_NORMAL_MAP,
        OPT_NORMAL_MAP_AMPLITUDE,
        OPT_BC_COMPRESS,
        OPT_COLORKEY,
        OPT_TONEMAP,
        OPT_X2_BIAS,
        OPT_PRESERVE_ALPHA_COVERAGE,
        OPT_INVERT_Y,
        OPT_RECONSTRUCT_Z,
        OPT_ROTATE_COLOR,
        OPT_PAPER_WHITE_NITS,
        OPT_BCNONMULT4FIX,
        OPT_SWIZZLE,
        OPT_MAX
    }

    public static partial class Texconv
    {
        private enum ROTATE
        {
            ROTATE_709_TO_HDR10 = 1,
            ROTATE_HDR10_TO_709,
            ROTATE_709_TO_2020,
            ROTATE_2020_TO_709,
            ROTATE_P3_TO_HDR10,
            ROTATE_P3_TO_2020,
        };

        private struct SValue
        {
            public string name;
            public ulong value;
        }

        private static SValue DEFFMT(string fmtname)
        {
            SValue v = new SValue();
            v.name = fmtname;
            v.value = (ulong)Enum.Parse(typeof(DXGI_FORMAT), "DXGI_FORMAT_" + fmtname, true);
            return v;
        }

        private static readonly SValue[] pFormats =
        {
            DEFFMT("R32G32B32A32_FLOAT"),
            DEFFMT("R32G32B32A32_UINT"),
            DEFFMT("R32G32B32A32_SINT"),
            DEFFMT("R32G32B32_FLOAT"),
            DEFFMT("R32G32B32_UINT"),
            DEFFMT("R32G32B32_SINT"),
            DEFFMT("R16G16B16A16_FLOAT"),
            DEFFMT("R16G16B16A16_UNORM"),
            DEFFMT("R16G16B16A16_UINT"),
            DEFFMT("R16G16B16A16_SNORM"),
            DEFFMT("R16G16B16A16_SINT"),
            DEFFMT("R32G32_FLOAT"),
            DEFFMT("R32G32_UINT"),
            DEFFMT("R32G32_SINT"),
            DEFFMT("R10G10B10A2_UNORM"),
            DEFFMT("R10G10B10A2_UINT"),
            DEFFMT("R11G11B10_FLOAT"),
            DEFFMT("R8G8B8A8_UNORM"),
            DEFFMT("R8G8B8A8_UNORM_SRGB"),
            DEFFMT("R8G8B8A8_UINT"),
            DEFFMT("R8G8B8A8_SNORM"),
            DEFFMT("R8G8B8A8_SINT"),
            DEFFMT("R16G16_FLOAT"),
            DEFFMT("R16G16_UNORM"),
            DEFFMT("R16G16_UINT"),
            DEFFMT("R16G16_SNORM"),
            DEFFMT("R16G16_SINT"),
            DEFFMT("R32_FLOAT"),
            DEFFMT("R32_UINT"),
            DEFFMT("R32_SINT"),
            DEFFMT("R8G8_UNORM"),
            DEFFMT("R8G8_UINT"),
            DEFFMT("R8G8_SNORM"),
            DEFFMT("R8G8_SINT"),
            DEFFMT("R16_FLOAT"),
            DEFFMT("R16_UNORM"),
            DEFFMT("R16_UINT"),
            DEFFMT("R16_SNORM"),
            DEFFMT("R16_SINT"),
            DEFFMT("R8_UNORM"),
            DEFFMT("R8_UINT"),
            DEFFMT("R8_SNORM"),
            DEFFMT("R8_SINT"),
            DEFFMT("A8_UNORM"),
            DEFFMT("R9G9B9E5_SHAREDEXP"),
            DEFFMT("R8G8_B8G8_UNORM"),
            DEFFMT("G8R8_G8B8_UNORM"),
            DEFFMT("BC1_UNORM"),
            DEFFMT("BC1_UNORM_SRGB"),
            DEFFMT("BC2_UNORM"),
            DEFFMT("BC2_UNORM_SRGB"),
            DEFFMT("BC3_UNORM"),
            DEFFMT("BC3_UNORM_SRGB"),
            DEFFMT("BC4_UNORM"),
            DEFFMT("BC4_SNORM"),
            DEFFMT("BC5_UNORM"),
            DEFFMT("BC5_SNORM"),
            DEFFMT("B5G6R5_UNORM"),
            DEFFMT("B5G5R5A1_UNORM"),

            // DXGI 1.1 formats
            DEFFMT("B8G8R8A8_UNORM"),
            DEFFMT("B8G8R8X8_UNORM"),
            DEFFMT("R10G10B10_XR_BIAS_A2_UNORM"),
            DEFFMT("B8G8R8A8_UNORM_SRGB"),
            DEFFMT("B8G8R8X8_UNORM_SRGB"),
            DEFFMT("BC6H_UF16"),
            DEFFMT("BC6H_SF16"),
            DEFFMT("BC7_UNORM"),
            DEFFMT("BC7_UNORM_SRGB"),

            // DXGI 1.2 formats
            DEFFMT("AYUV"),
            DEFFMT("Y410"),
            DEFFMT("Y416"),
            DEFFMT("YUY2"),
            DEFFMT("Y210"),
            DEFFMT("Y216"),
            // No support for legacy paletted video formats (AI44, IA44, P8, A8P8)
            DEFFMT("B4G4R4A4_UNORM"),

            new SValue{name = null, value = (ulong)DXGI_FORMAT.DXGI_FORMAT_UNKNOWN }
        };

        private static readonly SValue[] pFormatAliases =
        {
            new SValue{ name = "DXT1", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM },
            new SValue{ name = "DXT2", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM },
            new SValue{ name = "DXT3", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM },
            new SValue{ name = "DXT4", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM },
            new SValue{ name = "DXT5", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM },

            new SValue{ name = "RGBA", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM },
            new SValue{ name = "BGRA", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM },

            new SValue{ name = "FP16", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT },
            new SValue{ name = "FP32", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT },

            new SValue{ name = "BPTC", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM },
            new SValue{ name = "BPTC_FLOAT", value = (ulong)DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16 },

            new SValue{ name = null, value = (ulong)DXGI_FORMAT.DXGI_FORMAT_UNKNOWN }
        };

        private static readonly SValue[] pReadOnlyFormats =
        {
            DEFFMT("R32G32B32A32_TYPELESS"),
            DEFFMT("R32G32B32_TYPELESS"),
            DEFFMT("R16G16B16A16_TYPELESS"),
            DEFFMT("R32G32_TYPELESS"),
            DEFFMT("R32G8X24_TYPELESS"),
            DEFFMT("D32_FLOAT_S8X24_UINT"),
            DEFFMT("R32_FLOAT_X8X24_TYPELESS"),
            DEFFMT("X32_TYPELESS_G8X24_UINT"),
            DEFFMT("R10G10B10A2_TYPELESS"),
            DEFFMT("R8G8B8A8_TYPELESS"),
            DEFFMT("R16G16_TYPELESS"),
            DEFFMT("R32_TYPELESS"),
            DEFFMT("D32_FLOAT"),
            DEFFMT("R24G8_TYPELESS"),
            DEFFMT("D24_UNORM_S8_UINT"),
            DEFFMT("R24_UNORM_X8_TYPELESS"),
            DEFFMT("X24_TYPELESS_G8_UINT"),
            DEFFMT("R8G8_TYPELESS"),
            DEFFMT("R16_TYPELESS"),
            DEFFMT("R8_TYPELESS"),
            DEFFMT("BC1_TYPELESS"),
            DEFFMT("BC2_TYPELESS"),
            DEFFMT("BC3_TYPELESS"),
            DEFFMT("BC4_TYPELESS"),
            DEFFMT("BC5_TYPELESS"),
            
            // DXGI 1.1 formats
            DEFFMT("B8G8R8A8_TYPELESS"),
            DEFFMT("B8G8R8X8_TYPELESS"),
            DEFFMT("BC6H_TYPELESS"),
            DEFFMT("BC7_TYPELESS"),
            
            // DXGI 1.2 formats
            DEFFMT("NV12"),
            DEFFMT("P010"),
            DEFFMT("P016"),
            DEFFMT("420_OPAQUE"),
            DEFFMT("NV11"),
            
            // DXGI 1.3 formats
            new SValue{ name = "P208", value = 130 },
            new SValue{ name = "V208", value = 131 },
            new SValue{ name = "V408", value = 132 },

            new SValue{name = null, value = (ulong)DXGI_FORMAT.DXGI_FORMAT_UNKNOWN }
        };

        private static readonly SValue[] pFilters =
        {
            new SValue{ name = "POINT",                     value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_POINT },
            new SValue{ name = "LINEAR",                    value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_LINEAR },
            new SValue{ name = "CUBIC",                     value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_CUBIC },
            new SValue{ name = "FANT",                      value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_FANT },
            new SValue{ name = "BOX",                       value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_BOX },
            new SValue{ name = "TRIANGLE",                  value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_TRIANGLE },
            new SValue{ name = "POINT_DITHER",              value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_POINT | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "LINEAR_DITHER",             value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_LINEAR | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "CUBIC_DITHER",              value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_CUBIC | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "FANT_DITHER",               value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_FANT | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "BOX_DITHER",                value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_BOX | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "TRIANGLE_DITHER",           value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_TRIANGLE | TEX_FILTER_FLAGS.TEX_FILTER_DITHER) },
            new SValue{ name = "POINT_DITHER_DIFFUSION",    value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_POINT | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = "LINEAR_DITHER_DIFFUSION",   value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_LINEAR | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = "CUBIC_DITHER_DIFFUSION",    value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_CUBIC | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = "FANT_DITHER_DIFFUSION",     value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_FANT | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = "BOX_DITHER_DIFFUSION",      value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_BOX | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = "TRIANGLE_DITHER_DIFFUSION", value = (ulong)(TEX_FILTER_FLAGS.TEX_FILTER_TRIANGLE | TEX_FILTER_FLAGS.TEX_FILTER_DITHER_DIFFUSION) },
            new SValue{ name = null,                        value = (ulong)TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT}
        };

        private static readonly SValue[] pRotateColor =
        {
            new SValue{name = "709to2020", value = (ulong)ROTATE.ROTATE_709_TO_2020 },
            new SValue{name = "2020to709", value = (ulong)ROTATE.ROTATE_2020_TO_709 },
            new SValue{name = "709toHDR10", value = (ulong)ROTATE.ROTATE_709_TO_HDR10 },
            new SValue{name = "HDR10to709", value = (ulong)ROTATE.ROTATE_HDR10_TO_709 },
            new SValue{name = "P3to2020", value = (ulong)ROTATE.ROTATE_P3_TO_2020 },
            new SValue{name = "P3toHDR10", value = (ulong)ROTATE.ROTATE_P3_TO_HDR10 },
            new SValue{name = null, value = 0 },
        };

        private const ulong CODEC_DDS = 0xFFFF0001;
        private const ulong CODEC_TGA = 0xFFFF0002;
        private const ulong CODEC_HDP = 0xFFFF0003;
        private const ulong CODEC_JXR = 0xFFFF0004;
        private const ulong CODEC_HDR = 0xFFFF0005;
        private const ulong CODEC_PPM = 0xFFFF0006;
        private const ulong CODEC_PFM = 0xFFFF0007;
        private const ulong CODEC_EXR = 0xFFFF0008;

        private static readonly SValue[] pSaveFileTypes =   // valid formats to write to
        {
            new SValue{ name = "BMP",   value = (ulong)WICCodecs.WIC_CODEC_BMP  },
            new SValue{ name = "JPG",   value = (ulong)WICCodecs.WIC_CODEC_JPEG },
            new SValue{ name = "JPEG",  value = (ulong)WICCodecs.WIC_CODEC_JPEG },
            new SValue{ name = "PNG",   value = (ulong)WICCodecs.WIC_CODEC_PNG  },
            new SValue{ name = "DDS",   value = CODEC_DDS      },
            new SValue{ name = "TGA",   value = CODEC_TGA      },
            new SValue{ name = "HDR",   value = CODEC_HDR      },
            new SValue{ name = "TIF",   value = (ulong)WICCodecs.WIC_CODEC_TIFF },
            new SValue{ name = "TIFF",  value = (ulong)WICCodecs.WIC_CODEC_TIFF },
            new SValue{ name = "WDP",   value = (ulong)WICCodecs.WIC_CODEC_WMP  },
            new SValue{ name = "HDP",   value = CODEC_HDP      },
            new SValue{ name = "JXR",   value = CODEC_JXR      },
            new SValue{ name = "PPM",   value = CODEC_PPM      },
            new SValue{ name = "PFM",   value = CODEC_PFM      },
            new SValue{ name = "EXR",   value = CODEC_EXR      },
            new SValue{ name = null,    value = CODEC_DDS      }
        };

        private static readonly SValue[] pFeatureLevels =
        {
            new SValue{ name = "9.1",  value = 2048 },
            new SValue{ name = "9.2",  value = 2048 },
            new SValue{ name = "9.3",  value = 4096 },
            new SValue{ name = "10.0", value = 8192 },
            new SValue{ name = "10.1", value = 8192 },
            new SValue{ name = "11.0", value = 16384 },
            new SValue{ name = "11.1", value = 16384 },
            new SValue{ name = "12.0", value = 16384 },
            new SValue{ name = "12.1", value = 16384 },
            new SValue{ name = null, value = 0 },
        };

        

        public struct OPTION
        {
            public OPTIONS option;
            public string value;
        }
        public static ScratchImage LoadFromFile(string pathToFile, List<OPTION> options)
        {
            FileInfo fInfo = new FileInfo(pathToFile);
            if (!fInfo.Exists)
                return null;
            ulong width = 0;
            ulong height = 0;
            ulong mipLevels = 0;
            DXGI_FORMAT format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
            TEX_FILTER_FLAGS dwFilter = TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT;
            TEX_FILTER_FLAGS dwSRGB = TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT;
            TEX_FILTER_FLAGS dwConvert = TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT;
            TEX_COMPRESS_FLAGS dwCompress = TEX_COMPRESS_FLAGS.TEX_COMPRESS_DEFAULT;
            TEX_FILTER_FLAGS dwFilterOpts = TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT;
            ulong fileType = CODEC_DDS;
            float alphaThreshold = TEX_THRESHOLD_DEFAULT;
            float alphaWeight = 1.0f;
            CNMAP_FLAGS dwNormalMap = CNMAP_FLAGS.CNMAP_DEFAULT;
            float nmapAmplitude = 1.0f;
            float wicQuality = -1.0f;
            ulong colorKey = 0;
            ulong dwRotateColor = 0;
            float paperWhiteNits = 200.0f;
            float preserveAlphaCoverageRef = 0.0f;
            uint[] swizzleElements = { 0, 1, 2, 3 };

            ulong dwOptions = 0;
            foreach(OPTION opt in options)
            {
                switch(opt.option)
                {
                    case OPTIONS.OPT_WIDTH:
                        {
                            if (!ulong.TryParse(opt.value, out width))
                                return null;
                        }
                        break;
                    case OPTIONS.OPT_HEIGHT:
                        {
                            if (!ulong.TryParse(opt.value, out height))
                                return null;
                        }
                        break;
                    case OPTIONS.OPT_MIPLEVELS:
                        {
                            if (!ulong.TryParse(opt.value, out mipLevels))
                                return null;
                        }
                        break;
                    case OPTIONS.OPT_FORMAT:
                        {
                            format = (DXGI_FORMAT)LookupByName(opt.value, pFormats);
                            if(format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN)
                            {
                                format = (DXGI_FORMAT)LookupByName(opt.value, pFormatAliases);
                                if (format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN)
                                    return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_FILTER:
                        {
                            dwFilter = (TEX_FILTER_FLAGS)LookupByName(opt.value, pFilters);
                            if (dwFilter == TEX_FILTER_FLAGS.TEX_FILTER_DEFAULT)
                                return null;
                        }
                        break;
                    case OPTIONS.OPT_ROTATE_COLOR:
                        {
                            dwRotateColor = LookupByName(opt.value, pRotateColor);
                            if (dwRotateColor == 0)
                                return null;
                        }
                        break;
                    case OPTIONS.OPT_SRGBI:
                         dwSRGB |= TEX_FILTER_FLAGS.TEX_FILTER_SRGB_IN;
                        break;
                    case OPTIONS.OPT_SRGBO:
                        dwSRGB |= TEX_FILTER_FLAGS.TEX_FILTER_SRGB_OUT;
                        break;
                    case OPTIONS.OPT_SRGB:
                        dwSRGB |= TEX_FILTER_FLAGS.TEX_FILTER_SRGB;
                        break;
                    case OPTIONS.OPT_SEPALPHA:
                        dwFilterOpts |= TEX_FILTER_FLAGS.TEX_FILTER_SEPARATE_ALPHA;
                        break;
                    case OPTIONS.OPT_NO_WIC:
                        dwFilterOpts |= TEX_FILTER_FLAGS.TEX_FILTER_FORCE_NON_WIC;
                        break;
                    //case OPTIONS.OPT_FILETYPE:
                    //    {
                    //        fileType = LookupByName(opt.value, pSaveFileTypes);
                    //        if (fileType == 0)
                    //            return null;
                    //    }
                    //    break;
                    case OPTIONS.OPT_PREMUL_ALPHA:
                        {
                            if (TexUtils.HasFlag(dwOptions,1UL << (int)OPTIONS.OPT_DEMUL_ALPHA))
                            {
                                return null;
                            }
                            //dwOptions |= (1UL << (int)OPTIONS.OPT_PREMUL_ALPHA);
                        }
                        break;
                    case OPTIONS.OPT_DEMUL_ALPHA:
                        {
                            if (TexUtils.HasFlag(dwOptions, 1UL << (int)OPTIONS.OPT_PREMUL_ALPHA))
                            {
                                return null;
                            }
                            //dwOptions |= (1UL << (int)OPTIONS.OPT_DEMUL_ALPHA);
                        }
                        break;
                    case OPTIONS.OPT_TA_WRAP:
                        {
                            if(TexUtils.HasFlag(dwFilterOpts, TEX_FILTER_FLAGS.TEX_FILTER_MIRROR))
                            {
                                return null;
                            }
                            dwFilterOpts |= TEX_FILTER_FLAGS.TEX_FILTER_WRAP;
                        }
                        break;
                    case OPTIONS.OPT_TA_MIRROR:
                        {
                            if(TexUtils.HasFlag(dwFilterOpts, TEX_FILTER_FLAGS.TEX_FILTER_WRAP))
                            {
                                return null;
                            }
                            dwFilterOpts |= TEX_FILTER_FLAGS.TEX_FILTER_MIRROR;
                        }
                        break;
                    case OPTIONS.OPT_NORMAL_MAP:
                        {
                            dwNormalMap = CNMAP_FLAGS.CNMAP_DEFAULT;

                            if (opt.value.Contains('l'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_CHANNEL_LUMINANCE;
                            }
                            else if (opt.value.Contains('r'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_CHANNEL_RED;
                            }
                            else if (opt.value.Contains('g'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_CHANNEL_GREEN;
                            }
                            else if (opt.value.Contains('b'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_CHANNEL_BLUE;
                            }
                            else if (opt.value.Contains('a'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_CHANNEL_ALPHA;
                            }
                            else
                            {
                                return null;
                            }

                            if(opt.value.Contains('m'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_MIRROR;
                            }
                            else
                            {
                                if(opt.value.Contains('u'))
                                {
                                    dwNormalMap |= CNMAP_FLAGS.CNMAP_MIRROR_U;
                                }
                                if(opt.value.Contains('v'))
                                {
                                    dwNormalMap |= CNMAP_FLAGS.CNMAP_MIRROR_V;
                                }
                            }

                            if(opt.value.Contains('i'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_INVERT_SIGN;
                            }
                            if(opt.value.Contains('o'))
                            {
                                dwNormalMap |= CNMAP_FLAGS.CNMAP_COMPUTE_OCCLUSION;
                            }
                        }
                        break;
                    case OPTIONS.OPT_NORMAL_MAP_AMPLITUDE:
                        {
                            if(dwNormalMap == 0)
                            {
                                return null;
                            }
                            else if(!float.TryParse(opt.value, out nmapAmplitude))
                            {
                                return null;
                            }
                            else if(nmapAmplitude < 0.0f)
                            {
                                return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_ALPHA_THRESHOLD:
                        {
                            if(!float.TryParse(opt.value, out alphaThreshold))
                            {
                                return null;
                            }
                            else if(alphaThreshold < 0.0f)
                            {
                                return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_ALPHA_WEIGHT:
                        {
                            if(!float.TryParse(opt.value, out alphaWeight))
                            {
                                return null;
                            }
                            else if(alphaWeight < 0.0f)
                            {
                                return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_BC_COMPRESS:
                        {
                            dwCompress = TEX_COMPRESS_FLAGS.TEX_COMPRESS_DEFAULT;

                            bool found = false;
                            if(opt.value.Contains('u'))
                            {
                                dwCompress |= TEX_COMPRESS_FLAGS.TEX_COMPRESS_UNIFORM;
                                found = true;
                            }
                            if (opt.value.Contains('d'))
                            {
                                dwCompress |= TEX_COMPRESS_FLAGS.TEX_COMPRESS_DITHER;
                                found = true;
                            }
                            if (opt.value.Contains('q'))
                            {
                                dwCompress |= TEX_COMPRESS_FLAGS.TEX_COMPRESS_BC7_QUICK;
                                found = true;
                            }
                            if (opt.value.Contains('x'))
                            {
                                dwCompress |= TEX_COMPRESS_FLAGS.TEX_COMPRESS_BC7_USE_3SUBSETS;
                                found = true;
                            }

                            if(TexUtils.HasFlag(dwCompress, TEX_COMPRESS_FLAGS.TEX_COMPRESS_BC7_USE_3SUBSETS | TEX_COMPRESS_FLAGS.TEX_COMPRESS_BC7_QUICK))
                            {
                                return null;
                            }

                            if(!found)
                            {
                                return null;
                            }

                        }
                        break;
                    case OPTIONS.OPT_WIC_QUALITY:
                        {
                            if(!float.TryParse(opt.value, out wicQuality))
                            {
                                return null;
                            }
                            else if(wicQuality < 0.0f || wicQuality > 1.0f)
                            {
                                return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_COLORKEY:
                        {
                            if(!ulong.TryParse(opt.value, out colorKey))
                            {
                                if (!ulong.TryParse(opt.value, System.Globalization.NumberStyles.HexNumber, null, out colorKey))
                                {
                                    return null;
                                }
                                
                            }
                            colorKey &= 0xFFFFFF;
                        }
                        break;
                    case OPTIONS.OPT_X2_BIAS:
                        dwConvert |= TEX_FILTER_FLAGS.TEX_FILTER_FLOAT_X2BIAS;
                        break;
                    case OPTIONS.OPT_PAPER_WHITE_NITS:
                        {
                            if(!float.TryParse(opt.value, out paperWhiteNits))
                            {
                                return null;
                            }
                            else if(paperWhiteNits > 10000.0f || paperWhiteNits <= 0.0f)
                            {
                                return null;
                            }
                        }
                        break;
                    case OPTIONS.OPT_PRESERVE_ALPHA_COVERAGE:
                        {
                            if(float.TryParse(opt.value, out preserveAlphaCoverageRef))
                            {
                                return null;
                            }
                            else if(preserveAlphaCoverageRef < 0.0f || preserveAlphaCoverageRef > 1.0f)
                            {
                                return null;
                            }

                        }
                        break;
                    case OPTIONS.OPT_SWIZZLE:
                        {
                            if(opt.value == null || opt.value.Length > 4)
                            {
                                return null;
                            }
                            else if(!ParseSwizzleMask(opt.value, out swizzleElements))
                            {
                                return null;
                            }
                        }
                        break;
                }
            }

            var fileTypeName = LookupByValue(fileType, pSaveFileTypes);

            if (fileType != CODEC_DDS)
                mipLevels = 1;

            var ext = Path.GetExtension(fInfo.FullName).ToLower();

            TexMetadata info = new TexMetadata();
            ScratchImage image;
            if (ext == ".dds")
            {
                DDS_FLAGS ddsFlags = DDS_FLAGS.DDS_FLAGS_ALLOW_LARGE_FILES;
                if (TexUtils.HasFlag(dwOptions, 1U << (int)OPTIONS.OPT_DDS_DWORD_ALIGN))
                {
                    ddsFlags |= DDS_FLAGS.DDS_FLAGS_LEGACY_DWORD;
                }
                if (TexUtils.HasFlag(dwOptions, 1U << (int)OPTIONS.OPT_EXPAND_LUMINANCE))
                {
                    ddsFlags |= DDS_FLAGS.DDS_FLAGS_EXPAND_LUMINANCE;
                }
                if (TexUtils.HasFlag(dwOptions, 1U << (int)OPTIONS.OPT_DDS_BAD_DXTN_TAILS))
                {
                    ddsFlags |= DDS_FLAGS.DDS_FLAGS_BAD_DXTN_TAILS;
                }

                image = LoadFromDDSFile(pathToFile, ddsFlags, ref info);

                if (image == null)
                    return null;

                if(IsTypeless(info.format))
                {
                    if(TexUtils.HasFlag(dwOptions, 1U << (int)OPTIONS.OPT_TYPELESS_UNORM))
                    {
                        info.format = MakeTypelessUNORM(info.format);
                    }
                    else if (TexUtils.HasFlag(dwOptions, 1U << (int)OPTIONS.OPT_TYPELESS_FLOAT))
                    {
                        info.format = MakeTypelessFLOAT(info.format);
                    }

                    if(IsTypeless(info.format))
                    {
                        return null;
                    }

                    image.OverrideFormat(info.format);
                }
            }
            else if (ext == ".bmp")
            {
                image = LoadFromBMPEx(pathToFile, WIC_FLAGS.WIC_FLAGS_NONE | (WIC_FLAGS)dwFilter, ref info);

                if (image == null)
                    return null;
            }
            else if (ext == ".tga")
            {
                image = LoadFromTGAFile(pathToFile, TGA_FLAGS.TGA_FLAGS_NONE, ref info);
                if (image == null)
                    return null;
            }
            else if (ext == ".hdr")
            {
                image = LoadFromHDRFile(pathToFile, ref info);
                if(image == null)
                    return null;
            }
            else if (ext == ".ppm")
            {
                image = LoadFromPortablePixMap(pathToFile, ref info);
                if(image == null)
                    return null;
            }
            else if (ext == ".pfm")
            {
                image = LoadFromPortablePixMapHDR(pathToFile, ref info);
                if (image == null)
                    return null;
            }
            else if (ext == ".exr")
            {
                image = LoadFromEXRFile(pathToFile, ref info);
                if (image == null)
                    return null;
            }
            else
            {
                WIC_FLAGS wicFlags = WIC_FLAGS.WIC_FLAGS_NONE | (WIC_FLAGS)dwFilter;
                if (fileType == CODEC_DDS)
                    wicFlags |= WIC_FLAGS.WIC_FLAGS_ALL_FRAMES;

                image = LoadFromWICFile(pathToFile, ref info);
                if (image == null)
                    return null;
            }

            return null;
        }

        private static ulong LookupByName(string name, SValue[] pArray)
        {
            foreach(var p in pArray)
            {
                if (string.Equals(p.name, name, StringComparison.OrdinalIgnoreCase))
                    return p.value;
            }
            return 0;
        }

        private static string LookupByValue(ulong value, SValue[] pArray)
        {
            foreach (var p in pArray)
            {
                if (value == p.value)
                    return p.name;
            }
            return null;
        }

        private static bool ParseSwizzleMask(string mask, out uint[] sizzleElements)
        {
            sizzleElements = new uint[]{ 0, 1, 2, 3};
            if (mask[0] == 0)
                return false;

            for(int j = 0;j < 4;++j)
            {
                if (mask[j] == 0)
                    return false;

                switch(mask[j])
                {
                    case 'R':
                    case 'X':
                    case 'r':
                    case 'x':
                        for (int k = j; k < 4; ++k)
                            sizzleElements[k] = 0;
                        break;
                    case 'G':
                    case 'Y':
                    case 'g':
                    case 'y':
                        for (int k = j; k < 4; ++k)
                            sizzleElements[k] = 1;
                        break;
                    case 'B':
                    case 'Z':
                    case 'b':
                    case 'z':
                        for (int k = j; k < 4; ++k)
                            sizzleElements[k] = 2;
                        break;
                    case 'A':
                    case 'W':
                    case 'a':
                    case 'w':
                        for (int k = j; k < 4; ++k)
                            sizzleElements[k] = 3;
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }
    }
}
