using lab4.Models;

namespace lab4.Tests;

public class DishTests
{
    [Fact]
    public void Price_SetNegativeValue_RemainsZero()
    {
        // Arrange
        var dish = new Dish { Id = Guid.NewGuid(), Name = "Test Dish" };
        
        // Act
        dish.Price = -10m;
        
        // Assert
        Assert.Equal(0m, dish.Price);
    }

    [Fact]
    public void Weight_SetZero_RemainsZero()
    {
        // Arrange
        var dish = new Dish { Id = Guid.NewGuid(), Name = "Test Dish" };
        
        // Act
        dish.Weight = 0m;
        
        // Assert
        Assert.Equal(0m, dish.Weight);
    }

    [Theory]
    [InlineData(100.5)]
    [InlineData(0.01)]
    public void Price_SetValidValue_SetsCorrectly(decimal validPrice)
    {
        // Arrange
        var dish = new Dish { Id = Guid.NewGuid(), Name = "Test Dish" };
        
        // Act
        dish.Price = validPrice;
        
        // Assert
        Assert.Equal(validPrice, dish.Price);
    }
}

