using System;

namespace BegCShCollections.Arrays
{
    public class DaysOfWeek
    {
        public void Data()
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

            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }
    }
}
