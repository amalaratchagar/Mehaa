using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.Item
{
    public class IndexModel : PageModel
    {
        private readonly IItemRepositoryAsync _item;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IItemRepositoryAsync item, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _item = item;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.Inventory.Item> Items { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Items = await _item.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.Inventory.Item>>(ViewData, Items)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.Inventory.ItemCategory()) });
            else
            {
                var thisCustomer = await _item.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.Inventory.Item item)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _item.AddAsync(item);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _item.UpdateAsync(item);
                    await _unitOfWork.Commit();
                }
                Items = await _item.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", Items);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", item);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var itemCategory = await _item.GetByIdAsync(id);
            await _item.DeleteAsync(itemCategory);
            await _unitOfWork.Commit();
            Items = await _item.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", Items);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}