namespace lab3.Model.QuestItems;

public class Amulet : QuestItem
{
    private double _magicResonance;
    private double _attackPowerBoost;
    private double _healthRegen;

    public double MagicResonance
    {
        get => _magicResonance;
        set
        {
            if(value >= 0)
                _magicResonance = value;
        }
    }

    public double AttackPowerBoost
    {
        get => _attackPowerBoost;
        set
        {
            if(value >= 0)
                _attackPowerBoost  = value;
        }
    }

    public double HealthRegen
    {
        get => _healthRegen;
        set
        {
            if(value >= 0)
                _healthRegen = value;
        }
    }
    
    private Amulet(string name, string description, int level, double weight, Guid questId, 
        string pickupMessage, double magicResonance, double attackPowerBoost, double healthRegen)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.QuestId = questId;
        this.PickupMessage = pickupMessage;
        this.MagicResonance = magicResonance;
        this.AttackPowerBoost = attackPowerBoost;
        this.HealthRegen = healthRegen;
    }
    
    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private Guid _questId;
        private string _pickupMessage;
        private double _magicResonance;
        private double _attackPowerBoost;
        private double _healthRegen;

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

        public Builder SetQuestId(Guid questId)
        {
            this._questId = questId;
            return this;
        }

        public Builder SetPickupMessage(string pickupMessage)
        {
            this._pickupMessage = pickupMessage;
            return this;
        }

        public Builder SetMagicResonance(double magicResonance)
        {
            this._magicResonance = magicResonance;
            return this;
        }

        public Builder SetAttackPowerBoost(double attackPowerBoost)
        {
            this._attackPowerBoost = attackPowerBoost;
            return this;
        }

        public Builder SetHealthRegen(double healthRegen)
        {
            this._healthRegen = healthRegen;
            return this;
        }
        
        public Amulet Build()
        {
            return new Amulet(_name, _description, _level, _weight, _questId, _pickupMessage, _magicResonance, _attackPowerBoost,  _healthRegen);
        }
    }
    
    public static Builder AmuletBuilder => new Builder();
}