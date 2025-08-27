using Shouldly;
using Volo.Abp.Application.Dtos;
using Washyn.Kfc.Products;
using Xunit;

namespace Application.Tests.Products;

public class ProductAppServiceTests:ApplicationTestBase
{
    private readonly IProductsAppService _productsAppService;

    public ProductAppServiceTests()
    {
        _productsAppService = GetRequiredService<IProductsAppService>();
    }
    
    [Fact]
    public async Task Should_Create_And_Query_Product_AppService()
    {
        // Arrange
        var product = new CreateUpdateProduct()
        {
            Name = "Zapatos",
            Sku = "980243897453"
        };
        
        //Act
        await _productsAppService.CreateAsync(product);
        var result = await _productsAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        
        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(a => a.Name == product.Name);
    }
}
