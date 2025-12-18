using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public class PreparingOrder : IOrderState
{
    public OrderStatus Status { get; }

    public PreparingOrder()
    {
        Status = OrderStatus.Preparing;
    }
    public void Next(Order order)
    {
        order.OrderState = new OutForDeliveryOrder();
    }

    public void Cancel(Order order)
    {
        order.OrderState = new CanceledOrder();
    }
}