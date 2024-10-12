namespace ZooSimulatorLibrary.Extentions
{
    public class Utils
    {
        public static float CalculatePercentage(int percentage)
        {
            return percentage / 100.0f;
        }

        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        public static void WriteLineWarning(string message)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        public static IEnumerable<int> ProduceRandomValues(int iterations, int min = 0, int max = 21)
        {
            Random random = new();

            for (int i = 0; i < iterations; i++)
            {
                yield return random.Next(min, max);
            }
        }
    }
}
