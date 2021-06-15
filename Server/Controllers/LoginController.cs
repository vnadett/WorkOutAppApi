using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("Login")]
        public async Task<ActionResult<LoginUser>> Login(LoginUser loginUser)
        {
            LoginUser user = DBHelper.Login(loginUser);
            return await Task.FromResult(user);
        }
    }
}
