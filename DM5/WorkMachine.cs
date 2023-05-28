using System;
using System.Collections.Generic;
using System.Text;

namespace DM5
{
    internal class WorkMachine
    {
        public string str;

        public WorkMachine()
        {
            str = null;
        }

        // Создание слова
        public void CreateStr()
        {
            Program.ColorDisplay("Введите новое слово: ", ConsoleColor.Blue);
            str = Console.ReadLine();
            Program.ColorDisplay("Новое слово успешно создано\n", ConsoleColor.Green);
            Program.ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
            Console.ReadKey();
        }

        //Реализация автомата
        public void StartMachine()
        {
            char Q = 'H'; // начальное состояние
            int i = 0;
            if (str != null)
            {
                while (i != str.Length && Q != 'E') // E == Error
                {
                    switch (Q)
                    {
                        case 'H':
                            {
                                if (str[i] == '0')
                                {
                                    Q = 'B';
                                    i++;
                                }
                                else Q = 'E';
                                break;
                            }
                        case 'B':
                            {
                                if (str[i] == '1')
                                {
                                    Q = 'D'; // D == DC
                                    i++;
                                }
                                else Q = 'E';
                                break;
                            }
                        case 'D':
                            {
                                if (str[i] == '0')
                                {
                                    Q = 'B';
                                    i++;
                                }
                                else
                                {
                                    if (str[i] == 'T')
                                    {
                                        Q = 'S';
                                        i++;
                                    }
                                    else Q = 'E';
                                }
                                break;
                            }
                        case 'S':
                            {
                                if (i != str.Length)
                                {
                                    Q = 'E';
                                }
                                break;
                            }
                        default:
                            {
                                Q = 'E';
                                break;
                            }
                    }
                }

                if (Q == 'S')
                {
                    Program.ColorDisplay("Слово верно\n", ConsoleColor.Green);
                }
                else
                {
                    Program.ColorDisplay("Слово НЕ верно\n", ConsoleColor.Red);
                }
            }
            else Program.ColorDisplay("Слово НЕ верно\n", ConsoleColor.Red);
            Program.ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
            Console.ReadKey();
        }
    }
}
