using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLResourceExtractionTool
{
    public partial class LOLUnpacker : Form
    {
        public LOLUnpacker()
        {
            InitializeComponent();

            var path = "Archive_1.raf";

            byte[] raf;
            using (FileStream fs = File.OpenRead(path))
            {
                Console.WriteLine($"File Name: {"Archive_1.raf"}");
                raf = new byte[fs.Length];
                fs.Read(raf, 0, Convert.ToInt32(fs.Length));
            }
            
            int magicNumber = BitConverter.ToInt32(raf, 0);
            Console.WriteLine($"Magic Number: {magicNumber}");
            
            int version = BitConverter.ToInt32(raf, 4);
            Console.WriteLine($"Version: {version}");
            
            int managerIndex = BitConverter.ToInt32(raf, 8);
            Console.WriteLine($"Manager Index: {managerIndex}");
            
            int fileListOffset = BitConverter.ToInt32(raf, 12);
            Console.WriteLine($"File List Offset: {fileListOffset}");
            
            int pathListOffset = BitConverter.ToInt32(raf, 16);
            Console.WriteLine($"Path List Offset: {pathListOffset}");

            Console.WriteLine();
            var fileList = new FileList(raf, fileListOffset);

            Console.WriteLine();
            var pathList = new PathList(raf, pathListOffset);
        }
    }
}
