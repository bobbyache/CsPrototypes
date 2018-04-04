using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rdl2RdlcConverter
{
    public class RdlFolderConverter
    {
        public void Convert(string targetFolder, IProgress<int> progress)
        {
            RdlcConverter converter = new RdlcConverter();

            string[] rdlFiles = Directory.EnumerateFiles(targetFolder, "*.rdl")
                .Where(f => f.EndsWith(".rdl")).ToArray();

            int fileCount = rdlFiles.Count();

            for (int x = 0; x < fileCount; x++)
            {
                System.Threading.Thread.Sleep(3000);
                converter.Convert(rdlFiles[x]);
                progress.Report((int)Math.Round(((x + 1) / (double)fileCount) * 100));
            }
        }
    }
}
