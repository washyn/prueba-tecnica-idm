using Volo.Abp.Domain.Entities;

namespace Washyn.Kfc;

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public string Sku { get; set; }

    protected Product()
    {
    }

    public Product(Guid id, string name, string sku) : base(id)
    {
        Name = name;
        Sku = sku;
    }
}