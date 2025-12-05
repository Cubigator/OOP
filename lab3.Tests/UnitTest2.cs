using lab3.Model.Armors;
using lab3.Model.Potions;
using lab3.Model.QuestItems;
using lab3.Model.Weapons;
using lab3.Services.Combiners;
using Xunit;

namespace lab3_Tests;

public class UnitTest2
{
    private readonly ItemCombinerFactory _factory;

    public UnitTest2()
    {
        _factory = new ItemCombinerFactory();
    }

    [Fact]
    public void ArmorCombiner_BootsCombine_Test()
    {
        var combiner = _factory.CreateArmorCombiner();
        var first = Boots.BootsBuilder.SetLevel(1).SetWeight(10).Build();
        var second = Boots.BootsBuilder.SetLevel(2).SetWeight(20).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(3, result.Level);
        Assert.Equal(10.0, result.Weight); 
        Assert.Equal(0, result.HP); 
    }

    [Fact]
    public void ArmorCombiner_HelmetCombine_Test()
    {
        var combiner = _factory.CreateArmorCombiner();
        var first = Helmet.HelmetBuilder.SetIsNightVision(true).Build();
        var second = Helmet.HelmetBuilder.SetIsNightVision(false).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.True(result.IsNightVision);
    }

    [Fact]
    public void ArmorCombiner_ShieldCombine_Test()
    {
        var combiner = _factory.CreateArmorCombiner();
        var first = Shield.ShieldBuilder.SetBlockChance(0.3).Build();
        var second = Shield.ShieldBuilder.SetBlockChance(0.7).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(0.7, result.BlockChance);
    }

    [Fact]
    public void WeaponCombiner_SwordCombine_Test()
    {
        var combiner = _factory.CreateWeaponCombiner();
        var first = Sword.SwordBuilder.SetLevel(1).SetDamageConst(10).Build();
        var second = Sword.SwordBuilder.SetLevel(2).SetDamageConst(20).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(3, result.Level);
        Assert.Equal(150.0, result.Damage); 
    }

    [Fact]
    public void PotionCombiner_HealCombine_Test()
    {
        var combiner = _factory.CreatePotionCombiner();
        var first = Heal.HealBuilder.SetQuality(1).SetHpPerSecond(5).Build();
        var second = Heal.HealBuilder.SetQuality(0.5).SetHpPerSecond(10).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(1, result.Quality);
        Assert.Equal(15, result.HpPerSecond);
    }

    [Fact]
    public void QuestItemCombiner_AmuletCombine_Test()
    {
        var combiner = _factory.CreateQuestItemCombiner();
        var first = Amulet.AmuletBuilder.SetAttackPowerBoost(10).SetHealthRegen(2).Build();
        var second = Amulet.AmuletBuilder.SetAttackPowerBoost(20).SetHealthRegen(3).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(30, result.AttackPowerBoost);
        Assert.Equal(5, result.HealthRegen);
    }

    [Fact]
    public void QuestItemCombiner_ArtifactCombine_Test()
    {
        var combiner = _factory.CreateQuestItemCombiner();
        var first = Artifact.ArtifactBuilder.SetActivationCost(50).Build();
        var second = Artifact.ArtifactBuilder.SetActivationCost(30).Build();
        
        var result = combiner.Combine(first, second);
        
        Assert.Equal(30, result.ActivationCost);
    }
}
