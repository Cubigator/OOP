using Microsoft.EntityFrameworkCore;

namespace lab2;

public class Context : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
    public DbSet<OnlineLesson> OnlineLessons { get; set; }
    public DbSet<OfflineLesson> OfflineLessons { get; set; }
    
    public DbSet<OnlineCourse> OnlineCourses { get; set; }
    public DbSet<OfflineCourse> OfflineCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string host = Environment.GetEnvironmentVariable("HOST")!;
        string database = Environment.GetEnvironmentVariable("DATABASE")!;
        string username = Environment.GetEnvironmentVariable("USERNAME")!;
        string password = Environment.GetEnvironmentVariable("PASSWORD")!;

        optionsBuilder.UseNpgsql($"Host={host};Port=5432;Database={database};Username={username};Password={password};");
    }
}