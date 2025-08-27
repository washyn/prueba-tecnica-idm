using Volo.Abp.Domain.Repositories;

namespace Washyn.Kfc;

public interface IProductRepository : IRepository<Product, Guid>
{
}