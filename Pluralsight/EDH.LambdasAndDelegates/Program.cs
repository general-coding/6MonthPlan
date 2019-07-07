using System;
using System.Collections.Generic;
using System.Linq;

namespace EDEH.LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4},
            };

            IEnumerable<Customer> phxCustomers = customers
                                                    .Where(c => c.City == "Phoenix"
                                                            && c.ID < 500)
                                                    .OrderBy(c => c.FirstName);
            foreach (Customer customer in phxCustomers)
            {
                Console.WriteLine(customer.FirstName);
            }

            //ProcessData processData = new ProcessData();

            //BizRulesDelegate addDelegate = (x, y) => x + y;
            //BizRulesDelegate multiplyDelegate = (x, y) => x * y;
            //processData.Process(2, 3, addDelegate);
            //processData.Process(2, 3, multiplyDelegate);

            //Action<int, int> addAction = (x, y) => Console.WriteLine(x + y);
            //Action<int, int> multiplyAction = (x, y) => Console.WriteLine(x * y);
            //processData.ProcessAction(2, 3, addAction);
            //processData.ProcessAction(2, 3, multiplyAction);

            //Func<int, int, int> funcAddDel = (x, y) => x + y;
            //Func<int, int, int> funcMutliplyDel = (x, y) => x * y;
            //processData.ProcessFunc(2, 3, funcAddDel);
            //processData.ProcessFunc(2, 3, funcMutliplyDel);

            //Worker worker = new Worker();
            //worker.WorkPerformed += (s, e) =>
            //{
            //    Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
            //    Console.WriteLine("Some other value");
            //};
            //worker.WorkCompleted += (s, e) =>
            //{
            //    Console.WriteLine("Work is complete!");
            //};
            //worker.DoWork(8, WorkType.GenerateReports);

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
