using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Web.Services;

namespace Web.Pages.Supplier
{
public class IndexModel : PageModel
{
    private readonly ISupplierRepositoryAsync _supplier;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRazorRenderService _renderService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, ISupplierRepositoryAsync Supplier, IUnitOfWork unitOfWork, IRazorRenderService renderService)
    {
        _logger = logger;
        _supplier = Supplier;
        _unitOfWork = unitOfWork;
        _renderService = renderService;
    }
    public IEnumerable<Core.Entities.Supplier> Suppliers { get; set; }
    public void OnGet()
    {
    }
    public async Task<PartialViewResult> OnGetViewAllPartial()
    {
        Suppliers = await _supplier.GetAllAsync();
        return new PartialViewResult
        {
            ViewName = "_ViewAll",
            ViewData = new ViewDataDictionary<IEnumerable<Core.Entities.Supplier>>(ViewData, Suppliers)
        };
    }
    public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
    {
        if (id == 0)
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Core.Entities.Supplier()) });
        else
        {
            var thisSupplier = await _supplier.GetByIdAsync(id);
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisSupplier) });
        }
    }
    public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Core.Entities.Supplier Supplier)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await _supplier.AddAsync(Supplier);
                await _unitOfWork.Commit();
            }
            else
            {
                await _supplier.UpdateAsync(Supplier);
                await _unitOfWork.Commit();
            }
            Suppliers = await _supplier.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", Suppliers);
            return new JsonResult(new { isValid = true, html = html });
        }
        else
        {
            var html = await _renderService.ToStringAsync("_CreateOrEdit", Supplier);
            return new JsonResult(new { isValid = false, html = html });
        }
    }
    public async Task<JsonResult> OnPostDeleteAsync(int id)
    {
        var Supplier = await _supplier.GetByIdAsync(id);
        await _supplier.DeleteAsync(Supplier);
        await _unitOfWork.Commit();
        Suppliers = await _supplier.GetAllAsync();
        var html = await _renderService.ToStringAsync("_ViewAll", Suppliers);
        return new JsonResult(new { isValid = true, html = html });
    }
}
}
