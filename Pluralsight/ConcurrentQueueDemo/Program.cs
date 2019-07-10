using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Pluralsight.ConcurrentCollections.ConcurrentQueueDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //queue
            //DemoQueue();

            //oncurrent queue
            //DemoConcurrentQueue();

            //concurrent Stack
            //DemoConcurrentStack();

            //concurrent bag
            DemoConcurrentBag();
        }

        private static void DemoQueue()
        {
            Queue<string> shirts = new Queue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1 = shirts.Dequeue();
            Console.WriteLine("\r\nRemoving " + item1);

            string item2 = shirts.Peek();
            Console.WriteLine("Peeking   " + item2);

            Console.WriteLine("\r\nEnumerating:");
            foreach (string item in shirts)
                Console.WriteLine(item);

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());

        }

        private static void DemoConcurrentQueue()
        {
            ConcurrentQueue<string> shirts = new ConcurrentQueue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            //= shirts.Dequeue();
            bool success = shirts.TryDequeue(out string item1);
            if (success)
                Console.WriteLine("\r\nRemoving " + item1);
            else
                Console.WriteLine("queue was empty");

            //= shirts.Peek();
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine("Peeking   " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach (string item in shirts)
                Console.WriteLine(item);

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }

        private static void DemoConcurrentStack()
        {
            ConcurrentStack<string> shirts = new ConcurrentStack<string>();
            shirts.Push("Pluralsight");
            shirts.Push("WordPress");
            shirts.Push("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            //= shirts.Dequeue();
            bool success = shirts.TryPop(out string item1);
            if (success)
                Console.WriteLine("\r\nRemoving " + item1);
            else
                Console.WriteLine("queue was empty");

            //= shirts.Peek();
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine("Peeking   " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach (string item in shirts)
                Console.WriteLine(item);

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }

        private static void DemoConcurrentBag()
        {
            ConcurrentBag<string> shirts = new ConcurrentBag<string>
            {
                "Pluralsight",
                "WordPress",
                "Code School"
            };

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            //= shirts.Dequeue();
            bool success = shirts.TryTake(out string item1);
            if (success)
                Console.WriteLine("\r\nRemoving " + item1);
            else
                Console.WriteLine("queue was empty");

            //= shirts.Peek();
            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine("Peeking   " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach (string item in shirts)
                Console.WriteLine(item);

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }
    }
}
