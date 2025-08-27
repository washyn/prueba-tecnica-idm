using Shouldly;
using Washyn.Kfc;
using Xunit;

namespace Domain.Tests.Products;

public class ProductTests : DomainTestBase
{
    public ProductTests()
    {
    }
    
    [Fact]
    public void Should_Create_Product()
    {
        var sku = "45328670";
        var product = new Product(Guid.NewGuid(), "Prod", sku);
        
        product.Sku.ShouldBe(sku);
    }
}