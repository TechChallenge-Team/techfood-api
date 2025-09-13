using System;

namespace TechFood.Application.Orders.Dto;

public record OrderItemDto(Guid Id, string Name, string ImageUrl, decimal Price, int Quantity);
