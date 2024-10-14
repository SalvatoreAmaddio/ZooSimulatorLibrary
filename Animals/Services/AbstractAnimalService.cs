using ZooSimulatorLibrary.Notifiers;

namespace ZooSimulatorLibrary.Animals.Services
{
    public abstract class AbstractAnimalService : AbstractNotifier, IBaseAnimalService
    {
        public IAnimal? Animal { protected get; set; }
        public AbstractAnimalService(IAnimal animal)
        {
            Animal = animal;
        }

        public AbstractAnimalService()
        {
        }

        public void AnimalDeadWarning()
        {
            if (Animal == null) throw new NullAnimalException();
            Console.WriteLine($"Sorry, The {Animal.GetType().Name} is dead");
        }

        abstract public void Dispose();
    }
}