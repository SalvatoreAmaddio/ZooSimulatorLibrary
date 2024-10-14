using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;
using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.Models;

namespace ZooSimulatorLibrary.Animals
{
    public abstract class AbstractAnimal : AbstractModel, IAnimal
    {
        private static int AutoIncrementID = 0;
        public float MaxHealth => 1.0f;

        private float _health;
        public float Health { get => _health; set => UpdateProperty(ref value, ref _health); }
        public virtual float DeathThreshold => 0.0f;
        public IHealthService HealthService { get; set; }
        public IHealthMonitorService HealthMonitorService { get; set; }
        private int _id;
        public int Id { get => _id; set => UpdateProperty(ref value, ref _id); }
        public abstract string ImgURI { get; }
        public abstract string DyingImgURI { get; }
        public virtual bool CanWalk
        {
            get => !(HealthMonitorService.LifeState is DeadState);
        }
        public abstract double WalkingSpeed { get; }

        public AbstractAnimal(IHealthService? healthService = null, IHealthMonitorService? healthMonitorService = null)
        {
            Health = MaxHealth;
            Id = Interlocked.Increment(ref AutoIncrementID);

            if (healthService == null)
            {
                HealthService = new GeneralHealthService(this);
            }
            else
            {
                HealthService = healthService;
                HealthService.Animal = this;
            }

            if (healthMonitorService == null)
            {
                HealthMonitorService = new GeneralHealthMonitorService(this);
            }
            else
            {
                HealthMonitorService = healthMonitorService;
                HealthMonitorService.Animal = this;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is AbstractAnimal animal &&
                   Id == animal.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"{Id}) {GetType().Name} - Health Level: {Health:P2}";
        }

        public void Dispose()
        {
            HealthService.Dispose();
            HealthMonitorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}