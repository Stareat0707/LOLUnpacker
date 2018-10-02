using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLResourceExtractionTool
{
    class PathListEntry
    {
        public int PathOffset { get; set; }
        public int PathLength { get; set; }

        public PathListEntry(byte[] value, int startIndex)
        {
            PathOffset = BitConverter.ToInt32(value, startIndex);
            Console.WriteLine($"Path Offset: {PathOffset}");

            PathLength = BitConverter.ToInt32(value, startIndex + 4) - 1;
            Console.WriteLine($"Path Length: {PathLength}");
        }
    }
}
