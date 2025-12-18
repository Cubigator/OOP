namespace lab4.Models.Pricing;

public interface IPricingStrategy
{
    public decimal CalculatePrice(Order order);
}