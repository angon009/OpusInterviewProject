using StoreManager.Data;
using StoreManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Repositories
{
    public interface IItemRepository : IRepository<Item, int>
    {
        
    }
}
