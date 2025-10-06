using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Customers.Dto;

namespace TechFood.Application.Customers.Queries.GetCustomerByDocument;

public class GetCustomerByDocumentHandler(ICustomerQueryProvider queries) : IRequestHandler<GetCustomerByDocumentQuery, CustomerDto?>
{
    public Task<CustomerDto?> Handle(GetCustomerByDocumentQuery request, CancellationToken cancellationToken)
        => queries.GetByDocumentAsync(request.DocumentType, request.DocumentValue);
}
