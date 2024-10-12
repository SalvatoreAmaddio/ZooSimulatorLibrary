namespace ZooSimulatorLibrary.Zoo.Services
{
    public class NullZooException : NullReferenceException
    {
        public NullZooException() : base("Zoo cannot be null") { }
    }
}