using MediatR;
using TechFood.Application.Customers.Dto;
using TechFood.Domain.Enums;

namespace TechFood.Application.Customers.Queries.GetCustomerByDocument;

public record GetCustomerByDocumentQuery(DocumentType DocumentType, string DocumentValue) : IRequest<CustomerDto?>;
