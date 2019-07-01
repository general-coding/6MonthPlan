using System;

namespace BegCShCollections.Arrays.TopTenPops
{
    public class TopTen
    {
        /// <summary>
        /// PadLeft(15) adds 15 characters to the left as margin
        /// </summary>
        public void Data()
        {
            string filePath = "../../Arrays/TopTenPops/Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                //Console.WriteLine($"{country.Population}: {country.Name}");

                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name} ");
            }
        }
    }
}
