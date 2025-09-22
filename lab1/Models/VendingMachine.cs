using System.Collections.ObjectModel;

namespace lab1;

public class VendingMachine
{
    private Dictionary<int, Product> _products;
    private Wallet _wallet;

    public VendingMachine()
    {
        _products = new Dictionary<int, Product>();
        _wallet = new Wallet();
    }

    public IReadOnlyList<Product> ProductsList
    {
        get => _products.Values.ToList().AsReadOnly();
    }
    
    public void AddProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            AddProduct(product);
        }
    }

    public decimal CollectMoney()
    {
        decimal allSum = _wallet.Balance;
        _wallet.RemoveAllCoins();
        return allSum;
    }

    public void AddProduct(Product product)
    {
        _products.Add(_products.Count, product);
    }

    public Product BuyProduct(int productId, uint count, Wallet wallet)
    {
        if (_products.ContainsKey(productId))
        {
            if (_products[productId].Price * count > wallet.Balance)
            {
                throw new Exception("Недостаточно внесенных средств");
            }
            if (_products[productId].Count < count)
            {
                throw new Exception("Недостаточно единиц товара");
            }
            _products[productId].Count -= count;
        }
        else
        {
            throw new Exception("Такой позиции не существует");
        }
        return new Product(_products[productId].Name, _products[productId].Price, count);
    }

    public void PrintProducts()
    {
        Console.WriteLine("Доступные товары: ");
        foreach (var position in _products)
        {
            Console.WriteLine($"Позиция: {position.Key} - {position.Value.Name} \n" +
                              $"Цена: {position.Value.Price:C} \tКоличество: {position.Value.Count:N0} \n" +
                              $"{new string('*', 50)}");
        }
    }
}