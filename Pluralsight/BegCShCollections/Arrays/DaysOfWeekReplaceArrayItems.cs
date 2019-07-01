using System;

namespace BegCShCollections.Arrays
{
    public class DaysOfWeekReplaceArrayItems
    {
        public void Data()
        {
            string[] daysOfWeek = {
                "Monday"
                , "Tuesday"
                , "Wenday"
                , "Thursday"
                , "Friday"
                , "Saturday"
                , "Sunday"
            };

            Console.WriteLine("Before:");
            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            daysOfWeek[2] = "Wednesday";

            Console.WriteLine();

            Console.WriteLine("After:");
            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}
