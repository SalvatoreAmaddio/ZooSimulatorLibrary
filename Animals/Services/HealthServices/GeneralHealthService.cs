using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Animals.Services.HealthServices
{
    public class GeneralHealthService : AbstractAnimalService, IHealthService
    {
        public GeneralHealthService(IAnimal animal) : base(animal)
        {
        }

        public void IncreaseHealthBy(int percentage)
        {
            if (Animal == null) throw new NullAnimalException();

            Animal.Health = Math.Min(Animal.Health + Animal.Health * Utils.CalculatePercentage(percentage), Animal.MaxHealth);

            Animal.HealthMonitorService.AttemptRecovery();
            
            if (Animal.HealthMonitorService.IsDead)
            {
                AnimalDeadWarning();
                return;
            }
        }

        public virtual void ReduceHealthBy(int percentage)
        {
            if (Animal == null) throw new NullAnimalException();

            if (Animal.HealthMonitorService.IsDead) return;

            Animal.Health = Math.Max(0, Animal.Health - Animal.Health * Utils.CalculatePercentage(percentage));

            if (Animal.HealthMonitorService.HasDied())
            {
                AnimalDeadWarning();
                return;
            }
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}