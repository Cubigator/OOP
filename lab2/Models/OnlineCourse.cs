namespace lab2;

public class OnlineCourse : Course
{
    public List<OnlineLesson>? Lessons { get; set; } 
    public string? PlatformUrl { get; set; }
}