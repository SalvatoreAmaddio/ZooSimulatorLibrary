using MvvmHelpers;
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Zoo.Services.FeedingServices;
using ZooSimulatorLibrary.Zoo.Services.MortuaryServices;

namespace ZooSimulatorLibrary.Zoo
{
    public class Zoo : AbstractZoo
    {
        public ObservableRangeCollection<Monkey>? Monkeys => ExtractAnimals<Monkey>();
        public ObservableRangeCollection<Elephant>? Elephants => ExtractAnimals<Elephant>();
        public ObservableRangeCollection<Giraffe>? Giraffes => ExtractAnimals<Giraffe>();

        public Zoo(IFeedingService? feedingService = null, IMortuaryService? mortuaryService = null) : base(feedingService, mortuaryService)
        {

        }
    }
}