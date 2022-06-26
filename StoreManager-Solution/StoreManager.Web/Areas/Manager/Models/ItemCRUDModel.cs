using Autofac;
using StoreManager.Infrastructure.BusinessObjects;
using StoreManager.Infrastructure.Services;
using StoreManager.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreManager.Web.Areas.Manager.Models
{
    public class ItemCRUDModel
    {
        private IItemService _itemService;
        private ILifetimeScope _scope;

        public int Id { get; set; }


        [Required]
        public string? ItemCode { get; set; }


        [Required]
        public string? ItemName { get; set; }


        [Required]
        public string? Price { get; set; }

        public ItemCRUDModel()
        {

        }
        public ItemCRUDModel(IItemService itemService)
        {
            _itemService = itemService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _itemService = _scope.Resolve<IItemService>();
        }
        public async Task CreateItem()
        {
            var item = new Item
            {
                ItemName = ItemName,
                ItemCode = ItemCode,
                Price = Price
            };
            await _itemService.CreateItemAsync(item);
        }
        public async Task UpdateItem()
        {
            var item = new Item();

            item.Id = Id;
            item.ItemName = ItemName;
            item.ItemCode = ItemCode;
            item.Price = Price;

            await _itemService.EditItemAsync(item);
        }
        public async Task LoadData(int id)
        {
            var item = await _itemService.GetItemAsync(id);

            Id = item.Id;
            ItemName = item.ItemName;
            ItemCode = item.ItemCode;
            Price = item.Price;  
        }
        public async Task<object> GetPagedItems(DataTableAjaxRequestModel dataTableAjaxRequestModel)
        {
            var data = await _itemService.GetItemsAsync(
                dataTableAjaxRequestModel.PageIndex,
                dataTableAjaxRequestModel.PageSize,
                dataTableAjaxRequestModel.SearchText,
                dataTableAjaxRequestModel.GetSortText(new string[] { "ItemName", "ItemCode" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record!.ItemName!,
                                record!.ItemCode!,
                                record!.Price!.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
        public async Task DeleteItem(int id)
        {
            await _itemService.DeleteItemAsync(id);
        }
    }
}
