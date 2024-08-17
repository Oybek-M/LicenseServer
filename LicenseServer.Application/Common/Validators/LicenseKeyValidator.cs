using FluentValidation;
using LicenseServer.Domain.Entities;

namespace LicenseServer.Application.Common.Validators;

public class LicenseKeyValidator : AbstractValidator<LicenseKey>
{
    public LicenseKeyValidator()
    {
        RuleFor(l => l.ExpiredDate)
            .NotNull()
            .WithMessage("Yaroqlilik muddatini kiriting");

        RuleFor(l => l.SessionLimit)
            .NotNull()
            .WithMessage("Sessiya limitni kiriting");

        RuleFor(l => l.LicenseType)
            .NotNull()
            .WithMessage("Litsenziya turini kiriting");
    }
}
