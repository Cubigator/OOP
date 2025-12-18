using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public class CanceledOrder : IOrderState
{
    public OrderStatus Status { get; }

    public CanceledOrder()
    {
        Status = OrderStatus.Canceled;
    }
    public void Next(Order order)
    {
        
    }

    public void Cancel(Order order)
    {
        
    }
}