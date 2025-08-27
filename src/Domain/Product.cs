using Volo.Abp.Domain.Entities;

namespace Washyn.Kfc;

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

public class Channel
{
    public string Name { get; set; }
    public string Code { get; set; } // p.ej.: WEB, POS, MKT
    public bool IsActive { get; set; }
}