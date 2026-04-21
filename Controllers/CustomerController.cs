using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("github-json-category")]
        public async Task<IActionResult> AllCategories()
        {
            try
            {
                var githubUrl = "https://raw.githubusercontent.com/Chaitrali-tambe/ChaitraliJson/refs/heads/main/customers.json";

                var client = _httpClientFactory.CreateClient();


                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                var response = await client.GetAsync(githubUrl);
                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Could not reach GitHub.");

                // 4. Read content as string
                var jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize using your OrderResponse wrapper
                var data = JsonSerializer.Deserialize<CustomerModel>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(data?.Customers);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching data: {ex.Message}");
            }
        }
    }
}
