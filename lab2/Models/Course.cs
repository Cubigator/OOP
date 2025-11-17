namespace lab2;

public abstract class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Teacher> Teachers { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;
}