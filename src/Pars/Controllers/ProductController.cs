using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Mvc;
using Pars.Services.Contracts;
using Pars.ViewModels;
using Pars.ViewModels.Products;
using System.Threading.Tasks;

namespace Pars.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SearchProductsViewModel();
            var result = new PagedListResult<ProductListItemViewModel, SearchProductsViewModel>
            {
                PagedListViewModel = await _productService.GetAllAsync(model),
                SearchViewModel = model,
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
