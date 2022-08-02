using OOPDemo;

Person alex = new Person("Alex", "Miller");
Student studiousCody = new Student("Cody", "Adams", 193865);
Student studiousAlex = new Student("Alex", "Miller", 191982);
List<string> taughtCourses = new List<string>();
taughtCourses.Add("Python");
taughtCourses.Add("MERN");
taughtCourses.Add("C#");
Instructor max = new Instructor("Max", "Rauchman", taughtCourses);

List<Student> studentList = new List<Student>(){studiousAlex, studiousCody};

Lecture cSharp = new Lecture(max, studentList, "C#");

Console.WriteLine(alex.FullName());
Console.WriteLine(studiousAlex.FullName());
Console.WriteLine(studiousAlex.StudentId);
Console.WriteLine(max.FullName());
max.PrintCourses();

cSharp.PrintAttendance();

