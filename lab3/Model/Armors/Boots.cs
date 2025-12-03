namespace lab3.Model.Armors;

public class Boots : Armor
{
    private double _movementSpeedBonus;
    private double _jumpHeight;
    private double _sprintSpeed;

    public double MovementSpeedBonus
    {
        get => _movementSpeedBonus;
        set
        {
            if(value >= 0)
                _movementSpeedBonus = value;
        }
    }

    public double JumpHeight
    {
        get => _jumpHeight;
        set
        {
            if(value > 0)
                _jumpHeight = value;
        }
    }

    public double SprintSpeed
    {
        get => _sprintSpeed;
        set
        {
            if (value > 0)
                _sprintSpeed = value;
        }
    }

    private Boots(string name, string description, int level, double weight, double hp,
        double maxHp, double armorValue, double movementSpeedBonus, double jumpHeight, double sprintSpeed)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.HP = hp;
        this.MaxHp = maxHp;
        this.ArmorValue = armorValue;
        this.MovementSpeedBonus = movementSpeedBonus;
        this.JumpHeight = jumpHeight;
        this.SprintSpeed = sprintSpeed;
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
        private double _movementSpeedBonus;
        private double _jumpHeight;
        private double _sprintSpeed;

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

        public Builder SetMovementSpeedBonus(double movementSpeedBonus)
        {
            this._movementSpeedBonus = movementSpeedBonus;
            return this;
        }

        public Builder SetJumpHeight(double jumpHeight)
        {
            this._jumpHeight = jumpHeight;
            return this;
        }

        public Builder SetSprintSpeed(double sprintSpeed)
        {
            this._sprintSpeed = sprintSpeed;
            return this;
        }

        public Boots Build()
        {
            return new Boots(_name, _description, _level, _weight, _hp, _maxHp, 
                _armorValue, _movementSpeedBonus, _jumpHeight, _sprintSpeed);
        }
    }
    
    public static Builder BootsBuilder => new Builder();
}