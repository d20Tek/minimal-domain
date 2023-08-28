//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Minimal.Domain.Abstractions;

public interface IDomainEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    public Task HandleAsync(TEvent domainEvent, CancellationToken cancellation);
}
