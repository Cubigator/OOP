using lab4.Models.Observers;
using lab4.Models;
using lab4.Models.OrderStates;

Order order = new()
{
    OrderState = new AcceptedOrder()
};
order.Attach(new ConsoleObserver());
order.NextStatus();
