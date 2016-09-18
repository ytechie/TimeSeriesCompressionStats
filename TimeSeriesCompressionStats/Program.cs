using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSeriesCompressionStats
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<DatasourceRecord> records;
            int size;
            int originalSize;

            records = RandomDatasourceRecordGenerator.GenerateDummyData(1);
            originalSize = records.JsonSerialize().GetSizeInBytes();
            Console.WriteLine("Single, uncompressed record: {0} bytes", originalSize);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("--     JSON Encoded Tests    --");
            Console.WriteLine("-------------------------------");


            size = records.JsonSerialize().ToBytes().Compress().GetSizeInBytes();
            PrintResults(records.Count(), size, originalSize);


            records = RandomDatasourceRecordGenerator.GenerateDummyData(100);
            size = records.JsonSerialize().ToBytes().Compress().GetSizeInBytes();
            PrintResults(records.Count(), size, originalSize);


            records = RandomDatasourceRecordGenerator.GenerateDummyData(1000);
            size = records.JsonSerialize().ToBytes().Compress().GetSizeInBytes();
            PrintResults(records.Count(), size, originalSize);


            records = RandomDatasourceRecordGenerator.GenerateDummyData(10000);
            size = records.JsonSerialize().ToBytes().Compress().GetSizeInBytes();
            PrintResults(records.Count(), size, originalSize);


            Console.Read();
        }

        private static void PrintResults(int numberOfRecords, int size, int originalSize)
        {
            var plural = numberOfRecords > 1;
            Console.WriteLine("Compressed {0} Record{1}: {2} bytes",
                numberOfRecords, plural ? "s" : "", size);

            var recordSize = (double)size / numberOfRecords;
            Console.WriteLine("Single Record Size: {0:#.##} bytes", recordSize);
            Console.WriteLine("Compression Ratio: {0:#.##}%", recordSize / originalSize * 100);

            Console.WriteLine("-------------------------------");
        }
    }
}
