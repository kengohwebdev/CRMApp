using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            this.customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await customerServiceAsync.GetAllAsync();

            return Ok(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await customerServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Customer with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model)
        {
            var result = await customerServiceAsync.AddCustomerAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomerRequestModel model)
        {
            var result = await customerServiceAsync.UpdateCustomerAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await customerServiceAsync.DeleteCustomerAsync(id);
            if (result > 0)
                return Ok("Customer Deleted successfully");
            return BadRequest();
        }
    }
}