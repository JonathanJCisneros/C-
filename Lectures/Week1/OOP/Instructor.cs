namespace OOPDemo;

public class Instructor : Person
{
    public List<string> TaughtCourses {get; set;}
    public Instructor(string firstName, string lastName, List<string> taughtCourses) : base(firstName, lastName)
    {
        TaughtCourses = taughtCourses;
    }

    public void PrintCourses()
    {
        foreach(string course in TaughtCourses)
        {
            Console.WriteLine(course);
        }
    }
}