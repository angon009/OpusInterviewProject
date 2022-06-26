using Microsoft.EntityFrameworkCore;
using StoreManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.DbContexts
{
    public interface IStoreDbContext
    {
        DbSet<Item> Items { get; set; }
        DbSet<OrderMaster> OrderMasters { get; set; }    
        DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
