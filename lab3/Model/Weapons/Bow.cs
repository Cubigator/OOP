namespace lab3.Model.Weapons;

public class Bow : Weapon
{
    private int _arrowsCount;
    
    private Bow(string name, string? description, double weight, int level, int usageLimit,
        double damageConst,  double reloadConst, double actionRadiusConst, int arrowsCount)
    {
        this.Name = name;
        this.Description = description;
        this.Weight = weight; 
        this.Level = level;
        this.DamageConst = damageConst;
        this.ReloadConst = reloadConst;
        this.ActionRadiusConst = actionRadiusConst;
        this.UsageLimit = usageLimit;
        this.ArrowsCount = arrowsCount;
    }

    public double Damage => DamageConst * Level;
    public double Reload => ReloadConst / Level;
    public double ActionRadius => ActionRadiusConst * Level;

    public int ArrowsCount
    {
        get => _arrowsCount;
        set
        {
            if(value >= 0)
                _arrowsCount = value;
        }
    }

    public class Builder
    {
        private string _name;
        private string? _description;
        private double _weight;
        private int _level;
        private int _usageLimit;
        private double _damageConst;
        private double _reloadConst;
        private double _actionRadiusConst;
        private int _arrowsCount;
        
        public Builder SetName(string name)
        {
            this._name = name;
            return this;
        }
        public Builder SetDescription(string description)
        {
            this._description = description;
            return this;
        }
        public Builder SetWeight(double weight)
        {
            this._weight = weight;
            return this;
        }
        public Builder SetLevel(int level)
        {
            this._level = level;
            return this;
        }
        public Builder SetUsageLimit(int usageLimit)
        {
            this._usageLimit = usageLimit;
            return this;
        }
        public Builder SetDamageConst(double damageConst)
        {
            this._damageConst = damageConst;
            return this;
        }
        public Builder SetReloadConst(double reloadConst)
        {
            this._reloadConst = reloadConst;
            return this;
        }
        public Builder SetActionRadiusConst(double actionRadiusConst)
        {
            this._actionRadiusConst = actionRadiusConst;
            return this;
        }

        public Builder SetArrowsCount(int arrowsCount)
        {
            this._arrowsCount = arrowsCount;
            return this;
        }

        public Bow Build()
        {
            return new Bow(_name, _description, _weight, _level, _usageLimit,  _damageConst, _reloadConst, _actionRadiusConst, _arrowsCount);
        }
    }
    
    public static Builder BowBuilder = new Builder();
}