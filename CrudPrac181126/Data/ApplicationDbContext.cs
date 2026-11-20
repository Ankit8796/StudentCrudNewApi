using CrudPrac181126.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudPrac181126.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions Options):base(Options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
               .Property(s=>s.Gender)
               .HasConversion<string>();
        }


    }
}
