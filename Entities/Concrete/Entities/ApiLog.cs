using Core.Entities.Abstract;

namespace Entities.Concrete.Entities
{
    public class ApiLog : IEntity
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
        public bool IsNvi { get; set; }
    }
}
