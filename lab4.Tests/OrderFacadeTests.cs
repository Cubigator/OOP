using lab4.Models;
using lab4.Models.Enums;
using lab4.Models.OrderStates;
using lab4.Models.Pricing;
using Moq;

namespace lab4.Tests;

public class OrderFacadeTests
{
    private readonly Mock<IMenu> _menuMock;
    private readonly Mock<IOrderRepository> _repoMock;
    private readonly OrderFacade _facade;
    private readonly Guid _dishId = Guid.NewGuid();

    public OrderFacadeTests()
    {
        _menuMock = new Mock<IMenu>();
        _repoMock = new Mock<IOrderRepository>();
        _facade = new OrderFacade(_repoMock.Object, _menuMock.Object);
    }

    [Fact]
    public void CreateOrder_Successful()
    {
        // Arrange
        var testDish = new Dish { Id = _dishId, Name = "Test Dish", Price = 500m };
        _menuMock.Setup(m => m.GetDishById(_dishId)).Returns(testDish);
        
        // Act
        var order = _facade.CreateOrder("John", new[] { _dishId }, 
            OrderDeliveryType.Delivery, OrderType.Standard);
        
        // Assert
        Assert.Equal(OrderStatus.Accepted, order.OrderState.Status);
        Assert.Equal("John", order.CustomerName);
        _repoMock.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
    }

    [Fact]
    public void AdvanceStatus_ChangesState()
    {
        // Arrange
        var order = CreateMockOrder();
        _repoMock.Setup(r => r.Get(order.Id)).Returns(order);
        
        // Act
        _facade.AdvanceStatus(order.Id);
        
        // Assert
        Assert.Equal(OrderStatus.Preparing, order.OrderState.Status);
        _repoMock.Verify(r => r.Update(It.IsAny<Order>()), Times.Once);
    }

    private Order CreateMockOrder()
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
