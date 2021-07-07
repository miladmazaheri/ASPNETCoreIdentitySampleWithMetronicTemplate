using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.Warehouses
{
    public class WarehouseUpdateInput
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        [Required]
        [StringLength(KeyMaxLength)]
        public string Id { get; set; }
        [Required]
        [StringLength(StringMaxLength)]
        public string Name { get; set; }
        public int? UserId { get; set; }
    }
}
