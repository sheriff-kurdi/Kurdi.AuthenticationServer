using Kurdi.AuthenticationServer.Services;
using Kurdi.AuthenticationServer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kurdi.AuthenticationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        // POST api/<Authentication>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginVM loginVM)
        {
            var result = await authenticationService.Login(loginVM);
            var message = result;
            System.Type type = result.GetType();
            String status = (String)type.GetProperty("Status").GetValue(result, null);
            if (status == "Error")
            {
                return BadRequest(message);
            }
            return Ok(message);
        }

        // POST api/<Authentication>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterVM registerVM)
        {
            var result = await authenticationService.Register(registerVM);
            var message = result;
            System.Type type = result.GetType();
            String status = (String)type.GetProperty("Status").GetValue(result, null);
            if (status == "Error")
            {
                return BadRequest(message);
            }
            return Ok(message);
        }
    }
}
