//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Patterns.Domain.Abstractions;

public interface ICommand
{
}

public interface ICommand<out TResponse>
{
}
