using Pars.Entities.AuditableEntity;

namespace Pars.Entities
{
    public class Product : IAuditableEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public string Size { get; set; }
        public string Code { get; set; }
        public string CountInBox { get; set; }
        public string Material { get; set; }
        public string Usage { get; set; }
        public string BranchSize { get; set; }
        public string Color { get; set; }
        public string Thickness { get; set; }
        public string BoxWeight { get; set; }
        public string InstallationMethod { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }


        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}