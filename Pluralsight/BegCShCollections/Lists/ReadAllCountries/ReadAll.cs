using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            List<Country> countries = reader.ReadAllCountries(10);

            foreach (Country country in countries)
            {
                //Console.WriteLine($"{country.Population}: {country.Name}");

                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }

            Console.WriteLine($"{countries.Count} countries.");

            Console.ReadLine();
        }
    }
}
