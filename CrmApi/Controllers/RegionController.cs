using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync regionServiceAsync)
        {
            this.regionServiceAsync = regionServiceAsync;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // throw new Exception("custom exception");
            return Ok(await regionServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await regionServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Region with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegionModel model)
        {
            var result = await regionServiceAsync.AddRegionAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(RegionModel model)
        {
            var result = await regionServiceAsync.UpdateRegionAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await regionServiceAsync.DeleteRegionAsync(id);
            if (result > 0)
            {
                var response = new { Message = "Region Deleted Successfully" };
                return Ok(response);
            }
            return BadRequest();
        }
    }
}