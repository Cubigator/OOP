namespace lab4.Models.Observers;

public class ConsoleObserver : IObserver
{
    public void Update(Order order)
    {
        Console.WriteLine($"Для заказчика {order.CustomerName} с номером заказа {order.Id} обновлен " +
                          $"статус: {order.OrderState.Status}");
    }
}