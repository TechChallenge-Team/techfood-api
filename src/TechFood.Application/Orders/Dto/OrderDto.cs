using System;
using System.Collections.Generic;
using TechFood.Domain.Enums;

namespace TechFood.Application.Orders.Dto;

public record OrderDto(
    Guid Id,
    int Number,
    decimal Amount,
    DateTime CreatedAt,
    CustomerDto? Customer,
    OrderStatusType Status,
    List<OrderItemDto> Items);
