using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.EventHandlers;
using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Animals.Services.HealthMonitorServices
{
    public class GeneralHealthMonitorService : AbstractAnimalService, IHealthMonitorService
    {
        protected IAnimalLifeState lifeState = new AliveState();
        public IAnimalLifeState LifeState { get => lifeState; }
        public bool IsAlive => !IsDead;
        public bool IsDying => lifeState is DyingState;
        public bool IsDead => lifeState is DeadState;
        public bool IsGoingToDie => IsAlive && IsDying;

        protected const float Epsilon = 0.00001f;

        public event StageChangedEventHandler? StateChanged;

        public GeneralHealthMonitorService() : base()
        {
            StateChanged += OnStateChanged;
        }

        public GeneralHealthMonitorService(IAnimal animal) : base(animal)
        {
            StateChanged += OnStateChanged;
        }

        protected void OnStateChanged(object sender, StateChangedArgs e)
        {
            RaisePropertyChanged(nameof(IsDead));
            RaisePropertyChanged(nameof(IsAlive));
            RaisePropertyChanged(nameof(IsDying));
            RaisePropertyChanged(nameof(IsGoingToDie));
            RaisePropertyChanged(nameof(LifeState));
        }

        public IAnimalLifeState GetState()
        {
            return lifeState;
        }

        public virtual void SetState(IAnimalLifeState state)
        {
            StateChangedArgs args = new(lifeState, state, Animal);
            lifeState = state;
            IAnimalLifeState newState = lifeState;
            StateChanged?.Invoke(this, args);
        }

        protected void InvokeStateChangedEvents(StateChangedArgs args)
        {
            StateChanged?.Invoke(this, args);
        }

        public virtual void AttemptRecovery()
        {
            if (Animal == null) throw new NullAnimalException();

            if (Animal.Health >= Animal.DeathThreshold && IsDying)
            {
                SetState(new AliveState());
            }
        }

        public virtual bool HasDied()
        {
            //When an Animal has a health below its DeathThreshold, it is pronounced dead.
            //Elephants follow a silightly different approach. See the ElephantHealthMonitorService class.

            if (Animal == null) throw new NullAnimalException();

            if (Animal.Health <= Animal.DeathThreshold + Epsilon)
            {
                SetState(new DeadState());
            }

            return IsDead;
        }

        public override void Dispose()
        {
            StateChanged -= OnStateChanged;
            GC.SuppressFinalize(this);
        }
    }
}