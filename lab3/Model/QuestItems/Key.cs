namespace lab3.Model.QuestItems;

public class Key : QuestItem
{
    public Guid KeyId { get; set; }
    public bool IsUsableOnce { get; set; }
    
    private Key(string name, string description, int level, double weight, Guid questId, 
        string pickupMessage, Guid keyId, bool isUsableOnce)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.QuestId = questId;
        this.PickupMessage = pickupMessage;
        this.KeyId = keyId;
        this.IsUsableOnce = isUsableOnce;
    }
    
    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private Guid _questId;
        private string _pickupMessage;
        private Guid _keyId;
        private bool _isUsableOnce;

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

        public Builder SetKeyId(Guid keyId)
        {
            this._keyId = keyId;
            return this;
        }

        public Builder SetIsUsableOnce(bool isUsableOnce)
        {
            this._isUsableOnce = isUsableOnce;
            return this;
        }

        public Key Build()
        {
            return new Key(_name, _description, _level, _weight, _questId, _pickupMessage,  _keyId, _isUsableOnce);
        }
    }
    
    public static Builder KeyBuilder => new Builder();
}