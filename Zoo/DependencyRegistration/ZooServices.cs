using Microsoft.Extensions.DependencyInjection;
using ZooSimulatorLibrary.Zoo.Services.FeedingServices;
using ZooSimulatorLibrary.Zoo.Services.MortuaryServices;

namespace ZooSimulatorLibrary.Zoo.DependencyRegistration
{
    public class ZooServices
    {
        private static ZooServices _instance = null!;
        private ServiceCollection _services;
        private ServiceProvider _provider;

        private ZooServices()
        {
            _services = new();
            _services.AddTransient<IFeedingService, FeedingService>();
            _services.AddTransient<IMortuaryService, MortuaryService>();
            _services.AddTransient<Zoo>();
            _provider = _services.BuildServiceProvider();
        }

        public static ServiceProvider Provider
        {
            get => Instance._provider;
        }

        private static ZooServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new();
                return _instance;
            }
        }
    }
}