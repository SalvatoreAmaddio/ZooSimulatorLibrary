using MvvmHelpers;
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Models;
using ZooSimulatorLibrary.Zoo.Services.FeedingServices;
using ZooSimulatorLibrary.Zoo.Services.MortuaryServices;

namespace ZooSimulatorLibrary.Zoo
{
    public abstract class AbstractZoo : AbstractModel
    {
        public IMortuaryService MortuaryService { get; }
        public IFeedingService FeedingService { get; }
        public ObservableRangeCollection<IAnimal>[] Animals { get; set; } = [];
        public bool IsEmpty => Animals.Length == 0;
        protected ObservableRangeCollection<A>? ExtractAnimals<A>() where A : IAnimal, new()
        {
            List<A>? results = Animals?.FirstOrDefault(e => e.Any(animal => animal is A))?.Cast<A>().ToList();

            return (results == null) ? null : new (results);
        }

        public AbstractZoo(IFeedingService? feedingService = null, IMortuaryService? mortuaryService = null)
        {
            if (feedingService == null)
            {
                FeedingService = new FeedingService(this);
            }
            else
            {
                FeedingService = feedingService;
                FeedingService.Zoo = this;
            }

            if (mortuaryService == null)
            {
                MortuaryService = new MortuaryService(this);
            }
            else
            {
                MortuaryService = mortuaryService;
                MortuaryService.Zoo = this;
            }
        }
    }
}