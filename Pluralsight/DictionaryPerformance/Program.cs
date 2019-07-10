using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Pluralsight.ConcurrentCollections.DictionaryPerformance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // comment out all calls to Worker.DoSomethingTimeConsuming() 
            // throughout project to see how the benchmark works when threads spend
            // most of their time dealing with the concurrent dictionary
            int dictSize = 1000000;

            Console.WriteLine("Dictionary, single thread:");
            var dict = new Dictionary<int, int>();
            SingleThreadBenchmark.TimeDict(dict, dictSize);

            Console.WriteLine("\r\nConcurrentDictionary, single thread:");
            var dict2 = new ConcurrentDictionary<int, int>();
            SingleThreadBenchmark.TimeDict(dict2, dictSize);

            Console.WriteLine("\r\nConcurrentDictionary, multiple threads:");
            dict2 = new ConcurrentDictionary<int, int>();
            ParallelBenchmark.TimeDictParallel(dict2, dictSize);

            Console.Read();
        }
    }
}