namespace lab3.Model;

public abstract class Potion : Item
{
    private double _duration;
    private double _quality;

    public double Duration
    {
        get => _duration;
        set
        {
            if(value > 0)
                _duration = value;
        }
    }

    public double Quality
    {
        get => _quality;
        set
        {
            if(value >= 0 && value <= 1)
                _quality = value;
        }
    }
}