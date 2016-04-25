using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jpg_To_Pri_Convertor
{
    class clsMain
    {
        public static void WriteResourceToFile(string outputDir, string resourceLocation, string file)
        {
            using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceLocation + @".Resources." + file))
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(System.IO.Path.Combine(outputDir, file), System.IO.FileMode.Create))
                {
                    for (int i = 0; i < stream.Length; i++)
                    {
                        fileStream.WriteByte((byte)stream.ReadByte());
                    }
                    fileStream.Close();
                }
            }
        }
        public static void JpgToPri(string currentPri, string outputPri, string image)
        {
            var iStream = File.OpenRead(currentPri);
            var oStream = File.Create(outputPri);
            var rStream = File.OpenRead(image);

            var iReader = new BinaryReader(iStream);
            var oWriter = new BinaryWriter(oStream);

            iStream.CopyTo(oStream);

            var lengthR = (Math.Ceiling((double)rStream.Length / 8) * 8);

            iStream.Seek(0x14, SeekOrigin.Begin);
            var headerLength = iReader.ReadUInt32();
            iStream.Seek(0xB8, SeekOrigin.Begin);
            var dataOffset = iReader.ReadUInt32();
            var origDataitemLength = iReader.ReadUInt32();
            var dataLength = origDataitemLength + lengthR;
            oStream.Seek(0xBC, SeekOrigin.Begin);
            oWriter.Write((int)dataLength);

            oStream.Seek(headerLength + dataOffset + 0x18, SeekOrigin.Begin);
            oWriter.Write((int)dataLength);
            iStream.Seek(headerLength + dataOffset + 0x24, SeekOrigin.Begin);
            var stringCount = iReader.ReadUInt16();
            var blobCount = iReader.ReadUInt16();
            var origDataLength = iReader.ReadUInt32();
            oStream.Seek(0xC, SeekOrigin.Current);
            oWriter.Write((int)(origDataLength + lengthR));
            oStream.Seek(stringCount * 4, SeekOrigin.Current);
            var blobTableOffset = oStream.Position;
            var dataOffsets = blobTableOffset + blobCount * 8;
            var wallpaperBlobs = new List<int>();
            for (var i = 0; i < blobCount; i++)
            {
                iStream.Seek(blobTableOffset + i * 8, SeekOrigin.Begin);
                var offset = iReader.ReadUInt32();
                var length = iReader.ReadUInt32();
                iStream.Seek(dataOffsets + offset, SeekOrigin.Begin);
                if (iReader.ReadUInt16() == 0xD8FF)
                {
                    wallpaperBlobs.Add(i);
                }
            }
            if (wallpaperBlobs.Count != 10)
            {
                throw new Exception("Not compatible with this PRI file.");
            }
            foreach (var id in wallpaperBlobs)
            {
                oStream.Seek(blobTableOffset + id * 8, SeekOrigin.Begin);
                oWriter.Write(origDataLength);
                oWriter.Write((int)rStream.Length);
            }

            oStream.Seek(dataOffsets + origDataLength, SeekOrigin.Begin);
            if (oStream.Length - oStream.Position != 0x18)
            {
                throw new Exception("Not compatible with this PRI file.");
            }
            rStream.CopyTo(oStream);

            oStream.Seek((long)(lengthR - rStream.Length), SeekOrigin.Current);
            oWriter.Write(0xDEF5FADE);
            oWriter.Write((int)dataLength);
            oWriter.Write(0xDEFFFADE);
            oWriter.Write(0x00000000);
            oWriter.Write("mrm_pri2".ToCharArray());

            oStream.Seek(0xC, SeekOrigin.Begin);
            oWriter.Write((int)oStream.Length);
            oStream.Seek(-0xC, SeekOrigin.End);
            oWriter.Write((int)oStream.Length);

            iReader.Close();
            oWriter.Close();
            rStream.Close();
        }
    }
}
