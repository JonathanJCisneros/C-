namespace OOPDemo;

public class Student : Person
{
    public int StudentId {get; set;}
    public Student(string firstName, string lastName, int studentId) : base(firstName, lastName){
        StudentId = studentId;
    }
}