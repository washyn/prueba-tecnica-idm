using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Washyn.Kfc
{
    public class AppDbContext : AbpDbContext<AppDbContext>
    {
      public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }
    }
}