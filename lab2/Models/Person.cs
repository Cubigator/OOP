using System.ComponentModel.DataAnnotations;

namespace lab2;

public abstract class Person
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Patronymic { get; set; }
    [Key]
    public int PersonnelNumber { get; set; }
    public List<string>? Positions { get; set; }
}