///The ElephantHealthMonitorService class provides specialized health monitoring for elephants 
///in the zoo simulator, implementing the unique rules that govern their life state transitions. 
///By extending GeneralHealthMonitorService and overriding key methods, 
///it ensures that elephants are managed according to the simulator's specifications.

using ZooSimulatorLibrary.Animals.States;
using ZooSimulatorLibrary.EventHandlers;
using ZooSimulatorLibrary.Extentions;

namespace ZooSimulatorLibrary.Animals.Services.HealthMonitorServices
{
    public class ElephantHealthMonitorService : GeneralHealthMonitorService
    {
        public ElephantHealthMonitorService() : base()
        {
        }

        public override bool HasDied()
        {
            //When an Elephant has a health below or equal its DeathThreshold (70%) it enters in a Dying State.
            //If its health does not return ABOVE 70% it will die.

            if (Animal == null) throw new NullAnimalException();

            if (Animal.Health <= Animal.DeathThreshold)
            {
                SetState(new DyingState());
                if (IsGoingToDie)
                {
                    Utils.WriteLineWarning("I am Going to die!");
                }
            }

            return IsDead;
        }

        public override void SetState(IAnimalLifeState state)
        {
            StateChangedArgs args;

            //If the Elephan is already in a Dying State, then it's dead.
            if (state is DyingState && lifeState is DyingState)
            {
                args = new(lifeState, new DeadState(), Animal);
                lifeState = new DeadState();
            }
            else
            {
                args = new(lifeState, state, Animal);
                lifeState = state;
            }

            InvokeStateChangedEvents(args);
        }
    }
}