using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLResourceExtractionTool
{
    class PathList
    {
        int PathListSize { get; set; }
        int PathListCount { get; set; }
        PathListEntry[] PathListEntries { get; set; }
        public string[] PathStrings { get; set; }

        public PathList(byte[] value, int startIndex)
        {
            PathListSize = BitConverter.ToInt32(value, startIndex);
            Console.WriteLine($"Path List Size: {PathListSize}");

            PathListCount = BitConverter.ToInt32(value, startIndex + 4);
            Console.WriteLine($"Path List Count: {PathListCount}");

            Console.WriteLine();
            PathListEntry[] pathListEntries = new PathListEntry[PathListCount];
            for (int i = 0; i < PathListCount; ++i)
            {
                Console.WriteLine($"Path List Entry {i + 1}");

                pathListEntries[i] = new PathListEntry(value, startIndex + 8 + i * 8);

                Console.WriteLine();
            }

            Console.WriteLine();
            string[] pathStrings = new string[PathListCount];
            for (int i = 0; i < PathListCount; ++i)
            {
                Console.WriteLine($"Path String {i + 1}");

                pathStrings[i] = Encoding.Default.GetString(value, startIndex + pathListEntries[i].PathOffset, pathListEntries[i].PathLength);
                Console.WriteLine($"Path String: {pathStrings[i]}");

                Console.WriteLine();
            }
        }
                

    
    }
}
