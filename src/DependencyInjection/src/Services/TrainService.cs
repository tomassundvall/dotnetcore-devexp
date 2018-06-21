using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.DependencyInjection.Service
{
    public interface ITrainService
    {
        void AddWagon();
    }


    public class TrainService : ITrainService
    {
        private ILogger<TrainService> _log;
        private IBikeService _bikeService;
        private int _wagons;


        public TrainService(
            ILogger<TrainService> log,
            IBikeService bikeService) // ERROR!
        {
            _log = log;
            _bikeService = bikeService;
            _log.LogInformation("Instanciated [Singleton] TrainService {InstanceId}", this);
        }


        public void AddWagon()
        {
            _wagons++;
            _bikeService.AddWheel();
            _log.LogInformation("Added a train wagon! Now there is {NumberOfWagons} wagons :-).", _wagons);
        }
    }
}