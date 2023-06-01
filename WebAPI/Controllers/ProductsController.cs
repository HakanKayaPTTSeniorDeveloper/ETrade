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

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var dataResult = await _productService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var dataResult = await _productService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddRequestDto productAddRequestDto)
        {
            var result = await _productService.Add(productAddRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateRequestDto productUpdateRequestDto)
        {
            var result = await _productService.Update(productUpdateRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }






    }
}
