using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pluralsight.ConcurrentCollections.SubmitOrders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Each of these methods shows a different state in the program
            // as it was edited through module 1 of the course.

            // Uncomment any method and comment out the others to see
            // how the program worked at that point.

            // initially, with one thread:
            RunProgramOneThread();

            // multi-threaded but NOT thread-safe:
            // This method will give unpredictable results and may crash
            // Note that the stability of this function depends to some extent on 
            // your hardware. I put a Thread.Sleep(1) in the code used in the module
            // because that seemed to time the threads to maximize contention and so maximuze
            // the likelihood of showing errors on my computer.
            // You may need to adjust this time to get similar results on your hardware.
            RunProgramMultithreaded();

            // multi-threaded and thread-safe
            // because it uses a concurrent queue
            RunProgramConcurrent();

            // multi-threaded and thread-safe
            // because it uses locks to synchronize threads
            RunProgramWithLock();

            Console.Read();
        }

        public static void RunProgramOneThread()
        {
            Queue<string> orders = new Queue<string>();
            PlaceOrders(orders, "Mark");
            PlaceOrders(orders, "Ramdevi");

            foreach (string order in orders)
                Console.WriteLine("ORDER: " + order);
        }

        public static void RunProgramMultithreaded()
        {
            Queue<string> orders = new Queue<string>();
            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);

            foreach (string order in orders)
                Console.WriteLine("ORDER: " + order);
        }

        public static void RunProgramConcurrent()
        {
            ConcurrentQueue<string> orders = new ConcurrentQueue<string>();
            Task task1 = Task.Run(() => PlaceOrders2(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders2(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);

            foreach (string order in orders)
                Console.WriteLine("ORDER: " + order);
        }

        public static void RunProgramWithLock()
        {
            Queue<string> orders = new Queue<string>();
            Task task1 = Task.Run(() => PlaceOrders3(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders3(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);

            foreach (string order in orders)
                Console.WriteLine("ORDER: " + order);
        }

        public static void PlaceOrders(Queue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                orders.Enqueue(orderName);
            }
        }

        public static void PlaceOrders2(ConcurrentQueue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                orders.Enqueue(orderName);
            }
        }

        static object _lockObj = new object();
        public static void PlaceOrders3(Queue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                lock (_lockObj)
                {
                    orders.Enqueue(orderName);
                }
            }
        }
    }
}