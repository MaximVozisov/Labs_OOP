using UtilityLibraries;
using static UtilityLibraries.CollectionLibrary;
using static UtilityLibraries.PersonLibrary;
namespace Lab13;
public static class ListGenerator
{
    //генерация нового связного списка
    public static MyEventLinkedList<Person> GenerateMyEventLinkedList(string Name)
    {
        var list = new MyEventLinkedList<Person>(Name);
        int len = rnd.Next(UserInterface1.MIN_LENGTH, UserInterface1.MAX_LENGTH);
        for (int i = 0; i < len; ++i)
        {
            list.Add(GenerateHuman());
        }
        return list;
    }
    //генерация нового связного списка
    public static void RegenerateMyEventLinkedList(MyEventLinkedList<Person> list)
    {
        list.Clear();
        int len = rnd.Next(UserInterface1.MIN_LENGTH, UserInterface1.MAX_LENGTH);
        for (int i = 0; i < len; ++i)
        {
            list.Add(GenerateHuman());
        }
    }
}