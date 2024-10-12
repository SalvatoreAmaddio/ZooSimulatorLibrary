using MvvmHelpers;

namespace ZooSimulatorLibrary.Animals
{
    public class AnimalGenerator
    {
        public static async Task<ObservableRangeCollection<IAnimal>[]> GenerateZooAsync(int n = 5)
        {
            return await Task.WhenAll(
                GenerateAnimalAsync<Monkey>(n),
                GenerateAnimalAsync<Elephant>(n),
                GenerateAnimalAsync<Giraffe>(n)
                );
        }

        public static Task<ObservableRangeCollection<IAnimal>> GenerateAnimalAsync<A>(int n = 5) where A : IAnimal, new()
        {
            return Task.Run(() => GenerateAnimal<A>(n));
        }

        public static ObservableRangeCollection<IAnimal> GenerateAnimal<A>(int max) where A : IAnimal, new()
        {
            ObservableRangeCollection<IAnimal> animals = [];
            for (int i = 0; i < max; i++)
            {
                animals.Add(new A());
            }
            return animals;
        }
    }
}