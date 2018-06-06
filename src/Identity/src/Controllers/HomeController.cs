using Microsoft.AspNetCore.Mvc;

namespace TSundvall.DotnetCoreDevExp.Identity
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}