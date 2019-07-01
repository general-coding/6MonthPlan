using System;

namespace BegCShCollections.Arrays
{
    public class NthDay
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

            Console.WriteLine("Which day do you want to display?");
            Console.Write("(Monday = 1, etc.) > ");
            int iDay = int.Parse(Console.ReadLine());

            string chosenDay = daysOfWeek[iDay - 1];
            Console.WriteLine($"That day is {chosenDay}");
        }
    }
}
