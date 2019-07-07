using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEH.LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);

    public class Program
    {
        public static void Main(string[] args)
        {
            BizRulesDelegate addDelegate = (x, y) => x + y;
            BizRulesDelegate multiplyDelegate = (x, y) => x * y;

            ProcessData processData = new ProcessData();
            processData.Process(2, 3, addDelegate);
            processData.Process(2, 3, multiplyDelegate);

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
