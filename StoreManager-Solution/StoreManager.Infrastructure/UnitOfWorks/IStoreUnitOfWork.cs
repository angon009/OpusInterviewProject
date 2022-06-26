using StoreManager.Data;
using StoreManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork
    {
        IItemRepository Items { get;} 
    }
}
