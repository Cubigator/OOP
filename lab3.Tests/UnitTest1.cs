using lab3.Model;
using lab3.Model.Armors;
using lab3.Model.Potions;
using lab3.Model.Weapons;
using lab3.Services;
using Xunit;

namespace lab3_Tests;

public class UnitTest1
{
    private readonly Inventory _inventory;
    
    public UnitTest1()
    {
        _inventory = new Inventory(capacity: 100.0, quickAccessSize: 5);
    }

    [Fact]
    public void AddItem_Capacity_Test()
    {
        var helmet = Helmet.HelmetBuilder.SetWeight(10).Build();
        bool result = _inventory.AddItem(helmet);
        
        Assert.True(result);
        Assert.Equal(10.0, _inventory.Occupancy);
    }

    [Fact]
    public void MaxCapacity_Test()
    {
        for (int i = 0; i < 10; i++)
            _inventory.AddItem(Boots.BootsBuilder.SetWeight(11).Build());
        
        var heavyItem = Chainmail.ChainMailBuilder.SetWeight(20).Build();
        bool result = _inventory.AddItem(heavyItem);
        
        Assert.False(result);
        Assert.Equal(99.0, _inventory.Occupancy);
    }

    [Fact]
    public void EquipHelmet_Test()
    {
        var helmet = Helmet.HelmetBuilder.SetWeight(10).Build();
        _inventory.EquipHelmet(helmet);
        
        Assert.Equal(helmet, _inventory.Helmet);
    }

    [Fact]
    public void GetAvailableItems_Test()
    {
        _inventory.AddItem(Helmet.HelmetBuilder.SetWeight(10).Build());
        _inventory.AddItem(Sword.SwordBuilder.SetWeight(5).Build());
        
        var helmets = _inventory.GetAvailableItems<Helmet>();
        
        Assert.Single(helmets);
        Assert.IsType<Helmet>(helmets[0]);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    public void AddToQuickAccess_Test(int position, bool expected)
    {
        var item = Bow.BowBuilder.SetWeight(3).Build();
        bool result = _inventory.AddToQuickAccess(item, position);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void RemoveItem_Test()
    {
        var item = Helmet.HelmetBuilder.SetWeight(7).Build();
        _inventory.AddItem(item);
        _inventory.AddToQuickAccess(item, 0);
        
        bool removed = _inventory.RemoveItem(item);
        
        Assert.True(removed);
        Assert.Equal(0.0, _inventory.Occupancy);
    }

    [Fact]
    public void ClearInventory_Test()
    {
        _inventory.AddItem(Heal.HealBuilder.SetWeight(20).Build());
        _inventory.EquipHelmet(Helmet.HelmetBuilder.SetWeight(10).Build());
        
        _inventory.ClearInventory();
        
        Assert.Equal(0.0, _inventory.Occupancy);
        Assert.Null(_inventory.Helmet);
        Assert.Null(_inventory.CurrentWeapon);
    }
}
