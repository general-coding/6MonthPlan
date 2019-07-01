using System;
using System.Collections.Generic;

namespace BegCShCollections.ForLoop.ReadAllCountries
{
    public class RemovingItems
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../ForLoop/ReadAllCountries/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();
            //reader.RemoveCommaCountries(countries);
            countries.RemoveAll(x => x.Name.Contains(","));

            Console.WriteLine("Enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting...");
            }

            //Largest pop to least
            int maxToDisplay = userInput;
            for (int i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }

                Country country = countries[i];
                Console.WriteLine($"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }
        }
    }
}
