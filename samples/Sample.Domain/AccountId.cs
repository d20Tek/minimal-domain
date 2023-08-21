//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Minimal.Domain;

namespace Sample.Domain;

public sealed class AccountId : GuidId
{
    private AccountId(Guid id)
        : base(id)
    {
    }

    public static new AccountId CreateUnique() => new(Guid.NewGuid());

    public static AccountId Create(Guid guid) => new(guid);
}
