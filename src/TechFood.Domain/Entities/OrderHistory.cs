using System;
using TechFood.Domain.Enums;
using TechFood.Shared.Domain.Entities;

namespace TechFood.Domain.Entities;

public class OrderHistory : Entity
{
    private OrderHistory() { }

    public OrderHistory(
        OrderStatusType status
        )
    {
        Status = status;
        CreatedAt = DateTime.Now;
    }

    public DateTime CreatedAt { get; private set; }

    public OrderStatusType Status { get; private set; }
}
