using JWT_Authentication.DatabaseContext;
using JWTtOKEN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace JWTtOKEN.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        JWTSetting  setting;

        public UserController( ApplicationDbContext dbContext,IOptions<JWTSetting> options)
        {
            _dbContext = dbContext;
            setting = options.Value;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] usercred user)
        {
            var _user=_dbContext.tblUsers.FirstOrDefault(o=>o.Userid==user.username&& o.Password==user.password);
            if(_user==null)
                return Unauthorized(); 
           

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(setting.securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, _user.Userid),
                        //new Claim(ClaimTypes.Role, _user.Role)

                    }
                ),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);


            return Ok(finaltoken);
        }

    }
}
