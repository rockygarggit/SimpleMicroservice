using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commons.DTO.Product
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

    }
}
