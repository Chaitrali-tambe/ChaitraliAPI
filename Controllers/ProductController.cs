using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        [HttpGet("fetch-list")]
        public IActionResult GetList()
        {
            var product = new List<Product>
            {
                new Product { Id = 1, Name = "Okra", Category="Vegetable", Price=100 },
                new Product { Id = 2, Name = "Apple", Category="Fruit", Price=50 },
                new Product { Id = 3, Name = "Mix Fruit Juice", Category="Beverage", Price=40 },
                new Product { Id = 4, Name = "Chips", Category="Snacks", Price=30 },
                new Product { Id = 5, Name = "Pizza", Category="Fast Food", Price=30 },
                new Product { Id = 6, Name = "Chole Chawal", Category="Healthy Food", Price=30 }

            };

            return Ok(product);
        }
        
    }
}
