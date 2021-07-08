﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pars.DataLayer.Context;
using Pars.Entities;
using Pars.Services.Contracts;
using Pars.ViewModels.Orders;

namespace Pars.Services
{
    public class EfOrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Order> _orders;

        public EfOrderService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _orders = _uow.Set<Order>();
        }

        public async Task<OrderDto> GetAsync(long orderId)
        {
            var item = await _orders.Include(x => x.OrderItems).Include(x => x.OrderCheckouts).FirstAsync(x => x.Id == orderId);

            return MapToModel(item);
        }

        public async Task<List<OrderDto>> GetAllAsync(SearchOrdersViewModel input)
        {
            var skipRecords = input.PageNumber * input.MaxNumberOfRows;
            var query = _orders.Include(x => x.OrderItems).Include(x => x.OrderCheckouts).AsQueryable();
            if (input.OrderStatus.HasValue)
            {
                query = query.Where(x => x.OrderStatus == input.OrderStatus.Value);
            }

            if (input.FromDate.HasValue)
            {
                query = query.Where(x => x.OrderDate >= input.FromDate.Value);
            }

            if (input.ToDate.HasValue)
            {
                query = query.Where(x => x.OrderDate <= input.ToDate.Value);
            }

            query = query.OrderBy(x => x.Id);

            return await query.Skip(skipRecords).Take(input.MaxNumberOfRows).Select(x => MapToModel(x)).ToListAsync();

        }

        private static OrderDto MapToModel(Order item)
        {
            return new OrderDto
            {
                Id = item.Id,
                UserId = item.UserId,
                FreightPhoneNumber = item.FreightPhoneNumber,
                DeliveryDate = item.DeliveryDate,
                DiscountPrice = item.DiscountPrice,
                DriverName = item.DriverName,
                DriverPhoneNumber = item.DriverPhoneNumber,
                EstimateDateTime = item.EstimateDateTime,
                FreightCost = item.FreightCost,
                FreightName = item.FreightName,
                OrderDate = item.OrderDate,
                OrderStatus = item.OrderStatus,
                PurePrice = item.PurePrice,
                ReferralUserId = item.ReferralUserId,
                TaxPrice = item.TaxPrice,
                Title = item.Title,
                TotalPrice = item.TotalPrice,

                OrderItems = item.OrderItems?.Select(x => new OrderItemDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Count = x.Count,
                    TaxPrice = x.TaxPrice,
                    TotalPrice = x.TotalPrice,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    OrderId = x.OrderId,
                    TotalPurePrice = x.TotalPurePrice,
                    UnitPrice = x.UnitPrice
                }).ToList(),

                OrderCheckouts = item.OrderCheckouts?.Select(x => new OrderCheckoutDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Price = x.Price,
                    BankName = x.BankName,
                    DateTime = x.DateTime,
                    ReferenceNumber = x.ReferenceNumber,
                }).ToList()

            };
        }
    }
}