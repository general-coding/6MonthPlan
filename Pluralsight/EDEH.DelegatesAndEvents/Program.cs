using System;

namespace EDEH.DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    public class Program
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);

        public static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            //del1(5, WorkType.GenerateReports);
            //del2(10, WorkType.Golf);

            DoWork(del1);
            DoWork(del2);

            Console.Read();
        }

        public static void DoWork(WorkPerformedHandler workPerformedHandler)
        {
            workPerformedHandler(5, WorkType.GenerateReports);
        }

        public static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        }

        public static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        }
    }
}
