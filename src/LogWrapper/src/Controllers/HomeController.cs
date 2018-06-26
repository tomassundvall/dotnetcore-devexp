using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.LogWrapper
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private ILoggerAdapter<HomeController> _log;


        public HomeController(ILoggerAdapter<HomeController> log)
        {
            _log = log;
        }


        [HttpGet]
        public string Get()
        {
            _log.LogDebug("Test with Serilog {Structure} logging", "Structured");
            _log.LogDebug("Test with Serilog {Structure} logging", "Structured2");
            return "Hello world!";
        }
    }
}
