using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.Products
{
    public class ProductListItemViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public string Size { get; set; }
        public string Code { get; set; }
        public string CountInBox { get; set; }

        public string Picture { get; set; }

        public long Stock { get; set; }
    }

    public class SearchProductsViewModel
    {
        public string Name { get; set; }
        public string Sort { get; set; }
        public string CategoryId { get; set; }
        public string Size { get; set; }

        [Display(Name = "تعداد ردیف بازگشتی")]
        [Required(ErrorMessage = "(*)")]
        [Range(1, 1000, ErrorMessage = "عدد وارد شده باید در بازه 1 تا 1000 تعیین شود")]
        public int MaxNumberOfRows { set; get; } = 10;

        public int PageNumber { get; set; } = 0;

        public string WarehouseId { get; set; }
    }

}
