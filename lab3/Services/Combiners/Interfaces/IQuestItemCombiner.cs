using lab3.Model.QuestItems;

namespace lab3.Services.Combiners.Interfaces;

public interface IQuestItemCombiner
{
    public Amulet Combine(Amulet first, Amulet second);
    public Artifact Combine(Artifact first, Artifact second);
    public Key Combine(Key first, Key second);
    public Letter Combine(Letter first, Letter second);
}