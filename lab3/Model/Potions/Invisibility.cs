namespace lab3.Model.Potions;

public class Invisibility : Potion
{
    private double _invisibilityDegree;

    public double InvisibilityDegree
    {
        get =>  _invisibilityDegree;
        set
        {
            if (value >= 0)
                _invisibilityDegree = value;
        }
    }
    
    private Invisibility(string name, string description, int level, double weight, double duration, double quality,
        double invisibilityDegree)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.Duration = duration;
        this.Quality = quality;
        this.InvisibilityDegree = invisibilityDegree;
    }
    
    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private double _duration;
        private double _quality;
        private double _invisibilityDegree;

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

        public Builder SetInvisibilityDegree(double invisibilityDegree)
        {
            this._invisibilityDegree = invisibilityDegree;
            return this;
        }

        public Invisibility Build()
        {
            return new Invisibility(_name, _description, _level, _weight, _duration, _quality,  _invisibilityDegree);
        }
    }
    
    public static Builder InvisibilityBuilder => new Builder();
}