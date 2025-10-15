using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Events.Order;
using TechFood.Domain.Repositories;
using TechFood.Shared.Application.Exceptions;

namespace TechFood.Application.Preparations.Events;

internal class CancelPreparationOnOrderCancelledHandler(IPreparationRepository repo) : INotificationHandler<OrderCancelledEvent>
{
    public async Task Handle(OrderCancelledEvent notification, CancellationToken cancellationToken)
    {
        var preparation = await repo.GetByOrderIdAsync(notification.Id);
        if (preparation == null)
        {
            throw new ApplicationException(Exceptions.Preparation_PreparationNotFound);
        }

        preparation.Cancel();
    }
}
