using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dtos.ProductDtos.ProductAddDtos
{
    public class ProductAddRequestDto:IDto
    {
        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockCount { get; set; }
        public bool IsActive { get; set; }
    }
}
