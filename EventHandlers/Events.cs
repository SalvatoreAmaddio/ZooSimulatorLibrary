
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Animals.States;

namespace ZooSimulatorLibrary.EventHandlers
{

    public delegate void StageChangedEventHandler(object sender, StateChangedArgs e);

    public class StateChangedArgs(IAnimalLifeState oldState, IAnimalLifeState newState, IAnimal animal) : EventArgs
    {
        public IAnimalLifeState OldState { get; } = oldState;
        public IAnimalLifeState NewState { get; } = newState;
        public IAnimal Animal { get; } = animal;
    }

    public delegate void GameEndedEventHandler(object sender, EventArgs e);

}
