using lab4.Models;
using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;
using lab4.Models.Observers;
using Moq;

namespace lab4.Tests;

public class OrderTests
{
    [Fact]
    public void AttachObserver_Notify_CallsUpdate()
    {
        // Arrange
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = "John",
            OrderState = new AcceptedOrder(),
            Dishes = new List<Dish>(),
            OrderType = OrderType.Standard,
            DeliveryType = OrderDeliveryType.Pickup,
            Price = new DefaultPricingStrategy()
        };
        var mockObserver = new Mock<lab4.Models.Observers.IObserver>();
        
        // Act
        order.Attach(mockObserver.Object);
        order.NextStatus();
        
        // Assert
        mockObserver.Verify(o => o.Update(It.IsAny<Order>()), Times.Once);
    }

    [Fact]
    public void NextStatus_ThroughCompleteCycle()
    {
        // Arrange
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = "Test",
            Dishes = new List<Dish>(),
            OrderState = new AcceptedOrder(),
            OrderType = OrderType.Standard,
            DeliveryType = OrderDeliveryType.Pickup,
            Price = new DefaultPricingStrategy()
        };
        
        // Act
        order.NextStatus(); 
        order.NextStatus();
        order.NextStatus();
        
        // Assert
        Assert.Equal(OrderStatus.Delivered, order.OrderState.Status);
    }
}
