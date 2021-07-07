using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.Common.Enums;
using Pars.ViewModels;
using Pars.ViewModels.Public;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class OrderController : ControllerBase
    {
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
        public async Task<ActionResult<OrderDto>> GetOrderAsync(string orderId)
        {
            return new(new OrderDto());
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrdersAsync(GetOrderInput input)
        {
            return new(new List<OrderDto>());
        }

    }
}
