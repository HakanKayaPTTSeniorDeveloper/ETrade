using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.UserDtos.UserGetByIdDtos
{
    public class UserGetByIdResponseDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
