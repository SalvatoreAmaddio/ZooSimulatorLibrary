using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;

namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// Represents an Elephant in the zoo simulator.
    /// Inherits from <see cref="AbstractAnimal"/> and provides elephant-specific properties and behaviors.
    /// </summary>
    public class Elephant : AbstractAnimal
    {
        /// <summary>
        /// Gets the URI of the image representing the elephant in a healthy state.
        /// </summary>
        public override string ImgURI => "/Images/Animals/elephant.png";

        /// <summary>
        /// Gets the URI of the image representing the elephant when it is dying or dead.
        /// </summary>
        public override string DyingImgURI => "/Images/Animals/deadElephant.png";

        /// <summary>
        /// Gets the health threshold below which the elephant cannot walk and may die if not recovered.
        /// Elephants cannot walk when health is below 70%.
        /// </summary>
        public override float DeathThreshold => 0.7f;

        /// <summary>
        /// Gets a value indicating whether the elephant can walk based on its current health.
        /// Elephants cannot walk when health is below the death threshold.
        /// </summary>
        public override bool CanWalk => !(Health < DeathThreshold);

        /// <summary>
        /// Gets the walking speed of the elephant.
        /// </summary>
        public override double WalkingSpeed => 3.0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Elephant"/> class.
        /// Uses a custom <see cref="ElephantHealthMonitorService"/> for health monitoring.
        /// </summary>
        public Elephant() : base(null, new ElephantHealthMonitorService())
        {
        }
    }

}