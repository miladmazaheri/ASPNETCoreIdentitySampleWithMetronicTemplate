using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.ViewModels.Products;

namespace Pars.ViewModels.Warehouses
{
    public class WarehouseProductUpdateInput
    {
        private const int KeyMaxLength = 64;
        [Required]
        [StringLength(KeyMaxLength)]
        public string WarehouseId { get; set; }

        [Required]
        public List<ProductStock> ProductStocks { get; set; }
    }
    public class ProductStock
    {
        private const int KeyMaxLength = 64;
        [Required]
        [StringLength(KeyMaxLength)]
        public string ProductId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
