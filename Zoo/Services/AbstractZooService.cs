namespace ZooSimulatorLibrary.Zoo.Services
{
    /// <summary>
    /// An abstract base class for services associated with a zoo in the simulator.
    /// Provides common functionality and properties for zoo services.
    /// </summary>
    public abstract class AbstractZooService : IBaseZooService
    {
        /// <summary>
        /// Gets or sets the zoo associated with this service.
        /// The getter is protected to allow access within derived classes.
        /// </summary>
        protected AbstractZoo? Zoo { get; set; }

        public AbstractZoo? GetZoo()
        {
            return Zoo;
        }

        public void SetZoo(AbstractZoo zoo)
        {
            Zoo = zoo;
        }
    }

}