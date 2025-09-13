using System;
using System.Collections.Generic;
using TechFood.Domain.Enums;
using TechFood.Domain.Events.Order;
using TechFood.Domain.Common.Entities;
using TechFood.Domain.Common.Exceptions;
using TechFood.Domain.Common.Validations;

namespace TechFood.Domain.Entities;

public class Order : Entity, IAggregateRoot
{
    private Order() { }

    public Order(
        int number,
        Guid? customerId = null)
    {
        Number = number;
        CustomerId = customerId;
        CreatedAt = DateTime.Now;
        Status = OrderStatusType.Pending;

        _events.Add(new OrderCreatedEvent(
            Id,
            CustomerId,
            CreatedAt));
    }

    private readonly List<OrderItem> _items = [];

    private readonly List<OrderHistory> _historical = [];

    public int Number { get; private set; }

    public Guid? CustomerId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public OrderStatusType Status { get; private set; }

    public decimal Amount { get; private set; }

    public decimal Discount { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public IReadOnlyCollection<OrderHistory> Historical => _historical.AsReadOnly();

    public void ApplyDiscount(decimal discount)
    {
        if (Status != OrderStatusType.Pending)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotApplyDiscountToNonPendingStatus);
        }

        Validations.ThrowIsGreaterThanZero(discount, Resources.Exceptions.Order_DiscountCannotBeNegative);

        Discount = discount;

        CalculateAmount();
    }

    public void Receive()
    {
        if (Status != OrderStatusType.Pending)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotReceiveToNonPendingStatus);
        }

        UpdateStatus(OrderStatusType.Received);
    }

    public void Prepare()
    {
        if (Status != OrderStatusType.Received)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotPrepareToNonReceivedStatus);
        }

        UpdateStatus(OrderStatusType.InPreparation);
    }

    public void Ready()
    {
        if (Status != OrderStatusType.InPreparation)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotReadyToNonInPreparationStatus);
        }

        UpdateStatus(OrderStatusType.Ready);
    }

    public void Deliver()
    {
        if (Status != OrderStatusType.Ready)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotDeliverToNonReadyStatus);
        }

        UpdateStatus(OrderStatusType.Delivered);
    }

    public void Cancel()
    {
        UpdateStatus(OrderStatusType.Cancelled);

        _events.Add(new OrderCancelledEvent(
            Id,
            DateTime.Now));
    }

    public void AddItem(OrderItem item)
    {
        if (Status != OrderStatusType.Pending)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotAddItemToNonPendingStatus);
        }

        _items.Add(item);

        CalculateAmount();
    }

    public void RemoveItem(Guid itemId)
    {
        if (Status != OrderStatusType.Pending)
        {
            throw new DomainException(Resources.Exceptions.Order_CannotRemoveItemToNonPendingStatus);
        }

        var item = _items.Find(i => i.Id == itemId);

        Validations.ThrowObjectIsNull(item, Resources.Exceptions.Order_ItemNotFound);

        _items.Remove(item!);

        CalculateAmount();
    }

    private void CalculateAmount()
    {
        Amount = 0;

        foreach (var item in _items)
        {
            Amount += item.Quantity * item.UnitPrice;
        }

        Amount -= Discount;
    }

    private void UpdateStatus(OrderStatusType status)
    {
        Status = status;
        _historical.Add(new(status));
    }
}
