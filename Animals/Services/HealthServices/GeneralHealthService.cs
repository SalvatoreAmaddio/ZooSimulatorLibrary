///The GeneralHealthService class plays a crucial role in the zoo simulator by handling 
///health modifications for animals. It ensures that health changes adhere to the rules and 
///thresholds defined for each animal type and interacts with the health monitoring services 
///to manage life state transitions effectively.

using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Animals.Services.HealthServices
{
    /// <summary>
    /// Provides general health modification services for animals in the zoo simulator.
    /// Handles increasing and decreasing the animal's health based on specified percentages.
    /// </summary>
    public class GeneralHealthService : AbstractAnimalService, IHealthService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralHealthService"/> class with the specified animal.
        /// </summary>
        /// <param name="animal">The animal to associate with this health service.</param>
        public GeneralHealthService(IAnimal animal) : base(animal)
        {
        }

        /// <summary>
        /// Increases the animal's health by the specified percentage of its current health.
        /// Caps the health at the animal's maximum health.
        /// </summary>
        /// <param name="percentage">The percentage of the current health to increase (0-100).</param>
        /// <exception cref="NullAnimalException">Thrown if the <see cref="Animal"/> is null.</exception>
        public void IncreaseHealthBy(int percentage)
        {
            if (Animal == null)
                throw new NullAnimalException();

            Animal.Health = Math.Min(
                Animal.Health + Animal.Health * Utils.CalculatePercentage(percentage),
                Animal.MaxHealth);

            Animal.HealthMonitorService.AttemptRecovery();

            if (Animal.HealthMonitorService.IsDead)
            {
                AnimalDeadWarning();
                return;
            }
        }

        /// <summary>
        /// Reduces the animal's health by the specified percentage of its current health.
        /// Ensures the health does not drop below zero.
        /// </summary>
        /// <param name="percentage">The percentage of the current health to reduce (0-100).</param>
        /// <exception cref="NullAnimalException">Thrown if the <see cref="Animal"/> is null.</exception>
        public virtual void ReduceHealthBy(int percentage)
        {
            if (Animal == null)
                throw new NullAnimalException();

            if (Animal.HealthMonitorService.IsDead)
                return;

            Animal.Health = Math.Max(
                0,
                Animal.Health - Animal.Health * Utils.CalculatePercentage(percentage));

            if (Animal.HealthMonitorService.HasDied())
            {
                AnimalDeadWarning();
                return;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="GeneralHealthService"/> class.
        /// </summary>
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}