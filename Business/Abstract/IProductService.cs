using Core.Utilities.Results.Abstract;
using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetAllDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetByIdDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IResult> Add(ProductAddRequestDto productAddRequestDto);
        Task<IResult> Update(ProductUpdateRequestDto productUpdateRequestDto);
        Task<IResult> Delete(int id);
        Task<IDataResult<ProductGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<List<ProductGetAllResponseDto>>> GetAll();
    }
}
