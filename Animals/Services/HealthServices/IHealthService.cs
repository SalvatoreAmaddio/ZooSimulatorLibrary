namespace ZooSimulatorLibrary.Animals.Services.HealthServices
{
    public interface IHealthService : IBaseAnimalService
    {
        void IncreaseHealthBy(int percentage);
        void ReduceHealthBy(int percentage);
    }
}
