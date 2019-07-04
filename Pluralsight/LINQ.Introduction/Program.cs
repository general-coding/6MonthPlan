using System;

namespace LINQ.Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reporting large files
            string path = @"C:\windows";
            LargeFilesReport report = new LargeFilesReport();
            report.ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            report.ShowLargeFilesWithLinq(path);

            Console.Read();
        }
    }
}
