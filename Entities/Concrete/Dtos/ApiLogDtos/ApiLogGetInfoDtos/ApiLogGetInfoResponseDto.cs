using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetInfoDtos
{
    public class ApiLogGetInfoResponseDto
    {
        public int MonthlyInfo { get; set; }
        public decimal PercentChangePreviousMonth { get; set; }
    }
}
