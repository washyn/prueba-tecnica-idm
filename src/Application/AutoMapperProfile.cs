using AutoMapper;
using Washyn.Kfc.Products;

namespace Washyn.Kfc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateUpdateProduct>().ReverseMap();
        }
    }
}