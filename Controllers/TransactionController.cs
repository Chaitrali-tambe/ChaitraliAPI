using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("github-json-category")]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var githubUrl = "https://raw.githubusercontent.com/Chaitrali-tambe/ChaitraliJson/refs/heads/main/transactions.json";

                var client = _httpClientFactory.CreateClient();


                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                var response = await client.GetAsync(githubUrl);
                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Could not reach GitHub.");

                // 4. Read content as string
                var jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize using your OrderResponse wrapper
                var data = JsonSerializer.Deserialize<TransactionModel>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(data?.Transaction);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching data: {ex.Message}");
            }
        }
    }
}
