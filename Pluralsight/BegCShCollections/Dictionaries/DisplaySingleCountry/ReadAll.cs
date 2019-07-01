using System;
using System.Collections.Generic;

namespace BegCShCollections.Dictionaries.DisplaySingleCountry
{
    public class ReadAll
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../Dictionaries/DisplaySingleCountry/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country code do you want to look up?");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);

            if (!gotCountry)
            {
                Console.WriteLine($"Sorry, there is not country with code: {country.Code}");
            }
            else
            {
                Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");
            }
        }
    }
}
