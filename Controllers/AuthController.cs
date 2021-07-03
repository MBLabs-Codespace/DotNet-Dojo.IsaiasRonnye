using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpPut("login")]
        public ActionResult<JwtToken> Login()
        {
            var user = new User()
            {
                UserName = "Teste",
                Email = "Teste@email.com"
            };

            JwtToken token = new()
            {
                AccessToken = JwtHelper.GerarJwt(user)
            };

            return token;
        }
    }
}