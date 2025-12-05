using lab3.Model.Armors;
using lab3.Model;

namespace lab3.Services;

public class Inventory : IInventory
{
    private readonly List<Item> _items;
    private readonly Item?[] _quickAccessItems;
    
    public Helmet? Helmet { get; private set; }
    public Chainmail? Chainmail { get; private set; }
    public Shield? Shield { get; private set; }
    public Boots? Boots { get; private set; }
    
    public Weapon? CurrentWeapon { get; private set; }
    
    public double Capacity { get; private set; }

    public double Occupancy
    {
        get
        {
            double result = 0;
            foreach (var item in _items)
            {
                result += item.Weight;
            }
            return result;
        }
    }

    public Inventory(double capacity, int quickAccessSize)
    {
        Capacity = capacity;
        _items = new List<Item>();
        _quickAccessItems = new Item[quickAccessSize];
    }
    
    public void EquipHelmet(Helmet helmet)
    {
        Helmet = helmet;
    }

    public void EquipChainmail(Chainmail chainmail)
    {
        Chainmail = chainmail;
    }

    public void EquipShield(Shield shield)
    {
        Shield = shield;
    }

    public void EquipBoots(Boots boots)
    {
        Boots = boots;
    }

    public void EquipWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
    }
    
    public IReadOnlyList<T> GetAvailableItems<T>() where T : Item
    {
        List<T> buffer = new List<T>();
        foreach (var item in _items)
        {
            if(item is T)
                buffer.Add((T)item);
        }
        return buffer;
    }

    public bool AddItem(Item item)
    {
        if (this.Occupancy + item.Weight < Capacity)
        {
            _items.Add(item);
            return true;
        }
        return false;
    }

    public bool AddToQuickAccess(Item item, int position)
    {
        if (_quickAccessItems.Length <= position)
            return false;
        if (_quickAccessItems[position] is null)
        {
            _quickAccessItems[position] = item;
            return true;
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        _ = RemoveFromQuickAccess(item);
        return _items.Remove(item);
    }

    public bool RemoveFromQuickAccess(Item item)
    {
        for (int i = 0; i < _quickAccessItems.Length; i++)
        {
            if (_quickAccessItems[i] == item)
            {
                _quickAccessItems[i] = null;
                return true;
            }
        }
        return false;
    }

    public void ClearInventory()
    {
        _items.Clear();
        for (int i = 0; i < _quickAccessItems.Length; i++)
        {
            _quickAccessItems[i] = null;
        }
        Helmet = null;
        Chainmail = null;
        Shield = null;
        Boots = null;
        CurrentWeapon = null;
    }
}