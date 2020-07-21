using Commons.DTO.Product;
using System.Collections.Generic;

namespace ProductMicroservice.Services
{
    public interface IProductService
    {
        List<ProductDetail> GetAll();
        ProductDetail GetOneByProductById(int productId);
    }
}