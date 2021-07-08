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
    public class WarehouseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
    public class SearchWarehousesViewModel
    {
        public string Name { get; set; }
        public int? UserId { get; set; }
        [Display(Name = "تعداد ردیف بازگشتی")]
        [Required(ErrorMessage = "(*)")]
        [Range(1, 1000, ErrorMessage = "عدد وارد شده باید در بازه 1 تا 1000 تعیین شود")]
        public int MaxNumberOfRows { set; get; }

        public int PageNumber { get; set; }
    }
}
