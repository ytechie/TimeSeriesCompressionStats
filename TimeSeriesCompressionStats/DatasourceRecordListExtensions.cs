using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCompressionStats
{
    public static class DatasourceRecordListExtensions
    {
        public static string JsonSerialize(this IEnumerable<DatasourceRecord> records)
        {
            return JsonConvert.SerializeObject(records.ToArray());
        }

        public static byte[] ProtobufSerialize(this IEnumerable<DatasourceRecord> records)
        {
            return null;
        }

        public static byte[] ToBytes(this string serializedData)
        {
            return Encoding.UTF8.GetBytes(serializedData);
        }

        public static byte[] Compress(this byte[] uncompressedBytes)
        {
            var outputStream = new MemoryStream();
            using (var gz = new GZipStream(outputStream, CompressionLevel.Fastest, true))
            {
                gz.Write(uncompressedBytes, 0, uncompressedBytes.Length);
            }

            if (outputStream.CanSeek)
                outputStream.Position = 0;

            return outputStream.GetBuffer();
        }

        public static int GetSizeInBytes(this byte[] bytes)
        {
            return bytes.Length;
        }

        public static int GetSizeInBytes(this string data)
        {
            return Encoding.UTF8.GetByteCount(data);
        }
    }
}
