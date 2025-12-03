namespace lab3.Model.Potions;

public class Heal : Potion
{
    private double _hpPerSecond;
    private double _instantHeal;

    public double HpPerSecond
    {
        get => _hpPerSecond;
        set
        {
            if(value > 0)
                _hpPerSecond = value;
        }
    }

    public double InstantHeal
    {
        get => _instantHeal;
        set
        {
            if(value > 0)
                _instantHeal = value;
        }
    }

    private Heal(string name, string description, int level, double weight, double duration, double quality,
        double hpPerSecond, double instantHeal)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.Duration = duration;
        this.Quality = quality;
        this.HpPerSecond = hpPerSecond;
        this.InstantHeal = instantHeal;
    }

    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private double _duration;
        private double _quality;
        private double _hpPerSecond;
        private double _instantHeal;

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

        public Builder SetHpPerSecond(double hpPerSecond)
        {
            this._hpPerSecond = hpPerSecond;
            return this;
        }

        public Builder SetInstantHeal(double instantHeal)
        {
            this._instantHeal = instantHeal;
            return this;
        }

        public Heal Build()
        {
            return new Heal(_name, _description, _level, _weight, _duration, _quality, _hpPerSecond, _instantHeal);
        }
    }
    
    public static Builder HealBuilder => new Builder();
}