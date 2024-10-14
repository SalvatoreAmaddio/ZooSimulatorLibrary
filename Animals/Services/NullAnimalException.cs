///The NullAnimalException class provides a clear and specific way to handle cases where an operation 
///cannot proceed due to a missing Animal instance. By extending NullReferenceException, 
///it maintains consistency with .NET exception hierarchies while offering more 
///detailed context for the error.
namespace ZooSimulatorLibrary.Animals.Services
{
    /// <summary>
    /// Represents an exception that is thrown when an operation requiring an animal encounters a null reference.
    /// </summary>
    public class NullAnimalException : NullReferenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullAnimalException"/> class with a default error message.
        /// </summary>
        public NullAnimalException() : base("Animal cannot be null") { }
    }

}