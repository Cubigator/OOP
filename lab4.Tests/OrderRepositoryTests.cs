using lab4.Models;
using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;

namespace lab4.Tests;

public class OrderRepositoryTests
{
    [Fact]
    public void Instance_IsSingleton()
    {
        // Arrange & Act
        var instance1 = OrderRepository.Instance;
        var instance2 = OrderRepository.Instance;
        
        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Add_Get_ReturnsCopy()
    {
        // Arrange
        var repo = OrderRepository.Instance;
        var originalOrder = CreateTestOrder();
        
        // Act
        repo.Add(originalOrder);
        var retrieved = repo.Get(originalOrder.Id);
        
        // Assert
        Assert.NotNull(retrieved);
        Assert.NotSame(originalOrder, retrieved); // Copy created
    }

    [Fact]
    public void GetByStatus_FiltersCorrectly()
    {
        // Arrange
        var repo = OrderRepository.Instance;
        var acceptedOrder = CreateTestOrder();
        acceptedOrder.OrderState = new AcceptedOrder();
        var preparingOrder = CreateTestOrder();
        preparingOrder.OrderState = new PreparingOrder();
        
        repo.Add(acceptedOrder);
        repo.Add(preparingOrder);
        
        // Act
        var result = repo.GetByStatus(OrderStatus.Accepted);
        
        // Assert
        Assert.Single(result);
        Assert.Equal(acceptedOrder.Id, result[0].Id);
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
