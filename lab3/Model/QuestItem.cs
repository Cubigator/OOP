namespace lab3.Model;

public abstract class QuestItem : Item
{
    private Guid _questId;

    public Guid QuestId
    {
        get => _questId;
        set
        {
            _questId = value;
        }
    }
    public string? PickupMessage { get; set; }
}