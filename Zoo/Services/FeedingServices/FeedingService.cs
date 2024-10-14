///The FeedingService class is responsible for feeding all animals in the zoo, 
///increasing their health by random percentages. 
///It ensures that the feeding operation is applied across all animal collections and 
///adheres to the simulator's requirements.

using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Zoo.Services.FeedingServices
{
    /// <summary>
    /// Provides a feeding service for the zoo simulator, responsible for feeding all animals.
    /// </summary>
    public class FeedingService : AbstractZooService, IFeedingService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedingService"/> class.
        /// </summary>
        public FeedingService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedingService"/> class with the specified zoo.
        /// </summary>
        /// <param name="zoo">The zoo associated with this feeding service.</param>
        public FeedingService(AbstractZoo zoo) : base(zoo)
        {
        }

        /// <summary>
        /// Feeds all the animals in the zoo by increasing their health.
        /// Each animal's health is increased by a random percentage between 10% and 25%.
        /// </summary>
        /// <exception cref="NullZooException">Thrown if the <see cref="Zoo"/> property is <c>null</c>.</exception>
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