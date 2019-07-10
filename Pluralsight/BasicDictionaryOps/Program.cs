using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Pluralsight.ConcurrentCollections.BasicDictionaryOps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // StartOfModule contains the basic dictionary operations as presented
            // at the beginning of module 2, using Dictionary<string, int>
            StartOfModule();

            // StartOfModule contains the basic dictionary operations after modification
            // during the module, and therefore using ConcurrentDictionary<string, int>
            EndOfModule();

            Console.Read();
        }

        private static void StartOfModule()
        {
            Dictionary<string, int> stock = new Dictionary<string, int>()
            {
                {"jDays", 4},
                {"technologyhour", 3}
            };
            Console.WriteLine(string.Format("No. of shirts in stock = {0}", stock.Count));

            stock.Add("pluralsight", 6);
            stock["buddhistgeeks"] = 5;

            stock["pluralsight"] = 7; // up from 6 - we just bought one			
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            stock.Remove("jDays");

            Console.WriteLine("\r\nEnumerating:");
            foreach (KeyValuePair<string, int> keyValPair in stock)
            {
                Console.WriteLine("{0}: {1}", keyValPair.Key, keyValPair.Value);
            }
        }
        
        private static void EndOfModule()
        {
            ConcurrentDictionary<string, int> stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);
            Console.WriteLine(string.Format("No. of shirts in stock = {0}", stock.Count));

            bool success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succeeded? " + success);
            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succeeded? " + success);

            stock["buddhistgeeks"] = 5;

            // stock["pluralsight"]++;
            int psStock = stock.AddOrUpdate("pluralsight", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine("New value is " + psStock);

            Console.WriteLine(string.Format("stock[pluralsight] = {0}", stock.GetOrAdd("pluralsight", 0)));

            success = stock.TryRemove("jDays", out int jDaysValue);
            if (success)
                Console.WriteLine("value removed was: " + jDaysValue);

            Console.WriteLine("\r\nEnumerating:");
            foreach (KeyValuePair<string, int> keyValPair in stock)
            {
                Console.WriteLine("{0}: {1}", keyValPair.Key, keyValPair.Value);
            }
        }
    }
}