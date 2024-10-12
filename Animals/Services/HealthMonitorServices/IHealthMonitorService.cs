using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.EventHandlers;

namespace ZooSimulatorLibrary.Animals.Services.HealthMonitorServices
{
    public interface IHealthMonitorService : IBaseAnimalService
    {
        IAnimalLifeState LifeState { get; }
        bool IsAlive { get; }
        bool IsDying { get; }
        bool IsDead { get; }
        bool IsGoingToDie { get; }
        void SetState(IAnimalLifeState state);
        bool HasDied();
        void AttemptRecovery();

        event StageChangedEventHandler StateChanged;
    }
}