//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain.Abstractions;

public interface IQueryHandler<in TQuery>
    where TQuery : IQuery
{
    public Task HandleAsync(TQuery query, CancellationToken cancellationToken);
}

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    public Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);
}
