using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Washyn.Kfc.Controllers;

[Route("api/products")]
public class ProductController : AbpController,IProductsAppService
{
    private readonly IProductsAppService _productAppService;
    public ProductController(IProductsAppService productAppService)
    {
        _productAppService = productAppService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<ProductDto> GetAsync(Guid id)
    {
        return _productAppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _productAppService.GetListAsync(input);
    }

    [HttpPost]
    public async Task<ProductDto> CreateAsync(CreateUpdateProduct input)
    {
        return await _productAppService.CreateAsync(input);
    }
    [Route("{id}")]
    [HttpPut]
    public Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProduct input)
    {
        return _productAppService.UpdateAsync(id, input);
    }
    [Route("{id}")]
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _productAppService.DeleteAsync(id);
    }
}