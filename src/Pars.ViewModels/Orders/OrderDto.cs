using System;
using System.Collections.Generic;
using Pars.Common.Enums;

namespace Pars.ViewModels.Orders
{
   
    public class OrderDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public DateTime? EstimateDateTime { get; set; }

        public long TotalPrice { get; set; }
        public long DiscountPrice { get; set; }
        public long FreightCost { get; set; }
        public long TaxPrice { get; set; }
        public long PurePrice { get; set; }

        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }

        public string FreightName { get; set; }
        public string FreightPhoneNumber { get; set; }

        public int UserId { get; set; }
        public int? ReferralUserId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
        public List<OrderCheckoutDto> OrderCheckouts { get; set; }
    }

    public class OrderItemDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string ProductId { get; set; }
        public long UnitPrice { get; set; }
        public int Count { get; set; }
        public long Discount { get; set; }
        public int DiscountPercent { get; set; }
        public long TaxPrice { get; set; }
        public long TotalPrice { get; set; }
        public long TotalPurePrice { get; set; }
    }

    public class SubmitOrderItemDto : OrderItemDto
    {
        public string Name { get; set; }
        public string PictureAddress { get; set; }
        public Guid OrderBasketId { get; set; }
    }


    public class OrderCheckoutDto
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public long Price { get; set; }
        public string BankName { get; set; }
        public string ReferenceNumber { get; set; }
        public long OrderId { get; set; }
    }
}
