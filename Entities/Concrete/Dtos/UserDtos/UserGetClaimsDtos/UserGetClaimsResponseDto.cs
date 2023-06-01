using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.UserDtos.UserGetClaimsDtos
{
    public class UserGetClaimsResponseDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
