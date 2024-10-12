namespace ZooSimulatorLibrary.Zoo.Services
{
    public abstract class AbstractZooService : IBaseZooService
    {
        public AbstractZoo? Zoo { protected get; set; }
        protected readonly object _lockObject = new();
        public AbstractZooService(AbstractZoo zoo)
        {
            Zoo = zoo;
        }

        public AbstractZooService()
        {
        }
    }
}