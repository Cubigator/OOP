using lab4.Models.Enums;

namespace lab4.Models;

public interface IMenu
{
    public void AddDish(Dish dish);
    public void RemoveDish(Dish dish);
    public IReadOnlyList<Dish> GetOnlyVegetarianDishes();
    public IReadOnlyList<Dish> GetOnlyNoSpicyDishes();
    public IReadOnlyList<Dish> GetDishesByCategory(DishCategory category);
}