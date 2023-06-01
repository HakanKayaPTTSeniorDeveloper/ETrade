using Business.Abstract;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var dataResult = await _categoryService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var dataResult = await _categoryService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryAddRequestDto categoryAddRequestDto)
        {
            var result = await _categoryService.Add(categoryAddRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            var result = await _categoryService.Update(categoryUpdateRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }






    }
}
