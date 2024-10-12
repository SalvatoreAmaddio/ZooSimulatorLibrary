using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.EventHandlers;
using ZooSimulatorLibrary.Extentions;
using ZooSimulatorLibrary.Zoo;

namespace ZooSimulatorLibrary.Death
{
    /// <summary>
    /// This class is responsibile for affecting Animals' health over time. 
    /// Every hour each animal is subjected to a decrease of thier health.
    /// </summary>
    public class DeathManager : IDisposable
    {
        private readonly AbstractZoo zoo;
        private CancellationTokenSource _cancellationTokenSource;
        public event GameEndedEventHandler? GameEnded;
        public DeathManager(AbstractZoo zoo)
        {
            this.zoo = zoo;
            _cancellationTokenSource = new();
        }

        public DeathManager(AbstractZoo zoo, CancellationTokenSource cancellationTokenSource)
        {
            this.zoo = zoo;
            this._cancellationTokenSource = cancellationTokenSource;
        }

        public void AffectLifeExpectancy()
        {
            IList<int> values = Utils.ProduceRandomValues(zoo.Animals.CountAll()).ToArray();
            int currentValue = 0;

            for (int i = 0; i < zoo.Animals.Length; i++)
            {
                foreach (IAnimal animal in zoo.Animals[i])
                {
                    animal.HealthService.ReduceHealthBy(values[currentValue]);
                    currentValue++;
                }
            }

            Console.WriteLine("----------------------");
            zoo.MortuaryService.DisposeBodies();
        }

        public void Run()
        {
            Task.Run(RunInBackgroundAsync);
        }

        public void Stop(CancellationTokenSource? cancellationTokenSource = null)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = cancellationTokenSource ?? new();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InvokeGameEnded()
        {
            GameEnded?.Invoke(this, EventArgs.Empty);
        }

        private async Task RunInBackgroundAsync()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromHours(1), _cancellationTokenSource.Token);
                    AffectLifeExpectancy();

                    if (zoo.IsEmpty)
                    {
                        Console.WriteLine("All dead");
                        Stop();
                        InvokeGameEnded();
                    }
                }
                catch (TaskCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in background task: {ex.Message}");
                }
            }

            Console.WriteLine("Background task has been stopped.");
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}