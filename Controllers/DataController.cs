using ChaitraliAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {

        [HttpGet("fetch-json")]
        public IActionResult GetJsonFile()
        {
            var data = new MyData
            {
                Id = 1,
                title = "Test",
                Message = "Test Message",
            };

            
            return Ok(data);
        }
    }
}
