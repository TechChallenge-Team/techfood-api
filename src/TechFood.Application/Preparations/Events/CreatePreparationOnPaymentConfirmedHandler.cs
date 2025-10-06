using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Domain.Events.Payment;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Preparations.Events;

internal class CreatePreparationOnPaymentConfirmedHandler(IPreparationRepository repo) : INotificationHandler<PaymentConfirmedEvent>
{
    public async Task Handle(PaymentConfirmedEvent notification, CancellationToken cancellationToken)
    {
        var preparation = await repo.GetByIdAsync(notification.OrderId);
        if (preparation is not null)
        {
            return;
        }

        preparation = new Domain.Entities.Preparation(notification.OrderId);

        await repo.AddAsync(preparation);
    }
}
