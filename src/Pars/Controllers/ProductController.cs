using System.Linq;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Mvc;
using Pars.Services.Contracts;
using Pars.ViewModels;
using Pars.ViewModels.Products;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pars.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;

        public ProductController(IProductService productService, ICategoryService categoryService, IWarehouseService warehouseService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string categoryId, [FromQuery] string warehouseId)
        {
            var model = new SearchProductsViewModel() { CategoryId = categoryId, WarehouseId = warehouseId };
            var result = new ProductIndexViewModel
            {
                PagedListViewModel = await _productService.GetAllAsync(model),
                SearchViewModel = model,
                Warehouses = (await _warehouseService.GetAllForDropDownAsync())
                    .Select(x =>
                        new SelectListItem(x.Name, x.Id,
                            !string.IsNullOrWhiteSpace(warehouseId) && x.Id == warehouseId)).ToList(),
                Categories = (await _categoryService.GetAllForDropDownAsync())
                    .Select(x =>
                        new SelectListItem(x.Name, x.Id, !string.IsNullOrWhiteSpace(categoryId) && x.Id == categoryId))
                    .ToList(),
            };

            return View(result);
        }

        [AjaxOnly, HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Search(SearchProductsViewModel model)
        {
            var result = new PagedListResult<ProductListItemViewModel, SearchProductsViewModel>
            {
                PagedListViewModel = await _productService.GetAllAsync(model),
                SearchViewModel = model,
            };

            return PartialView("_Table", result);
        }
    }
}
