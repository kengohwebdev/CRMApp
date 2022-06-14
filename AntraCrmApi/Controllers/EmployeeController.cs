using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntraCrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string result = "Employee Controller";
            return Ok(result);
        }
    }
}
