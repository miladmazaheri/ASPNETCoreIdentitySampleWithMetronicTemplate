using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Common.Enums;

namespace Pars.ViewModels.Orders
{
    public class SearchOrderViewModel
    {
        public DateTime? FromDate  { get; set; }
        public DateTime? ToDate { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
