using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        [HttpPost("Registration")]
        public async Task<ActionResult<RegisterModel>> Registration(RegisterModel newUser)
        {
            RegisterModel user = DBHelper.Registration(newUser);
            return await Task.FromResult(user);

        }
    }
}
