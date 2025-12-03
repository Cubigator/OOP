namespace lab3.Model;

public abstract class Item
{
    private int _level;
    private double _weight;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int Level
    {
        get => _level;
        set
        {
            if(value > 0)
                _level = value;
        }
    }
    
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