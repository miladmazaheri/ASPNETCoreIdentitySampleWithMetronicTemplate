using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.Entities
{
    public class ProductWarehouse
    {
        public string ProductId { get; set; }
        public string WarehouseId { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }

        public long Count { get; set; }
    }
}
