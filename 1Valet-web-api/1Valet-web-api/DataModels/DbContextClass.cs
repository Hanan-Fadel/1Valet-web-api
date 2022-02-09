using Microsoft.EntityFrameworkCore;

namespace _1Valet_web_api.Models
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Type>()
              .Property(p => p.Id)
              .ValueGeneratedOnAdd();
        }

        //The tables to be created on SQL database when we run EF migration
        public DbSet<Device> Device {get; set;}
        public DbSet<Type> Type { get; set; }



    }
}
