﻿//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Minimal.Domain.Validations;

public static class GuidValidations
{
    public static bool NotEmpty(this Guid value) =>
        value != Guid.Empty;
}
