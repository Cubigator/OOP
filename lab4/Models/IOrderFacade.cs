using lab4.Models.Enums;

namespace lab4.Models;

public interface IOrderFacade
{
    public Order CreateOrder(string customerName, IReadOnlyList<Guid> dishIds,
        OrderDeliveryType deliveryType, OrderType orderType,
        string? comments=null);

    public void AddDish(Guid orderId, Guid dishId);
    public void RemoveDish(Guid orderId, Guid dishId);

    public void AdvanceStatus(Guid orderId);
    public void Cancel(Guid orderId);

    public IReadOnlyList<Order> GetOrdersByStatus(OrderStatus status);
}