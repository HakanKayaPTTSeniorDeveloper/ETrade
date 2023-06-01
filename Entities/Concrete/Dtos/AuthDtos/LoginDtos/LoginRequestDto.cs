using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.AuthDtos.LoginDtos
{
    public class LoginRequestDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
