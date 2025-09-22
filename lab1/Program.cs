using lab1;

public class Program
{
    private static Wallet _userWallet = new Wallet();
    private static Wallet _enteredAmount = new Wallet();
    private static VendingMachine _vendingMachine = new VendingMachine();
    private static List<Product> _purchasedProducts = new List<Product>();
    private static bool _isAdmin = false;
    private static JsonDataProvider _dataProvider = new JsonDataProvider();
    
    public static bool IsNumber(string input)
    {
        return double.TryParse(input, out _);
    }

    private static void GiveStartBalance(Wallet wallet)
    {
        foreach (var denom in Constants.DENOMINATIONS)
        {
            for (int i = 0; i < 10; i++)
            {
                wallet.AddCoin(denom);
            }
        }
    }
    private static void PrintMainMenu()
    {
        PrintHeader(false);
        Console.WriteLine("1. Список товаров");
        if (!_isAdmin)
        {
            Console.WriteLine("2. Получить администратора");
        }
        else
        {
            Console.WriteLine("2. Добавить товар");
        }
        Console.WriteLine("3. Список покупок");
        if(_isAdmin)
            Console.WriteLine("4. Вывод средств");
        Console.WriteLine("5. Пополнить кошелек");
        Console.WriteLine("6. Забрать сдачу");
        Console.WriteLine("Для выхода нажмите любую другую клавишу");
    }

    private static void PrintHeader(bool isPurchase)
    {
        Console.WriteLine($"Мой баланс: {_userWallet.Balance}");
        if(isPurchase)
            Console.WriteLine($"Введенная сумма: {_enteredAmount.Balance}");
    }

    private static void PrintPurchasedProducts()
    {
        Console.WriteLine($"Купленные товары: ");
        foreach (var product in _purchasedProducts)
        {
            Console.WriteLine($"{product.Name}: {product.Count}");
        }
    }
    
    private static void AddProduct(string name, decimal price, uint count)
    {
        Product product = new Product(name, price, count);
        _vendingMachine.AddProduct(product);
        _dataProvider.LoadToFile(Constants.VENDING_PRODUCTS_PATH, _vendingMachine.ProductsList.ToList());
    }


    private static void AdminRegistration()
    {
        Console.Write("Введите пароль: ");
        var password = Console.ReadLine();
        if (password == Environment.GetEnvironmentVariable("ADMIN_PASSWORD"))
        {
            _isAdmin = true;
            Console.WriteLine("Удачно");
            return;
        }
        _isAdmin = false;
        Console.WriteLine("Неудачно");
    }

    private static void KeepChange()
    {
        Console.WriteLine($"Ваша сдача: {_userWallet.Balance}");
        var change = _userWallet.RemoveAllCoins();
        Console.WriteLine($"Список монет: ");
        foreach (var coin in change)
        {
            Console.WriteLine($"{coin.Denomination:C}");
        }
        Console.ReadKey();
    }

    private static void PayBalance()
    {
        while (true)
        {
            Console.WriteLine("Введите номинал монеты (или ENTER для выхода): ");
            string input = Console.ReadLine()!;
            if (!IsNumber(input))
                return;
            decimal denomination = decimal.Parse(input);
            _userWallet.AddCoin(denomination);
        }
    }
    
    public static void Main(string[] args)
    {
        var products = _dataProvider.LoadFromFile(Constants.VENDING_PRODUCTS_PATH);
        _vendingMachine.AddProducts(products);
        GiveStartBalance(_userWallet);

        while (true)
        {
            Console.Clear();
            PrintMainMenu();
            string command = Console.ReadLine()!;
            Console.Clear();
            try
            {
                switch (command)
                {
                    case "1":
                        PrintHeader(true);
                        _vendingMachine.PrintProducts();
                        Console.Write(
                            "Введите номер позицию, которую хотите приобрести, или любую клавишу для выхода в меню: ");
                        string input = Console.ReadLine()!;
                        if (!IsNumber(input))
                            break;
                        int position = int.Parse(input);
                        Product boughtProduct = _vendingMachine.BuyProduct(position, 1, _userWallet);
                        _purchasedProducts.Add(boughtProduct);
                        Console.Write("Успешно");
                        Console.ReadLine();
                        break;
                    case "2":
                        if (!_isAdmin)
                        {
                            AdminRegistration();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("Введите название товара: ");
                            string productName = Console.ReadLine()!;
                            Console.Write("Введите цену товара: ");
                            decimal productPrice = decimal.Parse(Console.ReadLine()!);
                            Console.Write("Введите количество товара: ");
                            uint productCount = uint.Parse(Console.ReadLine()!);
                            AddProduct(productName, productPrice, productCount);
                            Console.Write("Успешно");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        PrintPurchasedProducts();
                        Console.WriteLine("Нажмите любую клавишу для выхода в меню");
                        Console.ReadKey();
                        break;
                    case "4":
                        if (!_isAdmin)
                            break;
                        Console.WriteLine("Подтвердите сбор средств, нажав 'y':");
                        string inp = Console.ReadLine()!;
                        if (inp == "y")
                        {
                            decimal result = _vendingMachine.CollectMoney();
                            Console.Clear();
                            Console.WriteLine($"Выведено средств: {result:C}");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        PayBalance();
                        break;
                    case "6":
                        KeepChange();
                        break;
                    default:
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
                Console.ReadKey();
            }
        }
    }
}