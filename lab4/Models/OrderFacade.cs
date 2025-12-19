using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;

namespace lab4.Models;

public class OrderFacade : IOrderFacade
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenu _menu;
    
    public OrderFacade(IOrderRepository orderRepository, IMenu menu)
    {
        _orderRepository = orderRepository;
        _menu = menu;
    }
    
    public Order CreateOrder(string customerName, IReadOnlyList<Guid> dishIds, OrderDeliveryType deliveryType, OrderType orderType,
        string? comments = null)
    {
        List<Dish> orderDishes = new List<Dish>();
        foreach (var dishId in dishIds)
        {
            Dish? dish = _menu.GetDishById(dishId);
            if (dish != null)
            {
                orderDishes.Add(dish);
            }
        }
        Order order = new Order()
        {
            Id = Guid.NewGuid(),
            OrderDate = DateTime.Now,
            DueDate = DateTime.Now.AddHours(2),
            DeliveryType = deliveryType,
            OrderState = new AcceptedOrder(),
            OrderType = orderType,
            Dishes = orderDishes,
            CustomerName = customerName,
            Comments = comments,
            Price = new DefaultPricingStrategy()
        };
        _orderRepository.Add(order);
        return order;
    }

    public void AddDish(Guid orderId, Guid dishId)
    {
        Order? order = _orderRepository.Get(orderId);
        Dish? dish = _menu.GetDishById(dishId);
        if (order is null || dish is null)
            return;
        order.Dishes.Add(dish);
        _orderRepository.Update(order);
    }

    public void RemoveDish(Guid orderId, Guid dishId)
    {
        Order? order = _orderRepository.Get(orderId);
        Dish? dish = _menu.GetDishById(dishId);
        if (order is null || dish is null)
            return;
        order.Dishes.Remove(dish);
        _orderRepository.Update(order);
    }

    public void AdvanceStatus(Guid orderId)
    {
        Order? order = _orderRepository.Get(orderId);
        if (order is null)
            return;
        order.NextStatus();
        _orderRepository.Update(order);
    }

    public void Cancel(Guid orderId)
    {
        Order? order = _orderRepository.Get(orderId);
        if (order is null)
            return;
        order.CancelOrder();
        _orderRepository.Update(order);
    }

    public IReadOnlyList<Order> GetOrdersByStatus(OrderStatus status)
    {
        return _orderRepository.GetByStatus(status);
    }
}