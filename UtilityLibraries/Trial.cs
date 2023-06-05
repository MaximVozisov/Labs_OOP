namespace UtilityLibraries;
using static UtilityLibraries.CollectionConsole;
using System.Collections;

public class Trial : IRandomInit, IComparable<Trial>, ICloneable
{
    protected static readonly string[] surname = { "Возисов", "Мазунин", "Молчанов", "Иванов", "Кузнецов", "Глазырин", "Власов", "Омутных", "Иванов", "Петров", "Сидоров" };
    protected static readonly string[] name = { "Максим", "Иван", "Егор", "Дима", "Артем", "Павел", "Сергей", "Олег", "Тимур", "Никита", "Данил", "Илья", "Андрей", "Александр" };
    protected static readonly int[] marks = { 5, 4, 3, 2 };
    public string? subject_name { get; protected set; }
    public string? subject_surname { get; protected set; }
    public float? result { get; protected set; }

    public Trial BaseTrial
    {
        get
        {
            return new Trial(this.subject_name, this.subject_surname, this.result);
        }
    }
    public Trial()
    {
        this.RandomInit();
    }
    public Trial(string? subject_surname, string? subject_name, float? result)
    {
        this.subject_name = subject_name;
        this.subject_surname = subject_surname;
        this.result = result;
    }
    public Trial(string subject_surname, string subject_name)
    {
        this.subject_name = subject_name;
        this.subject_surname = subject_surname;
    }
    public static Trial InputTrial()
    {
        string? subject_name, subject_surname;
        float? marks;
        Console.Write("Введите фамилию: ");
        subject_surname = Console.ReadLine();
        Console.Write("Введите имя: ");
        subject_name = Console.ReadLine();
        marks = GetInt("Введите оценку(2-5): ", "Оценка должна быть от 2 до 5\n", (int num) => num >= 2 && num <= 5);
        return new Trial(subject_surname, subject_name, marks);
    }
    public override string ToString()
    {
        return $"Ученик: {subject_surname} {subject_name}, Отметка: {result}";
    }
    public string NoVirtualToString()
    {
        return $"Ученик: {subject_surname} {subject_name}, Отметка: {result}";
    }
    public int CompareTo(Trial? t)
    {
        if (t is not null)
        {
            return string.Compare(this.subject_surname + this.subject_name + this.result, t.subject_surname + t.subject_name + t.result);
        }
        else
        {
            return -1;
        }
    }
    public virtual object Clone()
    {
        return new Trial(this.subject_surname, this.subject_name, this.result);
    }
    public virtual void RandomInit()
    {
        Random rnd = new Random();
        this.subject_surname = surname[rnd.Next(0, surname.Length - 1)];
        System.Threading.Thread.Sleep(5);
        this.subject_name = name[rnd.Next(0, name.Length - 1)];
        System.Threading.Thread.Sleep(5);
        this.result = marks[rnd.Next(0, marks.Length - 1)];
    }
    public override bool Equals(object obj)
    {
        if (obj is not null)
        {
            return (obj is Trial && ((Trial)obj).subject_surname == this.subject_surname &&
            ((Trial)obj).subject_name == this.subject_name && ((Trial)obj).result == this.result);
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
