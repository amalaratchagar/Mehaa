using Core.Interfaces;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.User.Permission
{
    public class IndexModel : PageModel
    {
        private readonly IPermissionRepositoryAsync _permission;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IPermissionRepositoryAsync permission, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _permission = permission;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.User.Permission> Permissions { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Permissions = await _permission.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.User.Permission>>(ViewData, Permissions)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.User.Permission()) });
            else
            {
                var thisCustomer = await _permission.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.User.Permission itemCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _permission.AddAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _permission.UpdateAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                Permissions = await _permission.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", Permissions);
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
            var itemCategory = await _permission.GetByIdAsync(id);
            await _permission.DeleteAsync(itemCategory);
            await _unitOfWork.Commit();
            Permissions = await _permission.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", Permissions);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}