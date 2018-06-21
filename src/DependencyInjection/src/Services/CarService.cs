using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.DependencyInjection.Service
{
    public interface ICarService
    {
        void AddPassanger();
    }


    public class CarService : ICarService
    {
        private ILogger<CarService> _log;
        private int _passangers;

        public CarService(ILogger<CarService> log)
        {
            _log = log;
            _log.LogInformation("Instanciated [Scoped] CarService {InstanceId}", this);
        }


        public void AddPassanger()
        {
            _passangers++;
            _log.LogInformation("Added a car passanger! Now there is {NumberOfPassangers} passangers :-).", _passangers);
        }
    }
}