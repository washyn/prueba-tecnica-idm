using Volo.Abp.Application.Dtos;

namespace Washyn.Kfc;

public class CreateUpdateProduct : EntityDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}