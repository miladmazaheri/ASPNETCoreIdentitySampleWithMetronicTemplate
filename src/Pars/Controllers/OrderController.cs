using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pars.ViewModels.Orders;

namespace Pars.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> Index(SearchOrderViewModel input)
        {
            return View();
        }
    }
}
