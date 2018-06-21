using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSundvall.DotnetCoreDevExp.DependencyInjection.Service;

namespace TSundvall.DotnetCoreDevExp.DependencyInjection
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private ILogger<HomeController> _log;
        private IBikeService _bikeService;
        private ICarService _carService;
        private ITrainService _trainService;


        public HomeController(
            ILogger<HomeController> log,
            IBikeService bikeService,
            ICarService carService,
            ITrainService trainService)
        {
            _log = log;
            _bikeService = bikeService;
            _carService = carService;
            _trainService = trainService;
        }


        [HttpGet]
        public string Get()
        {
            _bikeService.AddWheel();
            _carService.AddPassanger();
            _trainService.AddWagon();
            return "Hello world!";
        }
    }   
}