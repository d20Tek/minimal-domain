//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Domain.Abstractions;
using D20Tek.Patterns.Result;
using D20Tek.Patterns.Domain.Validations;

namespace Sample.Domain;

public sealed class AccountValidator : IValidator<Account>
{
    public ValidationsResult Validate(Account account)
    {
        var result = new ValidationsResult();

        result.AddOnFailure(
            () => account.Id.Value.NotEmpty(),
            Error.Validation("id.empty", "Account Id must be a valid unique identifier."));

        result.AddOnFailure(
            () => account.GivenName.NotEmpty(),
            Error.Validation("gn.empty", "GivenName should not be empty."));

        result.AddOnFailure(
            () => account.GivenName.InMaxLength(64),
            Error.Validation("gn.length", "GivenName cannot be greater than 64 char."));

        result.AddOnFailure(
            () => account.FamilyName.NotEmpty(),
            Error.Validation("fn.empty", "FamilyName should not be empty."));

        result.AddOnFailure(
            () => account.FamilyName.InMaxLength(64),
            Error.Validation("fn.length", "FamilyName cannot be greater than 64 char."));

        result.AddOnFailure(
            () => account.Email.NotEmpty(),
            Error.Validation("email.empty", "Email should not be empty."));

        result.AddOnFailure(
            () => account.Email.InMaxLength(128),
            Error.Validation("email.length", "Email cannot be greater than 128 char."));

        result.AddOnFailure(
            () => account.Email.IsValidEmailAddress(),
            Error.Validation("email.format", "Email value is not a valid email address format."));

        return result;
    }
}
