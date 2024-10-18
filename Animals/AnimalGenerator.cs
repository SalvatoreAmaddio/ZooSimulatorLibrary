///The AnimalGenerator class provides a convenient way to generate collections of animals 
///for the zoo simulator. By using asynchronous methods and observable collections, 
///it integrates well with WPF applications, ensuring a responsive UI and efficient data binding.
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using ZooSimulatorLibrary.Animals.DependencyRegistration;

namespace ZooSimulatorLibrary.Animals
{
    /// <summary>
    /// Provides methods to generate collections of animals for the zoo simulator.
    /// </summary>
    public class AnimalGenerator
    {
        /// <summary>
        /// Asynchronously generates the zoo with a specified number of each animal type.
        /// </summary>
        /// <param name="n">The number of each type of animal to generate. Default is 5.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an array of
        /// <see cref="ObservableRangeCollection{IAnimal}"/>, each containing instances of a specific animal type.
        /// </returns>
        public static async Task<ObservableRangeCollection<IAnimal>[]> GenerateZooAsync(int n = 5)
        {
            return await Task.WhenAll(
                GenerateAnimalAsync<Monkey>(n),
                GenerateAnimalAsync<Elephant>(n),
                GenerateAnimalAsync<Giraffe>(n)
            );
        }

        /// <summary>
        /// Asynchronously generates a collection of animals of a specified type.
        /// </summary>
        /// <typeparam name="A">
        /// The type of animal to generate. Must implement <see cref="IAnimal"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="n">The number of animals to generate. Default is 5.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an
        /// <see cref="ObservableRangeCollection{IAnimal}"/> with the generated animal instances.
        /// </returns>
        public static Task<ObservableRangeCollection<IAnimal>> GenerateAnimalAsync<A>(int n = 5) where A : class, IAnimal
        {
            return Task.Run(() => GenerateAnimal<A>(n));
        }

        /// <summary>
        /// Generates a collection of animals of a specified type.
        /// </summary>
        /// <typeparam name="A">
        /// The type of animal to generate. Must implement <see cref="IAnimal"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="max">The number of animals to generate.</param>
        /// <returns>An <see cref="ObservableRangeCollection{IAnimal}"/> containing the generated animal instances.</returns>
        public static ObservableRangeCollection<IAnimal> GenerateAnimal<A>(int max) where A : class, IAnimal
        {
            // Initialize a new collection to hold the animals
            ObservableRangeCollection<IAnimal> animals = new();
            for (int i = 0; i < max; i++)
            {
                IAnimal? animal = AnimalServices.Provider.GetService<A>();
                if (animal != null)
                    animals.Add(animal);
            }
            return animals;
        }
    }
}