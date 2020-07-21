using Commons.DTO.Cart;
using Commons.DTO.Product;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication.OAuth;
using Commons.DTO.User;

namespace CartMicroservice.Services
{
    public class CartService : ICartService
    {

        public async Task<CartResponseDto>  GetCart()
        {
            CartResponseDto response = new CartResponseDto();
            
            string accessToken = await GetAccessToken();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44396"); 
            client.DefaultRequestHeaders.Authorization =   new AuthenticationHeaderValue("Bearer", accessToken);

            for (int i = 1; i < 5; i++)
            {
                HttpResponseMessage clientResponse = await client.GetAsync($"/api/Products/{i}");

                if (clientResponse.IsSuccessStatusCode)
                {
                    ProductDetail product = await System.Text.Json.JsonSerializer.DeserializeAsync<ProductDetail>(await clientResponse.Content.ReadAsStreamAsync(),new JsonSerializerOptions { PropertyNameCaseInsensitive  = true});
                    response.items.Add(new CartItem { productDetail = product,quantiy = i});
                }
            }

            return response;
        }

        private async Task<string> GetAccessToken()
        {
            HttpClient client = new HttpClient();
            string baseUri = "http://localhost:40000/api/auth/sign-in";

            SignInRequestDTO requestDTO = new SignInRequestDTO { username = "sys", password = "SysPass" };

            var json = System.Text.Json.JsonSerializer.Serialize(requestDTO);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var result = await client.PostAsync(baseUri, stringContent);

            SignInResponseDTO resultContent =  await System.Text.Json.JsonSerializer.DeserializeAsync<SignInResponseDTO>(await result.Content.ReadAsStreamAsync());

                       
            return resultContent.token;

        }
    }
}
