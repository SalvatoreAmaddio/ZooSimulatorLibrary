///The MortuaryService class is a crucial component in the zoo simulator, 
///responsible for cleaning up dead animals from the zoo's collections. 
///It ensures that the zoo remains up-to-date by removing animals that are no longer alive, 
///thereby maintaining a realistic simulation environment.

namespace ZooSimulatorLibrary.Zoo.Services.MortuaryServices
{
    /// <summary>
    /// Provides a mortuary service for the zoo simulator, responsible for disposing of dead animals.
    /// </summary>
    public class MortuaryService : AbstractZooService, IMortuaryService
    {
        /// <summary>
        /// Disposes of the bodies of all dead animals in the zoo.
        /// </summary>
        /// <exception cref="NullZooException">Thrown if the <see cref="Zoo"/> property is <c>null</c>.</exception>
        public void DisposeBodies()
        {
            if (Zoo == null)
            {
                throw new NullZooException();
            }

            for (int i = 0; i < Zoo.Animals.Length; i++)
            {
                var toRemove = Zoo.Animals[i]
                    .Where(s => s.HealthMonitorService.IsDead)
                    .ToList();

                Zoo.Animals[i].RemoveRange(toRemove);

                if (Zoo.Animals[i].Count == 0)
                {
                    Zoo.Animals[i].Clear();
                }
            }

            Zoo.Animals = Zoo.Animals.Where(s => s.Count > 0).ToArray();
        }
    }

}
