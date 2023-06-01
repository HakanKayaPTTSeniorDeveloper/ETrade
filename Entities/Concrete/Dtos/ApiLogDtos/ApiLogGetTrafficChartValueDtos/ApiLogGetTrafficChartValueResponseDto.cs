using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetTrafficChartValueDtos
{
    public class ApiLogGetTrafficChartValueResponseDto : IDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int MonthlyTraffic { get; set; }
    }
}
