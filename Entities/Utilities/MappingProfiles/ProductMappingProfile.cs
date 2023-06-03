using AutoMapper;
using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetAllDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetByIdDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;
using Entity.Concrete.Entities;

namespace Business.Utilities.MappingProfiles
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductAddRequestDto>();
            CreateMap<ProductAddRequestDto, Product>();

            CreateMap<Product, ProductGetByIdResponseDto>();
            CreateMap<ProductGetByIdResponseDto, Product>();

            CreateMap<Product, ProductGetAllResponseDto>();
            CreateMap<ProductGetAllResponseDto, Product>();

            CreateMap<Product, ProductUpdateRequestDto>();
            CreateMap<ProductUpdateRequestDto, Product>();
        }
    }
}
