///The AbstractAnimal class serves as a foundational component in your zoo simulator, 
///encapsulating common functionality and promoting code reuse. 
using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;
using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.Models;

namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// An abstract base class representing a generic animal in the zoo simulator.
    /// Provides common properties and methods shared among all animal types.
    /// </summary>
    public abstract class AbstractAnimal : AbstractModel, IAnimal
    {
        /// <summary>
        /// A static counter used to assign unique IDs to each animal instance.
        /// </summary>
        private static int AutoIncrementID = 0;

        /// <summary>
        /// Gets the maximum health value of the animal, represented as a percentage (1.0 = 100% health).
        /// </summary>
        public float MaxHealth => 1.0f;

        private float _health;

        /// <summary>
        /// Gets or sets the current health percentage of the animal.
        /// </summary>
        public float Health
        {
            get => _health;
            set => UpdateProperty(ref value, ref _health);
        }

        /// <summary>
        /// Gets the health threshold below which the animal is considered dead.
        /// Default value is 0.0f and can be overridden by derived classes.
        /// </summary>
        public virtual float DeathThreshold => 0.0f;

        /// <summary>
        /// Gets or sets the health service used to modify the animal's health.
        /// </summary>
        public IHealthService HealthService { get; set; }

        /// <summary>
        /// Gets or sets the health monitoring service for the animal.
        /// </summary>
        public IHealthMonitorService HealthMonitorService { get; set; }

        private int _id;

        /// <summary>
        /// Gets or sets the unique identifier of the animal.
        /// </summary>
        public int Id
        {
            get => _id;
            set => UpdateProperty(ref value, ref _id);
        }

        /// <summary>
        /// Gets the URI of the image representing the animal in a healthy state.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract string ImgURI { get; }

        /// <summary>
        /// Gets the URI of the image representing the animal when it is dying or dead.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract string DyingImgURI { get; }

        /// <summary>
        /// Gets a value indicating whether the animal can walk based on its current health.
        /// Can be overridden by derived classes to implement specific logic.
        /// </summary>
        public virtual bool CanWalk
        {
            get => !(HealthMonitorService.LifeState is DeadState);
        }

        /// <summary>
        /// Gets the walking speed of the animal.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract double WalkingSpeed { get; }

        internal AbstractAnimal()
        {
            Health = MaxHealth;
            Id = Interlocked.Increment(ref AutoIncrementID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractAnimal"/> class with optional health and health monitor services.
        /// </summary>
        /// <param name="healthService">An optional health service. If null, a default service is provided.</param>
        /// <param name="healthMonitorService">An optional health monitor service. If null, a default service is provided.</param>
        public AbstractAnimal(IHealthService healthService, IHealthMonitorService healthMonitorService) : this()
        {
            Health = MaxHealth;
            Id = Interlocked.Increment(ref AutoIncrementID);

            HealthService = healthService;
            HealthService.SetAnimal(this);
            HealthMonitorService = healthMonitorService;
            HealthMonitorService.SetAnimal(this);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current animal based on the ID.
        /// </summary>
        /// <param name="obj">The object to compare with the current animal.</param>
        /// <returns><c>true</c> if the IDs are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            return obj is AbstractAnimal animal && Id == animal.Id;
        }

        /// <summary>
        /// Returns a hash code for the current animal.
        /// </summary>
        /// <returns>A hash code based on the animal's ID.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        /// <summary>
        /// Returns a string representation of the animal, including its ID, type, and health level.
        /// </summary>
        /// <returns>A string that represents the current animal.</returns>
        public override string ToString()
        {
            return $"{Id}) {GetType().Name} - Health Level: {Health:P2}";
        }

        /// <summary>
        /// Releases all resources used by the <see cref="AbstractAnimal"/> class.
        /// </summary>
        public void Dispose()
        {
            HealthService.Dispose();
            HealthMonitorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}