using Core.Utilities.Results.Abstract;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryDeleteDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetAllDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetByIdDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetByNameDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IResult> Add(CategoryAddRequestDto categoryAddRequestDto);
        Task<IResult> Update(CategoryUpdateRequestDto categoryUpdateRequestDto);
        Task<IResult> Delete(CategoryDeleteRequestDto categoryDeleteRequestDto);
        Task<IDataResult<CategoryGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<CategoryGetByNameResponseDto>> GetByName(string categoryName);
        Task<IDataResult<List<CategoryGetAllResponseDto>>> GetAll();
    }
}
