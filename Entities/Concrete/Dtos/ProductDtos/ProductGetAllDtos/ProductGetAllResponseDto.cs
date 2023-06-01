using Core.Entities.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dtos.ProductDtos.ProductGetAllDtos
{
    public class ProductGetAllResponseDto : IDto
    {
        public int Id { get; set; }
        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockCount { get; set; }
        public bool IsActive { get; set; }
    }
}
