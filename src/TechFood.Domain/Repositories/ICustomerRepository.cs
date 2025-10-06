using System;
using System.Threading.Tasks;
using TechFood.Domain.Entities;
using TechFood.Domain.Enums;

namespace TechFood.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Guid> CreateAsync(Customer customer);

    Task<Customer?> GetByIdAsync(Guid id);

    Task<Customer?> GetByDocument(DocumentType documentType, string documentValue);

    Task<Customer?> GetByDocumentAsync(DocumentType documentType, string documentValue);
}
