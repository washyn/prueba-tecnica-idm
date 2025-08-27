using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Washyn.Kfc.Products;

public class ProductsAppService :
    CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProduct>, IProductsAppService
{
    private readonly ILogger<ProductsAppService> _logger;

    public ProductsAppService(IProductRepository productRepository, ILogger<ProductsAppService> logger)
        : base(productRepository)
    {
        _logger = logger;
    }

    public async Task<ProductDto> CreateAsync(CreateUpdateProduct input)
    {
        _logger.LogInformation("Create product logger...............................");
        var product = ObjectMapper.Map<CreateUpdateProduct, Product>(input);
        var result = await Repository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(result);
    }

    public override Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return base.GetListAsync(input);
    }

    public override Task<ProductDto> GetAsync(Guid id)
    {
        return base.GetAsync(id);
    }

    public override Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProduct input)
    {
        return base.UpdateAsync(id, input);
    }

    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }
}