using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetListTopDtos
{
    public class ApiLogGetListTopResponseDto : IDto
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }

        public bool IsNvi { get; set; }
    }
}
