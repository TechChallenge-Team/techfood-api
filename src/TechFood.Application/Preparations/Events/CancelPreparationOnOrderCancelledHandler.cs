using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Events.Order;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Preparations.Events;

internal class CancelPreparationOnOrderCancelledHandler(IPreparationRepository repo) : INotificationHandler<OrderCancelledEvent>
{
    public async Task Handle(OrderCancelledEvent notification, CancellationToken cancellationToken)
    {
        var preparation = await repo.GetByOrderIdAsync(notification.Id);
        if (preparation == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Preparation_PreparationNotFound);
        }

        preparation.Cancel();
    }
}
