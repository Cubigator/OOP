using lab4.Models;
using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;

namespace lab4.Tests;

public class OrderStateTests
{
    [Theory]
    [InlineData(typeof(AcceptedOrder), typeof(PreparingOrder))]
    [InlineData(typeof(PreparingOrder), typeof(OutForDeliveryOrder))]
    [InlineData(typeof(OutForDeliveryOrder), typeof(DeliveredOrder))]
    public void NextState_ValidTransitions(Type currentState, Type expectedNextState)
    {
        // Arrange
        var order = CreateTestOrder();
        order.OrderState = (IOrderState)Activator.CreateInstance(currentState)!;
        
        // Act
        order.NextStatus();
        
        // Assert
        Assert.IsType(expectedNextState, order.OrderState);
    }

    [Fact]
    public void CancelFromAnyState_TransitionsToCanceled()
    {
        // Arrange
        var order = CreateTestOrder();
        order.OrderState = new PreparingOrder();
        
        // Act
        order.CancelOrder();
        
        // Assert
        Assert.IsType<CanceledOrder>(order.OrderState);
        Assert.Equal(OrderStatus.Canceled, order.OrderState.Status);
    }

    [Fact]
    public void DeliveredState_NextDoesNothing()
    {
        // Arrange
        var order = CreateTestOrder();
        order.OrderState = new DeliveredOrder();
        var initialStatus = order.OrderState.Status;
        
        // Act
        order.NextStatus();
        
        // Assert
        Assert.Equal(initialStatus, order.OrderState.Status);
    }

    private static Order CreateTestOrder()
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = "Test",
            Dishes = new List<Dish>(),
            OrderState = new AcceptedOrder(),
            OrderType = OrderType.Standard,
            DeliveryType = OrderDeliveryType.Pickup,
            Price = new DefaultPricingStrategy()
        };
    }
}
