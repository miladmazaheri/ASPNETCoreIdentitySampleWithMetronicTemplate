using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pars.ViewModels.Products;

namespace Pars.ViewModels.Orders
{
    public class OrderIndexViewModel : PagedListResult<OrderListItemViewModel, SearchOrderViewModel>
    {
        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> OrderStatuses { get; set; }
    }
}
