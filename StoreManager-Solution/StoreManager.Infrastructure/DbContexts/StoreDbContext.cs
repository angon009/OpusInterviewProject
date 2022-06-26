using Microsoft.EntityFrameworkCore;
using StoreManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.DbContexts
{
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;
        public StoreDbContext(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        } 
        public DbSet<Item> Items { get ; set ; }
        public DbSet<OrderMaster> OrderMasters { get ; set ; }
        public DbSet<OrderDetail> OrderDetails { get ; set ; }
    }
}
