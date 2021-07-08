using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.Common.Enums;
using Pars.Services.Contracts;
using Pars.ViewModels;
using Pars.ViewModels.Orders;
using Pars.ViewModels.Public;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<NameIdViewModel<int>>> GetAllOrderStatus()
        {
            return new(new List<NameIdViewModel<int>>()
            {
                new((int)OrderStatus.New,"سفارشات جدید"),
                new((int)OrderStatus.InProgress,"سفارشات در حال تولید"),
                new((int)OrderStatus.Delivered,"سفارشات تحویل شده"),
            });
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetAsync([FromQuery] long orderId)
        {
            return new ActionResult<OrderDto>(await _orderService.GetAsync(orderId));
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllAsync([FromQuery]SearchOrdersViewModel input)
        {
            return new ActionResult<List<OrderDto>> (await _orderService.GetAllAsync(input));
        }

    }
}
