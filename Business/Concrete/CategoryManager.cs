using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
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
        public async Task<IResult> Add(CategoryAddRequestDto categoryAddRequestDto)
        {
            var category = _mapper.Map<Category>(categoryAddRequestDto);
            return await _categoryDal.Add(category);
        }

        public async Task<IResult> Delete(CategoryDeleteRequestDto categoryDeleteRequestDto)
        {
            var category = _mapper.Map<Category>(categoryDeleteRequestDto);
            return await _categoryDal.Delete(category);

        }
        public async Task<IDataResult<List<CategoryGetAllResponseDto>>> GetAll()
        {
            var categoriesResult = await _categoryDal.GetList();

            if (categoriesResult.Success)
            {
                if (categoriesResult.Data != null)
                {
                    var categoryGetAllResponseDtos = _mapper.Map<List<CategoryGetAllResponseDto>>(categoriesResult.Data);
                    return new SuccessDataResult<List<CategoryGetAllResponseDto>>(categoryGetAllResponseDtos);
                }
            }
            return new ErrorDataResult<List<CategoryGetAllResponseDto>>(null);
        }

        public async Task<IDataResult<CategoryGetByIdResponseDto>> GetById(int id)
        {
            var categoryDataResult = await _categoryDal.Get(x => x.Id == id);

            if (categoryDataResult.Success)
            {
                if (categoryDataResult.Data != null)
                {
                    var categoryGetByIdResponseDto = _mapper.Map<CategoryGetByIdResponseDto>(categoryDataResult.Data);
                    return new SuccessDataResult<CategoryGetByIdResponseDto>(categoryGetByIdResponseDto);
                }
            }
            return new ErrorDataResult<CategoryGetByIdResponseDto>(null);
        }

        public async Task<IDataResult<CategoryGetByNameResponseDto>> GetByName(string categoryName)
        {
            var categoryDataResult = await _categoryDal.Get(x => x.Name == categoryName);
            if (categoryDataResult.Success)
            {
                if (categoryDataResult.Data != null)
                {
                    var categoryGetByNameResponseDto = _mapper.Map<CategoryGetByNameResponseDto>(categoryDataResult.Data);
                    return new SuccessDataResult<CategoryGetByNameResponseDto>(categoryGetByNameResponseDto);
                }
            }
            return new ErrorDataResult<CategoryGetByNameResponseDto>(null);
        }
        public async Task<IResult> Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateRequestDto);
            return await _categoryDal.Update(category);
        }
    }
}
