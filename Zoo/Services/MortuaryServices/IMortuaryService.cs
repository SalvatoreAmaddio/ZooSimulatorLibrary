namespace ZooSimulatorLibrary.Zoo.Services.MortuaryServices
{
    /// <summary>
    /// Defines the contract for a mortuary service in the zoo simulator.
    /// Responsible for handling the disposal of deceased animals in the zoo.
    /// </summary>
    public interface IMortuaryService : IBaseZooService
    {
        /// <summary>
        /// Disposes of the bodies of deceased animals in the zoo.
        /// </summary>
        void DisposeBodies();
    }
}
