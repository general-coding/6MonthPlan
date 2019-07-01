using System;
using System.Collections.Generic;

namespace BegCShCollections.Lists.ReadAllCountries
{
    public class ReadAll
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../Lists/ReadAllCountries/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            //Inserting a value at an index
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);

            //Removing a value at an index.
            countries.RemoveAt(lilliputIndex);

            foreach (Country country in countries)
            {
                //Console.WriteLine($"{country.Population}: {country.Name}");

                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }

            Console.WriteLine($"{countries.Count} countries.");
        }
    }
}
