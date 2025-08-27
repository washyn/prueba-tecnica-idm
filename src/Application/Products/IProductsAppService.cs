using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Washyn.Kfc.Products;

public interface IProductsAppService : ICrudAppService<ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProduct>
{
}