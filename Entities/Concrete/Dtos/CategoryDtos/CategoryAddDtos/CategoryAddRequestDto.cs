using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos
{
    public class CategoryAddRequestDto:IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
