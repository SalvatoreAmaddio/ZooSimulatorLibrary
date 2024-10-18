///The GeneralHealthMonitorService class is a core component of your the simulator, 
///providing the functionality to monitor animal health and manage life state transitions according 
///to the simulator's rules. 
///By adhering to solid design principles and using patterns like the State pattern and event-driven architecture, 
///this class is well-structured for maintainability and extensibility.

using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.EventHandlers;

namespace ZooSimulatorLibrary.Animals.Services.HealthMonitorServices
{
    /// <summary>
    /// Provides general health monitoring services for animals in the zoo simulator.
    /// Manages life state transitions (Alive, Dying, Dead) based on the animal's health.
    /// </summary>
    public class GeneralHealthMonitorService : AbstractAnimalService, IHealthMonitorService
    {
        /// <summary>
        /// Represents the current life state of the animal.
        /// Initialized to <see cref="AliveState"/>.
        /// </summary>
        protected IAnimalLifeState lifeState = new AliveState();

        /// <summary>
        /// Gets the current life state of the animal.
        /// </summary>
        public IAnimalLifeState LifeState => lifeState;

        /// <summary>
        /// Gets a value indicating whether the animal is alive.
        /// </summary>
        public bool IsAlive => !IsDead;

        /// <summary>
        /// Gets a value indicating whether the animal is in a dying state.
        /// </summary>
        public bool IsDying => lifeState is DyingState;

        /// <summary>
        /// Gets a value indicating whether the animal is dead.
        /// </summary>
        public bool IsDead => lifeState is DeadState;

        /// <summary>
        /// Gets a value indicating whether the animal is alive but will die soon (i.e., it is dying).
        /// </summary>
        public bool IsGoingToDie => IsAlive && IsDying;

        /// <summary>
        /// A small constant used to account for floating-point precision errors.
        /// </summary>
        protected const float Epsilon = 0.00001f;

        /// <summary>
        /// Occurs when the life state of the animal changes.
        /// </summary>
        public event StageChangedEventHandler? StateChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralHealthMonitorService"/> class.
        /// </summary>
        public GeneralHealthMonitorService() : base()
        {
            StateChanged += OnStateChanged;
        }

        /// <summary>
        /// Handles the <see cref="StateChanged"/> event by notifying property changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains event data.</param>
        protected void OnStateChanged(object sender, StateChangedArgs e)
        {
            RaisePropertyChanged(nameof(IsDead));
            RaisePropertyChanged(nameof(IsAlive));
            RaisePropertyChanged(nameof(IsDying));
            RaisePropertyChanged(nameof(IsGoingToDie));
            RaisePropertyChanged(nameof(LifeState));
        }

        /// <summary>
        /// Gets the current life state of the animal.
        /// </summary>
        /// <returns>The current <see cref="IAnimalLifeState"/>.</returns>
        public IAnimalLifeState GetState()
        {
            return lifeState;
        }

        /// <summary>
        /// Sets the life state of the animal and raises the <see cref="StateChanged"/> event.
        /// </summary>
        /// <param name="state">The new life state to set.</param>
        public virtual void SetState(IAnimalLifeState state)
        {
            var args = new StateChangedArgs(lifeState, state, Animal);
            lifeState = state;
            StateChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the <see cref="StateChanged"/> event with the specified arguments.
        /// </summary>
        /// <param name="args">The event data containing old and new states.</param>
        protected void InvokeStateChangedEvents(StateChangedArgs args)
        {
            StateChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Attempts to recover the animal from a dying state if its health is above the death threshold.
        /// </summary>
        /// <exception cref="NullAnimalException">Thrown if the <see cref="Animal"/> is null.</exception>
        public virtual void AttemptRecovery()
        {
            if (Animal == null)
                throw new NullAnimalException();

            if (Animal.Health >= Animal.DeathThreshold && IsDying)
            {
                SetState(new AliveState());
            }
        }

        /// <summary>
        /// Determines whether the animal has died based on its current health.
        /// Updates the life state if necessary.
        /// </summary>
        /// <returns><c>true</c> if the animal is dead; otherwise, <c>false</c>.</returns>
        /// <exception cref="NullAnimalException">Thrown if the <see cref="Animal"/> is null.</exception>
        public virtual bool HasDied()
        {
            // When an Animal has a health below its DeathThreshold, it is pronounced dead.
            // Elephants follow a slightly different approach. See the ElephantHealthMonitorService class.

            if (Animal == null)
                throw new NullAnimalException();

            if (Animal.Health <= Animal.DeathThreshold + Epsilon)
            {
                SetState(new DeadState());
            }

            return IsDead;
        }

        /// <summary>
        /// Releases all resources used by the <see cref="GeneralHealthMonitorService"/> class.
        /// </summary>
        public override void Dispose()
        {
            StateChanged -= OnStateChanged;
            GC.SuppressFinalize(this);
        }
    }

}