///The IHealthMonitorService interface is a crucial part of your zoo simulator, 
///providing the mechanisms needed to monitor animal health and manage life state transitions. 
///By implementing this interface, you can create services that handle the specific health rules 
///for different animal types while keeping your codebase organized and adhering to 
///solid object-oriented design principles.

using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.EventHandlers;

namespace ZooSimulatorLibrary.Animals.Services.HealthMonitorServices
{
    /// <summary>
    /// Provides health monitoring functionality for animals in the zoo simulator.
    /// Manages the life state transitions and exposes properties to check the animal's current state.
    /// </summary>
    public interface IHealthMonitorService : IBaseAnimalService
    {
        /// <summary>
        /// Gets the current life state of the animal.
        /// </summary>
        IAnimalLifeState LifeState { get; }

        /// <summary>
        /// Gets a value indicating whether the animal is alive.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Gets a value indicating whether the animal is in a dying state.
        /// </summary>
        bool IsDying { get; }

        /// <summary>
        /// Gets a value indicating whether the animal is dead.
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Gets a value indicating whether the animal is alive but will die soon (i.e., it is dying).
        /// </summary>
        bool IsGoingToDie { get; }

        /// <summary>
        /// Sets the life state of the animal.
        /// </summary>
        /// <param name="state">The new life state to set.</param>
        void SetState(IAnimalLifeState state);

        /// <summary>
        /// Determines whether the animal has died based on its current health.
        /// Updates the life state if necessary.
        /// </summary>
        /// <returns><c>true</c> if the animal is dead; otherwise, <c>false</c>.</returns>
        bool HasDied();

        /// <summary>
        /// Attempts to recover the animal from a dying state if its health is above the death threshold.
        /// </summary>
        void AttemptRecovery();

        /// <summary>
        /// Occurs when the life state of the animal changes.
        /// </summary>
        event StageChangedEventHandler StateChanged;
    }

}