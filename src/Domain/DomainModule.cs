using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;

namespace Washyn.Kfc;

[DependsOn(typeof(AbpDddDomainModule))]
public class DomainModule : AbpModule
{
}

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    protected Product()
    {
    }

    public Product(Guid id, string name, decimal price) : base(id)
    {
        Name = name;
        Price = price;
    }
}

public interface IProductRepository : IRepository<Product, Guid>
{
}