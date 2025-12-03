namespace lab3.Model;

public abstract class Armor : Item
{
    private double _hp;
    private double _maxHp;
    private double _armorValue;

    public double HP
    {
        get => _hp;
        set
        {
            if(value >= 0 && value <= _maxHp)
                _hp = value;
        }
    }

    public double MaxHp
    {
        get => _maxHp;
        set
        {
            if(value > 0)
                _maxHp = value;
        }
    }

    public double ArmorValue
    {
        get => _armorValue;
        set
        {
            if(value > 0)
                _armorValue = value;
        }
    }
}