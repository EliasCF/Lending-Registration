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

        public DbSet<Class> Classes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Zip_Code> Zip_Codes { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Mouse> Mouses { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Loaned_Computer> Loaned_Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Class>().HasKey(m => m.Id);
            builder.Entity<City>().HasKey(m => m.Id);
            builder.Entity<Zip_Code>().HasKey(m => m.Id);

            builder.Entity<Brand>().HasKey(m => m.Id);
            builder.Entity<Mouse>().HasKey(m => m.Id);
            builder.Entity<Model>().HasKey(m => m.Id);
            builder.Entity<Computer>().HasKey(m => m.Id);
            builder.Entity<Loaned_Computer>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}
