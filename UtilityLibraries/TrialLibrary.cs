using UtilityLibraries;

namespace UtilityLibraries;
public static class TrialLibrary
{
    public static Random rnd = new Random();

    public static Trial GenerateHuman()
    {
        switch (rnd.Next(0, 4))
        {
            case 0:
                return new Trial();
            case 1:
                return new Test();
            case 2:
                return new Exam();
            case 3:
                return new ExamOut();
            default:
                return new Trial();
        }
    }
}