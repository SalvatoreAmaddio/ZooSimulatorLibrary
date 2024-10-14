using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Zoo.Services.FeedingServices
{
    public class FeedingService : AbstractZooService, IFeedingService
    {
        public FeedingService() { }
        public FeedingService(AbstractZoo zoo) : base(zoo) { }

        public void Feed()
        {
            if (Zoo == null)
            {
                throw new NullZooException();
            }

            int[] values = Utils.ProduceRandomValues(Zoo.Animals.Length, 10, 26).ToArray();

            for (int i = 0; i < Zoo.Animals.Length; i++)
            {
                foreach (IAnimal animal in Zoo.Animals[i])
                {
                    animal.HealthService.IncreaseHealthBy(values[i]);
                }
            }
        }
    }
}