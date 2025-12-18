using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public class DeliveredOrder : IOrderState
{
    public OrderStatus Status { get; }

    public DeliveredOrder()
    {
        Status = OrderStatus.Delivered;
    }
    public void Next(Order order)
    {
        
    }

    public void Cancel(Order order)
    {
        order.OrderState = new CanceledOrder();
    }
}