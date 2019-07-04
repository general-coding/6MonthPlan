using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQ.Introduction
{
    public class LargeFilesReport
    {
        public void ShowLargeFilesWithLinq(string path)
        {
            IEnumerable<FileInfo> files = from file in new DirectoryInfo(path).GetFiles()
                                          orderby file.Length descending
                                          select file;

            Console.WriteLine("Using query similar to SQL");
            foreach (FileInfo file in files.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }

            Console.WriteLine("Using IEnumerable");
            files = new DirectoryInfo(path).GetFiles()
                    .OrderByDescending(f => f.Length)
                    .Take(5);

            foreach (FileInfo file in files.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }

        public void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();

            Console.WriteLine("Listing all files");
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file.Name} : {file.Length}");
            }

            //Sort descending
            Array.Sort(files, new FileInfoComparer());

            Console.WriteLine("Listing top 5 largest files");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name,-20} : {files[i].Length,10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
