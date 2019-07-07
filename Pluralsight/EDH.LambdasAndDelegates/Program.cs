using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDH.LambdasAndDelegates
{
    class Program
    {
        public static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
                Console.WriteLine("Some other value");
            };
            worker.WorkCompleted += (s, e) =>
            {
                Console.WriteLine("Work is complete!");
            };
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        //public static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
        //}

        //public static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Work is complete!");
        //}
    }
}
