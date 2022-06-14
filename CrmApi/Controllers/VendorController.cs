using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServiceAsync vendorServiceAsync;

        public VendorController(IVendorServiceAsync vendorServiceAsync)
        {
            this.vendorServiceAsync = vendorServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await vendorServiceAsync.GetAllAsync();

            return Ok(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await vendorServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Vendor with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendorRequestModel model)
        {
            var result = await vendorServiceAsync.AddVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VendorRequestModel model)
        {
            var result = await vendorServiceAsync.UpdateVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await vendorServiceAsync.DeleteVendorAsync(id);
            if (result > 0)
                return Ok("Vendor Deleted successfully");
            return BadRequest();
        }
    }
}