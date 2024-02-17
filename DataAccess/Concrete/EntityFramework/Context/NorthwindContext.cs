using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public NorthwindContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(p => {
                p.ToTable("Brands").HasKey(p=>p.Id);
                p.Property(p=>p.Id).HasColumnName("Id");
                p.Property(p=>p.Name).HasColumnName("Name");
            });
            base.OnModelCreating(modelBuilder);

            Brand[] brandSeedData = { new(1, "AUDI"), new(2, "Mercedes") };

            modelBuilder.Entity<Brand>().HasData(brandSeedData);
        }
    }
}
