namespace lab3.Model.Potions;

public class Speed : Potion
{
    private double _movementSpeedBoost;
    private double _attackSpeedIncrease;

    public double MovementSpeedBoost
    {
        get => _movementSpeedBoost;
        set
        {
            if(value >= 0)
                _movementSpeedBoost = value;
        }
    }

    public double AttackSpeedIncrease
    {
        get => _attackSpeedIncrease;
        set
        {
            if(value >= 0)
                _attackSpeedIncrease = value;
        }
    }
    
    private Speed(string name, string description, int level, double weight, double duration, double quality,
        double movementSpeedBoost, double attackSpeedIncrease)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.Duration = duration;
        this.Quality = quality;
        this.MovementSpeedBoost = movementSpeedBoost;
        this.AttackSpeedIncrease = attackSpeedIncrease;
    }
    
    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private double _duration;
        private double _quality;
        private double _movementSpeedBoost;
        private double _attackSpeedIncrease;

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

        public Builder SetDuration(double duration)
        {
            this._duration = duration;
            return this;
        }

        public Builder SetQuality(double quality)
        {
            this._quality = quality;
            return this;
        }

        public Builder SetMovementSpeedBoost(double movementSpeedBoost)
        {
            this._movementSpeedBoost = movementSpeedBoost;
            return this;
        }

        public Builder SetAttackSpeedIncrease(double attackSpeedIncrease)
        {
            this._attackSpeedIncrease = attackSpeedIncrease;
            return this;
        }

        public Speed Build()
        {
            return new Speed(_name, _description, _level, _weight, _duration, _quality,  _movementSpeedBoost, _attackSpeedIncrease);
        }
    }
    
    public static Builder SpeedBuilder => new Builder();
}