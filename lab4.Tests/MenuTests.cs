using lab4.Models;
using lab4.Models.Enums;

namespace lab4.Tests;

public class MenuTests
{
    [Fact]
    public void AddDish_MenuContainsDish()
    {
        // Arrange
        var menu = new Menu();
        var dish = new Dish { Id = Guid.NewGuid(), Name = "Salad" };
        
        // Act
        menu.AddDish(dish);
        var result = menu.GetDishById(dish.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(dish.Name, result.Name);
    }

    [Fact]
    public void GetOnlyVegetarianDishes_ReturnsOnlyVegetarian()
    {
        // Arrange
        var menu = new Menu();
        var vegDish = new Dish { Id = Guid.NewGuid(), Name = "Salad", IsVegetarian = true };
        var nonVegDish = new Dish { Id = Guid.NewGuid(), Name = "Steak", IsVegetarian = false };
        menu.AddDish(vegDish);
        menu.AddDish(nonVegDish);
        
        // Act
        var vegetarians = menu.GetOnlyVegetarianDishes();
        
        // Assert
        Assert.Single(vegetarians);
        Assert.Equal(vegDish.Id, vegetarians[0].Id);
    }

    [Theory]
    [InlineData(DishCategory.MAIN)]
    [InlineData(DishCategory.DRINK)]
    public void GetDishesByCategory_FiltersCorrectly(DishCategory category)
    {
        // Arrange
        var menu = new Menu();
        var categoryDish = new Dish { Id = Guid.NewGuid(), Name = "Test", Category = category };
        var otherDish = new Dish { Id = Guid.NewGuid(), Name = "Other", Category = DishCategory.SNACK };
        menu.AddDish(categoryDish);
        menu.AddDish(otherDish);
        
        // Act
        var result = menu.GetDishesByCategory(category);
        
        // Assert
        Assert.Single(result);
        Assert.Equal(categoryDish.Id, result[0].Id);
    }

    [Fact]
    public void GetDishById_NotFound_ReturnsNull()
    {
        // Arrange
        var menu = new Menu();
        var nonExistentId = Guid.NewGuid();
        
        // Act
        var result = menu.GetDishById(nonExistentId);
        
        // Assert
        Assert.Null(result);
    }
}
