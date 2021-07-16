using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Common.Enums;

namespace Pars.ViewModels.Orders
{
    public class SearchOrderViewModel
    {

        [Display(Name = "کاربر")]
        public int? UserId { get; set; }
        [Display(Name = "از تاریخ")]
        public DateTime? FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public DateTime? ToDate { get; set; }
        [Display(Name = "وضعیت")]
        public OrderStatus? OrderStatus { get; set; }

        [Display(Name = "تعداد ردیف بازگشتی")]
        [Required(ErrorMessage = "(*)")]
        [Range(1, 1000, ErrorMessage = "عدد وارد شده باید در بازه 1 تا 1000 تعیین شود")]
        public int MaxNumberOfRows { set; get; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}
