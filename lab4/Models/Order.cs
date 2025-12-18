using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;
using lab4.Models.Observers;

namespace lab4.Models;

public class Order
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public OrderDeliveryType DeliveryType { get; set; }
    public OrderType OrderType { get; set; }
    public IOrderState OrderState { get; set; } = null!;
    public string? Comments { get; set; }
    public string CustomerName { get; set; } = null!;
    public IPricingStrategy Price { get; set; } = null!;

    public List<Dish> Dishes { get; set; } = null!;

    public void NextStatus()
    {
        OrderState.Next(this);
        Notify();
    }

    public void CancelOrder()
    {
        OrderState.Cancel(this);
        Notify();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}