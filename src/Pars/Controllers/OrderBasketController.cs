using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Authorization;
using Pars.Services.Contracts;
using Pars.ViewModels.OrderBaskets;
using Pars.ViewModels.Orders;

namespace Pars.Controllers
{
    [Authorize]
    public class OrderBasketController : Controller
    {
        private readonly IOrderBasketService _orderBasketService;

        public OrderBasketController(IOrderBasketService orderBasketService)
        {
            _orderBasketService = orderBasketService;
        }

        [AjaxOnly, HttpGet]
        public async Task<IActionResult> Add(OrderBasketInput input)
        {
            var userId = User.Identity.GetUserId<int>();
            await _orderBasketService.AddAsync(userId, input.ProductId, input.Count);
            return await Card();
        }

        [AjaxOnly, HttpGet]
        public async Task<IActionResult> Subtract(OrderBasketInput input)
        {
            var userId = User.Identity.GetUserId<int>();
            await _orderBasketService.SubtractAsync(userId, input.ProductId, input.Count);
            return await Card();
        }

        [AjaxOnly, HttpGet]
        public async Task<IActionResult> Remove(Guid id)
        {
            var userId = User.Identity.GetUserId<int>();
            await _orderBasketService.RemoveAsync(userId, id);
            return await Card();
        }

        [AjaxOnly, HttpGet]
        public async Task<IActionResult> Clear()
        {
            var userId = User.Identity.GetUserId<int>();
            await _orderBasketService.ClearAsync(userId);
            return await Card();
        }
        [AjaxOnly, HttpGet]
        public async Task<IActionResult> Card()
        {
            var userId = User.Identity.GetUserId<int>();
            var model = await _orderBasketService.GetAllAsync(userId);
            return PartialView("_OrderBasket", model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var model = await _orderBasketService.GetAllForSubmitAsync(userId);
            return View(model);
        }
    }
}
