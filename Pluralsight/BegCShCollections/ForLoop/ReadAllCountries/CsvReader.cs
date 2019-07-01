using System;
using System.Collections.Generic;
using System.IO;

namespace BegCShCollections.ForLoop.ReadAllCountries
{
    public class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                //Ignore header line
                streamReader.ReadLine();

                string csvLine;
                while ((csvLine = streamReader.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }

            return countries;
        }

        //public void RemoveCommaCountries(List<Country> countries)
        //{
        //    for (int i = countries.Count - 1; i >= 0; i--)
        //    {
        //        if (countries[i].Name.Contains(","))
        //        {
        //            countries.RemoveAt(i);
        //        }
        //    }
        //}

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string name;
            string code;
            string region;
            string popText;

            string[] parts = csvLine.Split(',');

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;

                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;

                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            //If tryParse cannot parse popText, it will return population=0
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }
    }
}
