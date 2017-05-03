/*********************************************************************************
 *                      Used Andburn DDSReader sources.                          *
 *                      Link: https://github.com/andburn/dds-reader              *
 *********************************************************************************/
using System;
using System.IO;
using TTG_Tools.DDS.Utils;

namespace TTG_Tools.DDS
{
    public static class DDS2Raw
    {
        public static void Parse(byte[] DDS_file, string name, ref byte[] raw)
        {
            DDSStruct header = new DDSStruct();
            Utils.PixelFormat pf = Utils.PixelFormat.UNKNOWN;

            byte[] data = null;
            byte[] ddsheader = new byte[128];
            Array.Copy(DDS_file, 0, ddsheader, 0, ddsheader.Length);

            if (ReadHeader(ddsheader, ref header))
            {
                // patches for stuff
                if (header.depth == 0) header.depth = 1;

                uint blocksize = 0;
                pf = GetFormat(header, ref blocksize);
                if (pf != PixelFormat.UNKNOWN)
                {
                    byte[] temp = new byte[DDS_file.Length - 128];
                    Array.Copy(DDS_file, 128, temp, 0, temp.Length);
                    data = ReadData(temp, header);

                    if ((data != null) && (data.Length != 0))
                    {
                        byte[] rawData = Decompressor.Expand(header, data, pf);

                        //name = Methods.GetNameOfFileOnly(name, ".d3dtx") + ".png";

                        raw = rawData;

                        /*FileStream fs = new FileStream(name, FileMode.CreateNew);
                        fs.Write(rawData, 0, rawData.Length);
                        fs.Close();*/
                    }
                }
                
            }
        }

        public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, System.Drawing.Size size)
        {
            return (System.Drawing.Image)(new System.Drawing.Bitmap(imgToResize, size));
        }

        public static System.Drawing.Bitmap CreateBitmap(int width, int height, byte[] rawData, bool _alpha)
        {
            var pxFormat = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
            if (_alpha)
                pxFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb;

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height, pxFormat);

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height)
                , System.Drawing.Imaging.ImageLockMode.WriteOnly, pxFormat);
            IntPtr scan = data.Scan0;
            int size = bitmap.Width * bitmap.Height * 4;

            unsafe
            {
                byte* p = (byte*)scan;
                for (int i = 0; i < size; i += 4)
                {
                    // iterate through bytes.
                    // Bitmap stores it's data in RGBA order.
                    // DDS stores it's data in BGRA order.
                    p[i] = rawData[i + 2]; // blue
                    p[i + 1] = rawData[i + 1]; // green
                    p[i + 2] = rawData[i];   // red
                    p[i + 3] = rawData[i + 3]; // alpha
                }
            }

            bitmap.UnlockBits(data);
            return bitmap;
        }

        private static byte[] ReadData(byte[] data, DDSStruct header)
        {
            byte[] compdata = null;
            uint compsize = 0;

            if ((header.flags & Helper.DDSD_LINEARSIZE) > 1)
            {
                compdata = new byte[(int)header.sizeorpitch];
                if (compdata.Length <= 0) compdata = new byte[data.Length];
                Array.Copy(data, 0, compdata, 0, compdata.Length);
                //compdata = reader.ReadBytes((int)header.sizeorpitch);
                compsize = (uint)compdata.Length;
            }
            else
            {
                uint bps = header.width * header.pixelformat.rgbbitcount / 8;
                compsize = bps * header.height * header.depth;
                compdata = new byte[compsize];

                MemoryStream mem = new MemoryStream((int)compsize);

                byte[] temp;
                uint offset = 0;
                for (int z = 0; z < header.depth; z++)
                {
                    for (int y = 0; y < header.height; y++)
                    {
                        temp = new byte[(int)bps];
                        Array.Copy(data, offset, temp, 0, temp.Length);
                        //temp = reader.ReadBytes((int)bps);
                        mem.Write(temp, 0, temp.Length);
                        offset += bps;
                    }
                }
                mem.Seek(0, SeekOrigin.Begin);

                mem.Read(compdata, 0, compdata.Length);
                mem.Close();
            }

            return compdata;
        }
        
        private static bool ReadHeader(byte[] bheader, ref DDSStruct header)
        {
            byte[] temp = null;
            byte[] signature = new byte[4];
            //signature = reader.ReadBytes(4);
            Array.Copy(bheader, 0, signature, 0, signature.Length);

            if (signature[0] != 'D' && signature[1] != 'D' && signature[2] != 'S'
                && signature[3] != ' ') return false;

            //header.size = reader.ReadUInt32();
            temp = new byte[4];
            Array.Copy(bheader, 4, temp, 0, temp.Length);
            header.size = BitConverter.ToUInt32(temp, 0);
            if (header.size != 124) return false;

            uint offset = 8;
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
                //convert the data
            header.flags = BitConverter.ToUInt32(temp, 0);

            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.height = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.width = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.sizeorpitch = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.depth = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.mipmapcount = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.alphabitdepth = BitConverter.ToUInt32(temp, 0);

            header.reserved = new uint[10];
            for (int i = 0; i < 10; i++)
            {
                temp = new byte[4];
                Array.Copy(bheader, offset, temp, 0, temp.Length);
                offset += 4;
                header.reserved[i] = BitConverter.ToUInt32(temp, 0);
            }

            //pixelfromat
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.size = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.flags = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.fourcc = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.rgbbitcount = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.rbitmask = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.gbitmask = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.bbitmask = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.pixelformat.alphabitmask = BitConverter.ToUInt32(temp, 0);

            
            //caps
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.ddscaps.caps1 = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.ddscaps.caps2 = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.ddscaps.caps3 = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.ddscaps.caps4 = BitConverter.ToUInt32(temp, 0);
            temp = new byte[4];
            Array.Copy(bheader, offset, temp, 0, temp.Length);
            offset += 4;
            header.texturestage = BitConverter.ToUInt32(temp, 0);
            
            return true;
        }

        private static PixelFormat GetFormat(DDSStruct header, ref uint blocksize)
        {
            PixelFormat format = PixelFormat.UNKNOWN;
            if ((header.pixelformat.flags & Helper.DDPF_FOURCC) == Helper.DDPF_FOURCC)
            {
                blocksize = ((header.width + 3) / 4) * ((header.height + 3) / 4) * header.depth;

                switch (header.pixelformat.fourcc)
                {
                    case Helper.FOURCC_DXT1:
                        format = Utils.PixelFormat.DXT1;
                        blocksize *= 8;
                        break;

                    case Helper.FOURCC_DXT2:
                        format = Utils.PixelFormat.DXT2;
                        blocksize *= 16;
                        
                        break;

                    case Helper.FOURCC_DXT3:
                        format = Utils.PixelFormat.DXT3;
                        blocksize *= 16;
                        break;

                    case Helper.FOURCC_DXT4:
                        format = Utils.PixelFormat.DXT4;
                        blocksize *= 16;
                        break;

                    case Helper.FOURCC_DXT5:
                        format = Utils.PixelFormat.DXT5;
                        blocksize *= 16;
                        break;

                    case Helper.FOURCC_ATI1:
                        format = Utils.PixelFormat.ATI1N;
                        blocksize *= 8;
                        break;

                    case Helper.FOURCC_ATI2:
                        format = Utils.PixelFormat.THREEDC;
                        blocksize *= 16;
                        break;

                    case Helper.FOURCC_RXGB:
                        format = Utils.PixelFormat.RXGB;
                        blocksize *= 16;
                        break;

                    case Helper.FOURCC_DOLLARNULL:
                        format = Utils.PixelFormat.A16B16G16R16;
                        blocksize = header.width * header.height * header.depth * 8;
                        break;

                    case Helper.FOURCC_oNULL:
                        format = Utils.PixelFormat.R16F;
                        blocksize = header.width * header.height * header.depth * 2;
                        break;

                    case Helper.FOURCC_pNULL:
                        format = Utils.PixelFormat.G16R16F;
                        blocksize = header.width * header.height * header.depth * 4;
                        break;

                    case Helper.FOURCC_qNULL:
                        format = Utils.PixelFormat.A16B16G16R16F;
                        blocksize = header.width * header.height * header.depth * 8;
                        break;

                    case Helper.FOURCC_rNULL:
                        format = Utils.PixelFormat.R32F;
                        blocksize = header.width * header.height * header.depth * 4;
                        break;

                    case Helper.FOURCC_sNULL:
                        format = Utils.PixelFormat.G32R32F;
                        blocksize = header.width * header.height * header.depth * 8;
                        break;

                    case Helper.FOURCC_tNULL:
                        format = Utils.PixelFormat.A32B32G32R32F;
                        blocksize = header.width * header.height * header.depth * 16;
                        break;

                    default:
                        format = Utils.PixelFormat.UNKNOWN;
                        blocksize *= 16;
                        break;
                }
            }
            else
            {
                // uncompressed image
                if ((header.pixelformat.flags & Helper.DDPF_LUMINANCE) == Helper.DDPF_LUMINANCE)
                {
                    if ((header.pixelformat.flags & Helper.DDPF_ALPHAPIXELS) == Helper.DDPF_ALPHAPIXELS)
                    {
                        format = Utils.PixelFormat.LUMINANCE_ALPHA;
                    }
                    else
                    {
                        format = Utils.PixelFormat.LUMINANCE;
                    }
                }
                else
                {
                    if ((header.pixelformat.flags & Helper.DDPF_ALPHAPIXELS) == Helper.DDPF_ALPHAPIXELS)
                    {
                        format = Utils.PixelFormat.RGBA;
                    }
                    else
                    {
                        format = Utils.PixelFormat.RGB;
                    }
                }

                blocksize = (header.width * header.height * header.depth * (header.pixelformat.rgbbitcount >> 3));
            }

            return format;
        }
    }
}
