namespace BegCShCollections.Arrays.TopTenPops
{
    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }

        public Country(string name, string code, string region, int popluation)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = popluation;
        }
    }
}
