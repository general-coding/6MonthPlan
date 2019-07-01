using System;
using System.Collections.Generic;

namespace BegCShCollections.Dictionaries
{
    public class DictSnippets
    {
        public void Data()
        {
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            //Dictionary<string, Country> countries = new Dictionary<string, Country>();
            var countries = new Dictionary<string, Country>();
            countries.Add(norway.Code, norway);
            countries.Add(finland.Code, finland);

            Country selectedCountry = countries["NOR"];
            Console.WriteLine(selectedCountry.Name);

            foreach (var key in countries.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (var value in countries.Values)
            {
                Console.WriteLine(value.Name);
            }

            //A different way of initializing dictionary
            countries = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, finland }
            };

            bool exists = countries.TryGetValue("MUS", out Country country);
            if (exists)
            {
                Console.WriteLine(country.Name);
            }
            else
            {
                Console.WriteLine("There is not country with the code MUS");
            }
        }
    }
}
