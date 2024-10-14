/// Even though AbstractAnimalState currently does not contain any properties or methods, 
/// it provides a flexible structure for future enhancements. You can add common functionality 
/// here that should be shared among all life state classes.
namespace ZooSimulatorLibrary.Animals.States
{
    /// <summary>
    /// An abstract base class representing a general animal life state in the zoo simulator.
    /// Serves as a foundation for specific life states like Alive, Dying, and Dead.
    /// </summary>
    public abstract class AbstractAnimalState : IAnimalLifeState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractAnimalState"/> class.
        /// </summary>
        public AbstractAnimalState()
        {
        }
    }
}