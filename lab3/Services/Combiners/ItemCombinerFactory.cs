using lab3.Services.Combiners.Interfaces;

namespace lab3.Services.Combiners;

public class ItemCombinerFactory : IItemCombinerFactory
{
    public IArmorCombiner CreateArmorCombiner()
    {
        return new ArmorCombiner();
    }

    public IPotionCombiner CreatePotionCombiner()
    {
        return new PotionCombiner();
    }

    public IWeaponCombiner CreateWeaponCombiner()
    {
        return new WeaponCombiner();
    }

    public IQuestItemCombiner CreateQuestItemCombiner()
    {
        return new QuestItemCombiner();
    }
}