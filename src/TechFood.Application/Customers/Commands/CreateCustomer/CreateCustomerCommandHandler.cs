using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Application.Customers.Dto;
using TechFood.Domain.Enums;
using TechFood.Domain.Repositories;
using TechFood.Domain.ValueObjects;

namespace TechFood.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository repo) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var document = new Document(DocumentType.CPF, request.CPF);

        var cpfExists = await repo.GetByDocument(document.Type, document.Value);
        if (cpfExists != null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Customer_CpfAlreadyExists);
        }

        var customer = new Domain.Entities.Customer(
            new Name(request.Name),
            new Email(request.Email),
            document,
            null
        );

        var id = await repo.CreateAsync(customer);

        return new CustomerDto()
        {
            Id = id,
            DocumentType = customer.Document.Type,
            DocumentValue = customer.Document.Value,
            Name = customer.Name.FullName,
            Email = customer.Email.Address,
            Phone = customer.Phone?.Number,
        };
    }
}
