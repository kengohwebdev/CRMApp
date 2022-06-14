using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await categoryServiceAsync.GetAllAsync();

            return Ok(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await categoryServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Category with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryModel model)
        {
            var result = await categoryServiceAsync.AddCategoryAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryModel model)
        {
            var result = await categoryServiceAsync.UpdateCategoryAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryServiceAsync.DeleteCategoryAsync(id);
            if (result > 0)
                return Ok("Category Deleted successfully");
            return BadRequest();
        }
    }
}