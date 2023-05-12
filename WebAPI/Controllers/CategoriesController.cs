using Business.Abstract;
using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using Entity.Concrete.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task< IActionResult> Add(CategoryAddRequestDto categoryAddRequestDto)
        {
           var result=await _categoryService.Add(categoryAddRequestDto);
            return Ok(result);
        }

        [HttpGet("getByName")]
        public async Task< IActionResult> GetByName(string categoryName)
        {
            var dataResult =await _categoryService.GetByName(categoryName);
            return Ok(dataResult);
        }
    }
}
