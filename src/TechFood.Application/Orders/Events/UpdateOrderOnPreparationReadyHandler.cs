using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Events.Preparation;
using TechFood.Domain.Repositories;
using TechFood.Shared.Application.Exceptions;

namespace TechFood.Application.Orders.Events;

internal class UpdateOrderOnPreparationReadyHandler(IOrderRepository repo) : INotificationHandler<PreparationReadyEvent>
{
    public async Task Handle(PreparationReadyEvent notification, CancellationToken cancellationToken)
    {
        var order = await repo.GetByIdAsync(notification.OrderId);
        if (order == null)
        {
            throw new ApplicationException(Exceptions.Order_OrderNotFound);
        }

        order.Ready();
    }
}
