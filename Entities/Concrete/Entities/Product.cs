using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Entities
{
    public class Product:IEntity
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







