using Shouldly;
using Volo.Abp.Application.Dtos;
using Washyn.Kfc.Products;
using Xunit;
using Xunit.Abstractions;

namespace Api.Tests.Controllers;

public class ProductControllerTest: AppApiTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ProductControllerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async Task Test_Product_Create_List_And_Get()
    {
        // Arrange
        var path = "api/products";
        
        // Act
        var data = await GetJsonAsync<PagedResultDto<ProductDto>>(path);
        
        // Assert
        data.TotalCount.ShouldBe(0);
        data.Items.ShouldBeEmpty();
        _testOutputHelper.WriteLine("End test");
    }
}