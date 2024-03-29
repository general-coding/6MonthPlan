﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Queries
{
    public static class MyLinq
    {
        public static IEnumerable<double> Random()
        {
            Random random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source
                                                , Func<T, bool> predicate)
        {
            //List<T> result = new List<T>();

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    //result.Add(item);

                    yield return item;
                }
            }

            //return result;
        }
    }
}
