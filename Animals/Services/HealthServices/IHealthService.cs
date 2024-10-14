namespace ZooSimulatorLibrary.Animals.Services.HealthServices
{
    /// <summary>
    /// Defines methods for modifying an animal's health in the zoo simulator.
    /// </summary>
    public interface IHealthService : IBaseAnimalService
    {
        /// <summary>
        /// Increases the animal's health by the specified percentage of its current health.
        /// </summary>
        /// <param name="percentage">The percentage of the current health to increase.</param>
        void IncreaseHealthBy(int percentage);

        /// <summary>
        /// Reduces the animal's health by the specified percentage of its current health.
        /// </summary>
        /// <param name="percentage">The percentage of the current health to reduce.</param>
        void ReduceHealthBy(int percentage);
    }
}
