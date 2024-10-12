namespace ZooSimulatorLibrary.Animals.Services
{
    public class NullAnimalException : NullReferenceException
    {
        public NullAnimalException() : base("Animal cannot be null") { }
    }
}