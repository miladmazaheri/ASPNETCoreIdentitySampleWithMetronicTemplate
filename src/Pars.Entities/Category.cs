using System.Collections.Generic;
using Pars.Entities.AuditableEntity;

namespace Pars.Entities
{
    public class Category : IAuditableEntity
    {
        public string Id { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}