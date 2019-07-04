using System.Collections.Generic;

namespace LINQ.Features
{
    public static class MyLINQ
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
            }

            return count;
        }
    }
}
