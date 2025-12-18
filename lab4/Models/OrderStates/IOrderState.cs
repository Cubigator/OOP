using lab4.Models.Enums;

namespace lab4.Models.OrderStates;

public interface IOrderState
{
    public OrderStatus Status { get; } 
    public void Next(Order order);
    public void Cancel(Order order);
}