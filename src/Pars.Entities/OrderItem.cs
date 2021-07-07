using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Entities.AuditableEntity;

namespace Pars.Entities
{
    public class OrderItem:IAuditableEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitPrice { get; set; }
        public int Count { get; set; }
        public long Discount { get; set; }
        public int DiscountPercent { get; set; }
        public long TaxPrice { get; set; }
        public long TotalPrice { get; set; }
        public long TotalPurePrice { get; set; }
    }
}
