namespace lab2;

public abstract class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public Teacher Teacher { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}