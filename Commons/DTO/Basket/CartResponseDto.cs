using Commons.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons.DTO.Cart
{
    public class CartResponseDto
    {
        public CartResponseDto()
        {
            items = new List<CartItem>();
            /*  items = new List<CartItem>();

              var products =new  List<ProductDetail>();
              products.Add(new ProductDetail { ProductDescription = "Awesome Table", ProductId = 1, ProductName = "Simple Table", ProductPrice = 500.0M });
              products.Add(new ProductDetail { ProductDescription = "Awesome Chair", ProductId = 2, ProductName = "Simple Chair", ProductPrice = 200.0M });
              products.Add(new ProductDetail { ProductDescription = "Awesome Sofa", ProductId = 3, ProductName = "Simple Sofa", ProductPrice = 800.0M });
              products.Add(new ProductDetail { ProductDescription = "Awesome Coffee Table", ProductId = 4, ProductName = "Simple Coffee Table", ProductPrice = 300.0M });
              products.Add(new ProductDetail { ProductDescription = "Awesome End Table", ProductId = 4, ProductName = "Simple End Table", ProductPrice = 150.0M });

              items.Add(new CartItem() { productDetail = products[0], quantiy = 1 });
              items.Add(new CartItem() { productDetail = products[1], quantiy = 2 });
              items.Add(new CartItem() { productDetail = products[2], quantiy = 4 });
              items.Add(new CartItem() { productDetail = products[3], quantiy = 1 });
              items.Add(new CartItem() { productDetail = products[4], quantiy = 3 });
            */

        }
        public List<CartItem> items { get; set; }
        public decimal cartTotal
        {
            get => this.items.Sum(x => x.ItemTotal);
        }
    }

    public class CartItem
    {
        public CartItem()
        {
            this.productDetail = new ProductDetail();
        }

        public ProductDetail productDetail { get; set; }
        public int quantiy { get; set; }

        public decimal ItemTotal
        {
            get => this.productDetail.ProductPrice * this.quantiy; 
        }
    }
}
