using lab4.Models;
using lab4.Models.Pricing;
using lab4.Models.Enums;

namespace lab4.Tests;

public class PricingStrategyTests
{
    [Theory]
    [InlineData(OrderType.Standard, OrderDeliveryType.Pickup, 1000, 1000)]
    [InlineData(OrderType.Corporate, OrderDeliveryType.Delivery, 1000, 1200)]
    [InlineData(OrderType.Express, OrderDeliveryType.Pickup, 1000, 1100)]
    [InlineData(OrderType.Planned, OrderDeliveryType.Delivery, 1000, 1250)]
    public void CalculatePrice_AllCombinations(OrderType orderType, OrderDeliveryType deliveryType, 
        decimal dishesTotal, decimal expected)
    {
        // Arrange
        var strategy = new DefaultPricingStrategy();
        var order = new Order
        {
            Dishes = new List<Dish> { new Dish { Price = dishesTotal } },
            OrderType = orderType,
            DeliveryType = deliveryType,
            Price = strategy
        };
        
        // Act
        var result = strategy.CalculatePrice(order);
        
        // Assert
        Assert.Equal(expected, result);
    }
}
