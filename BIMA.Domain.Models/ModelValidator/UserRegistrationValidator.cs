using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.ModelValidator
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationModel>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Please insert a valid email address.").MaximumLength(35).WithMessage("Max input lenght is 35").Custom((e, context) => { if (e.Contains("<") || e.Contains(">") || e.Contains("'") || e.Contains("=")) { context.AddFailure("Invalid input, should not contain <, >, ', ="); } });
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("The minimum password length is 8 charatcters.")
                                    .Matches("[a-zA-Z0-9]").Matches("[^a-zA-Z0-9]").WithMessage("Password must contain minimum 1 uppercase, lowercase, digit and special character.").Custom((e, context) => { if (e.Contains("<") || e.Contains(">") || e.Contains("'") || e.Contains("=")) { context.AddFailure("Invalid input, should not contain <, >, ', ="); } });
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password mismatch");
        }
    }
}
