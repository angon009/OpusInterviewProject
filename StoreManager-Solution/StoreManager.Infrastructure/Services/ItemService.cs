using StoreManager.Infrastructure.BusinessObjects;
using StoreManager.Infrastructure.UnitOfWorks;
using ItemEntity = StoreManager.Infrastructure.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure.Services
{
    public class ItemService : IItemService
    {
        private readonly IStoreUnitOfWork _storeUnitOfWork;
        public ItemService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public async Task CreateItemAsync(Item item)
        {
            var itemCount = await _storeUnitOfWork.Items.GetCountAsync
                (x => x.ItemName == item.ItemName);

            if (itemCount == 0)
            {
                var entity = new ItemEntity()
                {
                    ItemName = item.ItemName,
                    ItemCode = item.ItemCode,
                    Price = item.Price
                };

                await _storeUnitOfWork.Items.AddAsync(entity);
                await _storeUnitOfWork.SaveAsync();
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            await _storeUnitOfWork.Items.RemoveAsync(id);
            await _storeUnitOfWork.SaveAsync();
        }

        public async Task EditItemAsync(Item item)
        {
            var itemCount = await _storeUnitOfWork.Items.GetCountAsync
                (x => x.ItemName == item.ItemName && x.Id == item.Id);

            if (itemCount == 0)
            {
                var itemEntity = await _storeUnitOfWork.Items.GetByIdAsync(item.Id);

                itemEntity.ItemName = item.ItemName;
                itemEntity.ItemCode = item.ItemCode;
                itemEntity.Price = item.Price;


                await _storeUnitOfWork.SaveAsync();
            }
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var itemEntity = await _storeUnitOfWork.Items.GetByIdAsync(id);
            var item = new Item();

            item.Id = itemEntity.Id;
            item.ItemName = itemEntity.ItemName;
            item.ItemCode = itemEntity.ItemCode;
            item.Price = itemEntity.Price;

            return item;
        }

        public async Task<(int total, int totalDisplay, IList<Item> records)> GetItemsAsync
            (int pageIndex,int pageSize, string searchText, string orderBy)
        {
            var results = await _storeUnitOfWork.Items.GetDynamicAsync(x => x.ItemName
            .Contains(searchText), orderBy, string.Empty, pageIndex, pageSize, true);


            List<Item> items = new List<Item>();
            foreach (ItemEntity item in results.data)
            {
                items.Add(new Item
                {
                    ItemName = item.ItemName,
                    ItemCode = item.ItemCode,
                    Price = item.Price
                });
            }

            return (results.total, results.totalDisplay, items);
        }
    }
}
