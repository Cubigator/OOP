namespace lab3.Model.Armors;

public class Helmet : Armor
{
    private double _visionRadius;

    public double VisionRadius
    {
        get => _visionRadius;
        set
        {
            if(value > 0)
                _visionRadius = value;
        }
    }
    public bool IsNightVision { get; set; }
    
    private Helmet(string name, string description, int level, double weight, double hp,
        double maxHp, double armorValue, double visionRadius, bool isNightVision)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.HP = hp;
        this.MaxHp = maxHp;
        this.ArmorValue = armorValue;
        this.VisionRadius = visionRadius;
        this.IsNightVision = isNightVision;
    }

    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private double _hp;
        private double _maxHp;
        private double _armorValue;
        private double _visionRadius;
        private bool _isNightVision;

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

        public Builder SetLevel(int level)
        {
            this._level = level;
            return this;
        }

        public Builder SetWeight(double weight)
        {
            this._weight = weight;
            return this;
        }

        public Builder SetHP(double hp)
        {
            this._hp = hp;
            return this;
        }

        public Builder SetMaxHp(double maxHp)
        {
            this._maxHp = maxHp;
            return this;
        }

        public Builder SetArmorValue(double armorValue)
        {
            this._armorValue = armorValue;
            return this;
        }

        public Builder SetVisionRadius(double visionRadius)
        {
            this._visionRadius = visionRadius;
            return this;
        }

        public Builder SetIsNightVision(bool isNightVision)
        {
            this._isNightVision = isNightVision;
            return this;
        }

        public Helmet Build()
        {
            return new Helmet(_name, _description, _level, _weight, _hp, _maxHp, 
                _armorValue, _visionRadius, _isNightVision);
        }
    }
    
    public static Builder HelmetBuilder => new Builder();
}