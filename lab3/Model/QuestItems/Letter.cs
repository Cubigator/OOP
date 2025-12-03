namespace lab3.Model.QuestItems;

public class Letter : QuestItem
{
    public string? Author { get; set; }
    public string Content { get; set; } = null!;

    private Letter(string name, string description, int level, double weight, Guid questId, 
        string pickupMessage, string author, string content)
    {
        this.Name = name;
        this.Description = description;
        this.Level = level;
        this.Weight = weight;
        this.QuestId = questId;
        this.PickupMessage = pickupMessage;
        this.Author = author;
        this.Content = content;
    }

    public class Builder
    {
        private string _name;
        private string _description;
        private int _level;
        private double _weight;
        private Guid _questId;
        private string _pickupMessage;
        private string _author;
        private string _content;

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

        public Builder SetAuthor(string author)
        {
            this._author = author;
            return this;
        }

        public Builder SetContent(string content)
        {
            this._content = content;
            return this;
        }

        public Letter Build()
        {
            return new Letter(_name, _description, _level, _weight, _questId, _pickupMessage, _author, _content);
        }
    }
    
    public static Builder LetterBuilder => new Builder();
}