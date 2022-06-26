using Microsoft.EntityFrameworkCore;
using StoreManager.Data;
using StoreManager.Infrastructure.DbContexts;
using StoreManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Repositories
{
    public class ItemRepository : Repository<Item, int>, IItemRepository
    {
        public ItemRepository(IStoreDbContext storeDbContext )
            : base((DbContext)storeDbContext)
        {

        }
    }
}
