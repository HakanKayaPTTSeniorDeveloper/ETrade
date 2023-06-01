using Core.Utilities.Results.Abstract;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetAllDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetByIdDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<List<CategoryGetAllResponseDto>>> GetAll();
        Task<IResult> Add(CategoryAddRequestDto CategoryAddRequestDto);
        Task<IResult> Update(CategoryUpdateRequestDto CategoryUpdateRequestDto);
        Task<IResult> Delete(int id);

    }
}
