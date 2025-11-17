namespace lab2;

public class Student : Person
{
    public int CourseNumber { get; set; }
    public string Faculty { get; set; } = null!;
    public string Group { get; set; } = null!;
    public List<Course>? CoursesAttended { get; set; }
}