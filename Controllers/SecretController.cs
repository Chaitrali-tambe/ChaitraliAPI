using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChaitraliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProtectedData() {
            return Ok("Success! You have a valid token and can see this data.");
        }
    }
}
