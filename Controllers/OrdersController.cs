using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OrdersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("github-json-Orders")]
        public async Task<IActionResult> GetAllRemoteOrders()
        {
            try
            {
                var githubUrl = "https://raw.githubusercontent.com/Chaitrali-tambe/ChaitraliJson/refs/heads/main/orders.json";

                // 2. Create the client
                var client = _httpClientFactory.CreateClient();

                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                var response = await client.GetAsync(githubUrl);
                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Could not reach GitHub.");

                // 4. Read content as string
                var jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize using your OrderResponse wrapper
                var data = JsonSerializer.Deserialize<OrdersModel>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(data?.Orders);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error fetching data: {ex.Message}");
            }
        }

    }


}
