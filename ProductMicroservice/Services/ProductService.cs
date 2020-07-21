using Commons.DTO.Product;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductService
    {
        private List<ProductDetail> products = new List<ProductDetail>();

        public ProductService()
        {
            products.Add(new ProductDetail { ProductDescription = "Awesome Table", ProductId = 1, ProductName = "Simple Table", ProductPrice = 500.0M });
            products.Add(new ProductDetail { ProductDescription = "Awesome Chair", ProductId = 2, ProductName = "Simple Chair", ProductPrice = 200.0M });
            products.Add(new ProductDetail { ProductDescription = "Awesome Sofa", ProductId = 3, ProductName = "Simple Sofa", ProductPrice = 800.0M });
            products.Add(new ProductDetail { ProductDescription = "Awesome Coffee Table", ProductId = 4, ProductName = "Simple Coffee Table", ProductPrice = 300.0M });
            products.Add(new ProductDetail { ProductDescription = "Awesome End Table", ProductId = 4, ProductName = "Simple End Table", ProductPrice = 150.0M });

        }

        public List<ProductDetail> GetAll()
        {
            return this.products;
        }

        public ProductDetail GetOneByProductById(int productId)
        {
            return this.products.Where(x => x.ProductId == productId).FirstOrDefault();
        }
    }
}
