using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Consts;
using Commons.DTO.Cart;
using CartMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartMicroservice.Controllers
{
    [Authorize]
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = RoleConsts.ROLE_USER)]
        [HttpGet]
        public async Task<ActionResult<CartResponseDto>> HandleGetBasket()
        {
                return Ok(await this._cartService.GetCart());
        }


    }
}
