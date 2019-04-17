using Komis.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Komis.Infrastructure.EF
{
    public class DBContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Car> Cars { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Image> Images { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

      
    }

}

