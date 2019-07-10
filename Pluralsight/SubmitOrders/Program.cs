using System;
using System.Collections.Generic;
using System.Threading;

namespace Pluralsight.ConcurrentCollections.SubmitOrders
{
    public class Program
	{
        public static void Main(string[] args)
        {
            Queue<string> orders = new Queue<string>();
            PlaceOrders(orders, "Mark");
            PlaceOrders(orders, "Ramdevi");

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