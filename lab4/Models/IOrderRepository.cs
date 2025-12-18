using lab4.Models.Enums;

namespace lab4.Models;

public interface IOrderRepository
{
    Order? Get(Guid id);
    IReadOnlyList<Order> GetAll();
    IReadOnlyList<Order> GetByStatus(OrderStatus status);
    void Add(Order order);
    void Update(Order order);
}