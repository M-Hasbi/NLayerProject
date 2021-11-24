using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;

namespace NLayerProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Category, CategoryWithProductDTO>();
            CreateMap<CategoryWithProductDTO, Category>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<ProductWithCategoryDTO, Product>();


        }
    }
}
