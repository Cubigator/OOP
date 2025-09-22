namespace lab1;

public class Wallet
{
    private List<Coin> _coins;
    private decimal _balance;

    public decimal Balance
    {
        get
        {
            if (_balance == 0)
            {
                decimal total = 0;
                foreach (var coin in _coins)
                {
                    total += coin.Denomination;
                }

                _balance = total;
            }
            return _balance;
        }
    }

    public Wallet()
    {
        _coins = new List<Coin>();
        _balance = 0;
    }

    public void AddCoin(decimal denomination)
    {
        _coins.Add(new Coin(denomination));
        _balance += denomination;
    }

    public void RemoveCoin(decimal denomination)
    {
        Coin coin = _coins.First(x => x.Denomination == denomination);
        _coins.Remove(coin);
        _balance -= denomination;
    }

    public List<Coin> RemoveAllCoins()
    {
        List<Coin> buffer = new List<Coin>(_coins);
        _coins.Clear();
        _balance = 0;
        return buffer;
    }
}