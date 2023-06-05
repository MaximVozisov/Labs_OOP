namespace UtilityLibraries;
using System.Collections;
public class Exam : Test
{
    public int count_tickets { get; protected set; }

    public Exam()
    {
        this.RandomInit();
    }
    public Exam(string? subject_surname, string? subject_name, float? result, string? name_test, int count_tickets) : base(subject_surname, subject_name, result, name_test)
    {
        this.count_tickets = count_tickets;
    }
    public override string ToString()
    {
        return $"Ученик: {subject_surname} {subject_name}" +
            $", Отметка: {result}" +
            $", Экзамен по: {name_test}" +
            $", Количество билетов: {count_tickets}";
    }
    public override object Clone()
    {
        return new Exam(this.subject_surname, this.subject_name, this.result, this.name_test, this.count_tickets);
    }
    public override void RandomInit()
    {
        Random rnd = new Random();
        this.subject_surname = surname[rnd.Next(0, surname.Length)];
        System.Threading.Thread.Sleep(5);
        this.subject_name = name[rnd.Next(0, name.Length)];
        System.Threading.Thread.Sleep(5);
        this.result = marks[rnd.Next(0, marks.Length)];
        System.Threading.Thread.Sleep(5);
        this.name_test = tests[rnd.Next(0, tests.Length)];
        System.Threading.Thread.Sleep(5);
        this.count_tickets = rnd.Next(2, 6);
    }
}
