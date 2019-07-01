using System;
using System.Collections.Generic;
using System.Linq;

namespace BegCShCollections.CollectionWithinCollections.ReadAllCountries
{
    public class LINQQuerySyntax
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../LINQ/ReadAllCountries/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            var filteredCountries = countries.Where(x => !x.Name.Contains(","));
            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(",")
                                     select country;

            //Gives 20 countries without commas in their name.
            foreach (Country country in filteredCountries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }

            //Gives 20 countries without commas in their name.
            foreach (Country country in filteredCountries2)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }
        }
    }
}
