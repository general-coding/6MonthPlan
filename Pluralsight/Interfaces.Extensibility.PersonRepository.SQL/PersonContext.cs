using Microsoft.EntityFrameworkCore;

namespace Interfaces.Extensibility.PersonRepository.SQL
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        { }

        public DbSet<PersonContext> People { get; set; }
    }
}
