//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain;

namespace Sample.Domain;

public sealed class Account : Entity<AccountId>
{
    public string GivenName { get; set; } = default!;

    public string FamilyName { get; set; } = default!;

    public string Email { get; set; } = default!;

    private Account(AccountId id,
        string givenName,
        string familyName,
        string email)
        : base(id)
    {
        GivenName = givenName;
        FamilyName = familyName;
        Email = email;
    }

    public static Account Create(
        string givenName,
        string familyName,
        string email)
    {
        return new(AccountId.CreateUnique(), givenName, familyName, email);
    }
}
