using System.Runtime.CompilerServices;

namespace lab3.Model.Weapons;

public class Sword : Weapon
{
    private Sword(string name, string? description, double weight, int level, int usageLimit, 
        double damageConst,  double reloadConst, double actionRadiusConst)
    {
        this.Name = name;
        this.Description = description;
        this.Weight = weight; 
        this.Level = level;
        this.DamageConst = damageConst;
        this.ReloadConst = reloadConst;
        this.ActionRadiusConst = actionRadiusConst;
        this.UsageLimit =  usageLimit;
    }

    public double Damage => DamageConst * Level;
    public double Reload => ReloadConst / Level;
    public double ActionRadius => ActionRadiusConst * Level;

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

        public Sword Build()
        {
            return new Sword(_name, _description, _weight, _level, _usageLimit,  _damageConst, _reloadConst, _actionRadiusConst);
        }
    }
    
    public static Builder SwordBuilder => new Builder();
}