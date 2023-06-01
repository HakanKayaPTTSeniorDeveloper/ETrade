using Business.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimAddDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimSearch;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimUpdateDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _OperationClaimService;
        public OperationClaimsController(IOperationClaimService OperationClaimService)
        {
            _OperationClaimService = OperationClaimService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var dataResult = await _OperationClaimService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var dataResult = await _OperationClaimService.GetList();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OperationClaimAddRequestDto operationClaimAddRequestDto)
        {
            var result = await _OperationClaimService.Add(operationClaimAddRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(OperationClaimUpdateRequestDto operationClaimUpdateRequestDto)
        {
            var result = await _OperationClaimService.Update(operationClaimUpdateRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _OperationClaimService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(OperationClaimSearchRequestDto operationClaimSearchRequestDto)
        {
            var dataResult = await _OperationClaimService.Search(operationClaimSearchRequestDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }





    }
}
