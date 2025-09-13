using System.Threading.Tasks;
using TechFood.Application.Customers.Dto;
using TechFood.Domain.Enums;

namespace TechFood.Application.Customers.Queries;

public interface ICustomerQueryProvider
{
    Task<CustomerDto?> GetByDocumentAsync(DocumentType documentType, string document);
}
