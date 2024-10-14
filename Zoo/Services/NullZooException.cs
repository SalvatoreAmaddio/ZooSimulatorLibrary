namespace ZooSimulatorLibrary.Zoo.Services
{
    /// <summary>
    /// Represents an exception that is thrown when an operation requiring a zoo encounters a null reference.
    /// </summary>
    public class NullZooException : NullReferenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullZooException"/> class with a default error message.
        /// </summary>
        public NullZooException() : base("Zoo cannot be null") { }
    }

}