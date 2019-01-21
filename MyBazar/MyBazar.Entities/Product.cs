using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBazar.Entities
{
    public class Product:BaseEntity
    {
        public Decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
