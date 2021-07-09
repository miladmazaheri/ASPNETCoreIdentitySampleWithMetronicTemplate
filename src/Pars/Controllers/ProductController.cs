using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pars.Services.Contracts;
using Pars.ViewModels.Products;

namespace Pars.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(SearchProductsViewModel model)
        {
            return View(await _productService.GetAllAsync(model));
        }
    }
}
