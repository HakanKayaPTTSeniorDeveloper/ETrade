using Business.Abstract;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimAddDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimUpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var dataResult = await _userOperationClaimService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var dataResult = await _userOperationClaimService.GetList();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserOperationClaimAddRequestDto userOperationClaimAddRequestDto)
        {
            var result = await _userOperationClaimService.Add(userOperationClaimAddRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UserOperationClaimUpdateRequestDto userOperationClaimUpdateRequestDto)
        {
            var result = await _userOperationClaimService.Update(userOperationClaimUpdateRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userOperationClaimService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var dataResult = await _userOperationClaimService.GetByUserId(userId);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }







    }
}
