namespace ZooSimulatorLibrary.Zoo.Services.FeedingServices
{
    /// <summary>
    /// Defines the contract for a feeding service in the zoo simulator.
    /// Responsible for feeding all animals in the zoo.
    /// </summary>
    public interface IFeedingService : IBaseZooService
    {
        /// <summary>
        /// Feeds all the animals in the zoo.
        /// </summary>
        void Feed();
    }
}