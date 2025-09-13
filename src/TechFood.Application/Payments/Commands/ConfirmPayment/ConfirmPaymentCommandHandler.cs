﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Payments.Commands.ConfirmPayment;

public class ConfirmPaymentCommandHandler(IPaymentRepository repo) : IRequestHandler<ConfirmPaymentCommand, Unit>
{
    public async Task<Unit> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await repo.GetByIdAsync(request.Id);
        if (payment == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Payment_PaymentNotFound);
        }

        payment.Confirm();

        return Unit.Value;
    }
}
