using ZooSimulatorLibrary.Animals;

namespace ZooSimulatorLibrary.Extentions
{
    public static class ExtensionUtils
    {
        /// <summary>
        /// Counts the total number of animals across all collections.
        /// </summary>
        /// <param name="Animals">An array of enumerable collections of animals.</param>
        /// <returns>The total count of animals across all collections.</returns>
        public static int CountAll(this IEnumerable<IAnimal>[] Animals)
        {
            return Animals.Sum(s => s.Count());
        }
    }
}