namespace TSundvall.DotnetCoreDevExp.DependencyInjection
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