using AutoMapper;
using PHVShop.Catalog.API.Models;

namespace PHVShop.Catalog.API.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>()
                .ForMember(obj => obj.CategoryName, src => src.MapFrom(x => x.Category.Name));
        }
    }
}
