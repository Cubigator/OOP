using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public class AcceptedOrder : IOrderState
{
    public OrderStatus Status { get; }
    
    public AcceptedOrder()
    {
        Status = OrderStatus.Accepted;
    }
    
    public void Next(Order order)
    {
        order.OrderState = new PreparingOrder();
    }

    public void Cancel(Order order)
    {
        order.OrderState = new CanceledOrder();
    }
}