///The AbstractAnimalService class serves as a foundational component for creating services 
///that operate on animals within your zoo simulator. By providing common properties and 
///enforcing the implementation of essential methods, it promotes code reuse and adherence 
///to good object-oriented design principles.
using ZooSimulatorLibrary.Notifiers;

namespace ZooSimulatorLibrary.Animals.Services
{
    /// <summary>
    /// An abstract base class for services associated with animals in the zoo simulator.
    /// Provides common functionality and properties for animal services.
    /// </summary>
    public abstract class AbstractAnimalService : AbstractNotifier, IBaseAnimalService
    {
        /// <summary>
        /// Gets or sets the animal associated with this service.
        /// </summary>
        public IAnimal? Animal { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractAnimalService"/> class.
        /// </summary>
        public AbstractAnimalService()
        {
        }

        /// <summary>
        /// Outputs a warning message indicating that the associated animal is dead.
        /// </summary>
        /// <exception cref="NullAnimalException">Thrown if the <see cref="Animal"/> property is null.</exception>
        public void AnimalDeadWarning()
        {
            if (Animal == null)
                throw new NullAnimalException();
            Console.WriteLine($"Sorry, the {Animal.GetType().Name} is dead");
        }

        /// <summary>
        /// Releases all resources used by the <see cref="AbstractAnimalService"/> class.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void Dispose();
    }

}