using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.ApiLogDtos.ApiLogGetErrorDto
{
    public class ApiLogGetErrorResponseDto:IDto
    {
        public int MonthlyError { get; set; }
        public decimal PercentChangePreviousMonth { get; set; }
    }
}
