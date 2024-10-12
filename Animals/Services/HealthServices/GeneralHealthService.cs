using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Animals.Services.HealthServices
{
    public class GeneralHealthService : AbstractAnimalService, IHealthService
    {
        public GeneralHealthService(IAnimal animal) : base(animal)
        {
        }

        public virtual void ReduceHealthBy(int percentage)
        {
            lock (_lockObject)
            {
                if (Animal == null) throw new NullAnimalException();

                if (Animal.HealthMonitorService.IsDead) return;

                Animal.Health = Math.Max(0, Animal.Health - Animal.Health * Utils.CalculatePercentage(percentage));

                if (Animal.HealthMonitorService.HasDied())
                {
                    AnimalDeadWarning();
                    return;
                }

                Console.WriteLine($"{Animal}");
            }
        }

        public void IncreaseHealthBy(int percentage)
        {
            lock (_lockObject)
            {

                if (Animal == null) throw new NullAnimalException();

                Animal.HealthMonitorService.AttemptRecovery();
                if (Animal.HealthMonitorService.IsDead)
                {
                    AnimalDeadWarning();
                    return;
                }

                Animal.Health = Math.Min(Animal.Health + Animal.Health * Utils.CalculatePercentage(percentage), Animal.MaxHealth);

                Console.WriteLine($"{Animal}");
            }
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}