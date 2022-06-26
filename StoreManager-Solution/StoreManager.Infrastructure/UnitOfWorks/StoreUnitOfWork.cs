using Microsoft.EntityFrameworkCore;
using StoreManager.Data;
using StoreManager.Infrastructure.DbContexts;
using StoreManager.Infrastructure.Repositories; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public IItemRepository Items { get; private set; }
        public StoreUnitOfWork(IStoreDbContext storeDbContext, IItemRepository items)
            :base((DbContext)storeDbContext)
        {
            Items = items;
        }
    }
}
