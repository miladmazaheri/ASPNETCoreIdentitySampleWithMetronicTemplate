using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Entities.AuditableEntity;
using Pars.Entities.Identity;

namespace Pars.Entities
{
    public class Warehouse:IAuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
