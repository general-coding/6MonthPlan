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
        public static void Main(string[] args)
        {
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1(5, WorkType.GenerateReports);
            //del2(10, WorkType.Golf);

            //DoWork(del1);
            //DoWork(del2);

            //Stacking events on top of each other
            //del1 += del2;
            //del1 += del3;
            //del1(10, WorkType.GenerateReports);

            //del1 += del2 + del3;
            //int finalHours = del1(10, WorkType.GenerateReports);
            //Console.WriteLine(finalHours);

            //Worker worker = new Worker();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            //worker.DoWork(5, WorkType.GenerateReports);

            //The compiler auto generates the EventHandler by using the delegate
            //defined in the Worker class
            //Use tab tab to auto generate the event handler
            //Worker worker = new Worker();
            //worker.WorkPerformed += Worker_WorkPerformed;
            //worker.WorkCompleted += Worker_WorkCompleted;
            //worker.DoWork(5, WorkType.GenerateReports);

            Worker worker = new Worker();
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            };
            worker.WorkCompleted += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Worker is done");
            };
            worker.DoWork(5, WorkType.GenerateReports);

            Console.Read();
        }

        //private static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

        //private static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

        //public static void DoWork(WorkPerformedHandler workPerformedHandler)
        //{
        //    workPerformedHandler(5, WorkType.GenerateReports);
        //}

        //public static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        //    return hours + 1;
        //}

        //public static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        //    return hours + 2;
        //}

        //private static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //    return hours + 3;
        //}
    }
}
