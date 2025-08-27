using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Washyn.Kfc;

public class ProductRepository : EfCoreRepository<AppDbContext, Product, Guid>, IProductRepository
{
    public ProductRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}