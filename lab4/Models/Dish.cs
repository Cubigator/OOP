using lab4.Models.Enums;

namespace lab4.Models;

public class Dish
{
    private decimal _price;
    private decimal _weight;
    
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsVegetarian { get; set; }
    public bool IsSpicy { get; set; }
    public DishCategory Category { get; set; }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value > 0)
                _price = value;
        }
    }

    public decimal Weight
    {
        get => _weight;
        set
        {
            if (value > 0)
                _weight = value;
        }
    }
}