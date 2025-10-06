using System;
using TechFood.Domain.Enums;

namespace TechFood.Application.Customers.Dto;

public class CustomerDto
{
    public Guid Id { get; set; }

    public DocumentType DocumentType { get; set; }

    public string DocumentValue { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; } = null!;
}
