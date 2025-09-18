namespace lab1;

public class Coin
{
    private decimal _denomination;

    public decimal Denomination
    {
        get => _denomination;
        set
        {
            if(value != 0.01m || value != 0.05m || value != 0.1m || value != 0.5m ||
               value != 1m || value != 2m || value != 5m || value != 10m)
            {
                throw new ArgumentException("Неверный номинал монеты");
            }
            _denomination = value;
        }
    }

    public Coin(decimal denomination)
    {
        Denomination = denomination;
    }
}