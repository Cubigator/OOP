namespace lab3.Model.Armors;

public class Chainmail : Armor
{
    private double _cutResistance;
    private double _noiseLevel;

    public double CutResistance
    {
        get => _cutResistance;
        set
        {
            if(value >= 0)
                _cutResistance = value;
        }
    }

    public double NoiseLevel
    {
        get => _noiseLevel;
        set
        {
            if(value >= 0)
                _noiseLevel = value;
        }
    }
    
    private Chainmail(string name, string description, int level, double weight, double hp,
        double maxHp, double armorValue, double cutResistance, double noiseLevel)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.HP = hp;
        this.MaxHp = maxHp;
        this.ArmorValue = armorValue;
        this.CutResistance = cutResistance;
        this.NoiseLevel = noiseLevel;
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
        private double _cutResistance;
        private double _noiseLevel;

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

        public Builder SetCutResistance(double cutResistance)
        {
            this._cutResistance = cutResistance;
            return this;
        }

        public Builder SetNoiseLevel(double noiseLevel)
        {
            this._noiseLevel = noiseLevel;
            return this;
        }

        public Chainmail Build()
        {
            return new Chainmail(_name, _description, _level, _weight, _hp, _maxHp, 
                _armorValue, _cutResistance, _noiseLevel);
        }
    }
    
    public static Builder ChainMailBuilder => new Builder();
}