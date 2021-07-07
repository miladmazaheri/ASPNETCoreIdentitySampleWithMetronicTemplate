using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.Products
{
    public class ProductWarehouseUpdateInput
    {
        private const int KeyMaxLength = 64;
        [Required]
        [StringLength(KeyMaxLength)]
        public string ProductId { get; set; }

        [Required]
        public List<WarehouseStock> WarehouseStocks { get; set; }

        
    }
    public class WarehouseStock
    {
        private const int KeyMaxLength = 64;
        [Required]
        [StringLength(KeyMaxLength)]
        public string WarehouseId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
