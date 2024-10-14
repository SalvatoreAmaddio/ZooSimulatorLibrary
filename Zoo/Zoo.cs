///The Zoo class provides a concrete implementation of a zoo, making it easy to access specific 
///animal collections and utilize the services provided by the base AbstractZoo class. 
using MvvmHelpers;
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Zoo.Services.FeedingServices;
using ZooSimulatorLibrary.Zoo.Services.MortuaryServices;

namespace ZooSimulatorLibrary.Zoo
{
    /// <summary>
    /// Represents a concrete implementation of a zoo in the simulator, providing access to specific animal collections.
    /// </summary>
    public class Zoo : AbstractZoo
    {
        /// <summary>
        /// Gets a collection of monkeys in the zoo.
        /// </summary>
        public ObservableRangeCollection<Monkey>? Monkeys => ExtractAnimals<Monkey>();

        /// <summary>
        /// Gets a collection of elephants in the zoo.
        /// </summary>
        public ObservableRangeCollection<Elephant>? Elephants => ExtractAnimals<Elephant>();

        /// <summary>
        /// Gets a collection of giraffes in the zoo.
        /// </summary>
        public ObservableRangeCollection<Giraffe>? Giraffes => ExtractAnimals<Giraffe>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Zoo"/> class with optional feeding and mortuary services.
        /// </summary>
        /// <param name="feedingService">An optional feeding service. If <c>null</c>, a default service is provided.</param>
        /// <param name="mortuaryService">An optional mortuary service. If <c>null</c>, a default service is provided.</param>
        public Zoo(IFeedingService? feedingService = null, IMortuaryService? mortuaryService = null)
            : base(feedingService, mortuaryService)
        {
        }
    }

}