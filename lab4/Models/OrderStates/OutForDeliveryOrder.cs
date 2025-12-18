using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public class OutForDeliveryOrder : IOrderState
{
    public OrderStatus Status { get; }

    public OutForDeliveryOrder()
    {
        Status = OrderStatus.OutForDelivery;
    }
    public void Next(Order order)
    {
        order.OrderState = new DeliveredOrder();
    }

    public void Cancel(Order order)
    {
        order.OrderState = new CanceledOrder();
    }
}