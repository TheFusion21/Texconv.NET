using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TexconvNET.DirectX;

namespace TexconvNET
{
    public static partial class Texconv
    {
        public class Image
        {
            public ulong width;
            public ulong height;
            public DXGI_FORMAT format;
            public ulong rowPitch;
            public ulong slicePitch;
            public byte[] pixels;
        }

        public class ScratchImage
        {
            private TexMetadata metadata;
            private ulong size;
            private Image[] image;
            private byte[] memory;


            public bool OverrideFormat(DXGI_FORMAT fmt)
            {
                if (!IsValid(fmt) || IsPlanar(fmt) || IsPalettized(fmt))
                    return false;
                for (int i = 0; i < image.Length; ++i)
                {
                    image[i].format = fmt;
                }

                return true;
            }

            public Image GetImage(ulong mip, ulong item, ulong slice)
            {
                if (mip > metadata.mipLevels)
                    return null;
                ulong index = 0;

                switch(metadata.dimension)
                {
                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE1D:
                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE2D:
                        if (slice > 0)
                            return null;
                        if (item >= metadata.arraySize)
                            return null;
                        index = item * metadata.mipLevels + mip;
                        break;

                    case TEX_DIMENSION.TEX_DIMENSION_TEXTURE3D:
                        if(item > 0)
                        {
                            return null;
                        }
                        else
                        {
                            ulong d = metadata.depth;

                            for(ulong level = 0;level < mip;++level)
                            {
                                index += d;
                                if (d > 1)
                                    d >>= 1;
                            }

                            if (slice >= d)
                                return null;

                            index += slice;
                        }
                        break;
                }
                return image[index];
            }

            public bool IsAlphaAllOpaque()
            {
                if (image == null)
                    return false;

                if (!HasAlpha(metadata.format))
                    return true;

                if(IsCompressed(metadata.format))
                {
                    for(int index = 0;index < image.Length;++index)
                    {
                        if (!_IsAlphaAllOpaqueBC(image[index]))
                            return false;
                    }
                }
                else
                {
                    XMVECTOR[] scanline = new XMVECTOR[metadata.width / 4];

                    const float threshold = 0.997f;
                    foreach(Image img in image)
                    {
                        ulong yOffset = 0;
                        for(ulong h = 0;h < img.height;++h)
                        {
                            if (!_LoadScanline(ref scanline, img.width, img.pixels.Skip((int)yOffset).ToArray(), img.rowPitch, img.format))
                                return false;

                            for(ulong w = 0;w < img.width;++w)
                            {
                                float alpha = scanline[w].a;
                                if (alpha < threshold)
                                    return false;
                            }
                            yOffset += img.rowPitch;
                        }
                    }
                }
                return true;
            }
        }

        public static ScratchImage LoadFromDDSFile(string path, DDS_FLAGS flags, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromBMPEx(string path, WIC_FLAGS flags, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromTGAFile(string path, TGA_FLAGS flags, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromHDRFile(string path, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromPortablePixMap(string path, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromPortablePixMapHDR(string path, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromEXRFile(string path, ref TexMetadata info)
        {
            return null;
        }
        public static ScratchImage LoadFromWICFile(string path, ref TexMetadata info)
        {
            return null;
        }

    }
}
