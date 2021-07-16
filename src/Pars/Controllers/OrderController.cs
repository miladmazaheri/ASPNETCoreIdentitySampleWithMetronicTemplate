using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pars.Common.Enums;
using Pars.Services.Contracts;
using Pars.Services.Contracts.Identity;
using Pars.Services.Identity;
using Pars.ViewModels;
using Pars.ViewModels.Orders;
using Pars.ViewModels.Products;

namespace Pars.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IApplicationUserManager _userManager;

        public OrderController(IOrderService orderService, IApplicationUserManager userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index([FromQuery] OrderStatus? orderStatus, [FromQuery] int? userId, [FromQuery] string title)
        {
            ViewBag.Title = !string.IsNullOrWhiteSpace(title) ? title : "لیست سفارشات";
            var model = new SearchOrderViewModel
            {
                OrderStatus = orderStatus
            };

            if (!User.IsInRole(ConstantRoles.Admin))
            {
                model.UserId = User.Identity.GetUserId<int>();
            }

            var result = new OrderIndexViewModel
            {
                PagedListViewModel = await _orderService.GetAllForListAsync(model),
                SearchViewModel = model,
                OrderStatuses = new List<SelectListItem>
                {
                    new SelectListItem(OrderStatus.New.GetName(),OrderStatus.New.ToString()),
                    new SelectListItem(OrderStatus.InProgress.GetName(),OrderStatus.InProgress.ToString()),
                    new SelectListItem(OrderStatus.Delivered.GetName(),OrderStatus.Delivered.ToString()),
                }
            };

            if (User.IsInRole(ConstantRoles.Admin))
            {
                result.Users = await _userManager.GetAllForComboAsync();
            }

            return View(result);
        }

        [AjaxOnly, HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Search(SearchOrderViewModel model)
        {
            var result = new PagedListResult<OrderListItemViewModel, SearchOrderViewModel>
            {
                PagedListViewModel = await _orderService.GetAllForListAsync(model),
                SearchViewModel = model,
            };

            return PartialView("_Table", result);
        }



    }
}
