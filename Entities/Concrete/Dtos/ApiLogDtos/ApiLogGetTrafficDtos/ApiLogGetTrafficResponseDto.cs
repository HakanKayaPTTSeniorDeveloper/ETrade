using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetTraficDtos
{
    public class ApiLogGetTrafficResponseDto:IDto
    {
        public int MonthlyTraffic { get; set; }
        public decimal PercentChangePreviousMonth { get; set; }
    }
}
