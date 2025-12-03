namespace lab3.Model.Armors;

public class Shield : Armor
{
    private double _blockChance;
    private double _damageReturn;

    public double BlockChance
    {
        get => _blockChance;
        set
        {
            if(value >= 0 && value <= 1)
                _blockChance = value;
        }
    }

    public double DamageReturn
    {
        get => _damageReturn;
        set
        {
            if(value >= 0 && value <= 1)
                _damageReturn = value;
        }
    }
    
    private Shield(string name, string description, int level, double weight, double hp,
        double maxHp, double armorValue, double blockChance, double damageReturn)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.HP = hp;
        this.MaxHp = maxHp;
        this.ArmorValue = armorValue;
        this.BlockChance = blockChance;
        this.DamageReturn = damageReturn;
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
        private double _blockChance;
        private double _damageReturn;

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

        public Builder SetBlockChance(double blockChance)
        {
            this._blockChance = blockChance;
            return this;
        }

        public Builder SetDamageReturn(double damageReturn)
        {
            this._damageReturn = damageReturn;
            return this;
        }

        public Shield Build()
        {
            return new Shield(_name, _description, _level, _weight, _hp, _maxHp, 
                _armorValue, _blockChance, _damageReturn);
        }
    }
    
    public static Builder ShieldBuilder => new Builder();
}