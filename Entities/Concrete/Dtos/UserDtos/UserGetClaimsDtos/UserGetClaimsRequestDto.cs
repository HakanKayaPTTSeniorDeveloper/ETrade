using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.UserDtos.UserGetClaimsDtos
{
    public class UserGetClaimsRequestDto : IDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
