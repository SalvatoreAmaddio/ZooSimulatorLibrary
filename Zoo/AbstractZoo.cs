///The AbstractZoo class provides a robust foundation for building zoo simulations. 
///It encapsulates essential services and animal collections, adhering to object-oriented design principles 
///that promote maintainability and scalability. 

using MvvmHelpers;
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Models;
using ZooSimulatorLibrary.Zoo.Services.FeedingServices;
using ZooSimulatorLibrary.Zoo.Services.MortuaryServices;

namespace ZooSimulatorLibrary.Zoo
{
    /// <summary>
    /// Represents an abstract zoo in the simulator, containing animals and services such as feeding and mortuary.
    /// </summary>
    public abstract class AbstractZoo : AbstractModel
    {
        /// <summary>
        /// Gets the mortuary service associated with the zoo.
        /// </summary>
        public IMortuaryService MortuaryService { get; }

        /// <summary>
        /// Gets the feeding service associated with the zoo.
        /// </summary>
        public IFeedingService FeedingService { get; }

        /// <summary>
        /// Gets or sets the collections of animals in the zoo.
        /// </summary>
        public ObservableRangeCollection<IAnimal>[] Animals { get; set; } = Array.Empty<ObservableRangeCollection<IAnimal>>();

        /// <summary>
        /// Gets a value indicating whether the zoo has any animals.
        /// </summary>
        public bool IsEmpty => Animals.Length == 0;

        /// <summary>
        /// Extracts a collection of animals of the specified type from the zoo.
        /// </summary>
        /// <typeparam name="A">The type of animal to extract.</typeparam>
        /// <returns>An <see cref="ObservableRangeCollection{A}"/> containing the animals of the specified type, or <c>null</c> if none are found.</returns>
        protected ObservableRangeCollection<A>? ExtractAnimals<A>() where A : class, IAnimal
        {
            var results = Animals?
                .FirstOrDefault(collection => collection.Any(animal => animal is A))?
                .OfType<A>()
                .ToList();

            return results == null ? null : new ObservableRangeCollection<A>(results);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractZoo"/> class with optional feeding and mortuary services.
        /// </summary>
        /// <param name="feedingService">An optional feeding service. If <c>null</c>, a default service is provided.</param>
        /// <param name="mortuaryService">An optional mortuary service. If <c>null</c>, a default service is provided.</param>
        public AbstractZoo(IFeedingService feedingService, IMortuaryService mortuaryService)
        {
            FeedingService = feedingService;
            feedingService.Zoo = this;
            MortuaryService = mortuaryService;
            MortuaryService.Zoo = this;
        }
    }

}