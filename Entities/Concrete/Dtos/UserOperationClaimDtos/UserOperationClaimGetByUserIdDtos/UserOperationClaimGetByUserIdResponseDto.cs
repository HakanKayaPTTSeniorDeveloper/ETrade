using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByUserIdDtos
{
    public class UserOperationClaimGetByUserIdResponseDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public bool IsActive { get; set; }
    }
}
