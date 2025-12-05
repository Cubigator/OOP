using lab3.Services.Combiners.Interfaces;
using lab3.Model.QuestItems;

namespace lab3.Services.Combiners;

public class QuestItemCombiner : IQuestItemCombiner
{
    public Amulet Combine(Amulet first, Amulet second)
    {
        return Amulet.AmuletBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetAttackPowerBoost(first.AttackPowerBoost + second.AttackPowerBoost)
            .SetHealthRegen(first.HealthRegen + second.HealthRegen)
            .SetMagicResonance(first.MagicResonance + second.MagicResonance)
            .SetPickupMessage(first.PickupMessage + second.PickupMessage)
            .SetQuestId(first.QuestId)
            .Build();
    }

    public Artifact Combine(Artifact first, Artifact second)
    {
        return Artifact.ArtifactBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetPickupMessage(first.PickupMessage + second.PickupMessage)
            .SetActivationCost(Math.Min(first.ActivationCost, second.ActivationCost))
            .SetQuestId(first.QuestId)
            .Build();
    }

    public Key Combine(Key first, Key second)
    {
        return Key.KeyBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetPickupMessage(first.PickupMessage + second.PickupMessage)
            .SetKeyId(first.KeyId)
            .SetIsUsableOnce(first.IsUsableOnce || second.IsUsableOnce)
            .SetQuestId(first.QuestId)
            .Build();
    }

    public Letter Combine(Letter first, Letter second)
    {
        return Letter.LetterBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetPickupMessage(first.PickupMessage + second.PickupMessage)
            .SetAuthor(first.Author + second.Author ?? string.Empty)
            .SetContent(first.Content + second.Content ?? string.Empty)
            .SetQuestId(first.QuestId)
            .Build();
    }
}