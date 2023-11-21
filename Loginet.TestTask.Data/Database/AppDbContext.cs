using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TestTask.Loginet.Data.Entities;

namespace TestTask.Loginet.Data.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Geo> Geos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.Navigation(y => y.Address).AutoInclude();
                b.Navigation(y => y.Company).AutoInclude();
            });
            modelBuilder.Entity<Address>()
                .Navigation(e => e.Geo)
                .AutoInclude();
        }
    }
}
