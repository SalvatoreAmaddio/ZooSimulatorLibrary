namespace ZooSimulatorLibrary.Animals.Services
{
    public interface IBaseAnimalService : IDisposable
    {
        IAnimal? Animal { set; }
    }
}