namespace TechFood.Contracts.Orders;

public record CreateOrderRequest(
    Guid? CustomerId,
    List<CreateOrderRequest.Item> Items)
{
    public record Item(Guid ProductId, int Quantity);
}
