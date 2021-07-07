using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.Products
{
    public class ProductUpdateInput
    {
        private const int KeyMaxLength = 64;
        private const int StringMaxLength = 128;
        [Required]
        [StringLength(KeyMaxLength)]
        public string Id { get; set; }
        [Required]
        [StringLength(StringMaxLength)]
        public string Name { get; set; }
        [Required]
        public long Price { get; set; }

        [StringLength(StringMaxLength)]
        public string Size { get; set; }
        [StringLength(StringMaxLength)]
        public string Code { get; set; }
        [StringLength(StringMaxLength)]
        public string CountInBox { get; set; }
        [StringLength(StringMaxLength)]
        public string Material { get; set; }
        [StringLength(StringMaxLength)]
        public string Usage { get; set; }
        [StringLength(StringMaxLength)]
        public string BranchSize { get; set; }
        [StringLength(StringMaxLength)]
        public string Color { get; set; }
        [StringLength(StringMaxLength)]
        public string Thickness { get; set; }
        [StringLength(StringMaxLength)]
        public string BoxWeight { get; set; }
        public string InstallationMethod { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        [StringLength(KeyMaxLength)]
        public string CategoryId { get; set; }
    }
}
