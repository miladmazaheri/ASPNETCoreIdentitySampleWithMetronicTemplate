using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pars.ViewModels.Products
{
    public class ProductIndexViewModel : PagedListResult<ProductListItemViewModel, SearchProductsViewModel>
    {
        public List<SelectListItem> Warehouses { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
