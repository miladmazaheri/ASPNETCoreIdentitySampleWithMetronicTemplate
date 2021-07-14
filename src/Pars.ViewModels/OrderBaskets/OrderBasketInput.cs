using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.OrderBaskets
{
    public class OrderBasketInput
    {
        private const int KeyMaxLength = 64;
        [Required]
        [StringLength(KeyMaxLength)]
        public string ProductId { get; set; }
        public int Count { get; set; } = 1;
    }
}
