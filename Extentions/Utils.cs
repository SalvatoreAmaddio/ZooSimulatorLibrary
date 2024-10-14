namespace ZooSimulatorLibrary.Extentions
{
    /// <summary>
    /// Provides utility methods for calculations, console output, and random value generation in the zoo simulator.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Calculates the decimal representation of a percentage.
        /// </summary>
        /// <param name="percentage">The percentage value to convert (e.g., 25 for 25%).</param>
        /// <returns>The decimal equivalent of the percentage (e.g., 0.25).</returns>
        public static float CalculatePercentage(int percentage)
        {
            return percentage / 100.0f;
        }

        /// <summary>
        /// Writes a message to the console with the specified foreground color.
        /// </summary>
        /// <param name="message">The message to write to the console.</param>
        /// <param name="color">The color to use for the message text. Default is white.</param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Writes a warning message to the console in red color.
        /// </summary>
        /// <param name="message">The warning message to write to the console.</param>
        public static void WriteLineWarning(string message)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Provides a thread-local instance of <see cref="Random"/> seeded with a unique value per thread.
        /// Ensures thread-safe random number generation without contention or duplicate sequences.
        /// </summary>
        private static readonly ThreadLocal<Random> _threadLocalRandom = new(() =>
        {
            // Seed with a value that is likely to be unique
            return new Random(Guid.NewGuid().GetHashCode());
        });

        /// <summary>
        /// Produces a sequence of random integer values within a specified range.
        /// Thread-safe and suitable for asynchronous operations.
        /// </summary>
        /// <param name="iterations">The number of random values to generate.</param>
        /// <param name="min">The inclusive lower bound of the random numbers returned. Default is 0.</param>
        /// <param name="max">The exclusive upper bound of the random numbers returned. Default is 21.</param>
        /// <returns>An enumerable sequence of random integer values.</returns>
        public static IEnumerable<int> ProduceRandomValues(int iterations, int min = 0, int max = 21)
        {
            Random random = _threadLocalRandom.Value!;

            for (int i = 0; i < iterations; i++)
            {
                yield return random.Next(min, max);
            }
        }
    }
}