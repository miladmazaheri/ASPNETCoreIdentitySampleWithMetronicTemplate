using Pars.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Pars.DataLayer.InMemoryDatabase
{
    public class InMemoryDatabaseContext : ApplicationDbContext
    {
        public InMemoryDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}