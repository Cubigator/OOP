using lab3.Model.Weapons;

namespace lab3.Services.Combiners.Interfaces;

public interface IWeaponCombiner
{
    public Sword Combine(Sword first, Sword second);
    public Bow Combine(Bow first, Bow second);
    public CrossBow Combine(CrossBow first, CrossBow second);
}