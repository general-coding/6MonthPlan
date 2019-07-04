using System.Data.Entity;

namespace LINQ.XML
{
    public class CarDb : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
