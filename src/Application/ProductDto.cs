using Volo.Abp.Application.Dtos;

namespace Washyn.Kfc;

public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    // TODO: remove and use productChannelPrice
    public decimal Price { get; set; }
}