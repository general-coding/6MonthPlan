using System;

namespace LINQ.Features
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Iterating
            new WaysToIterate().OldWay();
            new WaysToIterate().NewWay();

            //Creating extension methods
            string text = "50.05";
            double data = text.ToDouble();
            Console.WriteLine(data);

            //Lambda expressions
            new Lambda().NamedMethod();
            new Lambda().AnonymousMethod();
            new Lambda().Expression();
            new Lambda().FuncsForMethods();
            new Lambda().FuncsForExpression();
            new Lambda().Actions();

            Console.Read();
        }
    }
}
