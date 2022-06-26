using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync productServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productServiceAsync.GetAllAsync();

            return Ok(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await productServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Product with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var result = await productServiceAsync.AddProductAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductRequestModel model)
        {
            var result = await productServiceAsync.UpdateProductAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productServiceAsync.DeleteProductAsync(id);
            if (result > 0)
            {
                var response = new { Message = "Product Deleted Successfully" };
                return Ok(response);
            }
            return BadRequest();
        }
    }
}