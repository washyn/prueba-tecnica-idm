using AutoMapper;

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