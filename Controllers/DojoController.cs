using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DojoController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult<string> Get()
        {
            var name = User.Identity.Name;
            var email = User.Claims.Where(c => c.Type == "email").FirstOrDefault().Value;

            var result = $"Nome: {name}\nEmail: {email}";

            return Ok(result);
        }
    }
}