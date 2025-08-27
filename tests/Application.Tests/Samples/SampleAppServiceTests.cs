using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Washyn.Kfc.Products;
using Xunit;

namespace ERP.SYSTEM.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public class SampleAppServiceTests:SYSTEMApplicationTestBase
{
    private readonly IProductsAppService _productsAppService;

    public SampleAppServiceTests()
    {
        _productsAppService = GetRequiredService<IProductsAppService>();
    }

    // [Fact]
    // public async Task Initial_Data_Should_Contain_Sample_Data()
    // {
    //     //Act
    //     var result = await _boardAppService.GetListAsync(new PagedAndSortedResultRequestDto());
    //     
    //     //Assert
    //     result.TotalCount.ShouldBeGreaterThan(0);
    // }
    
    [Fact]
    public async Task SAMPLE()
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
