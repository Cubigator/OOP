namespace lab3.Model.QuestItems;

public class Artifact : QuestItem
{
    private double _activationCost;
    private int _artifactRarity;

    public double ActivationCost
    {
        get => _activationCost;
        set
        {
            if(value > 0)
                _activationCost = value;
        }
    }

    public int ArtifactRarity
    {
        get => _artifactRarity;
        set
        {
            if(value > 0)
                _artifactRarity = value;
            else
                _artifactRarity = 1;
        }
    }
    
    private Artifact(string name, string description, int level, double weight, Guid questId, 
        string pickupMessage, double activationCost, int artifactRarity)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.QuestId = questId;
        this.PickupMessage = pickupMessage;
        this.ActivationCost = activationCost;
        this.ArtifactRarity = artifactRarity;
    }
    
    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private Guid _questId;
        private string _pickupMessage;
        private double _activationCost;
        private int _artifactRarity;

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

        public Builder SetActivationCost(double activationCost)
        {
            this._activationCost = activationCost;
            return this;
        }

        public Builder SetArtifactRarity(int artifactRarity)
        {
            this._artifactRarity = artifactRarity;
            return this;
        }
        
        public Artifact Build()
        {
            return new Artifact(_name, _description, _level, _weight, _questId, _pickupMessage, _activationCost, _artifactRarity);
        }
    }
    
    public static Builder ArtifactBuilder => new Builder();
}