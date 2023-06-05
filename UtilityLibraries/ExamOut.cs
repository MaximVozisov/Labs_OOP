namespace UtilityLibraries;
using System.Collections;
public class ExamOut : Exam
{
    public int year_out { get; protected set; }

    public ExamOut()
    {
        this.RandomInit();
    }
    public ExamOut(string? subject_surname, string? subject_name, float? result, string? name_test, int count_tickets, int year_out) : base(subject_surname, subject_name, result, name_test, count_tickets)
    {
        this.year_out = year_out;
    }
    public override string ToString()
    {
        if (result <= 2)
        {
            return $"Ученик: {subject_surname} {subject_name}" +
            $", Отметка: {result}" +
            $", Экзамен по: {name_test}" +
            $", Количество билетов: {count_tickets}" +
            $", Год выпуска: Не выпустился";
        }
        else
        {
            return $"Ученик: {subject_surname} {subject_name}" +
            $", Отметка: {result}" +
            $", Экзамен по: {name_test}" +
            $", Количество билетов: {count_tickets}" +
            $", Год выпуска: {year_out} год";
        }
    }
    public override object Clone()
    {
        return new ExamOut(this.subject_surname, this.subject_name, this.result, this.name_test, this.count_tickets, this.year_out);
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
        System.Threading.Thread.Sleep(5);
        this.year_out = rnd.Next(1999, 2022);
    }
}
