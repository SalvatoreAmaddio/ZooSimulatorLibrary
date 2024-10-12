namespace ZooSimulatorLibrary.Zoo.Services.MortuaryServices
{
    public class MortuaryService : AbstractZooService, IMortuaryService
    {
        public MortuaryService() { }
        public MortuaryService(AbstractZoo zoo) : base(zoo) { }

        public void DisposeBodies()
        {
            if (Zoo == null)
            {
                throw new NullZooException();
            }

            for (int i = 0; i < Zoo.Animals.Length; i++)
            {
                var toRemove = Zoo.Animals[i].Where(s => s.HealthMonitorService.IsDead).ToList();
                Zoo.Animals[i].RemoveRange(toRemove);

                if (Zoo.Animals[i].Count == 0)
                {
                    Zoo.Animals[i].Clear();
                }
            }

            Zoo.Animals = Zoo.Animals.Where(s=>s.Count > 0).ToArray();
        }
    }
}
