using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCTController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductCTController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("github-json-products")]
        public async Task<IActionResult> GetRemoteProducts()
        {
            // 1. Your GitHub Raw link (Ensure it is the "raw" version)
            var githubUrl = "https://raw.githubusercontent.com/Chaitrali-tambe/ChaitraliJson/refs/heads/main/products.json";

            // 2. Create the client
            var client = _httpClientFactory.CreateClient();

            try
            {
                // 3. Fetch the data

                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                var response = await client.GetAsync(githubUrl);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Could not reach GitHub.");

                // 4. Read content as string
                var jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize using your OrderResponse wrapper
                var data = JsonSerializer.Deserialize<ProductCT>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(data?.Product);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error fetching data: {ex.Message}");
            }
        }


        ////below code when json file in the project solution

        //private readonly IWebHostEnvironment _env;

        //public ProductCTController(IWebHostEnvironment env)
        //{
        //    _env = env;
        //}

        //[HttpGet("getAllProducts")]
        //public async Task<IActionResult> GetAllOrders()
        //{
        //    var filepath = Path.Combine(_env.ContentRootPath, "Json", "products.json");

        //    if (!System.IO.File.Exists(filepath))
        //        return NotFound();

        //    string jsonstring = await System.IO.File.ReadAllTextAsync(filepath);

        //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        //    var data = JsonSerializer.Deserialize<ProductCT>(jsonstring, options);

        //    var productList = data?.Product;

        //    return Ok(productList);
    }
}
