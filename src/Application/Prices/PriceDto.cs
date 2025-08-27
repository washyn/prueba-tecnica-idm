namespace Washyn.Kfc.Prices;

public class PriceDto
{
    public Guid ProductId { get; set; }
    public string ChannelId { get; set; }
    
    public required string Currency { get; set; }

    public ProductDto? Product { get; set; }
    public Channel? Channel { get; set; }
}