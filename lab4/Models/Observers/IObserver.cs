namespace lab4.Models.Observers;

public interface IObserver
{
    public void Update(Order order);
}