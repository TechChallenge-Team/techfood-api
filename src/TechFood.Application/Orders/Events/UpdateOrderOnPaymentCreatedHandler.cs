using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Events.Payment;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Orders.Events;

internal class UpdateOrderOnPaymentCreatedHandler(IOrderRepository repo) : INotificationHandler<PaymentCreatedEvent>
{
    public async Task Handle(PaymentCreatedEvent notification, CancellationToken cancellationToken)
    {
        var order = await repo.GetByIdAsync(notification.OrderId);
        if (order == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Order_OrderNotFound);
        }

        order.Receive();
    }
}
