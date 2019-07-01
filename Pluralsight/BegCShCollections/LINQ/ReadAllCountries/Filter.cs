using System;
using System.Collections.Generic;
using System.Linq;

namespace BegCShCollections.LINQ.ReadAllCountries
{
    public class Filter
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../LINQ/ReadAllCountries/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            foreach (Country country in countries.Take(20))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }

            //Gives 17 countries without commas in their name, instead of 20.
            foreach (Country country in countries.Take(20).Where(x => !x.Name.Contains(",")))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }

            //Gives 20 countries without commas in their name.
            foreach (Country country in countries.Where(x => !x.Name.Contains(",")).Take(20))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }
        }
    }
}
