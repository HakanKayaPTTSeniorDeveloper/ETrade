using Core.Utilities.Results.Abstract;
using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetAllDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetByIdDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<List<ProductGetAllResponseDto>>> GetAll();
        Task<IResult> Add(ProductAddRequestDto ProductAddRequestDto);
        Task<IResult> Update(ProductUpdateRequestDto ProductUpdateRequestDto);
        Task<IResult> Delete(int id);
    }
}
