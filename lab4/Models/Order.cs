using lab4.Models.Enums;
using lab4.Models.OrderStates;

namespace lab4.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public OrderDeliveryType DeliveryType { get; set; }
    public OrderType OrderType { get; set; }
    public IOrderState OrderState { get; set; }
    public string? Comments { get; set; }
    public string CustomerName { get; set; } = null!;

    public List<Dish> Dishes { get; set; } = null!;

    public void NextStatus()
    {
        OrderState.Next(this);
    }

    public void CancelOrder()
    {
        OrderState.Cancel(this);
    }
}