using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync empservice)
        {
            employeeServiceAsync = empservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeServiceAsync.GetAllAsync();

            return Ok(result);

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Employee with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRequestModel model)
        {
            var result = await employeeServiceAsync.AddEmployeeAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeRequestModel model)
        {
            var result = await employeeServiceAsync.UpdateEmployeeAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.DeleteEmployeeAsync(id);
            if (result > 0)
            {
                var response = new { Message = "Employee Deleted Successfully" };
                return Ok(response);
            }
            return BadRequest();
        }
    }

}
    /*

    [HttpGet]
    //https://localhost:portnumber/api/employee
    public IActionResult Get()
    {
        string result = "All Employees are returned";
        return Ok(result);
    }
    [HttpGet]
    [Route("{id:int}/{age:int}")]
    //https://localhost:portnumber/api/employee/3/42
    public IActionResult Get(int id, int age)
    {
        string result = "Emp detail with Id =  "+id;
        return Ok(result);
    }
    [HttpGet]
    [Route("{name}")]
    //https://localhost:portnumber/api/employee/allen
    public IActionResult Get(string name)
    {
        string result = "Welcome =  " + name;
        return Ok(result);
    }
    [HttpGet]
    [Route("city/{city}")]
    //https://localhost:port/api/employee/city/chicago
    public IActionResult GetByCity(string city)
    {
        string result = "Welcome from city =  " + city;
        return Ok(result);
    }
    [HttpPost]
    //https://localhost:portnumber/api/employee
    public IActionResult AddEmployee(Employee employee)
    {
        return Ok("Employee has been inserted");
    }
    */

