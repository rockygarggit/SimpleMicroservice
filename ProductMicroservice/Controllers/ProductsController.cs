using Commons.Consts;
using Commons.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Services;
using System;
using System.Collections.Generic;

namespace ProductMicroservice.Controllers
{
    [Authorize]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [Authorize(Roles = RoleConsts.ROLE_USER)]
        [HttpGet]
        public ActionResult<List<ProductDetail>> HandleGetAllProducts()
        {
            return Ok(this._productService.GetAll());
        }

        [Authorize(Roles = RoleConsts.ROLE_USER)]
        [HttpGet("{productId}")]
        public ActionResult<ProductDetail> HandleGetOneUserByUuid(int productId)
        {

            if (productId == 0) throw new Exception("Product Not found");
            return Ok(this._productService.GetOneByProductById(productId));
        }
    }
}
