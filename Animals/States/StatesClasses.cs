///The AliveState, DyingState, and DeadState classes are essential components of your zoo simulator's 
///health management system. They represent the different life states of an animal and provide a 
///flexible framework for future development. By implementing the State design pattern, 
///the application can manage state-dependent behavior effectively, 
///leading to a clean and maintainable codebase.

namespace ZooSimulatorLibrary.Animals.States
{
    /// <summary>
    /// Represents the alive state of an animal in the zoo simulator.
    /// This class is intentionally left empty to allow for future extensions.
    /// </summary>
    public class AliveState : AbstractAnimalState
    {
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string "Alive" indicating the animal is alive.</returns>
        public override string ToString()
        {
            return "Alive";
        }
    }

    /// <summary>
    /// Represents the dying state of an animal in the zoo simulator.
    /// This class is intentionally left empty to allow for future extensions.
    /// </summary>
    public class DyingState : AbstractAnimalState
    {
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string "Dying!" indicating the animal is in a dying state.</returns>
        public override string ToString()
        {
            return "Dying!";
        }
    }

    /// <summary>
    /// Represents the dead state of an animal in the zoo simulator.
    /// This class is intentionally left empty to allow for future extensions.
    /// </summary>
    public class DeadState : AbstractAnimalState
    {
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string "Dead" indicating the animal is dead.</returns>
        public override string ToString()
        {
            return "Dead";
        }
    }

}