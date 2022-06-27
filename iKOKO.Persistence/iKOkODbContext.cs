using iKOKO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace iKOKO.Persistence
{
    public class iKOKODbContext : DbContext
    {
        public virtual DbSet<IceCream> IceCreams { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        public iKOKODbContext(DbContextOptions<iKOKODbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=iKOKODb;Trusted_Connection=true;MultipleActiveResultSets=true;")
        //    .EnableSensitiveDataLogging(true);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

    }
}
