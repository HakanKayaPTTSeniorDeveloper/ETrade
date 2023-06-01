using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.CategoryValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetAllDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryGetByIdDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [SecurityAspect("Category.Add", Priority = 2)]
        [ValidationAspect(typeof(CategoryAddRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 4)]
        public async Task<IResult> Add(CategoryAddRequestDto CategoryAddRequestDto)
        {
            var category = _mapper.Map<Category>(CategoryAddRequestDto);
            await _categoryDal.Add(category);
            return new SuccessResult(CategoryMessages.Added);
        }

        [SecurityAspect("Category.Delete", Priority = 2)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 3)]
        public async Task<IResult> Delete(int id)
        {
            var category = await _categoryDal.Get(x => x.Id == id && x.IsActive == true);
            if (category != null)
            {
                category.IsActive = false;
                await _categoryDal.Update(category);
                return new SuccessResult(CategoryMessages.Deleted);

            }

            return new ErrorResult(CategoryMessages.OperationFailed);
        }

        [SecurityAspect("Category.GetById", Priority = 2)]
        public async Task<IDataResult<CategoryGetByIdResponseDto>> GetById(int id)
        {
            var category = await _categoryDal.Get(x => x.Id == id && x.IsActive == true);
            var categoryGetByIdResponseDto = _mapper.Map<CategoryGetByIdResponseDto>(category);
            return new SuccessDataResult<CategoryGetByIdResponseDto>(categoryGetByIdResponseDto);
        }

        [SecurityAspect("Category.GetList", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<CategoryGetAllResponseDto>>> GetAll()
        {
            var categorys = await _categoryDal.GetList(x => x.IsActive == true);
            var categoryGetAllResponseDtos = _mapper.Map<List<CategoryGetAllResponseDto>>(categorys);
            categoryGetAllResponseDtos = categoryGetAllResponseDtos.OrderBy(x => x.Name).ToList();
            return new SuccessDataResult<List<CategoryGetAllResponseDto>>(categoryGetAllResponseDtos);
        }

        [SecurityAspect("Category.Update", Priority = 2)]
        [ValidationAspect(typeof(CategoryUpdateRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 4)]
        public async Task<IResult> Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateRequestDto);
            if (category != null)
            {
                await _categoryDal.Update(category);
                return new SuccessResult(CategoryMessages.Updated);
            }

            return new ErrorResult(CategoryMessages.OperationFailed);
        }

















    }
}
