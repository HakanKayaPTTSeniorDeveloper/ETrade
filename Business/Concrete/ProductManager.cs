using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetAllDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductGetByIdDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public async Task<IResult> Add(ProductAddRequestDto productAddRequestDto)
        {
            var Product = _mapper.Map<Product>(productAddRequestDto);
            return await _productDal.Add(Product);
        }

        public async Task<IResult> Delete(int id)
        {
            var productResult = await _productDal.Get(x => x.Id == id);
            if (productResult.Success)
            {
                if (productResult.Data != null)
                {
                    return await _productDal.Delete(productResult.Data);
                }
            }
            return new ErrorResult(ProductMessage.Deleted);

        }
        public async Task<IDataResult<List<ProductGetAllResponseDto>>> GetAll()
        {
            var productsResult = await _productDal.GetList();

            if (productsResult.Success)
            {
                if (productsResult.Data != null)
                {
                    var productGetAllResponseDtos = _mapper.Map<List<ProductGetAllResponseDto>>(productsResult.Data);
                    return new SuccessDataResult<List<ProductGetAllResponseDto>>(productGetAllResponseDtos);
                }
            }
            return new ErrorDataResult<List<ProductGetAllResponseDto>>(null);
        }

        public async Task<IDataResult<ProductGetByIdResponseDto>> GetById(int id)
        {
            var productDataResult = await _productDal.Get(x => x.Id == id);

            if (productDataResult.Success)
            {
                if (productDataResult.Data != null)
                {
                    var productGetByIdResponseDto = _mapper.Map<ProductGetByIdResponseDto>(productDataResult.Data);
                    return new SuccessDataResult<ProductGetByIdResponseDto>(productGetByIdResponseDto);
                }
            }
            return new ErrorDataResult<ProductGetByIdResponseDto>(null);
        }
        public async Task<IResult> Update(ProductUpdateRequestDto productUpdateRequestDto)
        {
            var product = _mapper.Map<Product>(productUpdateRequestDto);
            return await _productDal.Update(product);
        }


    }
}
