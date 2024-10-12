using ZooSimulatorLibrary.Animals;

namespace ZooSimulatorLibrary.Extentions
{
    public static class ExtentionUtils
    {
        public static int CountAll(this IEnumerable<IAnimal>[] Animals) 
        {
            return Animals.Sum(s => s.Count());
        }
    }
}