//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Minimal.Domain.Abstractions;

public interface ICommand
{
}

public interface ICommand<out TResponse>
{
}
