using lab4.Models.Enums;

namespace lab4.Models;

public class Menu : IMenu
{
    private readonly List<Dish> _dishes;

    public Menu()
    {
        _dishes = new List<Dish>();
    }
    
    public void AddDish(Dish dish)
    {
        _dishes.Add(dish);
    }

    public void RemoveDish(Dish dish)
    {
        _dishes.Remove(dish);
    }

    public IReadOnlyList<Dish> GetOnlyVegetarianDishes()
    {
        List<Dish> buffer = new();
        foreach (var dish in _dishes)
        {
            if (dish.IsVegetarian)
            {
                buffer.Add(dish);
            }
        }
        return buffer;
    }

    public IReadOnlyList<Dish> GetOnlyNoSpicyDishes()
    {
        List<Dish> buffer = new();
        foreach (var dish in _dishes)
        {
            if (!dish.IsSpicy)
            {
                buffer.Add(dish);
            }
        }
        return buffer;
    }

    public IReadOnlyList<Dish> GetDishesByCategory(DishCategory category)
    {
        List<Dish> buffer = new();
        foreach (var dish in _dishes)
        {
            if (dish.Category == category)
            {
                buffer.Add(dish);
            }
        }
        return buffer;
    }

    public Dish? GetDishById(Guid id)
    {
        Dish? dish = _dishes.FirstOrDefault(x => x.Id == id);
        return dish;
    }
}