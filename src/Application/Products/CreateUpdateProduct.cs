using Volo.Abp.Application.Dtos;

namespace Washyn.Kfc.Products;

public class CreateUpdateProduct : EntityDto
{
    public string Name { get; set; }
    public string Sku { get; set; }
}