using MediatR;
using TechFood.Application.Customers.Dto;

namespace TechFood.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(string CPF, string Name, string Email) : IRequest<CustomerDto>;
