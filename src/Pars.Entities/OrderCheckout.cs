using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Entities.AuditableEntity;

namespace Pars.Entities
{
    public class OrderCheckout : IAuditableEntity
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public long Price { get; set; }
        public string BankName { get; set; }
        public string ReferenceNumber { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
