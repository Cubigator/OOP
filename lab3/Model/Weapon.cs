namespace lab3.Model;

public abstract class Weapon : Item
{
    private double _damageConst;
    private double _reloadConst;
    private double _actionRadiusConst;
    private int _usageLimit;

    protected double DamageConst
    {
        get => _damageConst;
        set
        {
            if(value > 0)
                _damageConst = value;
        }
    }

    protected double ReloadConst
    {
        get => _reloadConst;
        set
        {
            if(value > 0)
                _reloadConst = value;
        }
    }

    protected double ActionRadiusConst
    {
        get => _actionRadiusConst;
        set
        {
            if(value > 0)
                _actionRadiusConst = value;
        }
    }

    public int UsageLimit
    {
        get => _usageLimit;
        set
        {
            if (value >= 0)
            {
                _usageLimit = value;
            }
        }
    }
}