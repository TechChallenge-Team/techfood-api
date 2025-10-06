using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Orders.Commands.DeliverOrder;

public class DeliverOrderCommandHandler(IOrderRepository repo) : IRequestHandler<DeliverOrderCommand, Unit>
{
    public async Task<Unit> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repo.GetByIdAsync(request.Id);
        if (order == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Order_OrderNotFound);
        }

        order.Deliver();

        return Unit.Value;
    }
}
