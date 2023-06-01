using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetByIdDtos
{
    public class ApiLogGetByIdResponseDto : IDto
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
        public bool IsNvi { get; set; }
    }
}
