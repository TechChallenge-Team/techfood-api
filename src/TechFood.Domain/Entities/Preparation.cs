using System;
using TechFood.Domain.Enums;
using TechFood.Domain.Events.Preparation;
using TechFood.Domain.Common.Entities;
using TechFood.Domain.Common.Exceptions;

namespace TechFood.Domain.Entities;

public class Preparation : Entity, IAggregateRoot
{
    private Preparation() { }

    public Preparation(Guid orderId)
    {
        OrderId = orderId;
        CreatedAt = DateTime.Now;
        Status = PreparationStatusType.Pending;

        _events.Add(new PreparationCreatedEvent(
            Id,
            OrderId,
            CreatedAt));
    }

    public Guid OrderId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? StartedAt { get; private set; }

    public DateTime? ReadyAt { get; private set; }

    public DateTime? DeliveredAt { get; private set; }

    public DateTime? CancelledAt { get; private set; }

    public PreparationStatusType Status { get; private set; }

    public void Start()
    {
        if (Status != PreparationStatusType.Pending)
        {
            throw new DomainException(Resources.Exceptions.Preparation_CanOnlyStartIfInPending);
        }

        Status = PreparationStatusType.Started;
        StartedAt = DateTime.Now;

        _events.Add(new PreparationStartedEvent(
            Id,
            OrderId,
            StartedAt.Value));
    }

    public void Ready()
    {
        if (Status != PreparationStatusType.Started)
        {
            throw new DomainException(Resources.Exceptions.Preparation_CanOnlyCompleteIfInProgress);
        }

        Status = PreparationStatusType.Ready;
        ReadyAt = DateTime.Now;

        _events.Add(new PreparationReadyEvent(
            Id,
            OrderId,
            ReadyAt.Value));
    }

    public void Cancel()
    {
        if (Status == PreparationStatusType.Cancelled)
        {
            throw new InvalidOperationException(Resources.Exceptions.Preparation_AlreadyCancelled);
        }

        Status = PreparationStatusType.Cancelled;
        CancelledAt = DateTime.Now;
    }
}
