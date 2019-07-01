using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BegCShCollections
{
    class DaysOfWeek
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = {
                "Monday"
                , "Tuesday"
                , "Wednesday"
                , "Thursday"
                , "Friday"
                , "Saturday"
                , "Sunday"
            };

            foreach(string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}
