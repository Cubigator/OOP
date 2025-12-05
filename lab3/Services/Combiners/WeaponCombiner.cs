using lab3.Services.Combiners.Interfaces;
using lab3.Model.Weapons;

namespace lab3.Services.Combiners;

public class WeaponCombiner : IWeaponCombiner
{
    public Sword Combine(Sword first, Sword second)
    {
        return Sword.SwordBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 2)
            .SetDamageConst(first.Damage / first.Level + second.Damage / first.Level)
            .SetActionRadiusConst(first.ActionRadius + second.ActionRadius)
            .SetReloadConst((first.Reload + second.Reload) / 3)
            .SetUsageLimit(first.UsageLimit + second.UsageLimit)
            .Build();
    }

    public Bow Combine(Bow first, Bow second)
    {
        return Bow.BowBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 2)
            .SetDamageConst(first.Damage / first.Level + second.Damage / first.Level)
            .SetActionRadiusConst(first.ActionRadius + second.ActionRadius)
            .SetReloadConst((first.Reload + second.Reload) / 3)
            .SetUsageLimit(first.UsageLimit + second.UsageLimit)
            .SetArrowsCount(first.ArrowsCount + second.ArrowsCount)
            .Build();
    }

    public CrossBow Combine(CrossBow first, CrossBow second)
    {
        return CrossBow.CrossBowBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 2)
            .SetDamageConst(first.Damage / first.Level + second.Damage / first.Level)
            .SetActionRadiusConst(first.ActionRadius + second.ActionRadius)
            .SetReloadConst((first.Reload + second.Reload) / 3)
            .SetUsageLimit(first.UsageLimit + second.UsageLimit)
            .SetArrowsCount(first.ArrowsCount + second.ArrowsCount)
            .SetPenetration(first.Penetration + second.Penetration)
            .Build();
    }
}