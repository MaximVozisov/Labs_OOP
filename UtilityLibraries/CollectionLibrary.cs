namespace UtilityLibraries;
public static class CollectionLibrary
{
    //вывод коллекции
    public static void Display<T>(IEnumerable<T> collection)
    {
        if (collection.Count() > 0)
        {
            int counter = 0;
            foreach (var item in collection)
            {
                Console.WriteLine(counter++.ToString() + ". " + (item?.ToString() ?? "NULL"));
            }
        }
        else
        {
            CollectionConsole.ColorDisplay("Коллекция пуста!\n", ConsoleColor.Red);
        }
    }
    public static void Display<T>(IEnumerable<T> collection, string label)
    {
        CollectionConsole.ColorDisplay(label, ConsoleColor.Magenta);
        if (collection.Count() > 0)
        {
            int counter = 0;
            foreach (var item in collection)
            {
                Console.WriteLine(counter++.ToString() + ". " + (item?.ToString() ?? "NULL"));
            }
        }
        else
        {
            CollectionConsole.ColorDisplay("Коллекция пуста!\n", ConsoleColor.Red);
        }
    }
}