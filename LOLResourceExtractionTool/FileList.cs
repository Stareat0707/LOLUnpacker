using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLResourceExtractionTool
{
    class FileList
    {
        public int NumberOfEntries { get; set; }
        public FileEntry[] FileEntries;

        public FileList(byte[] value, int startIndex)
        {
            NumberOfEntries = BitConverter.ToInt32(value, startIndex);
            Console.WriteLine($"Number of Entries: {NumberOfEntries}");

            Console.WriteLine();
            FileEntries = new FileEntry[NumberOfEntries];
            for (int i = 0; i < NumberOfEntries; ++i)
            {
                Console.WriteLine($"File Entry {i + 1}");
                FileEntries[i] = new FileEntry(value, startIndex + 4 + i * 16);
                Console.WriteLine();
            }
        }
    }
}
