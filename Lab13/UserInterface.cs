using Lab13;
using UtilityLibraries;
using UtilityLibraries;
using static UtilityLibraries.CollectionConsole;
using static UtilityLibraries.CollectionLibrary;
using static UtilityLibraries.TrialLibrary;
namespace Lab13;
internal static class UserInterface
{
    internal const int MIN_LENGTH = 10;
    internal const int MAX_LENGTH = 20;
    internal static void Execute()
    {
        bool needExit = false;
        var list1 = ListGenerator.GenerateMyEventLinkedList("Список 1");
        var list2 = ListGenerator.GenerateMyEventLinkedList("Список 2");
        //создание первого журнала и подписка его на события всех изменений первого списка
        var journal1 = new Journal<Trial>();
        list1.CountChanged += journal1.AddChange;
        list1.ReferenceChanged += journal1.AddChange;
        //создание второго журнала и подписка его на события изменения ссылок двух списков
        var journal2 = new Journal<Trial>();
        list2.CountChanged += journal2.AddChange;
        list2.ReferenceChanged += journal2.AddChange;
        while (!needExit)
        {
            ColorDisplay("Номера команд:\n1. Сгенерировать новый первый список\n2. Сгенерировать новый второй список" +
            "\n3. Добавить случайный элемент в первый список\n4. Добавить случайный элемент во второй список\n5. Удалить элемент из первого списка (по индексу)" +
            "\n6. Удалить элемент из второго списка (по индексу)\n7. Сгенерировать новый элемент вместо существующего в первом списке" +
            "\n8. Сгенерировать новый элемент вместо существующего во втором списке\n0. Выход\n-1. Вывести журнал изменений 1 списка\n-2. Вывести журнал изменений 2 списка\n", ConsoleColor.Yellow);
            ColorDisplay("Исходный список 1:\n", ConsoleColor.Magenta);
            Display(list1);
            ColorDisplay("Исходный список 2:\n", ConsoleColor.Magenta);
            Display(list2);
            int command = GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= -2 && num <= 8);
            if (command > 0)
            {
                Console.Clear();
                ColorDisplay("Исходный список:\n", ConsoleColor.Magenta);
            }
            switch (command)
            {
                case -2:
                    Console.Clear();
                    Console.WriteLine(journal2);
                    break;
                case -1:
                    Console.Clear();
                    Console.WriteLine(journal1);
                    break;
                case 1:
                    Display(list1);
                    ListGenerator.RegenerateMyEventLinkedList(list1);
                    ColorDisplay("Новый связный список:\n", ConsoleColor.Magenta);
                    Display(list1);
                    break;
                case 2:
                    Display(list2);
                    ListGenerator.RegenerateMyEventLinkedList(list2);
                    ColorDisplay("Новый связный список:\n", ConsoleColor.Magenta);
                    Display(list2);
                    break;
                case 3:
                    Display(list1);
                    list1.Add(GenerateHuman());
                    ColorDisplay("Список после добавления нового элемента:\n", ConsoleColor.Magenta);
                    Display(list1);
                    break;
                case 4:
                    Display(list2);
                    list2.Add(GenerateHuman());
                    ColorDisplay("Список после добавления нового элемента:\n", ConsoleColor.Magenta);
                    Display(list2);
                    break;
                case 5:
                    Display(list1);
                    if (list1.Count == 0)
                    {
                        Console.WriteLine("Список уже пуст!");
                    }
                    else
                    {
                        Console.WriteLine("Введённый элемент удалён: " + list1.RemoveFrom(GetInt("Введите индекс для удаления: ",
                              "Несуществующий индекс, повторите ввод =>\n", (int num) => num >= 0 && num < list1.Count)));
                        ColorDisplay("Список после удаления элемента:\n", ConsoleColor.Magenta);
                        Display(list1);
                    }
                    break;
                case 6:
                    Display(list2);
                    if (list2.Count == 0)
                    {
                        Console.WriteLine("Список уже пуст!");
                    }
                    else
                    {
                        Console.WriteLine("Введённый элемент удалён: " + list2.RemoveFrom(GetInt("Введите индекс для удаления: ",
                              "Несуществующий индекс, повторите ввод =>\n", (int num) => num >= 0 && num < list2.Count)));
                        ColorDisplay("Список после удаления элемента:\n", ConsoleColor.Magenta);
                        Display(list2);
                    }
                    break;
                case 7:
                    Display(list1);
                    if (list1.Count == 0)
                    {
                        Console.WriteLine("Изменять нечего, список пуст!");
                    }
                    else
                    {
                        list1[GetInt("Введите индекс для генерации нового элемента вместо существующего: ",
                              "Несуществующий индекс, повторите ввод =>\n", (int num) => num >= 0 && num < list1.Count)] = GenerateHuman();
                    }
                    break;
                case 8:
                    Display(list2);
                    if (list2.Count == 0)
                    {
                        Console.WriteLine("Изменять нечего, список пуст!");
                    }
                    else
                    {
                        list2[GetInt("Введите индекс для генерации нового элемента вместо существующего: ",
                              "Несуществующий индекс, повторите ввод =>\n", (int num) => num >= 0 && num < list2.Count)] = GenerateHuman();
                    }
                    break;
                case 0:
                    needExit = true;
                    break;
            }
            ColorDisplay("Для продолжения нажмите любую клавишу...", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }
    }
}