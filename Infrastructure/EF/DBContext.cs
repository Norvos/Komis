using Komis.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Komis.Infrastructure.EF
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Opinion> Opinions { get; set; }
    }
}
