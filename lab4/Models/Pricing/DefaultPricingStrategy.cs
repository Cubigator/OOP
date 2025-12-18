using lab4.Models.Enums;

namespace lab4.Models.Pricing;

public class DefaultPricingStrategy : IPricingStrategy
{
    private readonly Dictionary<OrderDeliveryType, decimal> _deliveryPrices =
        new Dictionary<OrderDeliveryType, decimal>
        {
            { OrderDeliveryType.Delivery, 300 },
            { OrderDeliveryType.Pickup, 0 },
        };

    private readonly Dictionary<OrderType, decimal> _orderPrices =
        new Dictionary<OrderType, decimal>
        {
            { OrderType.Standard, 1.00m },
            { OrderType.Corporate, 0.90m },
            { OrderType.Express, 1.1m },
            { OrderType.Planned, 0.95m }
        };
    
    public decimal CalculatePrice(Order order)
    {
        decimal dishesPrice = order.Dishes.Sum(x => x.Price);
        
        decimal totalPrice = dishesPrice * _orderPrices[order.OrderType];
        totalPrice += _deliveryPrices[order.DeliveryType];
        return totalPrice;
    }
}