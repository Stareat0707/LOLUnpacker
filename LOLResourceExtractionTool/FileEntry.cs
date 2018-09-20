using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLResourceExtractionTool
{
    class FileEntry
    {
        int PathHash { get; set; }
        public int DataOffset { get; set; }
        public int DataSize { get; set; }
        public int PathListIndex { get; set; }

        public FileEntry(byte[] value, int startIndex)
        {
            PathHash = BitConverter.ToInt32(value, startIndex);
            Console.WriteLine($"Path Hash: {PathHash}");

            DataOffset = BitConverter.ToInt32(value, startIndex + 4);
            Console.WriteLine($"Data Offset: {DataOffset}");

            DataSize = BitConverter.ToInt32(value, startIndex + 8);
            Console.WriteLine($"Data Size: {DataSize}");

            PathListIndex = BitConverter.ToInt32(value, startIndex + 12);
            Console.WriteLine($"Path List Index: {PathListIndex}");
        }
    }
}
