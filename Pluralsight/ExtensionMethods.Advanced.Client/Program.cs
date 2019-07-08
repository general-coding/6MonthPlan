using System;

namespace ExtensionMethods.Advanced.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Demo ?");
            var demo = Console.ReadLine();
            Console.WriteLine("Demo {0}".FormatWith(demo));
            Console.ReadLine();
        }
    }
}
