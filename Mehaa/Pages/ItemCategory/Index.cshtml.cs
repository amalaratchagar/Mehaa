using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.ItemCategory
{
    public class IndexModel : PageModel
    {
        private readonly IItemCategoryRepositoryAsync _itemCategory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IItemCategoryRepositoryAsync itemCategory, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _itemCategory = itemCategory;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.Inventory.ItemCategory> ItemCategories { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            ItemCategories = await _itemCategory.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.Inventory.ItemCategory>>(ViewData, ItemCategories)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.Inventory.ItemCategory()) });
            else
            {
                var thisCustomer = await _itemCategory.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.Inventory.ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _itemCategory.AddAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _itemCategory.UpdateAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                ItemCategories = await _itemCategory.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", ItemCategories);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", itemCategory);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var itemCategory = await _itemCategory.GetByIdAsync(id);
            await _itemCategory.DeleteAsync(itemCategory);
            await _unitOfWork.Commit();
            ItemCategories = await _itemCategory.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", ItemCategories);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}