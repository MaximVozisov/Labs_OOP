using UtilityLibraries;
using static UtilityLibraries.CollectionConsole;
using static UtilityLibraries.CollectionLibrary;
using static UtilityLibraries.TrialLibrary;
namespace Lab12;
public static class UserInterface
{
    internal static int MIN_LENGTH = 5;
    internal static int MAX_LENGTH = 15;
    internal static void Execute()
    {
        bool needExit = false;
        var myLinkedList = GenerateMyLinkedList();
        while (!needExit)
        {
            ColorDisplay("Номера команд:\n1. Сгенерировать и вывести новый связный список\n2. Добавить элемент\n3. Удалить элемент" +
            "\n4. Очистить список\n5. Проверить наличие элемента в списке\n6. Удалить из списка все элементы с заданными информационными полями." +
            "\n7. Поверхностное копирвоание с помощью CopyTo()\n8. Глубокое копирование\n0. Выход\n", ConsoleColor.Yellow);
            ColorDisplay("Исходный список:\n", ConsoleColor.Magenta);
            Display(myLinkedList);
            int command = GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 0 && num <= 8);
            Console.Clear();
            ColorDisplay("Исходный список:\n", ConsoleColor.Magenta);
            Display(myLinkedList);
            switch (command)
            {
                case 1:
                    myLinkedList = GenerateMyLinkedList();
                    ColorDisplay("Новый связный список:\n", ConsoleColor.Magenta);
                    Display(myLinkedList);
                    break;
                case 2:
                    ColorDisplay("Номера команд:\n1. Сгенерировать \n2. Добавить в ручную", ConsoleColor.Green);
                    command = GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 1 && num <= 2);
                    Console.Clear();
                    myLinkedList.Add(GenerateHuman());
                    ColorDisplay("Список после добавления нового элемента:\n", ConsoleColor.Magenta);
                    Display(myLinkedList);
                    break;
                case 3:
                    Console.WriteLine("Введённый элемент удалён: " + myLinkedList.Remove(Trial.InputTrial()));
                    ColorDisplay("Список после удаления элемента:\n", ConsoleColor.Magenta);
                    Display(myLinkedList);
                    break;
                case 4:
                    myLinkedList.Clear();
                    ColorDisplay("Текущий список:\n", ConsoleColor.Magenta);
                    Display(myLinkedList);
                    break;
                case 5:
                    Console.WriteLine("Список содержит введённый элемент: " + myLinkedList.Contains(Trial.InputTrial()));
                    break;
                case 6:
                    DelName(myLinkedList, Trial.InputTrial());
                    ColorDisplay("Текущий список:\n", ConsoleColor.Magenta);
                    Display(myLinkedList);
                    break;
                case 7:
                    Trial[] array = new Trial[myLinkedList.Count];
                    myLinkedList.CopyTo(array, 0);
                    ColorDisplay("Поверхностная копия (массив):\n", ConsoleColor.Magenta);
                    if (array.Length > 0)
                    {
                        int counter = 0;
                        foreach (var trial in array)
                        {
                            Console.WriteLine(counter++.ToString() + ". " + trial);
                        }
                    }
                    else
                    {
                        ColorDisplay("Массив пуст!\n", ConsoleColor.Red);
                    }
                    break;
                case 8:
                    var clone = (MyLinkedList<Trial>)myLinkedList.Clone();
                    ColorDisplay("Глубокая копия:\n", ConsoleColor.Magenta);
                    Display(clone);
                    ColorDisplay("Исходный список после очищения:\n", ConsoleColor.Magenta);
                    myLinkedList.Clear();
                    Display(myLinkedList);
                    ColorDisplay("Глубокая копия:\n", ConsoleColor.Magenta);
                    Display(clone);
                    myLinkedList = (MyLinkedList<Trial>)clone.Clone();
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
    // Удаление всех заданных элементов
    private static void DelName(MyLinkedList<Trial> myLinkedList, Trial item)
    {
        while (myLinkedList.Contains(item) != false)
        {
            myLinkedList.Remove(item);
        }
    }
    // Генерация нового связного списка
    public static MyLinkedList<Trial> GenerateMyLinkedList()
    {
        int len = rnd.Next(MIN_LENGTH, MAX_LENGTH);
        var myLinkedList = new MyLinkedList<Trial>();
        for (int i = 0; i < len; ++i)
        {
            myLinkedList.Add(GenerateHuman());
        }
        return myLinkedList;
    }
}