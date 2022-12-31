using JWTtOKEN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;

namespace JWTtOKEN.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Authenticate([FromBody] usercred user)
        {
            return Ok();
        }

    }
}
