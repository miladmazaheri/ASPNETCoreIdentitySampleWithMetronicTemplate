using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Common.Enums;
using Pars.Entities.AuditableEntity;
using Pars.Entities.Identity;

namespace Pars.Entities
{
    public class Order : IAuditableEntity
    {

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderCheckouts = new HashSet<OrderCheckout>();
        }
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
        public User User { get; set; }

        public int? ReferralUserId { get; set; }
        public User ReferralUser { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderCheckout> OrderCheckouts { get; set; }

    }
}
