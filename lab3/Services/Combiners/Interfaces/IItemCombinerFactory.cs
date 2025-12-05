namespace lab3.Services.Combiners.Interfaces;

public interface IItemCombinerFactory
{
    public IArmorCombiner CreateArmorCombiner();
    public IPotionCombiner CreatePotionCombiner();
    public IWeaponCombiner CreateWeaponCombiner();
    public IQuestItemCombiner CreateQuestItemCombiner();
}