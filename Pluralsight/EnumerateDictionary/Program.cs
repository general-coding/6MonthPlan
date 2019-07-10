using System;
using System.Collections.Concurrent;

namespace Pluralsight.ConcurrentCollections.EnumerateDictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // change this to a Dictionary<string, int> to see that enumerating while modifying
            // throws an exception for the standard dictionary
            ConcurrentDictionary<string, int> stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 0);
            stock.TryAdd("Code School", 0);
            stock.TryAdd("Buddhist Geeks", 0);

            foreach (var shirt in stock)
            {
                stock.AddOrUpdate("jDays", 0, (key, value) => value + 1);
                Console.WriteLine(shirt.Key + ": " + shirt.Value);
            }

            Console.Read();
        }
    }
}
