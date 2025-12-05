using lab3.Model.Armors;
using lab3.Model.Potions;
using lab3.Model.QuestItems;
using lab3.Model.Weapons;
using lab3.Model;

namespace lab3.Services;

public interface IInventory
{
    public void EquipHelmet(Helmet helmet);
    public void EquipChainmail(Chainmail chainmail);
    public void EquipShield(Shield shield);
    public void EquipBoots(Boots boots);
    public void EquipWeapon(Weapon weapon);
    public IReadOnlyList<T> GetAvailableItems<T>() where T : Item;
    public bool AddItem(Item item);
    public bool AddToQuickAccess(Item item, int position);
    public bool RemoveItem(Item item);
    public bool RemoveFromQuickAccess(Item item);
    public void ClearInventory();
}