using Core.Interfaces;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages.User.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepositoryAsync _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IUserRepositoryAsync user, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _user = user;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<Core.Entities.User.User> Users { get; set; }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Users = await _user.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.User.User>>(ViewData, Users)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.User.User()) });
            else
            {
                var thisCustomer = await _user.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisCustomer) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.User.User itemCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _user.AddAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _user.UpdateAsync(itemCategory);
                    await _unitOfWork.Commit();
                }
                Users = await _user.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", Users);
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
            var itemCategory = await _user.GetByIdAsync(id);
            await _user.DeleteAsync(itemCategory);
            await _unitOfWork.Commit();
            Users = await _user.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", Users);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}