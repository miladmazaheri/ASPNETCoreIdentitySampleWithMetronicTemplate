using Pars.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Pars.Common.EFCoreToolkit;

namespace Pars.DataLayer.SQLite
{
    public class SQLiteDbContext : ApplicationDbContext
    {
        public SQLiteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddDateTimeOffsetConverter();
        }
    }
}