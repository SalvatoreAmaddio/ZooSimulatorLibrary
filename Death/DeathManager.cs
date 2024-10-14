///The DeathManager class is an essential component of your the simulator, 
///handling the periodic decrease of animals' health and managing game-ending 
///conditions when all animals have died. By utilizing asynchronous programming 
///and adhering to solid object-oriented design principles, 
///it ensures smooth and efficient operation within the simulation.
using ZooSimulatorLibrary.Animals;
using ZooSimulatorLibrary.EventHandlers;
using ZooSimulatorLibrary.Extentions;
using ZooSimulatorLibrary.Zoo;

namespace ZooSimulatorLibrary.Death
{
    /// <summary>
    /// Responsible for affecting animals' health over time in the zoo simulator.
    /// Decreases each animal's health every hour and handles game end conditions.
    /// </summary>
    public class DeathManager : IDisposable
    {
        private readonly AbstractZoo zoo;
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// Occurs when the game has ended, typically when all animals are dead.
        /// </summary>
        public event GameEndedEventHandler? GameEnded;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeathManager"/> class with the specified zoo.
        /// </summary>
        /// <param name="zoo">The zoo to manage.</param>
        public DeathManager(AbstractZoo zoo)
        {
            this.zoo = zoo;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeathManager"/> class with the specified zoo and cancellation token source.
        /// </summary>
        /// <param name="zoo">The zoo to manage.</param>
        /// <param name="cancellationTokenSource">The cancellation token source to control the background task.</param>
        public DeathManager(AbstractZoo zoo, CancellationTokenSource cancellationTokenSource)
        {
            this.zoo = zoo;
            this._cancellationTokenSource = cancellationTokenSource;
        }

        /// <summary>
        /// Decreases the health of all animals in the zoo by random percentages and disposes of dead animals.
        /// </summary>
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

        /// <summary>
        /// Starts the background task that periodically decreases animals' health.
        /// </summary>
        public void Run()
        {
            Task.Factory.StartNew(() => RunInBackgroundAsync(),
                   TaskCreationOptions.LongRunning)
                   .ContinueWith(t =>
                   {
                       if (t.Exception != null)
                       {
                           Console.WriteLine($"Background task failed: {t.Exception.Flatten().Message}");
                       }
                   }, TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Stops the background task that decreases animals' health.
        /// </summary>
        /// <param name="cancellationTokenSource">An optional cancellation token source to replace the current one.</param>
        public void Stop(CancellationTokenSource? cancellationTokenSource = null)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = cancellationTokenSource ?? new CancellationTokenSource();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Invokes the <see cref="GameEnded"/> event to signal that the game has ended.
        /// </summary>
        public void InvokeGameEnded()
        {
            GameEnded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="DeathManager"/> class.
        /// </summary>
        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Runs the background task that periodically decreases animals' health.
        /// </summary>
        private async Task RunInBackgroundAsync()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromHours(1), _cancellationTokenSource.Token);

                    if (zoo.IsEmpty)
                    {
                        Console.WriteLine("All animals are dead.");
                        Stop();
                        InvokeGameEnded();
                        break;
                    }

                    AffectLifeExpectancy();
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
    }

}