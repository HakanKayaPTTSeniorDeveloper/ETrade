using Business.Abstract;
using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddRequestDto productAddRequestDto)
        {
            var result = await _productService.Add(productAddRequestDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateRequestDto productUpdateRequestDto)
        {
            var result = await _productService.Update(productUpdateRequestDto);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            return Ok(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }

    }
}
