using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using System.Linq;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public OrdersController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var filepath = Path.Combine(_env.ContentRootPath, "Json", "orders.json");

            if (!System.IO.File.Exists(filepath))
                return NotFound();

            string jsonstring = await System.IO.File.ReadAllTextAsync(filepath);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

            var data = JsonSerializer.Deserialize<OrdersModel>(jsonstring, options);

            var orderList = data?.Orders;

            return Ok(orderList);
        }
    }


}
