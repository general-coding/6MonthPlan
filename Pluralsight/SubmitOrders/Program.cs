using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pluralsight.ConcurrentCollections.SubmitOrders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> orders = new Queue<string>();
            //PlaceOrders(orders, "Mark");
            //PlaceOrders(orders, "Ramdevi");  

            //Multithreading the place orders
            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);

            foreach (string order in orders)
                Console.WriteLine("ORDER: " + order);

            Console.Read();
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
    }
}