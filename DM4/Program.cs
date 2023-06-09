﻿using Microsoft.VisualBasic;
using System;

namespace DM4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "«Основные алгоритмы на графах»";
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
