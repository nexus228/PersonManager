using Microsoft.EntityFrameworkCore;
using PersonManager_WEB_API.Model;

namespace PersonManager_WEB_API
{
    public class PersonManagerDbContext : DbContext
    {
        public PersonManagerDbContext(
        DbContextOptions<PersonManagerDbContext> options)
        : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Person");
        }

    }
}
