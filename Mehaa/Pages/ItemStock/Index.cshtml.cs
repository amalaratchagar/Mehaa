using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.ItemStock
{
    public class IndexModel : PageModel
    {
        private readonly IItemStockRepositoryAsync _itemStock;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IItemStockRepositoryAsync itemStock, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _itemStock = itemStock;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.Inventory.ItemStock> ItemStocks { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            ItemStocks = await _itemStock.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.Inventory.ItemStock>>(ViewData, ItemStocks)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.Inventory.ItemStock()) });
            else
            {
                var thisStock = await _itemStock.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisStock) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.Inventory.ItemStock itemStock)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _itemStock.AddAsync(itemStock);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _itemStock.UpdateAsync(itemStock);
                    await _unitOfWork.Commit();
                }
                ItemStocks = await _itemStock.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", ItemStocks);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", itemStock);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var itemStock = await _itemStock.GetByIdAsync(id);
            await _itemStock.DeleteAsync(itemStock);
            await _unitOfWork.Commit();
            ItemStocks = await _itemStock.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", ItemStocks);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}