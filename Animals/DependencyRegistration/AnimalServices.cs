﻿using Microsoft.Extensions.DependencyInjection;
using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;

namespace ZooSimulatorLibrary.Animals.DependencyRegistration
{
    public class AnimalServices
    {
        private static AnimalServices _instance = null!;
        private ServiceCollection _services;
        private ServiceProvider _provider;
        private AnimalServices()
        {
            _services = new();
            _services.AddTransient<ElephantHealthMonitorService>();
            _services.AddTransient<IHealthMonitorService, GeneralHealthMonitorService>();
            _services.AddTransient<IHealthService, GeneralHealthService>();

            _services.AddTransient<Monkey>(sp =>
                                               new Monkey(sp.GetRequiredService<IHealthService>(),
                                                       sp.GetRequiredService<IHealthMonitorService>()
                                                       )
            );

            _services.AddTransient<Giraffe>(sp =>
                                                new Giraffe(sp.GetRequiredService<IHealthService>(),
                                                            sp.GetRequiredService<IHealthMonitorService>()
                                                            )
            );

            _services.AddTransient<Elephant>(sp =>
                                                new Elephant(sp.GetRequiredService<IHealthService>(),
                                                             sp.GetRequiredService<ElephantHealthMonitorService>()
                                                             )
            );

            _provider = _services.BuildServiceProvider();
        }

        public static ServiceProvider Provider
        {
            get => Instance._provider;
        }

        private static AnimalServices Instance
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