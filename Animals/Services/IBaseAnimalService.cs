namespace ZooSimulatorLibrary.Animals.Services
{
    /// <summary>
    /// Defines the base contract for animal services in the zoo simulator.
    /// </summary>
    public interface IBaseAnimalService : IDisposable
    {
        /// <summary>
        /// Sets the animal associated with this service.
        /// </summary>
        IAnimal? Animal { set; }
    }
}