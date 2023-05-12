using Business.Abstract;
using Entity.Concrete.Dtos.AuthDtos.AuthLoginDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;
        public AuthsController(IAuthService authService)
        {

            _authService = authService;

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
          var result= _authService.Login(loginRequestDto);

           return Ok(result);

        }
    }
}
