using Core.Interfaces;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.User.UserPermission
{
    public class IndexModel : PageModel
    {
        private readonly IUserPermissionRepositoryAsync _userPermission;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IUserPermissionRepositoryAsync userPermission, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _userPermission = userPermission;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.User.UserPermission> UserPermissions { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            UserPermissions = await _userPermission.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.User.UserPermission>>(ViewData, UserPermissions)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.User.UserPermission()) });
            else
            {
                var thisCustomer = await _userPermission.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.User.UserPermission itemCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _userPermission.AddAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _userPermission.UpdateAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                UserPermissions = await _userPermission.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", UserPermissions);
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
            var itemCategory = await _userPermission.GetByIdAsync(id);
            await _userPermission.DeleteAsync(itemCategory);
            await _unitOfWork.Commit();
            UserPermissions = await _userPermission.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", UserPermissions);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}