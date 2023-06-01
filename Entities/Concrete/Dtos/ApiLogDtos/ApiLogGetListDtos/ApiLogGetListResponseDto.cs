using Core.Entities.Abstract;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetListDtos
{
    public class ApiLogGetListResponseDto : IDto
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
        public bool IsNvi { get; set; }
    }
}
