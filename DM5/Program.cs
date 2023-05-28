using System;

namespace DM5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Автомат";
            UserInterface.Start();
            return;
        }

        public static int GetInt(string inputMessage, string errorMessage, Predicate<int> condition)
        {
            int result;
            bool isCorrect;
            do
            {
                Console.Write(inputMessage);
                isCorrect = int.TryParse(Console.ReadLine(), out result) && condition(result);
                if (!isCorrect)
                {
                    ColorDisplay(errorMessage, ConsoleColor.Red);
                }
            } while (!isCorrect);
            return result;
        }

        public static void ColorDisplay(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
