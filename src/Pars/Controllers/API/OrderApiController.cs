﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Orders;
using Pars.ViewModels.Public;
using Pars.Common.Enums;
namespace Pars.Controllers.API
{
    [Route("api/Order/[action]")]
    [ApiController]
    [ApiKey]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<NameIdViewModel<int>>> GetAllOrderStatus()
        {
            return new(new List<NameIdViewModel<int>>()
            {
                new((int)OrderStatus.New,OrderStatus.New.GetName()),
                new((int)OrderStatus.InProgress,OrderStatus.InProgress.GetName()),
                new((int)OrderStatus.Delivered,OrderStatus.Delivered.GetName()),
            });
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetAsync([FromQuery] long orderId)
        {
            return new ActionResult<OrderDto>(await _orderService.GetAsync(orderId));
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllAsync([FromQuery]SearchOrderViewModel input)
        {
            return new ActionResult<List<OrderDto>> (await _orderService.GetAllAsync(input));
        }

    }
}
