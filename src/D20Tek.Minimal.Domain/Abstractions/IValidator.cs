//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Minimal.Result;

namespace D20Tek.Minimal.Domain.Abstractions;

public interface IValidator<in T>
{
    ValidationsResult Validate(T instance);
}
