using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Queries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IOrderedEnumerable<double> numbers = MyLinq.Random()
                                                        .Where(n => n > 0.5)
                                                        .Take(10)
                                                        .OrderBy(n => n);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight",   Rating = 8.9f, Year = 2008 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Casablanca",        Rating = 8.5f, Year = 1942 },
                new Movie { Title = "Star Wars V",       Rating = 8.7f, Year = 1980 }
            };

            //Causes deferred execution
            //query is a datastructure that is built. The Filter is not yet executed
            //Because order by is, the query is immediately executed
            //Otherwise the query will be executed when the foreach is met
            IEnumerable<Movie> query = movies
                                        .Where(m => m.Year > 2000)
                                        .OrderByDescending(m => m.Rating);

            //Here the the above query is forced to execute.
            //The Filter method will be executed, deferred execution
            foreach (Movie movie in query)
            {
                Console.WriteLine(movie.Title);
            }

            Console.Read();
        }
    }
}
