namespace ZooSimulatorLibrary.Animals.States
{
    /// <summary>
    /// Left empty on purpose for flexibility and potential changes
    /// </summary>
    public class AliveState : AbstractAnimalState
    {
        public override string ToString()
        {
            return "Alive";
        }
    }

    public class DyingState : AbstractAnimalState
    {
        public override string ToString()
        {
            return "Dying!";
        }
    }

    public class DeadState : AbstractAnimalState
    {
        public override string ToString()
        {
            return "Dead";
        }
    }
}