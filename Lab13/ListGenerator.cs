using UtilityLibraries;
using static UtilityLibraries.CollectionLibrary;
using static UtilityLibraries.TrialLibrary;
namespace Lab13;
public static class ListGenerator
{
    //генерация нового связного списка
    public static MyEventLinkedList<Trial> GenerateMyEventLinkedList(string Name)
    {
        var list = new MyEventLinkedList<Trial>(Name);
        int len = rnd.Next(UserInterface.MIN_LENGTH, UserInterface.MAX_LENGTH);
        for (int i = 0; i < len; ++i)
        {
            list.Add(GenerateHuman());
        }
        return list;
    }
    //генерация нового связного списка
    public static void RegenerateMyEventLinkedList(MyEventLinkedList<Trial> list)
    {
        list.Clear();
        int len = rnd.Next(UserInterface.MIN_LENGTH, UserInterface.MAX_LENGTH);
        for (int i = 0; i < len; ++i)
        {
            list.Add(GenerateHuman());
        }
    }
}