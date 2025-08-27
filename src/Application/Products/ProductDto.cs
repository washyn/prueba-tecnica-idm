using Volo.Abp.Application.Dtos;

namespace Washyn.Kfc.Products;

public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Sku { get; set; }
}