using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.Entities
{
    public class OrderBasket
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
        public string PictureAddress { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
