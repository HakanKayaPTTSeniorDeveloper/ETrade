using AutoMapper;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetAllDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetByIdDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using Entity.Concrete.Entities;

namespace Business.Utilities.MappingProfiles
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryAddRequestDto>();
            CreateMap<CategoryAddRequestDto, Category>();

            CreateMap<Category, CategoryGetByIdResponseDto>();
            CreateMap<CategoryGetByIdResponseDto, Category>();

            CreateMap<Category, CategoryGetAllResponseDto>();
            CreateMap<CategoryGetAllResponseDto, Category>();

            CreateMap<Category, CategoryUpdateRequestDto>();
            CreateMap<CategoryUpdateRequestDto, Category>();
        }
    }
}
