using Commons.DTO.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CartMicroservice.Services
{
    public interface ICartService
    {
        Task<CartResponseDto> GetCart();
    }
}
