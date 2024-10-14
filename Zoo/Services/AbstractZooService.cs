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
        public AbstractZoo? Zoo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractZooService"/> class with the specified zoo.
        /// </summary>
        /// <param name="zoo">The zoo to associate with the service.</param>
        public AbstractZooService(AbstractZoo zoo)
        {
            Zoo = zoo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractZooService"/> class.
        /// </summary>
        public AbstractZooService()
        {
        }
    }

}