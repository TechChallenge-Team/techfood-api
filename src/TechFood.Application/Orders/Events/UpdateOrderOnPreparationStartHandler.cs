using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Events.Preparation;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Orders.Events;

internal class UpdateOrderOnPreparationStartHandler(IOrderRepository repo) : INotificationHandler<PreparationStartedEvent>
{
    public async Task Handle(PreparationStartedEvent notification, CancellationToken cancellationToken)
    {
        var order = await repo.GetByIdAsync(notification.OrderId);
        if (order == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Order_OrderNotFound);
        }

        order.Prepare();
    }
}
