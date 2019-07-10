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
            DemoQueue();
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
    }

}
