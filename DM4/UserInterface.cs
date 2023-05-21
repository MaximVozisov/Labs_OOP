using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DM4
{
    static class UserInterface
    {
        public static void Start()
        {
            bool Exit = false;

            while (!Exit)
            {
                Console.Clear();
                Program.ColorDisplay("Номера команд:\n" +
                    "1. Ярусно-параллельная форма графа (топологическая сортировка).\n" +
                    "2. Поиск минимального пути. Алгоритм Шимбелла.\n" +
                    "3. Клика графа.\n" +
                    "0. Выход.\n", ConsoleColor.Blue);
                int command = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0 && num <= 3);
                Console.Clear();
                switch (command)
                {
                    case 1:
                        task1();
                        break;
                    case 2:
                        task2();
                        break;
                    case 3:
                        task3();
                        break;
                    case 0:
                        Exit = true;
                        break;
                }
            }
        }

        public static void task1()
        {
            bool Exit = false;
            while (!Exit)
            {
                Program.ColorDisplay("Номера команд:\n" +
                   "1. Ввести граф.\n" +
                   "2. Выполнить задание.\n" +
                   "0. Назад.\n", ConsoleColor.Yellow);
                int command = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0 && num <= 2);
                switch (command)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 0:
                        Exit = true;
                        break;
                }
                Program.ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void task2()
        {
            bool Exit = false;
            while (!Exit)
            {
                Program.ColorDisplay("Номера команд:\n" +
                   "1. Ввести граф.\n" +
                   "2. Выполнить задание.\n" +
                   "0. Назад.\n", ConsoleColor.Yellow);
                int command = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0 && num <= 2);
                switch (command)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 0:
                        Exit = true;
                        break;
                }
                Program.ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void task3()
        {
            bool Exit = false;
            while (!Exit)
            {
                Program.ColorDisplay("Номера команд:\n" +
                   "1. Ввести граф.\n" +
                   "2. Выполнить задание.\n" +
                   "0. Назад.\n", ConsoleColor.Yellow);
                int command = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0 && num <= 2);
                switch (command)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 0:
                        Exit = true;
                        break;
                }
                Program.ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}