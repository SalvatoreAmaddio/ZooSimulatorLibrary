using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;
using ZooSimulatorLibrary.Animals.Services.HealthServices;

namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// Represents a Monkey in the zoo simulator.
    /// Inherits from <see cref="AbstractAnimal"/> and provides monkey-specific properties and behaviors.
    /// </summary>
    public class Monkey : AbstractAnimal
    {
        /// <summary>
        /// Gets the health threshold below which the monkey is considered dead.
        /// Monkeys die when health is below 30%.
        /// </summary>
        public override float DeathThreshold => 0.3f;

        /// <summary>
        /// Gets the URI of the image representing the monkey in a healthy state.
        /// </summary>
        public override string ImgURI => "/Images/Animals/monkey.png";

        /// <summary>
        /// Gets the URI of the image representing the monkey when it is dying or dead.
        /// </summary>
        public override string DyingImgURI => "/Images/Animals/deadMonkey.png";

        /// <summary>
        /// Gets the walking speed of the monkey.
        /// </summary>
        public override double WalkingSpeed => 1.0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monkey"/> class.
        /// </summary>
        public Monkey(IHealthService healthService, IHealthMonitorService monitorService) : base(healthService, monitorService) { }
    }
}