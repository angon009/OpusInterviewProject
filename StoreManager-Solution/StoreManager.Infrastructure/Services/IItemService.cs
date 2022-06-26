using StoreManager.Infrastructure.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Services
{
    public interface IItemService
    {
        Task CreateItemAsync(Item item);
        Task EditItemAsync(Item item);
        Task<(int total, int totalDisplay, IList<Item> records)> GetItemsAsync(int pageIndex, 
            int pageSize,string searchText, string orderBy);
        Task<Item> GetItemAsync(int id);
        Task DeleteItemAsync(int id);
    }
}
