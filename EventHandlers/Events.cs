
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.Animals.States;

namespace ZooSimulatorLibrary.EventHandlers
{
    /// <summary>
    /// Represents the method that will handle the event when an animal's life state changes.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="StateChangedArgs"/> that contains the event data.</param>
    public delegate void StageChangedEventHandler(object sender, StateChangedArgs e);

    /// <summary>
    /// Provides data for the state changed event.
    /// </summary>
    public class StateChangedArgs : EventArgs
    {
        /// <summary>
        /// Gets the previous life state of the animal.
        /// </summary>
        public IAnimalLifeState OldState { get; }

        /// <summary>
        /// Gets the new life state of the animal.
        /// </summary>
        public IAnimalLifeState NewState { get; }

        /// <summary>
        /// Gets the animal whose state has changed.
        /// </summary>
        public IAnimal Animal { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateChangedArgs"/> class.
        /// </summary>
        /// <param name="oldState">The previous life state of the animal.</param>
        /// <param name="newState">The new life state of the animal.</param>
        /// <param name="animal">The animal whose state has changed.</param>
        public StateChangedArgs(IAnimalLifeState oldState, IAnimalLifeState newState, IAnimal animal)
        {
            OldState = oldState;
            NewState = newState;
            Animal = animal;
        }
    }

    /// <summary>
    /// Represents the method that will handle the event when the game ends.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains no event data.</param>
    public delegate void GameEndedEventHandler(object sender, EventArgs e);

}
