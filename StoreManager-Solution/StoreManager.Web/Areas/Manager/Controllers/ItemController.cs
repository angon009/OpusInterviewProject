using Autofac;
using Microsoft.AspNetCore.Mvc;
using StoreManager.Web.Areas.Manager.Models;
using StoreManager.Web.Models;

namespace StoreManager.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ItemController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<ItemController> _logger;
        public ItemController(ILogger<ItemController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetItems()
        {
            var dataTableAjaxRequestModel = new DataTableAjaxRequestModel(Request);
            var itemListModel = _scope.Resolve<ItemCRUDModel>();


            return Json(await itemListModel.GetPagedItems(dataTableAjaxRequestModel));
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<ItemCRUDModel>();
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Create(ItemCRUDModel itemCreateModel)
        {
            if (ModelState.IsValid)
            {
                itemCreateModel.Resolve(_scope);

                await itemCreateModel.CreateItem();

                return RedirectToAction("Index");
            }

            return View(itemCreateModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<ItemCRUDModel>();
            await model.LoadData(id);
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Edit(ItemCRUDModel itemEditModel)
        {
            if (ModelState.IsValid)
            {
                itemEditModel.Resolve(_scope);

                await itemEditModel.UpdateItem();

                return RedirectToAction("Index");
            }

            return View(itemEditModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var itemDeleteModel = _scope.Resolve<ItemCRUDModel>();
            await itemDeleteModel.DeleteItem(id);

            return RedirectToAction("Index");
        }

    }
}
