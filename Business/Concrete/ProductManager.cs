using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.ProductValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
        private IProductDal _ProductDal;
        private IMapper _mapper;
        public ProductManager(IProductDal ProductDal, IMapper mapper)
        {
            _ProductDal = ProductDal;
            _mapper = mapper;
        }

        [SecurityAspect("Product.Add", Priority = 2)]
        [ValidationAspect(typeof(ProductAddRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IProductService.Get", Priority = 4)]
        public async Task<IResult> Add(ProductAddRequestDto ProductAddRequestDto)
        {
            var Product = _mapper.Map<Product>(ProductAddRequestDto);
            await _ProductDal.Add(Product);
            return new SuccessResult(ProductMessages.Added);
        }

        [SecurityAspect("Product.Delete", Priority = 2)]
        [CacheRemoveAspect("IProductService.Get", Priority = 3)]
        public async Task<IResult> Delete(int id)
        {
            var Product = await _ProductDal.Get(x => x.Id == id && x.IsActive == true);
            if (Product != null)
            {
                Product.IsActive = false;
                await _ProductDal.Update(Product);
                return new SuccessResult(ProductMessages.Deleted);

            }

            return new ErrorResult(ProductMessages.OperationFailed);
        }

        [SecurityAspect("Product.GetById", Priority = 2)]
        public async Task<IDataResult<ProductGetByIdResponseDto>> GetById(int id)
        {
            var Product = await _ProductDal.Get(x => x.Id == id && x.IsActive == true);
            var ProductGetByIdResponseDto = _mapper.Map<ProductGetByIdResponseDto>(Product);
            return new SuccessDataResult<ProductGetByIdResponseDto>(ProductGetByIdResponseDto);
        }

        [SecurityAspect("Product.GetList", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ProductGetAllResponseDto>>> GetAll()
        {
            var Products = await _ProductDal.GetList(x => x.IsActive == true);
            var ProductGetAllResponseDtos = _mapper.Map<List<ProductGetAllResponseDto>>(Products);
            ProductGetAllResponseDtos = ProductGetAllResponseDtos.OrderBy(x => x.Name).ToList();
            return new SuccessDataResult<List<ProductGetAllResponseDto>>(ProductGetAllResponseDtos);
        }

        [SecurityAspect("Product.Update", Priority = 2)]
        [ValidationAspect(typeof(ProductUpdateRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IProductService.Get", Priority = 4)]
        public async Task<IResult> Update(ProductUpdateRequestDto ProductUpdateRequestDto)
        {
            var Product = _mapper.Map<Product>(ProductUpdateRequestDto);
            if (Product != null)
            {
                await _ProductDal.Update(Product);
                return new SuccessResult(ProductMessages.Updated);
            }

            return new ErrorResult(ProductMessages.OperationFailed);
        }

















    }
}
