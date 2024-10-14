using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;

namespace ZooSimulatorLibrary.Animals
{

    public interface IAnimal : IDisposable
    {
        string ImgURI { get; }
        string DyingImgURI { get; }
        float MaxHealth { get; }
        float Health { get; set; }
        float DeathThreshold { get; }
        IHealthMonitorService HealthMonitorService { get; }
        IHealthService HealthService { get; }
        int Id { get; }
        bool CanWalk { get; } 
        double WalkingSpeed { get; }
    }
}