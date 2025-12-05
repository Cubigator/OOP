using lab3.Services.Combiners.Interfaces;
using lab3.Model.Potions;

namespace lab3.Services.Combiners;

public class PotionCombiner : IPotionCombiner
{
    public Heal Combine(Heal first, Heal second)
    {
        return Heal.HealBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetHpPerSecond(first.HpPerSecond + second.HpPerSecond)
            .SetDuration(first.Duration + second.Duration)
            .SetInstantHeal(first.InstantHeal + second.InstantHeal)
            .SetQuality(Math.Max(first.Quality, second.Quality))
            .Build();
    }

    public Invisibility Combine(Invisibility first, Invisibility second)
    {
        return Invisibility.InvisibilityBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetDuration(first.Duration + second.Duration)
            .SetQuality(Math.Max(first.Quality, second.Quality))
            .SetInvisibilityDegree(first.InvisibilityDegree + second.InvisibilityDegree)
            .Build();
    }

    public Speed Combine(Speed first, Speed second)
    {
        return Speed.SpeedBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetDuration(first.Duration + second.Duration)
            .SetQuality(Math.Max(first.Quality, second.Quality))
            .SetAttackSpeedIncrease(first.AttackSpeedIncrease + second.AttackSpeedIncrease)
            .SetMovementSpeedBoost(first.MovementSpeedBoost + second.MovementSpeedBoost)
            .Build();
    }
}