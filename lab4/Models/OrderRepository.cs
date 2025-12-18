using lab4.Models.Enums;

namespace lab4.Models;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    
    public Order? Get(Guid id)
    {
        Order? order = _orders.FirstOrDefault(o => o.Id == id);
        if(order is null)
            return null;
        return new Order()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DueDate = order.DueDate,
            DeliveryType = order.DeliveryType,
            OrderState = order.OrderState,
            OrderType = order.OrderType,
            Dishes = new List<Dish>(order.Dishes),
            CustomerName = order.CustomerName,
            Comments = order.Comments,
            Price = order.Price
        };
    }

    public IReadOnlyList<Order> GetAll()
    {
        return _orders;
    }

    public IReadOnlyList<Order> GetByStatus(OrderStatus status)
    {
        return _orders.Where(o => o.OrderState.Status == status).ToList();
    }

    public void Add(Order order)
    {
        _orders.Add(new Order()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DueDate = order.DueDate,
            DeliveryType = order.DeliveryType,
            OrderState = order.OrderState,
            OrderType = order.OrderType,
            Dishes = new List<Dish>(order.Dishes),
            CustomerName = order.CustomerName,
            Comments = order.Comments,
            Price = order.Price
        });
    }

    public void Update(Order order)
    {
        Order? updatedOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
        if(updatedOrder is null)
            return;
        _orders.Remove(updatedOrder);
        _orders.Add(order);
    }
}