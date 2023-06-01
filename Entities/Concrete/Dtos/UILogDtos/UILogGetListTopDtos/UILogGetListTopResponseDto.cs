using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.UILogDtos.UILogGetListTopDtos
{
    public class UILogGetListTopResponseDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
