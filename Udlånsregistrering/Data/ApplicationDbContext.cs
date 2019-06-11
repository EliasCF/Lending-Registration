using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udlånsregistrering.Models;

namespace Udlånsregistrering.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Class { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Zip_Code> Zip_Code { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Class>().HasKey(m => m.Id);
            builder.Entity<City>().HasKey(m => m.Id);
            builder.Entity<Zip_Code>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}
