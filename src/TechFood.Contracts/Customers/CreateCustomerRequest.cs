using System.ComponentModel.DataAnnotations;

namespace TechFood.Contracts.Customers;

public record CreateCustomerRequest(
    [Required] string CPF,
    [Required] string Name,
    [Required, EmailAddress] string Email);
