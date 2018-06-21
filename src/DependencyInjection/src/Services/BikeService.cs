using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.DependencyInjection.Service
{
    public interface IBikeService
    {
        void AddWheel();
    }


    public class BikeService : IBikeService
    {
        private ILogger<BikeService> _log;
        private int _wheels = 0;


        public BikeService(ILogger<BikeService> log)
        {
            _log = log;
            _log.LogInformation("Instanciated [Transient] BikeService {InstanceId}", this);
        }


        public void AddWheel()
        {
            _wheels++;
            _log.LogInformation("Added a bike wheel! Now there is {NumberOfWheels} wheels :-).", _wheels);
        }
    }
}