namespace lab3.Model;

public abstract class Item
{
    private double _weight;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public double Weight
    {
        get => _weight;
        set
        {
            if (value > 0)
            {
                _weight = value;
            }
        }
    }
}