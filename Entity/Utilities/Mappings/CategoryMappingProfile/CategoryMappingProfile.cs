using AutoMapper;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Utilities.Mappings.CategoryMappingProfile
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryAddRequestDto>();
            CreateMap<CategoryAddRequestDto, Category>();
        }
    }
}
