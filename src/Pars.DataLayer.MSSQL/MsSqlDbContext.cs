using Pars.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Pars.DataLayer.MSSQL
{
    public class MsSqlDbContext : ApplicationDbContext
    {
        public MsSqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}