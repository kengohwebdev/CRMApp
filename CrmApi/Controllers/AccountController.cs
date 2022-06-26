using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync _accountServiceAsync;
        public AccountController(IAccountServiceAsync accountServiceAsync)
        {
            _accountServiceAsync = accountServiceAsync;
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> SignUp([FromBody]SignupModel model)
        {
            var result = await _accountServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
    }
}
