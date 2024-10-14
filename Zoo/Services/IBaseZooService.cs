namespace ZooSimulatorLibrary.Zoo.Services
{
    /// <summary>
    /// Defines the base contract for services associated with a zoo in the simulator.
    /// </summary>
    public interface IBaseZooService
    {
        /// <summary>
        /// Sets the zoo associated with this service.
        /// </summary>
        AbstractZoo? Zoo { set; }
    }
}