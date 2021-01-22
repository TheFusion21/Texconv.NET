using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexconvNET
{
    public static partial class DirectX
    {
        internal enum TEX_FILTER_FLAGS : ulong
        {
            TEX_FILTER_DEFAULT = 0,

            TEX_FILTER_WRAP_U = 0x1,
            TEX_FILTER_WRAP_V = 0x2,
            TEX_FILTER_WRAP_W = 0x4,
            TEX_FILTER_WRAP = (TEX_FILTER_WRAP_U | TEX_FILTER_WRAP_V | TEX_FILTER_WRAP_W),
            TEX_FILTER_MIRROR_U = 0x10,
            TEX_FILTER_MIRROR_V = 0x20,
            TEX_FILTER_MIRROR_W = 0x40,
            TEX_FILTER_MIRROR = (TEX_FILTER_MIRROR_U | TEX_FILTER_MIRROR_V | TEX_FILTER_MIRROR_W),
            // Wrap vs. Mirror vs. Clamp filtering options

            TEX_FILTER_SEPARATE_ALPHA = 0x100,
            // Resize color and alpha channel independently

            TEX_FILTER_FLOAT_X2BIAS = 0x200,
            // Enable *2 - 1 conversion cases for unorm<->float and positive-only float formats

            TEX_FILTER_RGB_COPY_RED = 0x1000,
            TEX_FILTER_RGB_COPY_GREEN = 0x2000,
            TEX_FILTER_RGB_COPY_BLUE = 0x4000,
            // When converting RGB to R, defaults to using grayscale. These flags indicate copying a specific channel instead
            // When converting RGB to RG, defaults to copying RED | GREEN. These flags control which channels are selected instead.

            TEX_FILTER_DITHER = 0x10000,
            // Use ordered 4x4 dithering for any required conversions
            TEX_FILTER_DITHER_DIFFUSION = 0x20000,
            // Use error-diffusion dithering for any required conversions

            TEX_FILTER_POINT = 0x100000,
            TEX_FILTER_LINEAR = 0x200000,
            TEX_FILTER_CUBIC = 0x300000,
            TEX_FILTER_BOX = 0x400000,
            TEX_FILTER_FANT = 0x400000, // Equiv to Box filtering for mipmap generation
            TEX_FILTER_TRIANGLE = 0x500000,
            // Filtering mode to use for any required image resizing

            TEX_FILTER_SRGB_IN = 0x1000000,
            TEX_FILTER_SRGB_OUT = 0x2000000,
            TEX_FILTER_SRGB = (TEX_FILTER_SRGB_IN | TEX_FILTER_SRGB_OUT),
            // sRGB <-> RGB for use in conversion operations
            // if the input format type is IsSRGB(), then SRGB_IN is on by default
            // if the output format type is IsSRGB(), then SRGB_OUT is on by default

            TEX_FILTER_FORCE_NON_WIC = 0x10000000,
            // Forces use of the non-WIC path when both are an option

            TEX_FILTER_FORCE_WIC = 0x20000000,
            // Forces use of the WIC path even when logic would have picked a non-WIC path when both are an option
        };

        internal const ulong TEX_FILTER_DITHER_MASK = 0xF0000;
        internal const ulong TEX_FILTER_MODE_MASK = 0xF00000;
        internal const ulong TEX_FILTER_SRGB_MASK = 0xF000000;

        internal enum TEX_COMPRESS_FLAGS : ulong
        {
            TEX_COMPRESS_DEFAULT = 0,

            TEX_COMPRESS_RGB_DITHER = 0x10000,
            // Enables dithering RGB colors for BC1-3 compression

            TEX_COMPRESS_A_DITHER = 0x20000,
            // Enables dithering alpha for BC1-3 compression

            TEX_COMPRESS_DITHER = 0x30000,
            // Enables both RGB and alpha dithering for BC1-3 compression

            TEX_COMPRESS_UNIFORM = 0x40000,
            // Uniform color weighting for BC1-3 compression; by default uses perceptual weighting

            TEX_COMPRESS_BC7_USE_3SUBSETS = 0x80000,
            // Enables exhaustive search for BC7 compress for mode 0 and 2; by default skips trying these modes

            TEX_COMPRESS_BC7_QUICK = 0x100000,
            // Minimal modes (usually mode 6) for BC7 compression

            TEX_COMPRESS_SRGB_IN = 0x1000000,
            TEX_COMPRESS_SRGB_OUT = 0x2000000,
            TEX_COMPRESS_SRGB = (TEX_COMPRESS_SRGB_IN | TEX_COMPRESS_SRGB_OUT),
            // if the input format type is IsSRGB(), then SRGB_IN is on by default
            // if the output format type is IsSRGB(), then SRGB_OUT is on by default

            TEX_COMPRESS_PARALLEL = 0x10000000,
            // Compress is free to use multithreading to improve performance (by default it does not use multithreading)
        }

        internal enum WICCodecs
        {
            WIC_CODEC_BMP = 1,          // Windows Bitmap (.bmp)
            WIC_CODEC_JPEG,             // Joint Photographic Experts Group (.jpg, .jpeg)
            WIC_CODEC_PNG,              // Portable Network Graphics (.png)
            WIC_CODEC_TIFF,             // Tagged Image File Format  (.tif, .tiff)
            WIC_CODEC_GIF,              // Graphics Interchange Format  (.gif)
            WIC_CODEC_WMP,              // Windows Media Photo / HD Photo / JPEG XR (.hdp, .jxr, .wdp)
            WIC_CODEC_ICO,              // Windows Icon (.ico)
        }

        internal const float TEX_THRESHOLD_DEFAULT = 0.5f;

        internal enum CNMAP_FLAGS : ulong
        {
            CNMAP_DEFAULT           = 0,

            CNMAP_CHANNEL_RED       = 0x1,
            CNMAP_CHANNEL_GREEN     = 0x2,
            CNMAP_CHANNEL_BLUE      = 0x3,
            CNMAP_CHANNEL_ALPHA     = 0x4,
            CNMAP_CHANNEL_LUMINANCE = 0x5,
                // Channel selection when evaluting color value for height
                // Luminance is a combination of red, green, and blue

            CNMAP_MIRROR_U          = 0x1000,
            CNMAP_MIRROR_V          = 0x2000,
            CNMAP_MIRROR            = 0x3000,
                // Use mirror semantics for scanline references (defaults to wrap)

            CNMAP_INVERT_SIGN       = 0x4000,
                // Inverts normal sign

            CNMAP_COMPUTE_OCCLUSION = 0x8000,
                // Computes a crude occlusion term stored in the alpha channel
        }
    }
}
