using System;
using System.Collections.Generic;
using System.Text;

namespace DM5
{
    static class UserInterface
    {
        static public void Start()
        {
            WorkMachine str = new WorkMachine();
            bool Exit = false;
            while (!Exit)
            {
                Program.ColorDisplay($"Слово: ", ConsoleColor.Yellow);
                if (str.str == null)
                {
                    Program.ColorDisplay($"Создайте слово!", ConsoleColor.Red);
                }
                else
                {
                    Program.ColorDisplay($"{str.str}", ConsoleColor.Green);
                }
                Program.ColorDisplay("\nНомера команд:\n" +
                   "1. Создание слова.\n" +
                   "2. Проверить слово.\n" +
                   "0. ВЫХОД.\n", ConsoleColor.Yellow);
                int command = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0 && num <= 2);
                switch (command)
                {
                    case 1:
                        str.CreateStr();
                        break;
                    case 2:
                        str.StartMachine();
                        break;
                    case 0:
                        Exit = true;
                        break;
                }
                Console.Clear();
            }
        }
    }
}
