namespace ZooSimulatorLibrary.Zoo.Services
{
    public abstract class AbstractZooService : IBaseZooService
    {
        public AbstractZoo? Zoo { protected get; set; }
        public AbstractZooService(AbstractZoo zoo)
        {
            Zoo = zoo;
        }

        public AbstractZooService()
        {
        }
    }
}