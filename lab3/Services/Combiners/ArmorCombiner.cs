using lab3.Model.Armors;
using lab3.Services.Combiners.Interfaces;

namespace lab3.Services.Combiners;

public class ArmorCombiner : IArmorCombiner
{
    public Boots Combine(Boots first, Boots second)
    {
        return Boots.BootsBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetArmorValue(first.ArmorValue + second.ArmorValue)
            .SetHP(first.HP + second.HP)
            .SetJumpHeight(first.JumpHeight + second.JumpHeight)
            .SetMaxHp(first.MaxHp + second.MaxHp)
            .SetMovementSpeedBonus(first.MovementSpeedBonus + second.MovementSpeedBonus)
            .SetSprintSpeed(first.SprintSpeed + second.SprintSpeed)
            .Build();
    }

    public Chainmail Combine(Chainmail first, Chainmail second)
    {
        return Chainmail.ChainMailBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetArmorValue(first.ArmorValue + second.ArmorValue)
            .SetHP(first.HP + second.HP)
            .SetMaxHp(first.MaxHp + second.MaxHp)
            .SetCutResistance(first.CutResistance + second.CutResistance)
            .SetNoiseLevel(first.NoiseLevel + second.NoiseLevel)
            .Build();
    }

    public Helmet Combine(Helmet first, Helmet second)
    {
        return Helmet.HelmetBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetArmorValue(first.ArmorValue + second.ArmorValue)
            .SetHP(first.HP + second.HP)
            .SetMaxHp(first.MaxHp + second.MaxHp)
            .SetIsNightVision(first.IsNightVision || second.IsNightVision)
            .SetVisionRadius(first.VisionRadius + second.VisionRadius)
            .Build();
    }

    public Shield Combine(Shield first, Shield second)
    {
        return Shield.ShieldBuilder
            .SetName(first.Name)
            .SetDescription(first.Description ?? string.Empty)
            .SetLevel(first.Level + second.Level)
            .SetWeight((first.Weight + second.Weight) / 3)
            .SetArmorValue(first.ArmorValue + second.ArmorValue)
            .SetHP(first.HP + second.HP)
            .SetMaxHp(first.MaxHp + second.MaxHp)
            .SetBlockChance(Math.Max(first.BlockChance, second.BlockChance))
            .SetDamageReturn(Math.Max(first.DamageReturn, second.DamageReturn))
            .Build();
    }
}