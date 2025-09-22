namespace lab1;

public class Coin
{
    private decimal _denomination;

    public decimal Denomination
    {
        get => _denomination;
        set
        {
            if(!Constants.DENOMINATIONS.Contains(value))
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