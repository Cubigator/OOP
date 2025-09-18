namespace lab1;

public class Product
{
    private string _name;
    private decimal _price;
    public uint Count { get; set; }
    
    public string Name
    {
        get => _name;
        set
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Наименования не может быть пустым");
            if (value.Length < 3)
                throw new ArgumentException("Наименования слишком короткое");
            _name = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Цена не может быть отрицательной");
            _price = value;
        }
    }

    public Product(string name, decimal price, uint count)
    {
        Name = name;
        Price = price;
        Count = count;
    }
}