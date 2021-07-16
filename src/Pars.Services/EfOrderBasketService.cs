using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
using Pars.Common.Enums;
using Pars.DataLayer.Context;
using Pars.Entities;
using Pars.Services.Contracts;
using Pars.Services.Contracts.Identity;
using Pars.ViewModels.Orders;
using Z.BulkOperations;

namespace Pars.Services
{
    public class EfOrderBasketService : IOrderBasketService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<OrderBasket> _orderBaskets;
        private readonly DbSet<Product> _products;
        private readonly DbSet<Order> _orders;
        private readonly IApplicationUserManager _applicationUserManager;

        public EfOrderBasketService(IUnitOfWork uow, IApplicationUserManager applicationUserManager)
        {
            _uow = uow;
            _applicationUserManager = applicationUserManager;
            _orderBaskets = uow.Set<OrderBasket>();
            _products = uow.Set<Product>();
            _orders = uow.Set<Order>();
        }

        public async Task AddAsync(int userId, string productId, int count = 1)
        {
            var item = await _orderBaskets.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (item != null)
            {
                var unitPrice = item.Price / item.Count;
                item.Count += count;
                item.Price = unitPrice * item.Count;
                _orderBaskets.Update(item);
                await _uow.SaveChangesAsync();
            }
            else
            {
                var product = await _products.FirstOrDefaultAsync(x => x.Id == productId);
                if (product != null)
                {
                    item = new OrderBasket
                    {
                        Id = Guid.NewGuid(),
                        Name = product.Name,
                        Count = count,
                        ProductId = productId,
                        CreationDate = DateTime.Now,
                        PictureAddress = product.Picture,
                        Price = product.Price * count,
                        UserId = userId
                    };
                    await _orderBaskets.SingleInsertAsync(item);
                }
            }
        }

        public async Task SubtractAsync(int userId, string productId, int count = 1)
        {
            var item = await _orderBaskets.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (item != null)
            {
                if (item.Count - count < 1)
                {
                    await _orderBaskets.SingleDeleteAsync(item);
                }
                else
                {
                    var unitPrice = item.Price / item.Count;
                    item.Count -= count;
                    item.Price = unitPrice * item.Count;
                    _orderBaskets.Update(item);
                    await _uow.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveAsync(int userId, Guid id)
        {
            await _orderBaskets.Where(x => x.Id == id && x.UserId == userId).DeleteFromQueryAsync();
        }

        public async Task ClearAsync(int userId)
        {
            await _orderBaskets.Where(x => x.UserId == userId).DeleteFromQueryAsync();
        }

        public Task<List<OrderBasket>> GetAllAsync(int userId)
        {
            return _orderBaskets.Where(x => x.UserId == userId).OrderBy(x => x.CreationDate).ToListAsync();
        }

        public async Task<List<SubmitOrderItemDto>> GetAllForSubmitAsync(int userId)
        {
            var data = await (from o in _orderBaskets.Where(x => x.UserId == userId)
                              join p in _products on o.ProductId equals p.Id
                              select new SubmitOrderItemDto
                              {
                                  Count = o.Count,
                                  Name = p.Name,
                                  PictureAddress = p.Picture,
                                  ProductId = p.Id,
                                  UnitPrice = p.Price,
                                  OrderBasketId = o.Id
                              }).ToListAsync();

            data.ForEach(item =>
            {
                item.Discount = 0;
                item.DiscountPercent = 0;
                item.TotalPrice = item.UnitPrice * item.Count;
                item.TaxPrice = (long)Math.Round(item.TotalPrice * 0.09);
                item.TotalPurePrice = item.TotalPrice + item.TaxPrice - item.Discount;
            });

            return data;
        }

        public async Task SubmitAsync(int userId)
        {
            if (!await _orderBaskets.AnyAsync(x => x.UserId == userId)) return;
            var refUserId = await _applicationUserManager.GetReferralUserIdAsync(userId);
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderStatus = OrderStatus.New,
                ReferralUserId = refUserId,
                UserId = userId,
                Title = $"سفارش تاریخ {DateTime.Now.ToShortPersianDateTimeString()}",
                OrderItems = (await GetAllForSubmitAsync(userId)).Select(x => new OrderItem
                {
                    Count = x.Count,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    ProductId = x.ProductId,
                    TaxPrice = x.TaxPrice,
                    TotalPrice = x.TotalPrice,
                    TotalPurePrice = x.TotalPurePrice,
                    UnitPrice = x.UnitPrice,
                }).ToList(),
            };
            order.TotalPrice = order.OrderItems.Sum(x => x.TotalPrice);
            order.DiscountPrice = order.OrderItems.Sum(x => x.Discount);
            order.TaxPrice = order.OrderItems.Sum(x => x.TaxPrice);
            order.PurePrice = order.OrderItems.Sum(x => x.TotalPurePrice);

            await _orders.AddAsync(order);
            await _uow.SaveChangesAsync();

        }
    }
}
