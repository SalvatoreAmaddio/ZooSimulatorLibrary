using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;

namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// Represents an animal in the zoo simulator.
    /// </summary>
    public interface IAnimal : IDisposable
    {
        /// <summary>
        /// Gets the URI of the image representing the animal in a healthy state.
        /// </summary>
        string ImgURI { get; }

        /// <summary>
        /// Gets the URI of the image representing the animal when it is dying or dead.
        /// </summary>
        string DyingImgURI { get; }

        /// <summary>
        /// Gets the maximum health value of the animal.
        /// </summary>
        float MaxHealth { get; }

        /// <summary>
        /// Gets or sets the current health percentage of the animal.
        /// </summary>
        float Health { get; set; }

        /// <summary>
        /// Gets the health threshold below which the animal is considered dead.
        /// </summary>
        float DeathThreshold { get; }

        /// <summary>
        /// Gets the health monitoring service for the animal.
        /// </summary>
        IHealthMonitorService HealthMonitorService { get; }

        /// <summary>
        /// Gets the health service used to modify the animal's health.
        /// </summary>
        IHealthService HealthService { get; }

        /// <summary>
        /// Gets the unique identifier of the animal.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets a value indicating whether the animal can walk based on its current health.
        /// </summary>
        bool CanWalk { get; }

        /// <summary>
        /// Gets the walking speed of the animal.
        /// </summary>
        double WalkingSpeed { get; }
    }

}