namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// Represents a Giraffe in the zoo simulator.
    /// Inherits from <see cref="AbstractAnimal"/> and provides giraffe-specific properties and behaviors.
    /// </summary>
    public class Giraffe : AbstractAnimal
    {
        /// <summary>
        /// Gets the walking speed of the giraffe.
        /// </summary>
        public override double WalkingSpeed => 2.0;

        /// <summary>
        /// Gets the URI of the image representing the giraffe in a healthy state.
        /// </summary>
        public override string ImgURI => "/Images/Animals/giraffe.png";

        /// <summary>
        /// Gets the URI of the image representing the giraffe when it is dying or dead.
        /// </summary>
        public override string DyingImgURI => "/Images/Animals/deadGiraffe.png";

        /// <summary>
        /// Gets the health threshold below which the giraffe is considered dead.
        /// Giraffes die when health is below 50%.
        /// </summary>
        public override float DeathThreshold => 0.5f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Giraffe"/> class.
        /// </summary>
        public Giraffe() { }
    }
}